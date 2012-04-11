//Copyrights go to ballock1 of MCDek.
using System;
using MCLawl;

namespace MCDek
{
    public class CmdRob : Command
    {
        public override string name { get { return "rob"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }
        public CmdRob() { }
        public override void Use(Player p, string message)
        {

            if (message.IndexOf(' ') == -1) { Help(p); return; }
            if (message.Split(' ').Length != 2) { Help(p); return; }

            Player who = Player.Find(message.Split(' ')[0]);
            if (who == null) { Player.SendMessage(p, "Could not find player specified"); return; }
            if (who == p) { Player.SendMessage(p, "Sorry. You cant rob yourself"); return; }
            if (p.group.Permission < who.group.Permission) { p.SendMessage("You cannot rob your superiors!"); return; }
            else
            {
                int rob2;
                try { rob2 = int.Parse(message.Split(' ')[1]);}
                catch { Player.SendMessage(p, "Invalid amount"); return; }
                if (p.money + rob2 > 16777215) { p.SendMessage("You cant steal that much You cannot have over 16777215 " + Server.moneys + "."); return; }
                Random RandomNumber = new Random();
                int rob1 = RandomNumber.Next(0, rob2);
                if (who.money < rob2) { Player.SendMessage(p, who.color + who.name + "doesnt have" + rob2 + Server.moneys); return; }
                if (rob2 < 150) { p.SendMessage("You cannot steal less than 150 " + Server.moneys + "."); return; }
                if (rob1 <= 25)
                {
                    Player.SendMessage(p, "%3You stole %a" + rob2 + Server.moneys + "from" + who.color + who.name);
                    p.money = p.money + rob2;
                    who.money = who.money - rob2; 
                }
                if (rob1 > 25)
                {
                    Player.SendMessage(p, "%cYou have failed, you have been fined you paid bail" + " %4-" + rob2 + "and were kicked");
                    p.money = p.money - (rob2);
                    if (p.money < 1) { p.money = 0; }
                    p.Kick("You tried to rob someone but failed!");

                }
            }
        }

        public override void Help(Player p)
        {
            Player.SendMessage(p, "/rob - Trying to rob someone of there hard earned money.");
        }
    }
}