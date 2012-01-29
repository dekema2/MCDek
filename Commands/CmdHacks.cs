using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCLawl
{
    public class CmdHacks : Command
    {
        public override string name { get { return "hacks"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Banned; } }
        public CmdHacks() { }

        public override void Use(Player p, string message)
        {
            if (message != "") { Help(p); return; }
            p.Kick("Your IP has been backtraced + reported to FBI Cyber Crimes Unit.");

        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/hacks - HACK THE PLANET");
        }
    }

}
