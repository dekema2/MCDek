using System;
using System.IO;
using MCDek;

namespace MCLawl
{
    public class CmdMine : Command
    {
        public override string name { get { return "tnt"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Builder; } }
        public CmdMine() { }

        public override void Use(Player p, string message)
        {
            if (p.BlockAction == 15)
            {
                p.BlockAction = 0; Player.SendMessage(p, "Mine mode is now &cOFF" + Server.DefaultColor + ".");
            }
            else
            {
                p.BlockAction = 15; Player.SendMessage(p, "TNT mode is now &aON" + Server.DefaultColor + ".");
            }

        
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/mine - Creates exploding claymore (with Physics 3).");
            Player.SendMessage(p, "Activates when Player passes through it");
        }
    }
}