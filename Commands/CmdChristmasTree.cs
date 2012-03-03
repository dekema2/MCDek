//Copyright 2012 Ballock1 and dekema2 of MCDek-DekemaServ, Inc. http://www.dekemaserv.com

﻿using System;
using System.IO;
using System.Net;
using MCDek;


namespace MCDek
{
    public class CmdChristmasTree : Command
    {
        public override string name { get { return "christmastree"; } }
        public override string shortcut { get { return "ct"; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.AdvBuilder; } }
        public override void Use(Player p, string message)
        {
            if (p == null) { Player.SendMessage(p, "This command can only be used in-game!"); return; }
            if (!Directory.Exists("extra/copy"))
                Directory.CreateDirectory("extra/copy");

            if (!File.Exists("extra/copy/christmastree.copy"))
            {
                Player.SendMessage(p, "ChristmasTree copy doesn't exist. Downloading...");
                try
                {
                    using (WebClient WEB = new WebClient())
                        WEB.DownloadFile("http://dl.dropbox.com/u/60701738/MCDek/xmas.cpy", "extra/copy/christmastree.copy");
                }
                catch
                {
                    Player.SendMessage(p, "Sorry, downloading failed. Please try again later.");
                    return;
                }
            }
            Command.all.Find("retrieve").Use(p, "christmastree");
            Command.all.Find("paste").Use(p, "");
            ushort[] loc = p.getLoc(false);
            Command.all.Find("click").Use(p, loc[0] + " " + loc[1] + " " + loc[2]);
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/christmastree - places a christmastree at your location!");
        }
    }
}