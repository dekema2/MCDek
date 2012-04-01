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
    public class CmdGoto : Command
    {
        public override string name { get { return "goto"; } }
        public override string shortcut { get { return "g"; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }
        public CmdGoto() { }

        public override void Use(Player p, string message)
        {
            if (message == "") { Help(p); return; }

            try
            {
                Level foundLevel = Level.Find(message);
                if (foundLevel != null)
                {
                    Level startLevel = p.level;

                    GC.Collect();

                    if (p.level == foundLevel) { Player.SendMessage(p, "You are already in \"" + foundLevel.name + "\"."); return; }
                    if (!p.ignorePermission)
                        if (p.group.Permission < foundLevel.permissionvisit) { Player.SendMessage(p, "You're not allowed to go to " + foundLevel.name + "."); return; }

                    p.Loading = true;
                    foreach (Player pl in Player.players) if (p.level == pl.level && p != pl) p.SendDie(pl.id);
                    foreach (PlayerBot b in PlayerBot.playerbots) if (p.level == b.level) p.SendDie(b.id);

                    Player.GlobalDie(p, true);
                    p.level = foundLevel; p.SendUserMOTD(); p.SendMap();

                    GC.Collect();

                    ushort x = (ushort)((0.5 + foundLevel.spawnx) * 32);
                    ushort y = (ushort)((1 + foundLevel.spawny) * 32);
                    ushort z = (ushort)((0.5 + foundLevel.spawnz) * 32);

                    if (!p.hidden) Player.GlobalSpawn(p, x, y, z, foundLevel.rotx, foundLevel.roty, true);
                    else unchecked { p.SendPos((byte)-1, x, y, z, foundLevel.rotx, foundLevel.roty); }

                    foreach (Player pl in Player.players)
                        if (pl.level == p.level && p != pl && !pl.hidden)
                            p.SendSpawn(pl.id, pl.color + pl.name, pl.pos[0], pl.pos[1], pl.pos[2], pl.rot[0], pl.rot[1]);

                    foreach (PlayerBot b in PlayerBot.playerbots)
                        if (b.level == p.level)
                            p.SendSpawn(b.id, b.color + b.name, b.pos[0], b.pos[1], b.pos[2], b.rot[0], b.rot[1]);

                    if (!p.hidden) Player.GlobalChat(p, p.color + "*" + p.name + Server.DefaultColor + " went to &b" + foundLevel.name, false);

                    p.Loading = false;

                    bool skipUnload = false;
                    if (startLevel.unload && !startLevel.name.Contains("&cMuseum "))
                    {
                        foreach (Player pl in Player.players) if (pl.level == startLevel) skipUnload = true;
                        if (!skipUnload && Server.AutoLoad) startLevel.Unload();
                    }
                }
                else if (Server.AutoLoad)
                {
                    Command.all.Find("load").Use(p, message);
                    foundLevel = Level.Find(message);
                    if (foundLevel != null) Use(p, message);
                }
                else Player.SendMessage(p, "There is no level \"" + message + "\" loaded.");

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch (Exception e) { Server.ErrorLog(e); }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/goto <mapname> - Teleports yourself to a different level.");
        }
    }
}