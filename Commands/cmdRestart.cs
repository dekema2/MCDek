using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MCLawl.Gui;

namespace MCLawl
{
    public class CmdRestart : Command
    {
        public override string name { get { return "restart"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Admin; } }
        public CmdRestart() { }

        public override void Use(Player p, string message)
        {
            if (message != "") { Help(p); return; }
            MCLawl_.Gui.Program.restartMe();
            //MCLawl_.Gui.Program.ExitProgram(true);
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/restart - Restarts the server!  Use carefully!");
        }
    }
}
