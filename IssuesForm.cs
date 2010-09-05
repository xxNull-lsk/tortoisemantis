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

namespace TortoiseMantis
{
    internal partial class IssuesForm : Form, IIssuesDisplay
    {
        private IssueHeaderData[] issueHeaders;
        private IssueHeaderData selectedIssue;
        private String myAccountID;
        private ConnectionSettings cs;
        private String searchString;
        private IssuesListColumnSorter issuesListColumnSorter;
        private IDictionary<string, string> userNameMapping;
        private IDictionary<string, string> statusMapping;
        private IDictionary<string, Color> statusColorMapping;

        public IssuesForm(Plugin plugin, ConnectionSettings cs)
        {
            InitializeComponent();
            issuesListColumnSorter = new IssuesListColumnSorter();
            issuesList.ListViewItemSorter = (IComparer)issuesListColumnSorter;
            this.Text += String.Format(" v{0}", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
            issueHeaders = null;
            selectedIssue = null;
            myAccountID = null;
            userNameMapping = new Dictionary<string, string>();
            statusMapping = new Dictionary<string, string>();
            this.cs = cs;
            searchString = String.Empty;
            plugin.StatusUpdated += new Plugin.StatusUpdatedHandler(plugin_StatusUpdated);
            InitializeStatusColorMapping();
        }

        void plugin_StatusUpdated(string status)
        {
            statusLabel.Text = status;
            progressBar.PerformStep();
        }

        private void IssuesForm_Load(object sender, EventArgs e)
        {
            progressBar.Value = progressBar.Minimum;
            statusLabel.Text = "connecting...";
        }

        public void SetStatusMappings(ObjectRef[] statusEnum)
        {
            statusMapping.Clear();
            IEnumerator e = statusEnum.GetEnumerator();
            while (e.MoveNext())
            {
                ObjectRef status = (ObjectRef)e.Current;
                statusMapping.Add(status.id, status.name);
            }
            ListIssues();
        }

        public void SetAccountData(AccountData[] accountData)
        {
            userNameMapping.Clear();
            IEnumerator e = accountData.GetEnumerator();
            while (e.MoveNext()) 
            {
                AccountData account = (AccountData)e.Current;
                userNameMapping.Add(account.id, account.name);
                if (account.name == cs.Username)
                {
                    this.myAccountID = account.id;
                }
            }
            ListIssues();
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
                    String statusString = GetStatusString(issueHeaderData.status);
                    if (owner != null && !this.radioButtonMyIssues.Checked)
                    {
                        statusString += String.Format(" ({0})", GetUserName(issueHeaderData.handler));
                    }
                    ListViewItem.ListViewSubItem status = item.SubItems.Add(statusString);
                    item.BackColor = getStatusColor(GetStatusString(issueHeaderData.status));
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
            progressBar.Value = progressBar.Maximum;
            statusLabel.Text = String.Format("showing {0} of {1} issues", issuesList.Items.Count, issueHeaders.Length);
        }

        public IssueHeaderData GetSelectedIssue()
        {
            return selectedIssue;
        }

        private String GetUserName(string userid)
        {
            if (userNameMapping.ContainsKey(userid))
                return userNameMapping[userid];
            return "unknown";
        }

        private String GetStatusString(string statusCode)
        {
            if (statusMapping.ContainsKey(statusCode))
                return statusMapping[statusCode];
            return "unknown";
        }

        private void InitializeStatusColorMapping()
        {
            statusColorMapping = new Dictionary<string, Color>();
            statusColorMapping.Add("new", Color.FromArgb(0xfc, 0xbd, 0xbd));
            statusColorMapping.Add("feedback", Color.FromArgb(0xe3, 0xb7, 0xeb)); 
            statusColorMapping.Add("acknowledged", Color.FromArgb(0xff, 0xcd, 0x85));
            statusColorMapping.Add("confirmed", Color.FromArgb(0xff, 0xf4, 0x94));
            statusColorMapping.Add("assigned", Color.FromArgb(0xc2, 0xdf, 0xff));
            statusColorMapping.Add("resolved", Color.FromArgb(0xd2, 0xf5, 0xb0));
            statusColorMapping.Add("closed", Color.FromArgb(0xc9, 0xcc, 0xc4));
        }
        
        private Color getStatusColor(string status)
        {
            if (statusColorMapping.ContainsKey(status))
                return statusColorMapping[status];
            return Color.White;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (issuesList.SelectedItems.Count == 1)
            {
                selectedIssue = (IssueHeaderData)issuesList.SelectedItems[0].Tag;
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

        private void issuesList_DoubleClick(object sender, EventArgs e)
        {
            buttonOK.PerformClick();
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

    }
}
