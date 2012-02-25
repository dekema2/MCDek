using System;


namespace MCDek
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

            if (p != null)
            {
                p.ignorePermission = true;
            }
            try
            {
                if (who != null)
                {
                    Command.all.Find("undo").Use(p, msg);
                    Command.all.Find("ban").Use(p, msg);
                    Command.all.Find("banip").Use(p, "@" + msg);
                    Command.all.Find("kick").Use(p, message);
                    Command.all.Find("undo").Use(p, msg);

                }
                else
                {
                    Command.all.Find("ban").Use(p, msg);
                    Command.all.Find("banip").Use(p, "@" + msg);
                    Command.all.Find("undo").Use(p, msg);

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