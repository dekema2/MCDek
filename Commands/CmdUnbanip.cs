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
using System.Data;
using System.Text.RegularExpressions;
//using MySql.Data.MySqlClient;
//using MySql.Data.Types;
using MCDek;
namespace MCLawl
{
    public class CmdUnbanip : Command
    {
        Regex regex = new Regex(@"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\." +
                                "([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$");
        public override string name { get { return "unbanip"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public CmdUnbanip() { }

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
             rerun: try
                    {
                        ip = MySQL.fillData("SELECT IP FROM Players WHERE Name = '" + message + "'");
                    }
                    catch (Exception e)
                    {
                        tryCounter++;
                        if (tryCounter < 10)
                        {
                            goto rerun;
                        }
                        else
                        {
                            Server.ErrorLog(e);
                            Player.SendMessage(p, "There was a database error fetching the IP address.  It has been logged.");
                            return;
                        }
                    }
                    if (ip.Rows.Count > 0)
                    {
                        message = ip.Rows[0]["IP"].ToString();
                    }
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

            if (!regex.IsMatch(message)) { Player.SendMessage(p, "Not a valid ip!"); return; }
            if (p != null) if (p.ip == message) { Player.SendMessage(p, "You shouldn't be able to use this command..."); return; }
            if (!Server.bannedIP.Contains(message)) { Player.SendMessage(p, message + " doesn't seem to be banned..."); return; }
            Player.GlobalMessage(message + " got &8unip-banned" + Server.DefaultColor + "!");
            Server.bannedIP.Remove(message); Server.bannedIP.Save("banned-ip.txt", false);
            Server.s.Log("IP-UNBANNED: " + message.ToLower());
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/unbanip <ip> - Un-bans an ip.  Also accepts a player name when you use @ before the name.");
        }
    }
}