using System;
using MCDek;

namespace MCLawl
{
    public class CmdUban : Command
    {

        public override string name { get { return "uban"; } }

        public override string shortcut { get { return ""; } }

        public override string type { get { return "mod"; } }

        public override bool museumUsable { get { return false; } }

        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }

        public CmdUban() { }
        public override void Use(Player p, string message)
        {
            if (message == "") { Help(p); return; }

            Player who = Player.Find(message.Split(' ')[0]);
            string msg = message.Split(' ')[0];
            if (p != null)
            {
                p.ignorePermission = true;
            }
            try
            {
                
                if (p == null)
                {
                    Command.all.Find("undo").Use(p, message);
                    Command.all.Find("ban").Use(p, message);
                    Command.all.Find("banip").Use(p, "@" + message);
                    Command.all.Find("kick").Use(p, message);
                    Command.all.Find("undo").Use(p, message);

                }
                else
                {
                    Command.all.Find("ban").Use(p, message);
                    Command.all.Find("banip").Use(p, "@" + message);
                    Command.all.Find("undo").Use(p, message);

                }

            }
            finally
            {
                if (p != null) p.ignorePermission = false;
            }



        }


        public override void Help(Player p)
        {
            Player.SendMessage(p, "/uban [name] [message]- Bans, undoes, and kicks [name] with a [message].");
        }
    }
}