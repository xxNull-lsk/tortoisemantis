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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MantisScreenSaver.MantisConnectReference;
using System.ServiceModel;

namespace MantisScreenSaver
{
    public partial class ScreenSaverForm : Form
    {
        #region win api stuff

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);

        #endregion

        private Point mouseLocation = Point.Empty;
        private Random rand = new Random();
        private bool isPreview = false;
        ConnectionSettings connectionSettings;
        private MantisConnectPortTypeClient client;

        public ScreenSaverForm()
        {
            InitializeComponent();
        }

        public ScreenSaverForm(System.Drawing.Rectangle bounds)
        {
            InitializeComponent();
            this.Bounds = bounds;
        }

        public ScreenSaverForm(IntPtr PreviewWndHandle)
        {
            InitializeComponent();
            SetParent(this.Handle, PreviewWndHandle);
            SetWindowLong(this.Handle, -16, new IntPtr(GetWindowLong(this.Handle, -16) | 0x40000000));
            Rectangle ParentRect;
            GetClientRect(PreviewWndHandle, out ParentRect);
            Size = ParentRect.Size;
            Location = new Point(0, 0);
            labelBugCount.Font = new System.Drawing.Font(labelBugCount.Font.Name, 10);
            isPreview = true;
        }

        private void ScreenSaverForm_Load(object sender, EventArgs e)
        {
            Cursor.Hide();
            TopMost = true;
            timerAnimation.Start();
            timerFetchCount.Start();
            connectionSettings = new ConnectionSettings();
            connectionSettings.LoadFromRegistry();
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress endpoint = new EndpointAddress(connectionSettings.URL);
            client = new MantisConnectPortTypeClient(binding, endpoint);
            client.mc_project_get_issue_headersCompleted += new EventHandler<mc_project_get_issue_headersCompletedEventArgs>(client_mc_project_get_issue_headersCompleted);

            FetchBugCount();
        }

        private void FetchBugCount()
        {
            client.mc_project_get_issue_headersAsync(connectionSettings.Username, connectionSettings.Password, connectionSettings.ProjectID, "0", "0");
        }

        void client_mc_project_get_issue_headersCompleted(object sender, mc_project_get_issue_headersCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                labelBugCount.Text = String.Format("open bugs:\n{0}", e.Result.Length);
            }
            else
            {
                labelBugCount.Text = "Error retrieving bug count:\n" + e.Error.Message;
            }
        }

        private void ScreenSaverForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isPreview)
            {
                if (!mouseLocation.IsEmpty)
                {
                    if (Math.Abs(mouseLocation.X - e.X) > 5 ||
                        Math.Abs(mouseLocation.Y - e.Y) > 5)
                        Application.Exit();
                }
                mouseLocation = e.Location;
            }
        }

        private void ScreenSaverForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!isPreview)
            {
                Application.Exit();
            }
        }

        private void ScreenSaverForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (!isPreview)
            {
                Application.Exit();
            }
        }

        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            Point p = new Point();
            p.X = rand.Next(Math.Max(1, Bounds.Width - labelBugCount.Width));
            p.Y = rand.Next(Math.Max(1, Bounds.Height - labelBugCount.Height));
            labelBugCount.Location = p;
        }

        private void timerFetchCount_Tick(object sender, EventArgs e)
        {
            FetchBugCount();
        }
    }
}
