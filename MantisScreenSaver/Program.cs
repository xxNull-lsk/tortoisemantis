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
using System.Windows.Forms;


namespace MantisScreenSaver
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string arg0 = String.Empty;
            string arg1 = String.Empty;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0)
            {
                arg0 = args[0].ToLower().Trim();
                if (arg0.Length > 2)
                {
                    arg1 = arg0.Substring(3).Trim();
                    arg0 = arg0.Substring(0, 2);
                }
                else if (args.Length > 1)
                {
                    arg1 = args[1];
                }
            }

            switch (arg0)
            {
                case "/p":
                    // preview
                    if (arg1 != String.Empty)
                    {
                        IntPtr hwnd = new IntPtr(long.Parse(arg1));
                        Application.Run(new ScreenSaverForm(hwnd));
                    }
                    break;
                case "/s":
                    // show
                    ShowScreenSaver();
                    Application.Run();
                    break;
                case "/c":
                default:
                    Application.Run(new ConfigureForm());
                    // configure
                    break;
            }

        }

        static void ShowScreenSaver()
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                ScreenSaverForm screensaver = new ScreenSaverForm(screen.Bounds);
                screensaver.Show();
            }
        }
    }
        
}
