﻿/*
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

namespace MCLawl
{
    public class CmdPossess : Command
    {
        public override string name { get { return "possess"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Admin; } }
        public CmdPossess() { }

        public override void Use(Player p, string message)
        {
            if (message.Split(' ').Length > 2) { Help(p); return; }
            if (p == null) { Player.SendMessage(p, "Console possession?  Nope.avi."); return; }
            try
            {
                string skin = (message.Split(' ').Length == 2) ? message.Split(' ')[1] : "";
                message = message.Split(' ')[0];
                if (message == "")
                {
                    if (p.possess == "")
                    {
                        Help(p);
                        return;
                    }
                    else
                    {
                        Player who = Player.Find(p.possess);
                        if (who == null)
                        {
                            p.possess = "";
                            Player.SendMessage(p, "Possession disabled.");
                            return;
                        }
                        who.following = "";
                        who.canBuild = true;
                        p.possess = "";
                        if (!who.MarkPossessed())
                        {
                            return;
                        }
                        p.invincible = false;
                        Command.all.Find("hide").Use(p, "");
                        Player.SendMessage(p, "Stopped possessing " + who.color + who.name + Server.DefaultColor + ".");
                        return;
                    }
                }
                else if (message == p.possess)
                {
                    Player who = Player.Find(p.possess);
                    if (who == null)
                    {
                        p.possess = "";
                        Player.SendMessage(p, "Possession disabled.");
                        return;
                    }
                    if (who == p)
                    {
                        Player.SendMessage(p, "Cannot possess yourself!");
                        return;
                    }
                    who.following = "";
                    who.canBuild = true;
                    p.possess = "";
                    if (!who.MarkPossessed())
                    {
                        return;
                    }
                    p.invincible = false;
                    Command.all.Find("hide").Use(p, "");
                    Player.SendMessage(p, "Stopped possessing " + who.color + who.name + Server.DefaultColor + ".");
                    return;
                }
                else
                {
                    Player who = Player.Find(message);
                    if (who == null)
                    {
                        Player.SendMessage(p, "Could not find player.");
                        return;
                    }
                    if (who.group.Permission >= p.group.Permission)
                    {
                        Player.SendMessage(p, "Cannot possess someone of equal or greater rank.");
                        return;
                    }
                    if (who.possess != "")
                    {
                        Player.SendMessage(p, "That player is currently possessing someone!");
                        return;
                    }
                    if (who.following != "")
                    {
                        Player.SendMessage(p, "That player is either following someone or already possessed.");
                        return;
                    }
                    if (p.possess != "")
                    {
                        Player oldwho = Player.Find(p.possess);
                        if (oldwho != null)
                        {
                            oldwho.following = "";
                            oldwho.canBuild = true;
                            if (!oldwho.MarkPossessed())
                            {
                                return;
                            }
                            //p.SendSpawn(oldwho.id, oldwho.color + oldwho.name, oldwho.pos[0], oldwho.pos[1], oldwho.pos[2], oldwho.rot[0], oldwho.rot[1]);
                        }
                    }
                    Command.all.Find("tp").Use(p, who.name);
                    if (!p.hidden)
                    {
                        Command.all.Find("hide").Use(p, "");
                    }
                    p.possess = who.name;
                    who.following = p.name;
                    if (!p.invincible)
                    {
                        p.invincible = true;
                    }
                    bool result = (skin == "#") ? who.MarkPossessed() : who.MarkPossessed(p.name);
                    if (!result)
                    {
                        return;
                    }
                    p.SendDie(who.id);
                    who.canBuild = false;
                    Player.SendMessage(p, "Successfully possessed " + who.color + who.name + Server.DefaultColor + ".");
                }
            }
            catch (Exception e)
            {
                Server.ErrorLog(e);
                Player.SendMessage(p, "There was an error.");
            }
        }

        public override void Help(Player p)
        {
            Player.SendMessage(p, "/possess <player> [skin as #] - DEMONIC POSSESSION HUE HUE");
            Player.SendMessage(p, "Using # after player name makes possessed keep their custom skin during possession.");
            Player.SendMessage(p, "Not using it makes them lose their skin, and makes their name show as \"Player (YourName)\".");
        }
    }
}
