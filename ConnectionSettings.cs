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

namespace TortoiseMantis
{
    internal class ConnectionSettings
    {
        private String url;
        private String username;
        private String password;
        private bool valid;

        private const String URL_MARKER = "url";
        private const String USERNAME_MARKER = "username";
        private const String PASSWORD_MARKER = "password";

        public ConnectionSettings(String parameters)
        {
            url = String.Empty;
            username = String.Empty;
            password = String.Empty;
            valid = false;
            this.url = parameters.Substring(URL_MARKER.Length + 1);

            String[] chunks = parameters.Split(' ');
            try
            {
                foreach (String chunk in chunks)
                {
                    if (chunk.StartsWith(URL_MARKER + ":"))
                    {
                        this.url = chunk.Substring(URL_MARKER.Length + 1);
                    }
                    if (chunk.StartsWith(USERNAME_MARKER + ":"))
                    {
                        this.username = chunk.Substring(USERNAME_MARKER.Length + 1);
                    }
                    if (chunk.StartsWith(PASSWORD_MARKER + ":"))
                    {
                        this.password = chunk.Substring(PASSWORD_MARKER.Length + 1);
                    }
                }
                if ( (url != String.Empty ) && ( username != String.Empty ) && ( password != String.Empty ) )
                {
                    valid = true;
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                valid = false;
            }
        }

        public bool isValid()
        {
            return this.valid;
        }

        public String URL
        {
            get { return this.url; }
        }

        public String Username
        {
            get { return this.username; }
        }

        public String Password
        {
            get { return this.password; }
        }

    }
}
