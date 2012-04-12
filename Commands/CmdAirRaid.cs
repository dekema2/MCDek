using System;
using MCDek;
// This still needs a ton of work

namespace MCLawl
{
    class CmdAirRaid : Command
    {        
        public override string name { get { return "airraid"; } }
        public override string shortcut { get { return "ar"; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public CmdAirRaid() { }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/airraid - Drops tnt on your city then brings in killer bots :)");

        }
        public override void Use(Player p, string message)
        {
                        if (p != null)
            {
                    Command.all.Find("detonate").Use(p, message + p.pos[0]*2 + p.pos[1] + p.pos[2]*2);
                    Command.all.Find("detonate").Use(p, message + p.pos[0] * 2 + p.pos[1] + p.pos[2] * 4);
                    Command.all.Find("detonate").Use(p, message + p.pos[0] * 4 + p.pos[1] + p.pos[2] * 2);
                    Command.all.Find("detonate").Use(p, message + p.pos[0] * 4 + p.pos[1] + p.pos[2] * 4);
                    Command.all.Find("detonate").Use(p, message + p.pos[0] * 6 + p.pos[1] + p.pos[2] * 4);
                    Command.all.Find("detonate").Use(p, message + p.pos[0] * 4 + p.pos[1] + p.pos[2] * 6);
                    Command.all.Find("detonate").Use(p, message + p.pos[0] * 6 + p.pos[1] + p.pos[2] * 6);
                    Command.all.Find("detonate").Use(p, message + p.pos[0] * 6 + p.pos[1] + p.pos[2] * 2);
                    Command.all.Find("detonate").Use(p, message + p.pos[0] * 2 + p.pos[1] + p.pos[2] * 6);
                    Command.all.Find("botai").Use(p, message + "add Steve");
                    Command.all.Find("botai").Use(p, message + "add Steve1");
                    Command.all.Find("botai").Use(p, message + "add Steve2");
                    Command.all.Find("botai").Use(p, message + "add Steve3");
                    Command.all.Find("botai").Use(p, message + "add Steve4");
                    Command.all.Find("botai").Use(p, message + "add Steve5");
                    Command.all.Find("botadd").Use(p, message + "Steve");
                    Command.all.Find("botadd").Use(p, message + "Steve1");
                    Command.all.Find("botadd").Use(p, message + "Steve2");
                    Command.all.Find("botadd").Use(p, message + "Steve3");
                    Command.all.Find("botadd").Use(p, message + "Steve4");
                    Command.all.Find("botadd").Use(p, message + "Steve5");
                    Command.all.Find("botset").Use(p, message + "Steve1 hunt");
                    Command.all.Find("botset").Use(p, message + "Steve1 kill");
                    Command.all.Find("botset").Use(p, message + "Steve2 hunt");
                    Command.all.Find("botset").Use(p, message + "Steve2 kill");
                    Command.all.Find("botset").Use(p, message + "Steve3 hunt");
                    Command.all.Find("botset").Use(p, message + "Steve3 kill");
                    Command.all.Find("botset").Use(p, message + "Steve4 hunt");
                    Command.all.Find("botset").Use(p, message + "Steve4 kill");
                    Command.all.Find("botset").Use(p, message + "Steve5 hunt");
                    Command.all.Find("botset").Use(p, message + "Steve5 kill");

            }
        }
    }
}
