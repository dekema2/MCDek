using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;

namespace MCLawl
{
    public class CmdImport : Command
    {
        public override string name { get { return "import"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public CmdImport() { }

        public override void Use(Player p, string message)
        {
            if (message == "") { Help(p); return; }
            string fileName;
            fileName = "extra/import/" + message + ".dat";

            if (!Directory.Exists("extra/import")) Directory.CreateDirectory("extra/import");
            if (!File.Exists(fileName))
            {
                Player.SendMessage(p, "Could not find .dat file");
                return;
            }
            
            FileStream fs = File.OpenRead(fileName);
            if (ConvertDat.Load(fs, message) != null)
            {
                Player.SendMessage(p, "Converted map!");
            }
            else
            {
                Player.SendMessage(p, "The map conversion failed.");
                return;
            }
            fs.Close();

            Command.all.Find("load").Use(p, message);
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/import [.dat file] - Imports the .dat file given");
            Player.SendMessage(p, ".dat files should be located in the /extra/import/ folder");
        }
    }
}