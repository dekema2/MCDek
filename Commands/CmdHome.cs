//Copyright 2012 MCDek-DekemaServ, Created by ballock1; 

﻿using System;


namespace MCDek
{
    public class CmdHome : Command
    {

        public override string name { get { return "home"; } }

        public override string shortcut { get { return ""; } }

        public override string type { get { return "other"; } }

        public override bool museumUsable { get { return false; } }

        public override LevelPermission defaultRank { get { return LevelPermission.Builder; } }

        public CmdHome() { }
        public override void Use(Player p, string message)
        {
            if (p != null)
            {
                    Command.all.Find("time").Use(p, msg);
                    Command.all.Find("inbox").Use(p, msg);
                    Command.all.Find("who").Use(p, message);
                    
            }
        }


        public override void Help(Player p)
        {
            Player.SendMessage(p, "/home - Tells you time, checks your inbox, who is online, and more.");
        }
    }
}
