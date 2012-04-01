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
    public class CmdWhois : Command
    {
        public override string name { get { return "whois"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Banned; } }
        public CmdWhois() { }

        public override void Use(Player p, string message)
        {
            Player who = null;
            if (message == "") { who = p; message = p.name; } else { who = Player.Find(message); }
            if (who != null && !who.hidden)
            {
                Player.SendMessage(p, who.color + who.name + Server.DefaultColor + " is on &b" + who.level.name);
                Player.SendMessage(p, who.color + who.prefix + who.name + Server.DefaultColor + " has :");
                Player.SendMessage(p, "> > the rank of " + who.group.color + who.group.name);
                try
                {
                    if (!Group.Find("Nobody").commands.Contains("pay") && !Group.Find("Nobody").commands.Contains("give") && !Group.Find("Nobody").commands.Contains("take")) Player.SendMessage(p, "> > &a" + who.money + Server.DefaultColor + " " + Server.moneys);
                }
                catch { }
                Player.SendMessage(p, "> > &cdied &a" + who.overallDeath + Server.DefaultColor + " times");
                Player.SendMessage(p, "> > &bmodified &a" + who.overallBlocks + Server.DefaultColor + " blocks, &a" + who.loginBlocks + Server.DefaultColor + " since logging in.");
                string storedTime = Convert.ToDateTime(DateTime.Now.Subtract(who.timeLogged).ToString()).ToString("HH:mm:ss");
                Player.SendMessage(p, "> > been logged in for &a" + storedTime);
                Player.SendMessage(p, "> > first logged into the server on &a" + who.firstLogin.ToString("yyyy-MM-dd") + " at " + who.firstLogin.ToString("HH:mm:ss"));
                Player.SendMessage(p, "> > logged in &a" + who.totalLogins + Server.DefaultColor + " times, &c" + who.totalKicked + Server.DefaultColor + " of which ended in a kick.");
                Player.SendMessage(p, "> > " + Awards.awardAmount(who.name) + " awards");

                bool skip = false;
                if (p != null) if (p.group.Permission <= LevelPermission.AdvBuilder) skip = true;
                if (!skip)
                    {
                        string givenIP;
                        if (Server.bannedIP.Contains(who.ip)) givenIP = "&8" + who.ip + ", which is banned"; 
                        else givenIP = who.ip;
                        Player.SendMessage(p, "> > the IP of " + givenIP);
                        if (Server.useWhitelist)
                        {
                            if (Server.whiteList.Contains(who.name))
                            {
                                Player.SendMessage(p, "> > Player is &fWhitelisted");
                            }
                        }
                        if (Server.devs.Contains(who.name.ToLower()))
                        {
                            Player.SendMessage(p, Server.DefaultColor + "> > Player is a &9Developer");
                        }
                    }
            }
            else { Player.SendMessage(p, "\"" + message + "\" is offline! Using /whowas instead."); Command.all.Find("whowas").Use(p, message); }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/whois [player] - Displays information about someone.");
        }
    }
}