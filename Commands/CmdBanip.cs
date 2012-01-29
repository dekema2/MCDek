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
using System.Data;
//using MySql.Data.MySqlClient;
//using MySql.Data.Types;

namespace MCLawl
{
    public class CmdBanip : Command
    {
        public override string name { get { return "banip"; } }
        public override string shortcut { get { return "bi"; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public CmdBanip() { }

        public override void Use(Player p, string message)
        {
            if (message == "") { Help(p); return; }
            if (message[0] == '@')
            {
                message = message.Remove(0, 1).Trim();
                Player who = Player.Find(message);
                if (who == null)
                {
                    DataTable ip;
                    int tryCounter = 0;
            rerun:  try
                    {
                        ip = MySQL.fillData("SELECT IP FROM Players WHERE Name = '" + message + "'");
                    }
                    catch (Exception e)
                    {
                        tryCounter++;
                        if (tryCounter < 10)
                            goto rerun;
                        else
                        {
                            Server.ErrorLog(e);
                            return;
                        }
                    }
                    if (ip.Rows.Count > 0)
                        message = ip.Rows[0]["IP"].ToString();
                    else
                    {
                        Player.SendMessage(p, "Unable to find an IP address for that user.");
                        return;
                    }
                    ip.Dispose();
                }
                else
                {
                    message = who.ip;
                }
            }
            else
            {
                Player who = Player.Find(message);
                if (who != null)
                    message = who.ip;
            }

            if (message.Equals("127.0.0.1")) { Player.SendMessage(p, "You can't ip-ban the server!"); return; }
            if (message.IndexOf('.') == -1) { Player.SendMessage(p, "Invalid IP!"); return; }
            if (message.Split('.').Length != 4) { Player.SendMessage(p, "Invalid IP!"); return; }
            if (p != null) { if (p.ip == message) { Player.SendMessage(p, "You can't ip-ban yourself.!"); return; } }
            if (Server.bannedIP.Contains(message)) { Player.SendMessage(p, message + " is already ip-banned."); return; }
            Player.GlobalMessage(message + " got &8ip-banned!");
            if (p != null)
            {
                IRCBot.Say("IP-BANNED: " + message.ToLower() + " by " + p.name);
            }
            else
            {
                IRCBot.Say("IP-BANNED: " + message.ToLower() + " by console");
            }
            Server.bannedIP.Add(message);
            Server.bannedIP.Save("banned-ip.txt", false);
            Server.s.Log("IP-BANNED: " + message.ToLower());
            /*
            foreach (Player pl in Player.players) {
                if (message == pl.ip) { pl.Kick("Kicked by ipban"); }
            }*/
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/banip <ip/name> - Bans an ip. Also accepts a player name when you use @ before the name.");
        }
    }
}