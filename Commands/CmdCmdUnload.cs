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
using MCDek;
using System;
using System.IO;

namespace MCLawl
{
    class CmdCmdUnload : Command
    {
        public override string name { get { return "cmdunload"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Nobody; } }
        public CmdCmdUnload() { }

        public override void Use(Player p, string message)
        {
            if (message == "") { Help(p); return; }
            if (Command.core.Contains(message.Split(' ')[0]))
            {
                Player.SendMessage(p, "/" + message.Split(' ')[0] + " is a core command, you cannot unload it!");
                return;
            }
            Command foundCmd = Command.all.Find(message.Split(' ')[0]);
            if(foundCmd == null)
            {
                Player.SendMessage(p, message.Split(' ')[0] + " is not a valid or loaded command.");
                return;
            }
            Command.all.Remove(foundCmd);
            GrpCommands.fillRanks();
            Player.SendMessage(p, "Command was successfully unloaded.");
        }

        public override void Help(Player p)
        {
            Player.SendMessage(p, "/cmdunload <command> - Unloads a command from the server.");
        }
    }
}
