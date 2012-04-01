using System;
using System.Data;
using MCDek;
//using MySql.Data.MySqlClient;
//using MySql.Data.Types;

namespace MCLawl
{
    public class CmdClearBlockChanges : Command
    {
        public override string name { get { return "clearblockchanges"; } }
        public override string shortcut { get { return "cbc"; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Admin; } }
        public CmdClearBlockChanges() { }

        public override void Use(Player p, string message)
        {
            Level l = Level.Find(message);
            if (l == null && message != "") { Player.SendMessage(p, "Could not find level."); return; }
            if (l == null) l = p.level;

            MySQL.executeQuery("TRUNCATE TABLE `Block" + l.name + "`");
            Player.SendMessage(p, "Cleared &cALL" + Server.DefaultColor + " recorded block changes in: &d" + l.name);
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/clearblockchanges <map> - Clears the block changes stored in /about for <map>.");
            Player.SendMessage(p, "&cUSE WITH CAUTION");
        }
    }
}