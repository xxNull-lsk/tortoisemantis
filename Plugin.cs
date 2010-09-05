/**
 * 
 * TortoiseMantis Copyright 2010 Andreas Stieger <andreas.stieger@gmx.de>
 * 
 * This file is part of TortoiseMantis.
 * 
 * TortoiseMantis is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * TortoiseMantis is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 * 
 **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.ServiceModel;
using System.Windows.Forms;
using TortoiseMantis.MantisConnectReference;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Runtime.Remoting.Messaging;
using Interop.BugTraqProvider;

namespace TortoiseMantis
{
    [ComVisible(true),
        Guid("F25B6B8F-1BA0-4BCA-A809-0C0B6F4A0CED"),
        ClassInterface(ClassInterfaceType.None)]
    public sealed class Plugin : IBugTraqProvider
    {

        private IIssuesDisplay form;
        private MantisConnectPortTypeClient client;
        private ConnectionSettings cs;
        private bool connectionErrorReported;

        public bool ValidateParameters(IntPtr hParentWnd, string parameters)
        {
            ConnectionSettings cs = new ConnectionSettings(parameters);
            if (!cs.isValid())
            {
                MessageBox.Show("invalid parameters\nexample:\nurl:http://bugserver/bugs/api/soap/mantisconnect.php username:foouser password:foopass project:fooproject",
                    "invalid parameters", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public string GetLinkText(IntPtr hParentWnd, string parameters)
        {
            // TODO 
            return "Choose Issue";
        }

        public string GetCommitMessage(IntPtr hParentWnd, string parameters, string commonRoot, string[] pathList, string originalMessage)
        {
            connectionErrorReported = false;
            cs = new ConnectionSettings(parameters);
            IssuesForm form = new IssuesForm(this, cs);
            this.form = form;

            // WTF does this take so long?
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress endpoint = new EndpointAddress(cs.URL);
            client = new MantisConnectPortTypeClient(binding, endpoint);

            client.mc_versionCompleted += new EventHandler<mc_versionCompletedEventArgs>(client_mc_versionCompleted);
            client.mc_projects_get_user_accessibleCompleted += new EventHandler<mc_projects_get_user_accessibleCompletedEventArgs>(client_mc_projects_get_user_accessibleCompleted);
            client.mc_enum_statusCompleted += new EventHandler<mc_enum_statusCompletedEventArgs>(client_mc_enum_statusCompleted);
            client.mc_projects_get_user_accessibleAsync(cs.Username, cs.Password);
            client.mc_enum_statusAsync(cs.Username, cs.Password);

            if (form.ShowDialog() == DialogResult.OK)
            {
                IssueHeaderData issue = form.GetSelectedIssue();
                if (issue != null)
                {
                    String retMessage = String.Format("BUGFIX: {0}\nissue {1}\n", issue.summary, issue.id);
                    return retMessage;
                }
            }
            return originalMessage;
        }

        private void ReportConnectionErrorOnce(String message)
        {
            if (!connectionErrorReported)
            {
                connectionErrorReported = true;
                MessageBox.Show(message, "communication error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void client_mc_versionCompleted(object sender, mc_versionCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                OnStatusUpdated(String.Format("connected to MantisBT v{0}", e.Result));
            }
            else
            {
                ReportConnectionErrorOnce(e.Error.Message);
            }
        }

        private void client_mc_enum_statusCompleted(object sender, mc_enum_statusCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                OnStatusUpdated(String.Format("loaded {0} status mappings", e.Result.Length));
                form.SetStatusMappings(e.Result);
            }
            else
            {
                ReportConnectionErrorOnce(e.Error.Message);
            }
        }

        private void client_mc_projects_get_user_accessibleCompleted(object sender, mc_projects_get_user_accessibleCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                foreach (ProjectData projectData in e.Result)
                {
                    if (projectData.name == cs.Project)
                    {
                        OnStatusUpdated(String.Format("found project \"{0}\" ({1})", projectData.name, projectData.id));
                        client.mc_project_get_usersCompleted += new EventHandler<mc_project_get_usersCompletedEventArgs>(client_mc_project_get_usersCompleted);
                        client.mc_project_get_issue_headersCompleted += new EventHandler<mc_project_get_issue_headersCompletedEventArgs>(client_mc_project_get_issue_headersCompleted);
                        client.mc_project_get_usersAsync(cs.Username, cs.Password, projectData.id, "0");
                        client.mc_project_get_issue_headersAsync(cs.Username, cs.Password, projectData.id, "0", "0");
                        return;
                    }
                }
            }
            else
            {
                ReportConnectionErrorOnce(e.Error.Message);
            }
        }

        private void client_mc_project_get_usersCompleted(object sender, mc_project_get_usersCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                OnStatusUpdated(String.Format("read {0} usernames", e.Result.Length));
                form.SetAccountData(e.Result);
                OnAccountDataLoaded();
            }
            else
            {
                ReportConnectionErrorOnce(e.Error.Message);
            }
        }

        private void client_mc_project_get_issue_headersCompleted(object sender, mc_project_get_issue_headersCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                OnStatusUpdated(String.Format("found {0} issues", e.Result.Length));
                form.SetIssueHeaderData(e.Result);
                OnIssuesLoaded();
            }
            else
            {
                ReportConnectionErrorOnce(e.Error.Message);
            }
        }

        public delegate void StatusUpdatedHandler(string status);
        public event StatusUpdatedHandler StatusUpdated;

        private void OnStatusUpdated(string status)
        {
            if (StatusUpdated != null)
            {
                StatusUpdated(status);
            }
        }

        public delegate void AccountDataLoadedHandler();
        public event AccountDataLoadedHandler AccountDataLoaded;

        private void OnAccountDataLoaded()
        {
            if (AccountDataLoaded != null)
            {
                AccountDataLoaded();
            }
        }

        public delegate void IssuesLoadedHandler();
        public event IssuesLoadedHandler IssuesLoaded;

        private void OnIssuesLoaded()
        {
            if (IssuesLoaded != null)
            {
                IssuesLoaded();
            }
        }

    }
}
