using System;

namespace MCLawl
{
    public class CmdLimit : Command
    {
        public override string name { get { return "limit"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Admin; } }
        public CmdLimit() { }

        public override void Use(Player p, string message)
        {
            if (message.Split(' ').Length != 2) { Help(p); return; }
            int newLimit;
            try { newLimit = int.Parse(message.Split(' ')[1]); }
            catch { Player.SendMessage(p, "Invalid limit amount"); return; }
            if (newLimit < 1) { Player.SendMessage(p, "Cannot set below 1."); return; }

            Group foundGroup = Group.Find(message.Split(' ')[0]);
            if (foundGroup != null)
            {
                foundGroup.maxBlocks = newLimit;
                Player.GlobalChat(null, foundGroup.color + foundGroup.name + Server.DefaultColor + "'s building limits were set to &b" + newLimit, false);
                Group.saveGroups(Group.GroupList);
            }
            else
            {
                switch (message.Split(' ')[0].ToLower())
                {
                    case "rp":
                    case "restartphysics":
                        Server.rpLimit = newLimit;
                        Player.GlobalMessage("Custom /rp's limit was changed to &b" + newLimit.ToString());
                        break;
                    case "rpnorm":
                    case "rpnormal":
                        Server.rpNormLimit = newLimit;
                        Player.GlobalMessage("Normal /rp's limit was changed to &b" + newLimit.ToString());
                        break;

                    default:
                        Player.SendMessage(p, "No supported /limit");
                        break;
                }
            }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/limit <type> <amount> - Sets the limit for <type>");
            Player.SendMessage(p, "<types> - " + Group.concatList(true, true) + ", RP, RPNormal");
        }
    }
}