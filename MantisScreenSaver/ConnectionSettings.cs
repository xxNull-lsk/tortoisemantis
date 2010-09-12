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
using System.Text;
using System.Diagnostics;
using System.Security.Cryptography;
using Microsoft.Win32;

namespace MantisScreenSaver
{
    internal class ConnectionSettings
    {
        private String url;
        private String username;
        private String password;
        private String projectname;
        private String projectid;

        public ConnectionSettings()
        {
            url = String.Empty;
            username = String.Empty;
            password = String.Empty;
            projectname = String.Empty;
            projectid = String.Empty;
        }

        public void LoadFromRegistry()
        {
            byte[] encrypted = new byte[0];
            byte[] plain;
            byte[] entropy = new byte[16];

            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\MantisScreenSaver");
            if (key != null)
            {
                url = (string)key.GetValue("url", String.Empty);
                username = (string)key.GetValue("username", String.Empty);
                encrypted = (byte[])key.GetValue("password", encrypted);                
                entropy = (byte[])key.GetValue("entropy", entropy);
                try
                {
                    plain = ProtectedData.Unprotect(encrypted, entropy, DataProtectionScope.CurrentUser);
                    password = UnicodeEncoding.ASCII.GetString(plain).Trim();
                }
                catch (CryptographicException cryptographicException)
                {
                    password = String.Empty;
                }
                projectname = (string)key.GetValue("projectname", String.Empty);
                projectid = (string)key.GetValue("projectid", String.Empty);
            }
        }

        public void SaveToRegistry()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\MantisScreenSaver");
            // pad up to multiples of 16
            if ( (password.Length % 16) != 0 )
            {
                password = password.PadRight( password.Length + (16 - (password.Length % 16)));
            }
            byte[] plain = UnicodeEncoding.ASCII.GetBytes(password);
            byte[] entropy = new byte[16];
            byte[] encrypted;
            new RNGCryptoServiceProvider().GetBytes(entropy);
            encrypted = ProtectedData.Protect(plain, entropy, DataProtectionScope.CurrentUser);
            key.SetValue("url", url);
            key.SetValue("username", username);
            key.SetValue("password", encrypted, RegistryValueKind.Binary);
            key.SetValue("entropy", entropy, RegistryValueKind.Binary);
            key.SetValue("projectname", projectname);
            key.SetValue("projectid", projectid, RegistryValueKind.String);
        }

        public String URL
        {
            get { return this.url; }
            set { this.url = value; }
        }

        public String Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public String Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public String ProjectID
        {
            get { return this.projectid; }
            set { this.projectid = value; }
        }

        public String ProjectName
        {
            get { return this.projectname; }
            set { this.projectname = value; }
        }

    }
}
