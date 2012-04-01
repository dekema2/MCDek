using System;
using System.IO;
using MCDek;
namespace MCLawl
{
    public class CmdInvincible : Command
    {
        public override string name { get { return "invincible"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public CmdInvincible() { }

        public override void Use(Player p, string message)
        {
            Player who;
            if (message != "")
            {
                who = Player.Find(message);
            }
            else
            {
                who = p;
            }

            if (who == null)
            {
                Player.SendMessage(p, "Cannot find player.");
                return;
            }

            if (who.group.Permission > p.group.Permission)
            {
                Player.SendMessage(p, "Cannot toggle invincibility for someone of higher rank");
                return;
            }

            if (who.invincible == true)
            {
                who.invincible = false;
                if (Server.cheapMessage)
                    Player.GlobalChat(p, who.color + who.name + Server.DefaultColor + " has stopped being immortal", false);
            }
            else
            {
                who.invincible = true;
                if (Server.cheapMessage)
                    Player.GlobalChat(p, who.color + who.name + Server.DefaultColor + " " + Server.cheapMessageGiven, false);
            }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/invincible [name] - Turns invincible mode on/off.");
            Player.SendMessage(p, "If [name] is given, that player's invincibility is toggled");
        }
    }
}