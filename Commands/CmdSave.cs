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
using MCDek;
namespace MCLawl
{
    public class CmdSave : Command
    {
        public override string name { get { return "save"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public CmdSave() { }

        public override void Use(Player p, string message)
        {
            if (message.ToLower() == "all")
            {
                foreach (Level l in Server.levels)
                {
                    try
                    {
                        l.Save();
                    }
                    catch { }
                }
                Player.GlobalMessage("All levels have been saved.");
            }
            else
            {
                if (message.Split(' ').Length == 1)         //Just save level given
                {
                    Level foundLevel = Level.Find(message);
                    if (foundLevel != null)
                    {
                        foundLevel.Save(true);
                        Player.SendMessage(p, "Level \"" + foundLevel.name + "\" saved.");
                        int backupNumber = p.level.Backup(true);
                        if (backupNumber != -1)
                            p.level.ChatLevel("Backup " + backupNumber + " saved.");
                    }
                    else
                    {
                        Player.SendMessage(p, "Could not find level specified");
                    }
                }
                else if (message.Split(' ').Length == 2)
                {
                    Level foundLevel = Level.Find(message.Split(' ')[0]);
                    string restoreName = message.Split(' ')[1].ToLower();
                    if (foundLevel != null)
                    {
                        foundLevel.Save(true);
                        int backupNumber = p.level.Backup(true, restoreName);
                        Player.GlobalMessage(foundLevel.name + " had a backup created named &b" + restoreName);
                    }
                    else
                    {
                        Player.SendMessage(p, "Could not find level specified");
                    }
                }
                else
                {
                    if (p == null)
                    {
                        Use(p, "all");
                    }
                    else
                    {
                        p.level.Save(true);
                        Player.SendMessage(p, "Level \"" + p.level.name + "\" saved.");

                        int backupNumber = p.level.Backup(true);
                        if (backupNumber != -1)
                            p.level.ChatLevel("Backup " + backupNumber + " saved.");
                    }
                }
            }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/save - Saves the level you are currently in");
            Player.SendMessage(p, "/save all - Saves all loaded levels.");
            Player.SendMessage(p, "/save <map> - Saves the specified map.");
            Player.SendMessage(p, "/save <map> <name> - Backups the map with a given restore name");
        }
    }
}