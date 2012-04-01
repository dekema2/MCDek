using System;
using MCDek;

namespace MCLawl
{
    public class CmdGive : Command
    {
        public override string name { get { return "give"; } }
        public override string shortcut { get { return "gib"; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Admin; } }
        public CmdGive() { }

        public override void Use(Player p, string message)
        {
            if (message.IndexOf(' ') == -1) { Help(p); return; }
            if (message.Split(' ').Length != 2) { Help(p); return; }

            Player who = Player.Find(message.Split(' ')[0]);
            if (who == null) { Player.SendMessage(p, "Could not find player entered"); return; }
            if (who == p) { Player.SendMessage(p, "Sorry. Can't allow you to give " + Server.moneys + " to yourself"); return; }

            int amountGiven;
            try { amountGiven = int.Parse(message.Split(' ')[1]); }
            catch { Player.SendMessage(p, "Invalid amount"); return; }

            if (who.money + amountGiven > 16777215) { Player.SendMessage(p, "Players cannot have over 16777215 " + Server.moneys); return; }
            if (amountGiven < 0) { Player.SendMessage(p, "Cannot give someone negative " + Server.moneys); return; }

            who.money += amountGiven;
            Player.GlobalMessage(who.color + who.prefix + who.name + Server.DefaultColor + " was given " + amountGiven + " " + Server.moneys);
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/give [player] <amount> - Gives [player] <amount> " + Server.moneys);
        }
    }
}