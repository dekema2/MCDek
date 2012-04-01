using System;
using System.Collections.Generic;
using MCDek;

namespace MCLawl
{
    public class CmdDrop : Command
    {
        public override string name { get { return "drop"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public CmdDrop() { }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Builder; } }

        public override void Use(Player p, string message)
        {
            if (message != "") { Help(p); return; }
            if (p.hasflag != null)
            {
                p.level.ctfgame.DropFlag(p, p.hasflag);
                return;
            }
            else
            {
                Player.SendMessage(p, "You are not carrying a flag.");
            }

        }

        public override void Help(Player p)
        {
            Player.SendMessage(p, "/drop - Drop the flag if you are carrying it.");
        }
    }
}
