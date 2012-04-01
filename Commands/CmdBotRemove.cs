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
using System.IO;
using MCDek;
namespace MCLawl
{
    public class CmdBotRemove : Command
    {
        public override string name { get { return "botremove"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Admin; } }
        public string[,] botlist;
        public CmdBotRemove() { }

        public override void Use(Player p, string message)
        {
            if (message == "") { Help(p); return; }
            try
            {
                if (message.ToLower() == "all")
                {
                    for (int i = 0; i < PlayerBot.playerbots.Count; i++)
                    {
                        if (PlayerBot.playerbots[i].level == p.level)
                        {
                            //   PlayerBot.playerbots.Remove(PlayerBot.playerbots[i]);
                            PlayerBot Pb = PlayerBot.playerbots[i];
                            Pb.removeBot();
                            i--;
                        }
                    }
                }
                else
                {
                    PlayerBot who = PlayerBot.Find(message);
                    if (who == null) { Player.SendMessage(p, "There is no bot " + who + "!"); return; }
                    if (p.level != who.level) { Player.SendMessage(p, who.name + " is in a different level."); return; }
                    who.removeBot();
                    Player.SendMessage(p, "Removed bot.");
                }
            }
            catch (Exception e) { Server.ErrorLog(e); Player.SendMessage(p, "Error caught"); }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/botremove <name> - Remove a bot on the same level as you");
            //   Player.SendMessage(p, "If All is used, all bots on the current level are removed");
        }
    }
}