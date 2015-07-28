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
using TortoiseMantis;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            String p = "url:http://192.168.8.7/mantis/api/soap/mantisconnect.php username:Allan password:1234";

            Plugin plugin = new Plugin();
            if (plugin.ValidateParameters(System.IntPtr.Zero, p))
            {
                string[] param = {};
                string ret = plugin.GetCommitMessage(System.IntPtr.Zero, p, string.Empty, param, "original message");
                System.Console.Out.WriteLine(ret);
//                System.Console.In.ReadLine();
                //ret = plugin.GetCommitMessage(System.IntPtr.Zero, p, string.Empty, param, "original message");
                //System.Console.Out.WriteLine(ret);
                System.Console.In.ReadLine();
            }
        }
    }
}
