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

namespace TortoiseMantis
{
    internal partial class IssuesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.GroupBox groupBoxFilter;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IssuesForm));
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.radioButtonMyIssues = new System.Windows.Forms.RadioButton();
            this.radioButtonAllIssues = new System.Windows.Forms.RadioButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxIssues = new System.Windows.Forms.GroupBox();
            this.issuesList = new System.Windows.Forms.ListView();
            this.columnIssue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSummary = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.buttonsRightPanel = new System.Windows.Forms.Panel();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            groupBoxFilter = new System.Windows.Forms.GroupBox();
            groupBoxFilter.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxIssues.SuspendLayout();
            this.buttonsPanel.SuspendLayout();
            this.buttonsRightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFilter
            // 
            groupBoxFilter.Controls.Add(this.textBoxSearch);
            groupBoxFilter.Controls.Add(this.labelSearch);
            groupBoxFilter.Controls.Add(this.radioButtonMyIssues);
            groupBoxFilter.Controls.Add(this.radioButtonAllIssues);
            groupBoxFilter.Dock = System.Windows.Forms.DockStyle.Top;
            groupBoxFilter.Location = new System.Drawing.Point(8, 8);
            groupBoxFilter.Margin = new System.Windows.Forms.Padding(8);
            groupBoxFilter.Name = "groupBoxFilter";
            groupBoxFilter.Size = new System.Drawing.Size(616, 76);
            groupBoxFilter.TabIndex = 3;
            groupBoxFilter.TabStop = false;
            groupBoxFilter.Text = "Filter";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(228, 16);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(165, 20);
            this.textBoxSearch.TabIndex = 3;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(171, 21);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(44, 13);
            this.labelSearch.TabIndex = 2;
            this.labelSearch.Text = "&Search:";
            // 
            // radioButtonMyIssues
            // 
            this.radioButtonMyIssues.AutoSize = true;
            this.radioButtonMyIssues.Checked = true;
            this.radioButtonMyIssues.Location = new System.Drawing.Point(24, 19);
            this.radioButtonMyIssues.Name = "radioButtonMyIssues";
            this.radioButtonMyIssues.Size = new System.Drawing.Size(96, 17);
            this.radioButtonMyIssues.TabIndex = 1;
            this.radioButtonMyIssues.TabStop = true;
            this.radioButtonMyIssues.Text = "assigned to &me";
            this.radioButtonMyIssues.UseVisualStyleBackColor = true;
            this.radioButtonMyIssues.CheckedChanged += new System.EventHandler(this.filterRadio_Changed);
            // 
            // radioButtonAllIssues
            // 
            this.radioButtonAllIssues.AutoSize = true;
            this.radioButtonAllIssues.Location = new System.Drawing.Point(24, 48);
            this.radioButtonAllIssues.Name = "radioButtonAllIssues";
            this.radioButtonAllIssues.Size = new System.Drawing.Size(95, 17);
            this.radioButtonAllIssues.TabIndex = 0;
            this.radioButtonAllIssues.Text = "show &all issues";
            this.radioButtonAllIssues.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar,
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 353);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(632, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 16);
            this.progressBar.Value = 50;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(65, 17);
            this.statusLabel.Text = "some status";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBoxIssues);
            this.panel1.Controls.Add(groupBoxFilter);
            this.panel1.Controls.Add(this.buttonsPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8, 8, 8, 0);
            this.panel1.Size = new System.Drawing.Size(632, 353);
            this.panel1.TabIndex = 1;
            // 
            // groupBoxIssues
            // 
            this.groupBoxIssues.Controls.Add(this.issuesList);
            this.groupBoxIssues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxIssues.Location = new System.Drawing.Point(8, 84);
            this.groupBoxIssues.Margin = new System.Windows.Forms.Padding(8);
            this.groupBoxIssues.Name = "groupBoxIssues";
            this.groupBoxIssues.Padding = new System.Windows.Forms.Padding(5);
            this.groupBoxIssues.Size = new System.Drawing.Size(616, 235);
            this.groupBoxIssues.TabIndex = 4;
            this.groupBoxIssues.TabStop = false;
            this.groupBoxIssues.Text = "Issues List";
            // 
            // issuesList
            // 
            this.issuesList.AllowColumnReorder = true;
            this.issuesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnIssue,
            this.columnStatus,
            this.columnSummary});
            this.issuesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.issuesList.FullRowSelect = true;
            this.issuesList.HideSelection = false;
            this.issuesList.Location = new System.Drawing.Point(5, 18);
            this.issuesList.Margin = new System.Windows.Forms.Padding(0);
            this.issuesList.MultiSelect = false;
            this.issuesList.Name = "issuesList";
            this.issuesList.Size = new System.Drawing.Size(606, 212);
            this.issuesList.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.issuesList.TabIndex = 2;
            this.issuesList.UseCompatibleStateImageBehavior = false;
            this.issuesList.View = System.Windows.Forms.View.Details;
            this.issuesList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.issuesList_ColumnClick);
            this.issuesList.SelectedIndexChanged += new System.EventHandler(this.issuesList_SelectedIndexChanged);
            this.issuesList.DoubleClick += new System.EventHandler(this.issuesList_DoubleClick);
            // 
            // columnIssue
            // 
            this.columnIssue.Text = "Issue";
            this.columnIssue.Width = 70;
            // 
            // columnStatus
            // 
            this.columnStatus.Text = "Status";
            this.columnStatus.Width = 130;
            // 
            // columnSummary
            // 
            this.columnSummary.Text = "Summary";
            this.columnSummary.Width = 502;
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.buttonsRightPanel);
            this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonsPanel.Location = new System.Drawing.Point(8, 319);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.buttonsPanel.Size = new System.Drawing.Size(616, 34);
            this.buttonsPanel.TabIndex = 0;
            // 
            // buttonsRightPanel
            // 
            this.buttonsRightPanel.Controls.Add(this.buttonOK);
            this.buttonsRightPanel.Controls.Add(this.buttonCancel);
            this.buttonsRightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonsRightPanel.Location = new System.Drawing.Point(453, 5);
            this.buttonsRightPanel.Name = "buttonsRightPanel";
            this.buttonsRightPanel.Size = new System.Drawing.Size(163, 24);
            this.buttonsRightPanel.TabIndex = 2;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonOK.Enabled = false;
            this.buttonOK.Location = new System.Drawing.Point(0, 0);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 24);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonCancel.Location = new System.Drawing.Point(88, 0);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 24);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // IssuesForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(632, 375);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IssuesForm";
            this.Text = "TortoiseMantis";
            this.Load += new System.EventHandler(this.IssuesForm_Load);
            groupBoxFilter.ResumeLayout(false);
            groupBoxFilter.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBoxIssues.ResumeLayout(false);
            this.buttonsPanel.ResumeLayout(false);
            this.buttonsRightPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.ListView issuesList;
        private System.Windows.Forms.ColumnHeader columnIssue;
        private System.Windows.Forms.ColumnHeader columnStatus;
        private System.Windows.Forms.ColumnHeader columnSummary;
        private System.Windows.Forms.Panel buttonsRightPanel;
        private System.Windows.Forms.GroupBox groupBoxIssues;
        private System.Windows.Forms.RadioButton radioButtonMyIssues;
        private System.Windows.Forms.RadioButton radioButtonAllIssues;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label labelSearch;

    }
}