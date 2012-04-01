/*
   Copyright 2010 MCSharp team (Modified for use with MCZall/MCLawl) Licensed under the
   Educational Community License, Version 2.0 (the "License"); you may
   not use this file except in compliance with the License. You may
   obtain a copy of the License at
   
   http://www.osedu.org/licenses/ECL-2.0
   
   Unless required by applicable law or agreed to in writing,
   software distributed under the License is distributed on an "AS IS"
   BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
   or implied. See the License for the specific language governing
   permissions and limitations under the License.
*/
using System;
//using MySql.Data.MySqlClient;
//using MySql.Data.Types;
using MCDek;
namespace MCLawl
{
    public class CmdColor : Command
    {
        public override string name { get { return "color"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public CmdColor() { }

        public override void Use(Player p, string message)
        {
            if (message == "" || message.Split(' ').Length > 2) { Help(p); return; }
            int pos = message.IndexOf(' ');
            if (pos != -1)
            {
                Player who = Player.Find(message.Substring(0, pos));
                if (who == null) { Player.SendMessage(p, "There is no player \"" + message.Substring(0, pos) + "\"!"); return; }
                if (message.Substring(pos + 1) == "del")
                {
                    MySQL.executeQuery("UPDATE Players SET color = '' WHERE name = '" + who.name + "'");
                    Player.GlobalChat(who, who.color + "*" + Name(who.name) + " color reverted to " + who.group.color + "their group's default" + Server.DefaultColor + ".", false);
                    who.color = who.group.color;

                    Player.GlobalDie(who, false);
                    Player.GlobalSpawn(who, who.pos[0], who.pos[1], who.pos[2], who.rot[0], who.rot[1], false);
                    who.SetPrefix();
                    return;
                }
                string color = c.Parse(message.Substring(pos + 1));
                if (color == "") { Player.SendMessage(p, "There is no color \"" + message + "\"."); }
                else if (color == who.color) { Player.SendMessage(p, who.name + " already has that color."); }
                else
                {
                    //Player.GlobalChat(who, p.color + "*" + p.name + "&e changed " + who.color + Name(who.name) +
                    //                  " color to " + color +
                    //                  c.Name(color) + "&e.", false);
                    MySQL.executeQuery("UPDATE Players SET color = '" + c.Name(color) + "' WHERE name = '" + who.name + "'");

                    Player.GlobalChat(who, who.color + "*" + Name(who.name) + " color changed to " + color + c.Name(color) + Server.DefaultColor + ".", false);
                    who.color = color;

                    Player.GlobalDie(who, false);
                    Player.GlobalSpawn(who, who.pos[0], who.pos[1], who.pos[2], who.rot[0], who.rot[1], false);
                    who.SetPrefix();
                }
            }
            else
            {
                if (message == "del")
                {
                    MySQL.executeQuery("UPDATE Players SET color = '' WHERE name = '" + p.name + "'");

                    Player.GlobalChat(p, p.color + "*" + Name(p.name) + " color reverted to " + p.group.color + "their group's default" + Server.DefaultColor + ".", false);
                    p.color = p.group.color;

                    Player.GlobalDie(p, false);
                    Player.GlobalSpawn(p, p.pos[0], p.pos[1], p.pos[2], p.rot[0], p.rot[1], false);
                    p.SetPrefix();
                    return;
                }
                string color = c.Parse(message);
                if (color == "") { Player.SendMessage(p, "There is no color \"" + message + "\"."); }
                else if (color == p.color) { Player.SendMessage(p, "You already have that color."); }
                else
                {
                    MySQL.executeQuery("UPDATE Players SET color = '" + c.Name(color) + "' WHERE name = '" + p.name + "'");

                    Player.GlobalChat(p, p.color + "*" + Name(p.name) + " color changed to " + color + c.Name(color) + Server.DefaultColor + ".", false);
                    p.color = color;

                    Player.GlobalDie(p, false);
                    Player.GlobalSpawn(p, p.pos[0], p.pos[1], p.pos[2], p.rot[0], p.rot[1], false);
                    p.SetPrefix();
                }
            }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/color [player] <color/del>- Changes the nick color.  Using 'del' removes color.");
            Player.SendMessage(p, "&0black &1navy &2green &3teal &4maroon &5purple &6gold &7silver");
            Player.SendMessage(p, "&8gray &9blue &alime &baqua &cred &dpink &eyellow &fwhite");
        }
        static string Name(string name)
        {
            string ch = name[name.Length - 1].ToString().ToLower();
            if (ch == "s" || ch == "x") { return name + Server.DefaultColor + "'"; }
            else { return name + Server.DefaultColor + "'s"; }
        }
    }
}