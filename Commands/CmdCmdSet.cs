/*
	Copyright 2010 MCSharp team (Modified for use with MCZall/MCLawl) Licensed under the
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
using MCDek;
namespace MCLawl
{
    public class CmdCmdSet : Command
    {
        public override string name { get { return "cmdset"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Admin; } }
        public CmdCmdSet() { }

        public override void Use(Player p, string message)
        {
            if (message == "" || message.IndexOf(' ') == -1) { Help(p); return; }

            string foundBlah = Command.all.FindShort(message.Split(' ')[0]);

            Command foundCmd;
            if (foundBlah == "") foundCmd = Command.all.Find(message.Split(' ')[0]);
            else foundCmd = Command.all.Find(foundBlah);

            if (foundCmd == null) { Player.SendMessage(p, "Could not find command entered"); return; }
            if (p != null && !p.group.CanExecute(foundCmd)) { Player.SendMessage(p, "This command is higher than your rank."); return; }

            LevelPermission newPerm = Level.PermissionFromName(message.Split(' ')[1]);
            if (newPerm == LevelPermission.Null) { Player.SendMessage(p, "Could not find rank specified"); return; }
            if (p != null && newPerm > p.group.Permission) { Player.SendMessage(p, "Cannot set to a rank higher than yourself."); return; }

            GrpCommands.rankAllowance newCmd = GrpCommands.allowedCommands.Find(rA => rA.commandName == foundCmd.name);
            newCmd.lowestRank = newPerm;
            GrpCommands.allowedCommands[GrpCommands.allowedCommands.FindIndex(rA => rA.commandName == foundCmd.name)] = newCmd;

            GrpCommands.Save(GrpCommands.allowedCommands);
            GrpCommands.fillRanks();
            Player.GlobalMessage("&d" + foundCmd.name + Server.DefaultColor + "'s permission was changed to " + Level.PermissionToName(newPerm));
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/cmdset [cmd] [rank] - Changes [cmd] rank to [rank]");
            Player.SendMessage(p, "Only commands you can use can be modified");
            Player.SendMessage(p, "Available ranks: " + Group.concatList());
        }
    }
}