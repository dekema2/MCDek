/*
	Copyright 2010 MCLawl Team - Written by Valek
 
    Licensed under the
	Educational Community License, Version 2.0 (the "License"); you may
	not use this file except in compliance with the License. You may
	obtain a copy of the License at
	
	http://www.osedu.org/licenses/ECL-2.0
	
	Unless required by applicable law or agreed to in writing,
	software distributed under the License is distributed on an "AS IS"
	BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
	or implied. See the License for the specific language governing
	permissions and limitations under the License.
*/

using System;

namespace MCLawl
{
    public class CmdCompile : Command
    {
        public override string name { get { return "compile"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Admin; } }
        public CmdCompile() { }

        public override void Use(Player p, string message)
        {
            if(message == "" || message.IndexOf(' ') != -1) { Help(p); return; }
            bool success = false;
            try
            {
                 success = Scripting.Compile(message);
            }
            catch (Exception e)
            {
                Server.ErrorLog(e);
                Player.SendMessage(p, "An exception was thrown during compilation.");
                return;
            }
            if (success)
            {
                Player.SendMessage(p, "Compiled successfully.");
            }
            else
            {
                Player.SendMessage(p, "Compilation error.  Please check compile.log for more information.");
            }
        }

        public override void Help(Player p)
        {
            Player.SendMessage(p, "/compile <class name> - Compiles a command class file into a DLL.");
        }
    }
}
