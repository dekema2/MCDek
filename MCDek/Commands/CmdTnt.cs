using System;
using System.IO;

namespace MCLawl
{
    public class CmdTnt : Command
    {
        public override string name { get { return "tnt"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Builder; } }
        public CmdTnt() { }

        public override void Use(Player p, string message)
        {
            if (message.Split(' ').Length > 1) { Help(p); return; }

            if (p.BlockAction == 13 || p.BlockAction == 14)
            {
                p.BlockAction = 0; Player.SendMessage(p, "TNT mode is now &cOFF" + Server.DefaultColor + ".");
            }
            else if (message.ToLower() == "small" || message == "")
            {
                p.BlockAction = 13; Player.SendMessage(p, "TNT mode is now &aON" + Server.DefaultColor + ".");
            }
            else if (message.ToLower() == "big")
            {
                if (p.group.Permission > LevelPermission.AdvBuilder)
                {
                    p.BlockAction = 14; Player.SendMessage(p, "TNT mode is now &aON" + Server.DefaultColor + ".");
                }
                else
                {
                    Player.SendMessage(p, "This mode is reserved for OPs");
                }
            }
            else
            {
                Help(p);
            }

            p.painting = false;
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/tnt [small/big] - Creates exploding TNT (with Physics 3).");
            Player.SendMessage(p, "Big TNT is reserved for OP+.");
        }
    }
}