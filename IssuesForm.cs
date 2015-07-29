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
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TortoiseMantis.MantisConnectReference;
using System.Globalization;

namespace TortoiseMantis
{
    internal partial class IssuesForm : Form
    {
        private ObjectRef[] statusEnum;
        private AccountData[] accountData;
        private ProjectData[] projectData;
        private IssueHeaderData[] issueHeaders;
        private IssueHeaderData[] selectedIssue;
        private String myAccountID;
        private ConnectionSettings cs;
        private String searchString;
        private IssuesListColumnSorter issuesListColumnSorter;
        private Plugin mplugin;


        public IssuesForm(Plugin plugin, ConnectionSettings cs)
        {
            InitializeComponent();
            issuesListColumnSorter = new IssuesListColumnSorter();
            issuesList.ListViewItemSorter = (IComparer) issuesListColumnSorter;
            issuesListColumnSorter.SortColumn = 0;
            issuesListColumnSorter.SortOrder = SortOrder.Descending;
            this.Text += String.Format(" v{0}", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
            statusEnum = null;
            issueHeaders = null;
            selectedIssue = null;
            accountData = null;
            myAccountID = null;
            this.cs = cs;
            searchString = String.Empty;
            plugin.StatusUpdated += new Plugin.StatusUpdatedHandler(plugin_StatusUpdated);
            mplugin = plugin;
        }

        void plugin_StatusUpdated(string status)
        {
            statusLabel.Text = status;
            progressBar.PerformStep();
        }

        private void IssuesForm_Load(object sender, EventArgs e)
        {
            progressBar.Value = progressBar.Minimum;
        }

        public void SetStatusMappings(ObjectRef[] statusEnum)
        {
            this.statusEnum = statusEnum;
        }

        public void SetAccountData(AccountData[] accountData)
        {
            this.accountData = accountData;
            IEnumerator e = accountData.GetEnumerator();
            while (e.MoveNext()) 
            {
                AccountData account = (AccountData)e.Current;
                if (account.name.ToLower() == cs.Username.ToLower())
                {
                    myAccountID = account.id;
                    return;
                }
            }
        }

        public void SetProjectData(ProjectData[] projectData, string strDepth = "")
        {
            this.projectData = projectData;
            IEnumerator e = projectData.GetEnumerator();
            if (strDepth == "")
            {
                comboBoxProjects.Items.Clear();
                ProjectData project = new ProjectData();
                project.enabled = true;
                project.description = "所有项目";
                project.name = "所有项目";
                project.id = "0";
                comboBoxProjects.Items.Add(project);
            }

            while (e.MoveNext())
            {
                ProjectData project = (ProjectData)e.Current;
                string szTmp = project.name;
                project.name = strDepth + szTmp;
                comboBoxProjects.Items.Add(project);
                comboBoxProjects.DisplayMember = "name";
                SetProjectData(project.subprojects, "  " + strDepth);
                plugin_StatusUpdated(String.Format("总计{0}个工程", comboBoxProjects.Items.Count));
            }
            if (strDepth == "")
            {
                comboBoxProjects.SelectedIndex = 0;
            }
        }

        public void SetIssueHeaderData(IssueHeaderData[] issueHeaders)
        {
            this.issueHeaders = issueHeaders;
            ListIssues();
        }

        private void ListIssues()
        {
            if (issueHeaders == null)
            {
                return;
            }
            bool showThisIssue;
            issuesList.BeginUpdate();
            issuesList.Items.Clear();
            IEnumerator issueHeadersEnumerator = issueHeaders.GetEnumerator();
            while (issueHeadersEnumerator.MoveNext())
            {
                IssueHeaderData issueHeaderData = (IssueHeaderData)issueHeadersEnumerator.Current;
                showThisIssue = true;
                if (this.radioButtonMyIssues.Checked)
                {
                    if ((myAccountID != null) && (issueHeaderData.handler != myAccountID))
                    {
                        showThisIssue = false;
                    }
                }

                if (searchString != String.Empty)
                {
                    showThisIssue &=
                        (
                        issueHeaderData.summary.Contains(searchString) ||
                        issueHeaderData.id.Contains(searchString)
                        );
                }

                if (showThisIssue)
                {
                    ListViewItem item = new ListViewItem(issueHeaderData.id);
                    //item.UseItemStyleForSubItems = false; // allow coloring of just status
                    String owner = issueHeaderData.handler;
                    String statusString = getStatusString(issueHeaderData.status);
                    if (owner != null)
                    {
                        statusString += String.Format(" ({0})", GetUserName(issueHeaderData.handler));
                    }
                    ListViewItem.ListViewSubItem status = item.SubItems.Add(statusString);
                    item.BackColor = getStatusColor(issueHeaderData.status);
                    item.SubItems.Add(issueHeaderData.last_updated.ToString("yyyy-MM-dd HH:mm"));
                    item.SubItems.Add(issueHeaderData.summary);
                    item.Tag = issueHeaderData;
                    issuesList.Items.Add(item);
                }
            }

            // if the filter found one item, select it
            if (issuesList.Items.Count == 1)
            {
                issuesList.Items[0].Selected = true;
            }
            issuesList.Sort();
            issuesList.EndUpdate();
            issuesList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            progressBar.Value = progressBar.Maximum;
            statusLabel.Text = String.Format("{0}/{1}个问题", issuesList.Items.Count, issueHeaders.Length);
        }

        public IssueHeaderData[] GetSelectedIssue()
        {
            return selectedIssue;
        }

        private String GetUserName(string userid)
        {
            if (accountData == null)
            {
                return userid;
            }
            else
            {
                IEnumerator e = accountData.GetEnumerator();
                while (e.MoveNext())
                {
                    // TODO: make O(log n)
                    AccountData account = (AccountData)e.Current;
                    if (account.id == userid)
                    {
                        return account.name;
                    }
                }
            }
            return "unknown";
        }

        private String getStatusString(string statusCode)
        {
            if (statusEnum == null)
            {
                return statusCode;
            }
            else
            {
                IEnumerator e = statusEnum.GetEnumerator();
                while (e.MoveNext())
                {
                    // TODO: make O(log n)
                    ObjectRef status = (ObjectRef)e.Current;
                    if (status.id == statusCode)
                    {
                        return status.name;
                    }
                }
            }
            return "unknown";
        }

        private Color getStatusColor(string status)
        {
            Color color = Color.White;
            switch (status)
            {
                case "10":
                    color = Color.FromArgb(0xfc, 0xbd, 0xbd);
                    break;
                case "20":
                    color = Color.FromArgb(0xe3, 0xb7, 0xeb); 
                    break;
                case "30":
                    color = Color.FromArgb(0xff, 0xcd, 0x85); 
                    break;
                case "40":
                    color = Color.FromArgb(0xff, 0xf4, 0x94); 
                    break;
                case "50":
                    color = Color.FromArgb(0xc2, 0xdf, 0xff); 
                    break;
                case "80":
                    color = Color.FromArgb(0xd2, 0xf5, 0xb0); 
                    break;
                case "90":
                    color = Color.FromArgb(0xc9, 0xcc, 0xc4); 
                    break;
            }
            return color;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (issuesList.SelectedItems.Count > 0)
            {
                List<IssueHeaderData> datas = new List<IssueHeaderData>();
                foreach (ListViewItem item in issuesList.SelectedItems)
	            {
                    datas.Add((IssueHeaderData)item.Tag);
	            }
                selectedIssue = datas.ToArray();
            }
        }

        private void filterRadio_Changed(object sender, EventArgs e)
        {
            ListIssues();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            searchString = textBoxSearch.Text;
            ListIssues();
        }

        private void issuesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonOK.Enabled = (issuesList.SelectedItems.Count > 0);
        }

        private void issuesList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == issuesListColumnSorter.SortColumn)
            {
                if (issuesListColumnSorter.SortOrder == SortOrder.Ascending)
                {
                    issuesListColumnSorter.SortOrder = SortOrder.Descending;
                }
                else
                {
                    issuesListColumnSorter.SortOrder = SortOrder.Ascending;
                }
            }
            else
            {
                issuesListColumnSorter.SortColumn = e.Column;
                issuesListColumnSorter.SortOrder = SortOrder.Ascending;
            }
            issuesList.Sort();
        }

        private void comboBoxProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            mplugin.GetProjectIssue((ProjectData)comboBoxProjects.SelectedItem);
        }

    }
}
