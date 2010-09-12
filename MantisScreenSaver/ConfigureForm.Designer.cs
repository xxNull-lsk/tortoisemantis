namespace MantisScreenSaver
{
    partial class ConfigureForm
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
            System.Windows.Forms.Label labelUsername;
            System.Windows.Forms.Label labelPassword;
            System.Windows.Forms.Label labelAPI;
            System.Windows.Forms.Label labelProject;
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.listBoxProject = new System.Windows.Forms.ListBox();
            this.textBoxAPIURL = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            labelUsername = new System.Windows.Forms.Label();
            labelPassword = new System.Windows.Forms.Label();
            labelAPI = new System.Windows.Forms.Label();
            labelProject = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Location = new System.Drawing.Point(12, 25);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new System.Drawing.Size(58, 13);
            labelUsername.TabIndex = 0;
            labelUsername.Text = "&Username:";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new System.Drawing.Point(12, 48);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new System.Drawing.Size(56, 13);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "&Password:";
            // 
            // labelAPI
            // 
            labelAPI.AutoSize = true;
            labelAPI.Location = new System.Drawing.Point(12, 76);
            labelAPI.Name = "labelAPI";
            labelAPI.Size = new System.Drawing.Size(52, 13);
            labelAPI.TabIndex = 4;
            labelAPI.Text = "&API URL:";
            // 
            // labelProject
            // 
            labelProject.AutoSize = true;
            labelProject.Location = new System.Drawing.Point(12, 137);
            labelProject.Name = "labelProject";
            labelProject.Size = new System.Drawing.Size(43, 13);
            labelProject.TabIndex = 7;
            labelProject.Text = "P&roject:";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(104, 102);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(176, 26);
            this.buttonConnect.TabIndex = 8;
            this.buttonConnect.Text = "C&onnect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(12, 236);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(88, 25);
            this.buttonOK.TabIndex = 9;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(192, 236);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(88, 25);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // listBoxProject
            // 
            this.listBoxProject.DisplayMember = "name";
            this.listBoxProject.FormattingEnabled = true;
            this.listBoxProject.Location = new System.Drawing.Point(104, 137);
            this.listBoxProject.Name = "listBoxProject";
            this.listBoxProject.Size = new System.Drawing.Size(176, 82);
            this.listBoxProject.Sorted = true;
            this.listBoxProject.TabIndex = 11;
            // 
            // textBoxAPIURL
            // 
            this.textBoxAPIURL.Location = new System.Drawing.Point(104, 76);
            this.textBoxAPIURL.Name = "textBoxAPIURL";
            this.textBoxAPIURL.Size = new System.Drawing.Size(176, 20);
            this.textBoxAPIURL.TabIndex = 5;
            this.textBoxAPIURL.Text = "http://127.0.0.1/bugs-test/api/soap/mantisconnect.php";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(104, 48);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(176, 20);
            this.textBoxPassword.TabIndex = 3;
            this.textBoxPassword.Text = "foopass";
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(104, 22);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(176, 20);
            this.textBoxUsername.TabIndex = 1;
            this.textBoxUsername.Text = "foouser";
            // 
            // ConfigureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 270);
            this.Controls.Add(this.listBoxProject);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(labelProject);
            this.Controls.Add(this.textBoxAPIURL);
            this.Controls.Add(labelAPI);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(labelPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(labelUsername);
            this.Name = "ConfigureForm";
            this.Text = "Mantis Screen Saver Options";
            this.Load += new System.EventHandler(this.ConfigureForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxAPIURL;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ListBox listBoxProject;

    }
}

