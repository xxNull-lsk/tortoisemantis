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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using MantisScreenSaver.MantisConnectReference;

namespace MantisScreenSaver
{
    public partial class ConfigureForm : Form
    {
        public ConfigureForm()
        {
            InitializeComponent();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                BasicHttpBinding binding = new BasicHttpBinding();
                EndpointAddress endpoint = new EndpointAddress(textBoxAPIURL.Text);
                MantisConnectPortTypeClient client = new MantisConnectPortTypeClient(binding, endpoint);
                ProjectData[] projects = new ProjectData[0];

                listBoxProject.BeginUpdate();
                listBoxProject.Items.Clear();
                listBoxProject.Enabled = false;

                try
                {
                    projects = client.mc_projects_get_user_accessible(textBoxUsername.Text, textBoxPassword.Text);
                }
                catch (CommunicationException communicationException)
                {
                    MessageBox.Show(communicationException.ToString(), "communication exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (projects.Length > 0)
                {
                    listBoxProject.Items.AddRange(projects);
                    listBoxProject.SelectedIndex = 0;
                    listBoxProject.Enabled = true;
                }
            }
            catch (ProtocolException protocolException)
            {
                MessageBox.Show("connection failed: \n" + protocolException.Message);
            }
            catch (UriFormatException uriFormatException)
            {
                MessageBox.Show("incorrect URL: \n" + uriFormatException.Message);
            }
            catch (EndpointNotFoundException endpointNotFoundException)
            {
                MessageBox.Show("enpoint not found: \n" + endpointNotFoundException.Message);
            }
            finally
            {
                listBoxProject.EndUpdate();
                this.Cursor = Cursors.Default;
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = ((Button)sender).DialogResult;
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            ProjectData selectedProject = (ProjectData)listBoxProject.SelectedItem;
            ConnectionSettings connectionSettings = new ConnectionSettings();
            if (selectedProject != null)
            {
                connectionSettings.ProjectID = selectedProject.id;
                connectionSettings.ProjectName = selectedProject.name;
            }
            connectionSettings.URL = textBoxAPIURL.Text;
            connectionSettings.Username = textBoxUsername.Text;
            connectionSettings.Password = textBoxPassword.Text;
            connectionSettings.SaveToRegistry();
            DialogResult = ((Button)sender).DialogResult;
            Close();
        }

        private void ConfigureForm_Load(object sender, EventArgs e)
        {
            ConnectionSettings connectionSettings = new ConnectionSettings();
            connectionSettings.LoadFromRegistry();
            textBoxAPIURL.Text = connectionSettings.URL;
            textBoxUsername.Text = connectionSettings.Username;
            textBoxPassword.Text = connectionSettings.Password;
            ProjectData project = new ProjectData();
            project.name = connectionSettings.ProjectName;
            project.id = connectionSettings.ProjectID;
            listBoxProject.Items.Add(project);
            listBoxProject.SelectedIndex = 0;
        }
    }
}
