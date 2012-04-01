using System;
using System.IO;
using System.Net;
using MCDek;


namespace MCLawl
{
    public class CmdFastHouse : Command
    {
        public override string name { get { return "fasthouse"; } }
        public override string shortcut { get { return "fh"; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.AdvBuilder; } }
        public override void Use(Player p, string message)
        {
            if (p == null) { Player.SendMessage(p, "This command can only be used in-game!"); return; }
            if (!Directory.Exists("extra/copy"))
                Directory.CreateDirectory("extra/copy");

            if (!File.Exists("extra/copy/house.copy"))
            {
                Player.SendMessage(p, "FastHouse copy doesn't exist. Downloading...");
                try
                {
                    using (WebClient WEB = new WebClient())
                        WEB.DownloadFile("http://dekemaserv.com/house.copy", "extra/copy/house.copy");
                }
                catch
                {
                    Player.SendMessage(p, "Sorry, downloading failed. Please try again later.");
                    return;
                }
            }
            Command.all.Find("retrieve").Use(p, "fasthouse");
            Command.all.Find("paste").Use(p, "");
            ushort[] loc = p.getLoc(false);
            Command.all.Find("click").Use(p, loc[0] + " " + loc[1] + " " + loc[2]);
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/fasthouse - places a premade house at your location!");
        }
    }
}
