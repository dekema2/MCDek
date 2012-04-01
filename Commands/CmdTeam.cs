using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MCDek;
namespace MCLawl
{
    public class CmdTeam : Command
    {
        public override string name { get { return "team"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public CmdTeam() { }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Builder; } }
        public override void Use(Player p, string message)
        {
            if (!p.level.ctfmode)
            {
                Player.SendMessage(p, "CTF has not been enabled for this map.");
                return;
            }
            if (message.Split(' ')[0].ToLower() == "set")
            {
                if (p.group.Permission >= LevelPermission.Operator)
                {
                    string name = message.Split(' ')[1].ToLower();
                    string team = message.Split(' ')[2].ToLower();
                    if (team == "none")
                    {
                        Player pl = Player.Find(name);
                        if (pl == null || pl.level != p.level) { Player.SendMessage(p, "That player does not exist or is not on your level."); }
                        if (pl.team == null) { Player.SendMessage(p, "That player is not on a team."); }
                        pl.team.RemoveMember(pl);
                        return;
                    }
                    string color = c.Parse(team);
                    if (color == "") { Player.SendMessage(p, "Invalid team color chosen."); return; }
                    Player who = Player.Find(name);
                    if (who == null || who.level != p.level) { Player.SendMessage(p, "That player does not exist or is not on your level."); }
                    char teamCol = (char)color[1];
                    if (p.level.ctfgame.teams.Find(team1 => team1.color == teamCol) == null){Player.SendMessage(p, "Invalid team color chosen."); return;}
                    Team workTeam = p.level.ctfgame.teams.Find(team1 => team1.color == teamCol);
                    if (who.team != null) { who.team.RemoveMember(who);}
                    workTeam.AddMember(who);
                }
            }
            if (message.Split(' ')[0].ToLower() == "join")
            {
                string color = c.Parse(message.Split(' ')[1]);
                if (color == "") { Player.SendMessage(p, "Invalid team color chosen."); return; }
                char teamCol = (char)color[1];
                if (p.level.ctfgame.teams.Find(team => team.color == teamCol) == null) { Player.SendMessage(p, "Invalid team color chosen."); return; }
                Team workTeam = p.level.ctfgame.teams.Find(team => team.color == teamCol);
                if (p.team != null) { p.team.RemoveMember(p); }
                workTeam.AddMember(p);
            }
            else if (message.Split(' ')[0].ToLower() == "leave")
            {
                if (p.team != null)
                {
                    p.team.RemoveMember(p);
                }
                else
                {
                    Player.SendMessage(p, "You are not on a team.");
                    return;
                }
            }
            else if (message.Split(' ')[0].ToLower() == "chat")
            {
                if (p.team == null) { Player.SendMessage(p, "You must be on a team before you can use team chat."); return; }
                p.teamchat = !p.teamchat;
                if (p.teamchat)
                {
                    Player.SendMessage(p, "Team chat has been enabled.");
                    return;
                }
                else
                {
                    Player.SendMessage(p, "Team chat has been disabled.");
                    return;
                }

            }
            else if (message.Split(' ')[0].ToLower() == "scores")
            {
                foreach (Team t in p.level.ctfgame.teams)
                {
                    Player.SendMessage(p, t.teamstring + " has " + t.points + " point(s).");
                }
            }

        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/team join [color] - Joins the team specified by the color.");
            Player.SendMessage(p, "/team leave - Leaves the team you are on.");
            Player.SendMessage(p, "/team set [name] [color] - Op+ - Sets a player to a specified team.");
            Player.SendMessage(p, "/team set [name] none - Op+ - Removes a player from a team.");
            Player.SendMessage(p, "/team scores - Shows the current scores for all teams.");
        }
    }
}
