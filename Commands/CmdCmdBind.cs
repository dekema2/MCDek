using System;
using MCDek;

namespace MCLawl
{
    public class CmdCmdBind : Command
    {
        public override string name { get { return "cmdbind"; } }
        public override string shortcut { get { return "cb"; } }
        public override string type { get { return "build"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Builder; } }
        public CmdCmdBind() { }

        public override void Use(Player p, string message)
        {
            string foundcmd, foundmessage = ""; int foundnum = 0;

            if (message.IndexOf(' ') == -1)
            {
                bool OneFound = false;
                for (int i = 0; i < 10; i++)
                {
                    if (p.cmdBind[i] != null)
                    {
                        Player.SendMessage(p, "&c/" + i + Server.DefaultColor + " bound to &b" + p.cmdBind[i] + " " + p.messageBind[i]);
                        OneFound = true;
                    }
                }
                if (!OneFound) Player.SendMessage(p, "You have no commands binded");
                return;
            }

            if (message.Split(' ').Length == 1)
            {
                try
                {
                    foundnum = Convert.ToInt16(message);
                    if (p.cmdBind[foundnum] == null) { Player.SendMessage(p, "No command stored here yet."); return; }
                    foundcmd = "/" + p.cmdBind[foundnum] + " " + p.messageBind[foundnum];
                    Player.SendMessage(p, "Stored command: &b" + foundcmd);
                }
                catch { Help(p); }
            }
            else if (message.Split(' ').Length > 1)
            {
                try
                {
                    foundnum = Convert.ToInt16(message.Split(' ')[message.Split(' ').Length - 1]);
                    foundcmd = message.Split(' ')[0];
                    if (message.Split(' ').Length > 2)
                    {
                        foundmessage = message.Substring(message.IndexOf(' ') + 1);
                        foundmessage = foundmessage.Remove(foundmessage.LastIndexOf(' '));
                    }

                    p.cmdBind[foundnum] = foundcmd;
                    p.messageBind[foundnum] = foundmessage;

                    Player.SendMessage(p, "Binded &b/" + foundcmd + " " + foundmessage + " to &c/" + foundnum);
                }
                catch { Help(p); }
            }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/cmdbind [command] [num] - Binds [command] to [num]");
            Player.SendMessage(p, "[num] must be between 0 and 9");
            Player.SendMessage(p, "Use with \"/[num]\" &b(example: /2)");
            Player.SendMessage(p, "Use /cmdbind [num] to see stored commands.");
        }
    }
}