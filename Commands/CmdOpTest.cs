using System;
using System.Threading;
using System.Diagnostics;
using MCLawl;

namespace MCDek
{
    public class CmdOpTest : Command
    {
        public static bool testing = false;
        public bool voted;
        public override string name { get { return "optest"; } }
        public override string shortcut { get { return "opt"; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public CmdOpTest() { }

        public override void Use(Player p, string message)
        {

            if (message == "")
            {
                Help(p);
            }
            if (message == "stop")
            {
                Player.SendMessage(p, c.red + "You just quit your test.  It will still show test, but voting is disabled."); Server.voting = false; return;
            }

            if (p == null)
            { Player.SendMessage(p, "You can't take the optest in console."); return; }

            if (message == "start")
            {
                //Cmdoptest.testing = true;
                // int truevotes = 0;
                // int falsevotes = 0;
                int correct = 0;
                int wrong = 0;

                if (!Server.voting)
                {
                    Server.restarting = true;
                    Server.voting = true;
                    Server.NoVotes = 0;
                    Server.YesVotes = 0;
                    Player.SendMessage(p, c.yellow + "Your Optest has just started, now please answer the questions with y or n and enter.  This is also a timed test, so be expected to answer quickly as possible. ");
                    System.Threading.Thread.Sleep(3000);
                    Player.SendMessage(p, c.red + "Your first question: " + c.green + "If you see someone 'griefing' the server, you are supposed to immediatly harass them and then leave them alone." + Server.DefaultColor + "(" + c.green + "Yes " + Server.DefaultColor + "/" + c.red + "No" + Server.DefaultColor + ")");
                    System.Threading.Thread.Sleep(15000);

                    Player.SendMessage(p, c.maroon + "Question about to end........");
                    Thread.Sleep(1000);
                    int time = 5;
                    while (time != 0)
                    {
                        Player.SendMessage(p, c.maroon + "Finishing question" + Server.DefaultColor + " in %2" + time);
                        time--;
                        Thread.Sleep(1000);

                    }

                    Server.voting = false;

                    //  Player.SendMessage(p, "The vote is in! " + c.green + "Y: " + Server.YesVotes + c.red + " N: " + Server.NoVotes);
                    Player.players.ForEach(delegate(Player winners)
                    {
                        winners.voted = false;
                    }
                    );
                    if (Server.YesVotes >= 1)
                    {
                        Player.SendMessage(p, c.red + "Your answer is Incorrect.");
                        wrong = wrong + 1;

                    }
                    //int c1 = 0;
                    if (Server.NoVotes >= 1)
                    {
                        Player.SendMessage(p, c.lime + "Your answer is Correct."); correct = correct + 1;
                    }
                    if (Server.YesVotes < 1 && Server.NoVotes < 1)
                    { Player.SendMessage(p, c.maroon + "You never answered, so your answer is incorrect."); wrong = wrong + 1; }
                }
                else
                {
                    Player.SendMessage(p, "A person is already taking an Optest. Please wait for player to finish.");
                }
                if (!Server.voting)
                {
                    Server.restarting = true;
                    Server.voting = true;
                    Server.NoVotes = 0;
                    Server.YesVotes = 0;
                    Player.SendMessage(p, c.red + "Second question: " + c.green + "When you see a person abusing or being mean to a player, do you do nothing and watch (yes), or tell a higher ranked person to do something (no)?");
                    System.Threading.Thread.Sleep(15000);

                    Player.SendMessage(p, c.maroon + "Question about to end........");
                    Thread.Sleep(1000);
                    int time = 5;
                    while (time != 0)
                    {
                        Player.SendMessage(p, c.maroon + "Finishing question" + Server.DefaultColor + " in %2" + time);
                        time--;
                        Thread.Sleep(1000);
                    }

                    Server.voting = false;
                    Player.players.ForEach(delegate(Player winners)
                    {
                        winners.voted = false;
                    }
                    );
                    if (Server.YesVotes >= 1)
                    {
                        Player.SendMessage(p, c.red + "Your answer is Incorrect."); wrong = wrong + 1;
                    }

                    if (Server.NoVotes >= 1)
                    { Player.SendMessage(p, c.lime + "Your answer is Correct."); correct = correct + 1; }
                    if (Server.YesVotes < 1 && Server.NoVotes < 1)
                    { Player.SendMessage(p, c.maroon + "You never answered, so your answer is incorrect."); wrong = wrong + 1; }



                }
                else
                {
                    Player.SendMessage(p, "A person is already taking an Optest. Please wait for player to finish.");
                }
                if (!Server.voting)
                {
                    Server.restarting = true;
                    Server.voting = true;
                    Server.NoVotes = 0;
                    Server.YesVotes = 0;
                    Player.SendMessage(p, c.red + "Third question: " + c.green + "Spleef is a game where people compete to shoot each other with a 'spleefgun'." + Server.DefaultColor + "(" + c.green + "Yes " + Server.DefaultColor + "/" + c.red + "No" + Server.DefaultColor + ")");
                    System.Threading.Thread.Sleep(15000);

                    Player.SendMessage(p, c.maroon + "Question about to end........");
                    Thread.Sleep(1000);
                    int time = 5;
                    while (time != 0)
                    {
                        Player.SendMessage(p, c.maroon + "Finishing question" + Server.DefaultColor + " in %2" + time);
                        time--;
                        Thread.Sleep(1000);
                    }

                    Server.voting = false;
                    Player.players.ForEach(delegate(Player winners)
                    {
                        winners.voted = false;
                    }
                    );
                    if (Server.YesVotes >= 1)
                    {
                        Player.SendMessage(p, c.red + "Your answer is Incorrect."); wrong = wrong + 1;
                    }

                    if (Server.NoVotes >= 1)
                    { Player.SendMessage(p, c.lime + "Your answer is Correct."); correct = correct + 1; }
                    if (Server.YesVotes < 1 && Server.NoVotes < 1)
                    { Player.SendMessage(p, c.maroon + "You never answered, so your answer is incorrect."); wrong = wrong + 1; }



                }
                else
                {
                    Player.SendMessage(p, "A person is already taking an Optest. Please wait for player to finish.");
                }
                if (!Server.voting)
                {
                    Server.restarting = true;
                    Server.voting = true;
                    Server.NoVotes = 0;
                    Server.YesVotes = 0;
                    Player.SendMessage(p, c.red + "Forth question: " + c.green + "To build faster, players are allowed to use a command called 'cuboid' by clicking 2 points on a map." + Server.DefaultColor + "(" + c.green + "Yes " + Server.DefaultColor + "/" + c.red + "No" + Server.DefaultColor + ")");
                    System.Threading.Thread.Sleep(15000);

                    Player.SendMessage(p, c.maroon + "Question about to end........");
                    Thread.Sleep(1000);
                    int time = 5;
                    while (time != 0)
                    {
                        Player.SendMessage(p, c.maroon + "Finishing question" + Server.DefaultColor + " in %2" + time);
                        time--;
                        Thread.Sleep(1000);
                    }

                    Server.voting = false;
                    Player.players.ForEach(delegate(Player winners)
                    {
                        winners.voted = false;
                    }
                    );
                    if (Server.YesVotes >= 1)
                    {
                        Player.SendMessage(p, c.lime + "Your answer is Correct."); correct = correct + 1;
                    }

                    if (Server.NoVotes >= 1)
                    { Player.SendMessage(p, c.red + "Your answer is Incorrect."); wrong = wrong + 1; }
                    if (Server.YesVotes < 1 && Server.NoVotes < 1)
                    { Player.SendMessage(p, c.maroon + "You never answered, so your answer is incorrect."); wrong = wrong + 1; }



                }
                else
                {
                    Player.SendMessage(p, "A person is already taking an Optest. Please wait for player to finish.");
                }
                if (!Server.voting)
                {
                    Server.restarting = true;
                    Server.voting = true;
                    Server.NoVotes = 0;
                    Server.YesVotes = 0;
                    Player.SendMessage(p, c.red + "Fifth question: " + c.green + "If you see somone who is spamming the chat, the best thing to do is '/warn' them or tell someone with greater power to ask them to stop." + Server.DefaultColor + "(" + c.green + "Yes " + Server.DefaultColor + "/" + c.red + "No" + Server.DefaultColor + ")");
                    System.Threading.Thread.Sleep(15000);

                    Player.SendMessage(p, c.maroon + "Question about to end........");
                    Thread.Sleep(1000);
                    int time = 5;
                    while (time != 0)
                    {
                        Player.SendMessage(p, c.maroon + "Finishing question" + Server.DefaultColor + " in %2" + time);
                        time--;
                        Thread.Sleep(1000);
                    }

                    Server.voting = false;
                    Player.players.ForEach(delegate(Player winners)
                    {
                        winners.voted = false;
                    }
                    );
                    if (Server.YesVotes >= 1)
                    {
                        Player.SendMessage(p, c.lime + "Your answer is Correct."); correct = correct + 1;
                    }

                    if (Server.NoVotes >= 1)
                    { Player.SendMessage(p, c.red + "Your answer is Incorrect."); wrong = wrong + 1; }
                    if (Server.YesVotes < 1 && Server.NoVotes < 1)
                    { Player.SendMessage(p, c.maroon + "You never answered, so your answer is incorrect."); wrong = wrong + 1; }



                }
                else
                {
                    Player.SendMessage(p, "A person is already taking an Optest. Please wait for player to finish.");
                }
                if (!Server.voting)
                {
                    Server.restarting = true;
                    Server.voting = true;
                    Server.NoVotes = 0;
                    Server.YesVotes = 0;
                    Player.SendMessage(p, c.red + "Sixth question: " + c.green + "If a guest can't complete building a house by himself and needs help, the best thing to do is 'ignore them'." + Server.DefaultColor + "(" + c.green + "Yes " + Server.DefaultColor + "/" + c.red + "No" + Server.DefaultColor + ")");
                    System.Threading.Thread.Sleep(15000);

                    Player.SendMessage(p, c.maroon + "Question about to end........");
                    Thread.Sleep(1000);
                    int time = 5;
                    while (time != 0)
                    {
                        Player.SendMessage(p, c.maroon + "Finishing question" + Server.DefaultColor + " in %2" + time);
                        time--;
                        Thread.Sleep(1000);
                    }

                    Server.voting = false;
                    Player.players.ForEach(delegate(Player winners)
                    {
                        winners.voted = false;
                    }
                    );
                    if (Server.YesVotes >= 1)
                    {
                        Player.SendMessage(p, c.red + "Your answer is Incorrect."); wrong = wrong + 1;
                    }

                    if (Server.NoVotes >= 1)
                    { Player.SendMessage(p, c.lime + "Your answer is Correct."); correct = correct + 1; }
                    if (Server.YesVotes < 1 && Server.NoVotes < 1)
                    { Player.SendMessage(p, c.maroon + "You never answered, so your answer is incorrect."); wrong = wrong + 1; }



                }
                else
                {
                    Player.SendMessage(p, "A person is already taking an Optest. Please wait for player to finish.");
                }
                if (!Server.voting)
                {
                    Server.restarting = true;
                    Server.voting = true;
                    Server.NoVotes = 0;
                    Server.YesVotes = 0;
                    Player.SendMessage(p, c.red + "Seventh question: " + c.green + "When the owner of the server tells you to quit begging or breaking rules, you should stop or you will get banned." + Server.DefaultColor + "(" + c.green + "Yes " + Server.DefaultColor + "/" + c.red + "No" + Server.DefaultColor + ")");
                    System.Threading.Thread.Sleep(15000);

                    Player.SendMessage(p, c.maroon + "Question about to end........");
                    Thread.Sleep(1000);
                    int time = 5;
                    while (time != 0)
                    {
                        Player.SendMessage(p, c.maroon + "Finishing question" + Server.DefaultColor + " in %2" + time);
                        time--;
                        Thread.Sleep(1000);
                    }

                    Server.voting = false;
                    Player.players.ForEach(delegate(Player winners)
                    {
                        winners.voted = false;
                    }
                    );
                    if (Server.YesVotes >= 1)
                    {
                        Player.SendMessage(p, c.lime + "Your answer is Correct."); correct = correct + 1;

                    }

                    if (Server.NoVotes >= 1)
                    { Player.SendMessage(p, c.red + "Your answer is Incorrect."); wrong = wrong + 1; }
                    if (Server.YesVotes < 1 && Server.NoVotes < 1)
                    { Player.SendMessage(p, c.maroon + "You never answered, so your answer is incorrect."); wrong = wrong + 1; }



                }
                else
                {
                    Player.SendMessage(p, "A person is already taking an Optest. Please wait for player to finish.");
                }
                if (!Server.voting)
                {
                    Server.restarting = true;
                    Server.voting = true;
                    Server.NoVotes = 0;
                    Server.YesVotes = 0;
                    Player.SendMessage(p, c.red + "Eighth question: " + c.green + "To copy an object on a map, use '/copy' then you must click 3 times in one spot and then another." + Server.DefaultColor + "(" + c.green + "Yes " + Server.DefaultColor + "/" + c.red + "No" + Server.DefaultColor + ")");
                    System.Threading.Thread.Sleep(15000);

                    Player.SendMessage(p, c.maroon + "Question about to end........");
                    Thread.Sleep(1000);
                    int time = 5;
                    while (time != 0)
                    {
                        Player.SendMessage(p, c.maroon + "Finishing question" + Server.DefaultColor + " in %2" + time);
                        time--;
                        Thread.Sleep(1000);
                    }

                    Server.voting = false;
                    Player.players.ForEach(delegate(Player winners)
                    {
                        winners.voted = false;
                    }
                    );
                    if (Server.YesVotes >= 1)
                    {
                        Player.SendMessage(p, c.red + "Your answer is Incorrect."); wrong = wrong + 1;
                    }

                    if (Server.NoVotes >= 1)
                    { Player.SendMessage(p, c.lime + "Your answer is Correct."); correct = correct + 1; }
                    if (Server.YesVotes < 1 && Server.NoVotes < 1)
                    { Player.SendMessage(p, c.maroon + "You never answered, so your answer is incorrect."); wrong = wrong + 1; }



                }
                else
                {
                    Player.SendMessage(p, "A person is already taking an Optest. Please wait for player to finish.");
                }
                if (!Server.voting)
                {
                    Server.restarting = true;
                    Server.voting = true;
                    Server.NoVotes = 0;
                    Server.YesVotes = 0;
                    Player.SendMessage(p, c.red + "Ninth question: " + c.green + "You are supposed to promote someone after they beg for a rank several times." + Server.DefaultColor + "(" + c.green + "Yes " + Server.DefaultColor + "/" + c.red + "No" + Server.DefaultColor + ")");
                    System.Threading.Thread.Sleep(15000);

                    Player.SendMessage(p, c.maroon + "Question about to end........");
                    Thread.Sleep(1000);
                    int time = 5;
                    while (time != 0)
                    {
                        Player.SendMessage(p, c.maroon + "Finishing question" + Server.DefaultColor + " in %2" + time);
                        time--;
                        Thread.Sleep(1000);
                    }

                    Server.voting = false;
                    Player.players.ForEach(delegate(Player winners)
                    {
                        winners.voted = false;
                    }
                    );
                    if (Server.YesVotes >= 1)
                    {
                        Player.SendMessage(p, c.red + "Your answer is Incorrect."); wrong = wrong + 1;
                    }

                    if (Server.NoVotes >= 1)
                    { Player.SendMessage(p, c.lime + "Your answer is Correct."); correct = correct + 1; }
                    if (Server.YesVotes < 1 && Server.NoVotes < 1)
                    { Player.SendMessage(p, c.maroon + "You never answered, so your answer is incorrect."); wrong = wrong + 1; }



                }
                else
                {
                    Player.SendMessage(p, "A person is already taking an Optest. Please wait for player to finish.");
                }
                if (!Server.voting)
                {
                    Server.restarting = true;
                    Server.voting = true;
                    Server.NoVotes = 0;
                    Server.YesVotes = 0;
                    Player.SendMessage(p, c.red + "Tenth and last question: " + c.green + "You hear someone joking about Devs and making racist comments. Are you are supposed to ask them to stop (yes), or join them (no).");
                    System.Threading.Thread.Sleep(15000);

                    Player.SendMessage(p, c.maroon + "Question about to end........");
                    Thread.Sleep(1000);
                    int time = 5;
                    while (time != 0)
                    {
                        Player.SendMessage(p, c.maroon + "Finishing question" + Server.DefaultColor + " in %2" + time);
                        time--;
                        Thread.Sleep(1000);
                    }

                    Server.voting = false;
                    Player.players.ForEach(delegate(Player winners)
                    {
                        winners.voted = false;
                    }
                    );
                    if (Server.YesVotes >= 1)
                    {
                        Player.SendMessage(p, c.lime + "Your answer is Correct."); correct = correct + 1;

                    }

                    if (Server.NoVotes >= 1)
                    { Player.SendMessage(p, c.red + "Your answer is Incorrect."); wrong = wrong + 1; }
                    if (Server.YesVotes < 1 && Server.NoVotes < 1)
                    { Player.SendMessage(p, c.maroon + "You never answered, so your answer is incorrect."); wrong = wrong + 1; }


                }
                else
                {
                    Player.SendMessage(p, "A person is already taking an Optest. Please wait for player to finish.");
                }

                string totalcorrect = Convert.ToString(correct);
                string totalwrong = Convert.ToString(wrong);
                int dividedint = correct / wrong;
                //multiply 100 to get percentage
                int multiplied_percent = dividedint * 10;
                string strmultiplied = Convert.ToString(multiplied_percent);
                // string dividedanswer = Convert.ToString(dividedint);
                Player.SendMessage(p, "Number Correct: " + totalcorrect);
                Player.SendMessage(p, "Number Wrong: " + totalwrong);
                Player.SendMessage(p, "You got " + strmultiplied + " percent on this test.");
                if (correct < 7)
                { Player.SendMessage(p, "Sorry, but you must get 70 percent or above to pass this test."); return; }

                if (correct >= 7)
                { Player.SendMessage(p, c.lime + "Congratulations!! You have just passed this test."); }
                LevelPermission permission = p.group.Permission;
                if (permission >= LevelPermission.Operator)
                {
                    Player.SendMessage(p, "You can't rank any higher. This test is only used to prove if you deserve operator."); return;
                }
                if (correct >= 7)
                {
                    Command.all.Find("setrank").Use(null, p.name + " operator"); return;
                }
            }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/Optest [start] - Gives a player an optest to become an operator!");
            Player.SendMessage(p, "/Optest [stop] - Stops the test.");
        }
    }
}
