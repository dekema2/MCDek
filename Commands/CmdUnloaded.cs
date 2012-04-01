using System;
using System.IO;
using System.Collections.Generic;
using MCDek;

namespace MCLawl
{
    public class CmdUnloaded : Command
    {
        public override string name { get { return "unloaded"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "information"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }
        public CmdUnloaded() { }

        public override void Use(Player p, string message)
        {
            try
            {
                List<string> levels = new List<string>(Server.levels.Count);

                string unloadedLevels = ""; int currentNum = 0; int maxMaps = 0;

                if (message != "")
                {
                    try { maxMaps = int.Parse(message) * 50; currentNum = maxMaps - 50; }
                    catch { Help(p); return; }
                }

                DirectoryInfo di = new DirectoryInfo("levels/");
                FileInfo[] fi = di.GetFiles("*.lvl");
                foreach (Level l in Server.levels) { levels.Add(l.name.ToLower()); }

                if (maxMaps == 0)
                {
                    foreach (FileInfo file in fi)
                    {
                        if (!levels.Contains(file.Name.Replace(".lvl", "").ToLower()))
                        {
                            unloadedLevels += ", " + file.Name.Replace(".lvl", "");
                        }
                    }
                    if (unloadedLevels != "")
                    {
                        Player.SendMessage(p, "Unloaded levels: ");
                        Player.SendMessage(p, "&4" + unloadedLevels.Remove(0, 2));
                        if (fi.Length > 50) { Player.SendMessage(p, "For a more structured list, use /unloaded <1/2/3/..>"); }
                    }
                    else Player.SendMessage(p, "No maps are unloaded");
                }
                else
                {
                    if (maxMaps > fi.Length) maxMaps = fi.Length;
                    if (currentNum > fi.Length) { Player.SendMessage(p, "No maps beyond number " + fi.Length); return; }

                    Player.SendMessage(p, "Unloaded levels (" + currentNum + " to " + maxMaps + "):");
                    for (int i = currentNum; i < maxMaps; i++)
                    {
                        if (!levels.Contains(fi[i].Name.Replace(".lvl", "").ToLower()))
                        {
                            unloadedLevels += ", " + fi[i].Name.Replace(".lvl", "");
                        }
                    }

                    if (unloadedLevels != "")
                    {
                        Player.SendMessage(p, "&4" + unloadedLevels.Remove(0, 2));
                    }
                    else Player.SendMessage(p, "No maps are unloaded");
                }
            }
            catch (Exception e) { Server.ErrorLog(e); Player.SendMessage(p, "An error occured"); }
            //Exception catching since it needs to be tested on Ocean Flatgrass
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/unloaded - Lists all unloaded levels.");
            Player.SendMessage(p, "/unloaded <1/2/3/..> - Shows a compact list.");
        }
    }
}