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
using MCDek;
namespace MCLawl
{
    public class CmdWhitelist : Command
    {
        public override string name { get { return "whitelist"; } }
        public override string shortcut { get { return "w"; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public CmdWhitelist() { }

        public override void Use(Player p, string message)
        {
            if (message == "") { Help(p); return; }
            int pos = message.IndexOf(' ');
            if (pos != -1)
            {
                string action = message.Substring(0, pos);
                string player = message.Substring(pos + 1);

                switch (action)
                {
                    case "add":
                        if (Server.whiteList.Contains(player))
                        {
                            Player.SendMessage(p, "&f" + player + Server.DefaultColor + " is already on the whitelist!");
                            break;
                        }
                        Server.whiteList.Add(player);
                        Player.GlobalMessageOps(p.color + p.prefix + p.name + Server.DefaultColor + " added &f" + player + Server.DefaultColor + " to the whitelist.");
                        Server.whiteList.Save("whitelist.txt");
                        Server.s.Log("WHITELIST: Added " + player);
                        break;
                    case "del":
                        if (!Server.whiteList.Contains(player))
                        {
                            Player.SendMessage(p, "&f" + player + Server.DefaultColor + " is not on the whitelist!");
                            break;
                        }
                        Server.whiteList.Remove(player);
                        Player.GlobalMessageOps(p.color + p.prefix + p.name + Server.DefaultColor + " removed &f" + player + Server.DefaultColor + " from the whitelist.");
                        Server.whiteList.Save("whitelist.txt");
                        Server.s.Log("WHITELIST: Removed " + player);
                        break;
                    case "list":
                        string output = "Whitelist:&f";
                        foreach (string wlName in Server.whiteList.All())
                        {
                            output += " " + wlName + ",";
                        }
                        output = output.Substring(0, output.Length - 1);
                        Player.SendMessage(p, output);
                        break;
                    default:
                        Help(p);
                        return;
                }
            }
            else
            {
                if (message == "list")
                {
                    string output = "Whitelist:&f";
                    foreach (string wlName in Server.whiteList.All())
                    {
                        output += " " + wlName + ",";
                    }
                    output = output.Substring(0, output.Length - 1);
                    Player.SendMessage(p, output);
                }
                else
                {
                    Help(p);
                }
            }
        }

        public override void Help(Player p)
        {
            Player.SendMessage(p, "/whitelist <add/del/list> [player] - Handles whitelist entry for [player], or lists all entries.");
        }
    }
}
