using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using MCDek;
//using MySql.Data.MySqlClient;
//using MySql.Data.Types;

namespace MCLawl
{
    public class CmdDeleteLvl : Command
    {
        public override string name { get { return "deletelvl"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Admin; } }
        public CmdDeleteLvl() { }

        public override void Use(Player p, string message)
        {
            if (message == "") { Help(p); return; }
            Level foundLevel = Level.Find(message);
            if (foundLevel != null) foundLevel.Unload();

            if (foundLevel == Server.mainLevel) { Player.SendMessage(p, "Cannot delete the main level."); return; }

            try
            {
                if (!Directory.Exists("levels/deleted")) Directory.CreateDirectory("levels/deleted");

                if (File.Exists("levels/" + message + ".lvl"))
                {
                    if (File.Exists("levels/deleted/" + message + ".lvl"))
                    {
                        int currentNum = 0;
                        while (File.Exists("levels/deleted/" + message + currentNum + ".lvl")) currentNum++;

                        File.Move("levels/" + message + ".lvl", "levels/deleted/" + message + currentNum + ".lvl");
                    }
                    else
                    {
                        File.Move("levels/" + message + ".lvl", "levels/deleted/" + message + ".lvl");
                    }
                    Player.SendMessage(p, "Created backup.");

                    try { File.Delete("levels/level properties/" + message + ".properties"); }
                    catch { }
                    try { File.Delete("levels/level properties/" + message); }
                    catch { }

                    MySQL.executeQuery("DROP TABLE `Block" + message + "`, `Portals" + message + "`, `Messages" + message + "`, `Zone" + message + "`");

                    Player.GlobalMessage("Level " + message + " was deleted.");
                }
                else
                {
                    Player.SendMessage(p, "Could not find specified level.");
                }
            }
            catch (Exception e) { Player.SendMessage(p, "Error when deleting."); Server.ErrorLog(e); }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/deletelvl [map] - Completely deletes [map] (portals, MBs, everything");
            Player.SendMessage(p, "A backup of the map will be placed in the levels/deleted folder");
        }
    }
}