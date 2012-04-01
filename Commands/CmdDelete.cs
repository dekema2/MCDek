using System;
using System.Collections.Generic;
using MCDek;
namespace MCLawl
{
    public class CmdDelete : Command
    {
        public override string name { get { return "delete"; } }
        public override string shortcut { get { return "d"; } }
        public override string type { get { return "build"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.AdvBuilder; } }
        public CmdDelete() { }

        public override void Use(Player p, string message)
        {
            if (message != "") { Help(p); return; }

            p.deleteMode = !p.deleteMode;
            Player.SendMessage(p, "Delete mode: &a" + p.deleteMode);
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/delete - Deletes any block you click");
            Player.SendMessage(p, "\"any block\" meaning door_air, portals, mb's, etc");
        }
    }
}