using System;
using MCLawl;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace MCDek
{
    class CmdGriefPatrol : Command
    {
        public override string name { get { return "griefpatrol"; } }
        public override string shortcut { get { return "gp"; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Builder; } }
        public CmdGriefPatrol() { }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/griefpatrol - Takes you to a random " + MCLawl.Group.findPermInt(CommandOtherPerms.GetPerm(this)).name + " or lower and hides you from view!");
        }

        public override void Use(Player p, string message)
        {
            if (message != "")
            {
                Help(p);
                return;
            }
            if (p == null)
            {
                Player.SendMessage(p, "You can't use this command!");
                return;
            }
            List<string> getpatrol = (from pl in Player.players where (int)pl.@group.Permission <= CommandOtherPerms.GetPerm(this) select pl.name).ToList();
            if (getpatrol.Count <= 0)
            {
                Player.SendMessage(p, "Others must be online to use this command!");
                return;
            }
            Random random = new Random();
            int index = random.Next(getpatrol.Count);
            string value = getpatrol[index];
            Player who = Player.Find(value);
            Command.all.Find("tp").Use(p, who.name);
            Command.all.Find("hide").Use(p, message);
            Player.SendMessage(p, "You are now watching " + who.color + who.name + "!");
        }
    }
}