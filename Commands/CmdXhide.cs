using System;
using System.IO;
using MCLawl;


namespace MCDek
{
    public class CmdXhide : Command
    {
        public override string name { get { return "xhide"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Admin; } }

        public override void Use(Player p, string message)
        {
            if (p == null) { Player.SendMessage(p, "This command can only be used in-game!"); return; }
            if (message != "") { Help(p); return; }
            if (p.possess != "")
            {
                Player.SendMessage(p, "Stop your current possession first.");
                return;
            }
            p.hidden = !p.hidden;
            if (p.hidden)
            {
                Player.GlobalDie(p, true);
                Player.GlobalChat(p, "&c- " + p.color + p.prefix + p.name + Server.DefaultColor + " " + (File.Exists("text/logout/" + p.name + ".txt") ? File.ReadAllText("text/logout/" + p.name + ".txt") : "Disconnected."), false);

            }
            else
            {
                Player.GlobalSpawn(p, p.pos[0], p.pos[1], p.pos[2], p.rot[0], p.rot[1], false, "");
                Player.GlobalChat(p, "&a+ " + p.color + p.prefix + p.name + Server.DefaultColor + " " + (File.Exists("text/login/" + p.name + ".txt") ? File.ReadAllText("text/login/" + p.name + ".txt") : "joined the game."), false);
            }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/xhide - /hide only without that stupid message.");
        }
    }
}