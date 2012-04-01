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
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using MCDek;
namespace MCLawl
{
    class CmdRestore : Command
    {
        public override string name { get { return "restore"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public CmdRestore() { }

        public override void Use(Player p, string message)
        {
            //Thread CrossThread;

            if (message != "")
            {
                Server.s.Log(@Server.backupLocation + "/" + p.level.name + "/" + message + "/" + p.level.name + ".lvl");
                if (File.Exists(@Server.backupLocation + "/" + p.level.name + "/" + message + "/" + p.level.name + ".lvl"))
                {
                    try
                    {
                        File.Copy(@Server.backupLocation + "/" + p.level.name + "/" + message + "/" + p.level.name + ".lvl", "levels/" + p.level.name + ".lvl", true);
                        Level temp = Level.Load(p.level.name);
                        temp.physThread.Start();
                        if (temp != null)
                        {
                            p.level.spawnx = temp.spawnx;
                            p.level.spawny = temp.spawny;
                            p.level.spawnz = temp.spawnz;

                            p.level.height = temp.height;
                            p.level.width = temp.width;
                            p.level.depth = temp.depth;

                            p.level.blocks = temp.blocks;
                            p.level.setPhysics(0);
                            p.level.ClearPhysics();

                            Command.all.Find("reveal").Use(p, "all");
                        }
                        else
                        {
                            Server.s.Log("Restore nulled");
                            File.Copy("levels/" + p.level.name + ".lvl.backup", "levels/" + p.level.name + ".lvl", true);
                        }

                    }
                    catch { Server.s.Log("Restore fail"); }
                }
                else { Player.SendMessage(p, "Backup " + message + " does not exist."); }
            }
            else
            {
                if (Directory.Exists(@Server.backupLocation + "/" + p.level.name))
                {
                    string[] directories = Directory.GetDirectories(@Server.backupLocation + "/" + p.level.name);
                    int backupNumber = directories.Length;
                    Player.SendMessage(p, p.level.name + " has " + backupNumber + " backups .");

                    bool foundOne = false; string foundRestores = "";
                    foreach (string s in directories)
                    {
                        string directoryName = s.Substring(s.LastIndexOf('\\') + 1);
                        try
                        {
                            int.Parse(directoryName);
                        }
                        catch
                        {
                            foundOne = true;
                            foundRestores += ", " + directoryName;
                        }
                    }

                    if (foundOne)
                    {
                        Player.SendMessage(p, "Custom-named restores:");
                        Player.SendMessage(p, "> " + foundRestores.Remove(0, 2));
                    }
                }
                else
                {
                    Player.SendMessage(p, p.level.name + " has no backups yet.");
                }
            }
        }

        public override void Help(Player p)
        {
            Player.SendMessage(p, "/restore <number> - restores a previous backup of the current map");
        }
    }
}
