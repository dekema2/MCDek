using System;
using System.Collections.Generic;
using System.Data;
//using MySql.Data.MySqlClient;
//using MySql.Data.Types;

namespace MCLawl
{
    public class CmdSend : Command
    {
        public override string name { get { return "send"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Builder; } }
        public CmdSend() { }

        public override void Use(Player p, string message)
        {
            if (message == "" || message.IndexOf(' ') == -1) { Help(p); return; }

            Player who = Player.Find(message.Split(' ')[0]);

            string whoTo;
            if (who != null) whoTo = who.name;
            else whoTo = message.Split(' ')[0];

            message = message.Substring(message.IndexOf(' ') + 1);

            //DB
            MySQL.executeQuery("CREATE TABLE if not exists `Inbox" + whoTo + "` (PlayerFrom CHAR(20), TimeSent DATETIME, Contents VARCHAR(255));");
            MySQL.executeQuery("INSERT INTO `Inbox" + whoTo + "` (PlayerFrom, TimeSent, Contents) VALUES ('" + p.name + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + message.Replace("'", "\\'") + "')");
            //DB

            Player.SendMessage(p, "Message sent to &5" + whoTo + ".");
            if (who != null) who.SendMessage("Message recieved from &5" + p.name + Server.DefaultColor + ".");
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/send [name] <message> - Sends <message> to [name].");
        }
    }
}