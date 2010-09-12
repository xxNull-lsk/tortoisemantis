namespace MantisScreenSaver
{
    partial class ScreenSaverForm
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
            this.components = new System.ComponentModel.Container();
            this.labelBugCount = new System.Windows.Forms.Label();
            this.timerAnimation = new System.Windows.Forms.Timer(this.components);
            this.timerFetchCount = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // labelBugCount
            // 
            this.labelBugCount.AutoSize = true;
            this.labelBugCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBugCount.ForeColor = System.Drawing.Color.Red;
            this.labelBugCount.Location = new System.Drawing.Point(12, 9);
            this.labelBugCount.Name = "labelBugCount";
            this.labelBugCount.Size = new System.Drawing.Size(964, 108);
            this.labelBugCount.TabIndex = 0;
            this.labelBugCount.Text = "retrieving bug count...";
            this.labelBugCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerAnimation
            // 
            this.timerAnimation.Interval = 10000;
            this.timerAnimation.Tick += new System.EventHandler(this.timerAnimation_Tick);
            // 
            // timerFetchCount
            // 
            this.timerFetchCount.Interval = 300000;
            this.timerFetchCount.Tick += new System.EventHandler(this.timerFetchCount_Tick);
            // 
            // ScreenSaverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.labelBugCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScreenSaverForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ScreenSaverForm";
            this.Load += new System.EventHandler(this.ScreenSaverForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ScreenSaverForm_KeyPress);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ScreenSaverForm_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScreenSaverForm_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBugCount;
        private System.Windows.Forms.Timer timerAnimation;
        private System.Windows.Forms.Timer timerFetchCount;
    }
}