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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IssuesForm));
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.comboBoxProjects = new System.Windows.Forms.ComboBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.radioButtonMyIssues = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonAllIssues = new System.Windows.Forms.RadioButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.issuesList = new System.Windows.Forms.ListView();
            this.columnIssue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSummary = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.buttonsRightPanel = new System.Windows.Forms.Panel();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxFilter.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.buttonsPanel.SuspendLayout();
            this.buttonsRightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.comboBoxProjects);
            this.groupBoxFilter.Controls.Add(this.textBoxSearch);
            this.groupBoxFilter.Controls.Add(this.labelSearch);
            this.groupBoxFilter.Controls.Add(this.radioButtonMyIssues);
            this.groupBoxFilter.Controls.Add(this.label1);
            this.groupBoxFilter.Controls.Add(this.radioButtonAllIssues);
            resources.ApplyResources(this.groupBoxFilter, "groupBoxFilter");
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.TabStop = false;
            // 
            // comboBoxProjects
            // 
            resources.ApplyResources(this.comboBoxProjects, "comboBoxProjects");
            this.comboBoxProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProjects.FormattingEnabled = true;
            this.comboBoxProjects.Name = "comboBoxProjects";
            this.comboBoxProjects.SelectedIndexChanged += new System.EventHandler(this.comboBoxProjects_SelectedIndexChanged);
            // 
            // textBoxSearch
            // 
            resources.ApplyResources(this.textBoxSearch, "textBoxSearch");
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // labelSearch
            // 
            resources.ApplyResources(this.labelSearch, "labelSearch");
            this.labelSearch.Name = "labelSearch";
            // 
            // radioButtonMyIssues
            // 
            resources.ApplyResources(this.radioButtonMyIssues, "radioButtonMyIssues");
            this.radioButtonMyIssues.Checked = true;
            this.radioButtonMyIssues.Name = "radioButtonMyIssues";
            this.radioButtonMyIssues.TabStop = true;
            this.radioButtonMyIssues.UseVisualStyleBackColor = true;
            this.radioButtonMyIssues.CheckedChanged += new System.EventHandler(this.filterRadio_Changed);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // radioButtonAllIssues
            // 
            resources.ApplyResources(this.radioButtonAllIssues, "radioButtonAllIssues");
            this.radioButtonAllIssues.Name = "radioButtonAllIssues";
            this.radioButtonAllIssues.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar,
            this.statusLabel});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Value = 50;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            resources.ApplyResources(this.statusLabel, "statusLabel");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.issuesList);
            this.panel1.Controls.Add(this.groupBoxFilter);
            this.panel1.Controls.Add(this.buttonsPanel);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // issuesList
            // 
            this.issuesList.AllowColumnReorder = true;
            this.issuesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnIssue,
            this.columnStatus,
            this.columnSummary});
            resources.ApplyResources(this.issuesList, "issuesList");
            this.issuesList.FullRowSelect = true;
            this.issuesList.HideSelection = false;
            this.issuesList.Name = "issuesList";
            this.issuesList.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.issuesList.UseCompatibleStateImageBehavior = false;
            this.issuesList.View = System.Windows.Forms.View.Details;
            this.issuesList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.issuesList_ColumnClick);
            this.issuesList.SelectedIndexChanged += new System.EventHandler(this.issuesList_SelectedIndexChanged);
            // 
            // columnIssue
            // 
            resources.ApplyResources(this.columnIssue, "columnIssue");
            // 
            // columnStatus
            // 
            resources.ApplyResources(this.columnStatus, "columnStatus");
            // 
            // columnSummary
            // 
            resources.ApplyResources(this.columnSummary, "columnSummary");
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.buttonsRightPanel);
            resources.ApplyResources(this.buttonsPanel, "buttonsPanel");
            this.buttonsPanel.Name = "buttonsPanel";
            // 
            // buttonsRightPanel
            // 
            this.buttonsRightPanel.Controls.Add(this.buttonOK);
            this.buttonsRightPanel.Controls.Add(this.buttonCancel);
            resources.ApplyResources(this.buttonsRightPanel, "buttonsRightPanel");
            this.buttonsRightPanel.Name = "buttonsRightPanel";
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // IssuesForm
            // 
            this.AcceptButton = this.buttonOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "IssuesForm";
            this.Load += new System.EventHandler(this.IssuesForm_Load);
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.Panel buttonsRightPanel;
        private System.Windows.Forms.RadioButton radioButtonMyIssues;
        private System.Windows.Forms.RadioButton radioButtonAllIssues;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.ComboBox comboBoxProjects;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.ListView issuesList;
        private System.Windows.Forms.ColumnHeader columnIssue;
        private System.Windows.Forms.ColumnHeader columnStatus;
        private System.Windows.Forms.ColumnHeader columnSummary;

    }
}