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
using System.Collections.Generic;
using System.Text;
using Meebey.SmartIrc4net;
using System.Threading;

namespace MCLawl
{
    class IRCBot
    {
        static IrcClient irc = new IrcClient();
        static string server = Server.ircServer;
        static string channel = Server.ircChannel;
        static string opchannel = Server.ircOpChannel;
        static string nick = Server.ircNick;
        static Thread ircThread;

        static string[] names;

        public IRCBot()
        {
            // The IRC Bot must run in a seperate thread, or else the server will freeze.
            ircThread = new Thread(new ThreadStart(delegate
            {
                // Attach event handlers
                irc.OnConnecting += new EventHandler(OnConnecting);
                irc.OnConnected += new EventHandler(OnConnected);
                irc.OnChannelMessage += new IrcEventHandler(OnChanMessage);
                irc.OnJoin += new JoinEventHandler(OnJoin);
                irc.OnPart += new PartEventHandler(OnPart);
                irc.OnQuit += new QuitEventHandler(OnQuit);
                irc.OnNickChange += new NickChangeEventHandler(OnNickChange);
                irc.OnDisconnected += new EventHandler(OnDisconnected);
                irc.OnQueryMessage += new IrcEventHandler(OnPrivMsg);
                irc.OnNames += new NamesEventHandler(OnNames);
                irc.OnChannelAction += new ActionEventHandler(OnAction);

                // Attempt to connect to the IRC server
                try { irc.Connect(server, Server.ircPort); }
                catch (Exception ex) { Console.WriteLine("Unable to connect to IRC server: {0}", ex.Message); }
            }));
            ircThread.Start();
        }

        // While connecting
        void OnConnecting(object sender, EventArgs e)
        {
            Server.s.Log("Connecting to IRC");
        }
        // When connected
        void OnConnected(object sender, EventArgs e)
        {
            Server.s.Log("Connected to IRC");
            irc.Login(nick, nick, 0, nick);

            // Check to see if we want to register our bot with nickserv

            if (Server.ircIdentify && Server.ircPassword != string.Empty)
            {
                Server.s.Log("Identifying with Nickserv");
                irc.SendMessage(SendType.Message, "nickserv", "IDENTIFY " + Server.ircPassword);
            }

            Server.s.Log("Joining channels");
            irc.RfcJoin(channel);
            irc.RfcJoin(opchannel);

            irc.Listen();
        }

        void OnNames(object sender, NamesEventArgs e)
        {
            names = e.UserList;
        }
        void OnDisconnected(object sender, EventArgs e)
        {
            try { irc.Connect(server, 6667); }
            catch { Console.WriteLine("Failed to reconnect to IRC"); }
        }

        // On public channel message
        void OnChanMessage(object sender, IrcEventArgs e)
        {
            string temp = e.Data.Message; string storedNick = e.Data.Nick;

            string allowedchars = "1234567890-=qwertyuiop[]\\asdfghjkl;'zxcvbnm,./!@#$%^*()_+QWERTYUIOPASDFGHJKL:\"ZXCVBNM<>? ";

            foreach (char ch in temp)
            {
                if (allowedchars.IndexOf(ch) == -1)
                    temp = temp.Replace(ch.ToString(), "*");
            }

            if (e.Data.Channel == opchannel)
            {
                Server.s.Log("[(Op) IRC] " + e.Data.Nick + ": " + temp);
                Player.GlobalMessageOps(Server.IRCColour + "[(Op) IRC] " + storedNick + ": &f" + temp);
            }
            else
            {
                Server.s.Log("[IRC] " + e.Data.Nick + ": " + temp);
                Player.GlobalChat(null, Server.IRCColour + "[IRC] " + storedNick + ": &f" + temp, false);
            }

            //if (temp.IndexOf(':') < temp.IndexOf(' ')) {
            //    storedNick = temp.Substring(0, temp.IndexOf(':'));
            //    temp = temp.Substring(temp.IndexOf(' ') + 1);
            //}

            //s.Log("IRC: " + e.Data.Nick + ": " + e.Data.Message);
            //Player.GlobalMessage("IRC: &1" + e.Data.Nick + ": &f" + e.Data.Message);
        }
        // When someone joins the IRC
        void OnJoin(object sender, JoinEventArgs e)
        {
            Server.s.Log(e.Data.Nick + " has joined channel " + e.Data.Channel);
            if (e.Data.Channel == opchannel)
            {
                Player.GlobalChat(null, Server.IRCColour + e.Data.Nick + Server.DefaultColor + " has joined the operator channel", false);
            }
            else
            {
                Player.GlobalChat(null, Server.IRCColour + e.Data.Nick + Server.DefaultColor + " has joined the channel", false);
            }
            irc.RfcNames(channel);
            irc.RfcNames(opchannel);
        }
        // When someone leaves the IRC
        void OnPart(object sender, PartEventArgs e)
        {
            Server.s.Log(e.Data.Nick + " has left channel " + e.Data.Channel);
            if (e.Data.Channel == opchannel)
            {
                Player.GlobalChat(null, Server.IRCColour + e.Data.Nick + Server.DefaultColor + " has left the operator channel", false);
            }
            else
            {
                Player.GlobalChat(null, Server.IRCColour + e.Data.Nick + Server.DefaultColor + " has left the channel", false);
            }
            irc.RfcNames(channel);
            irc.RfcNames(opchannel);
        }
        void OnQuit(object sender, QuitEventArgs e)
        {
            Server.s.Log(e.Data.Nick + " has left IRC");
            Player.GlobalChat(null, Server.IRCColour + e.Data.Nick + Server.DefaultColor + " has left IRC", false);
            irc.RfcNames(channel);
            irc.RfcNames(opchannel);
        }
        void OnPrivMsg(object sender, IrcEventArgs e)
        {
            Server.s.Log("IRC RECEIVING MESSAGE");
            if (Server.ircControllers.Contains(e.Data.Nick))
            {
                string cmd;
                string msg;
                int len = e.Data.Message.Split(' ').Length;
                cmd = e.Data.Message.Split(' ')[0];
                if (len > 1)
                {
                    msg = e.Data.Message.Substring(e.Data.Message.IndexOf(' ')).Trim();
                }
                else
                {
                    msg = "";
                }

                if (msg != "" || cmd == "restart" || cmd == "update")
                {
                    Server.s.Log(cmd + " : " + msg);
                    switch (cmd)
                    {
                        case "kick":
                            if (Player.Find(msg.Split()[0]) != null)
                            {
                                Command.all.Find("kick").Use(null, msg);
                            }
                            else
                            {
                                irc.SendMessage(SendType.Message, e.Data.Nick, "Player not found.");
                            }
                            break;
                        case "ban":
                            if (Player.Find(msg) != null)
                            {
                                Command.all.Find("ban").Use(null, msg);
                            }
                            else
                            {
                                irc.SendMessage(SendType.Message, e.Data.Nick, "Player not found.");
                            }
                            break;
                        case "banip":
                            if (Player.Find(msg) != null)
                            {
                                Command.all.Find("banip").Use(null, msg);
                            }
                            else
                            {
                                irc.SendMessage(SendType.Message, e.Data.Nick, "Player not found.");
                            }
                            break;
                        case "say":
                            irc.SendMessage(SendType.Message, channel, msg); break;
                        case "setrank":
                            if (Player.Find(msg.Split(' ')[0]) != null)
                            {
                                Command.all.Find("setrank").Use(null, msg);
                            }
                            else
                            {
                                irc.SendMessage(SendType.Message, e.Data.Nick, "Player not found.");
                            }
                            break;
                        case "mute":
                            if (Player.Find(msg) != null)
                            {
                                Command.all.Find("mute").Use(null, msg);
                            }
                            else
                            {
                                irc.SendMessage(SendType.Message, e.Data.Nick, "Player not found.");
                            }
                            break;
                        case "joker":
                            if (Player.Find(msg) != null)
                            {
                                Command.all.Find("joker").Use(null, msg);
                            }
                            else
                            {
                                irc.SendMessage(SendType.Message, e.Data.Nick, "Player not found.");
                            }
                            break;
                        case "physics":
                            if (Level.Find(msg.Split(' ')[0]) != null)
                            {
                                Command.all.Find("physics").Use(null, msg);
                            }
                            else
                            {
                                irc.SendMessage(SendType.Message, e.Data.Nick, "Map not found.");
                            }
                            break;
                        case "load":
                            if (Level.Find(msg.Split(' ')[0]) != null)
                            {
                                Command.all.Find("load").Use(null, msg);
                            }
                            else
                            {
                                irc.SendMessage(SendType.Message, e.Data.Nick, "Map not found.");
                            }
                            break;
                        case "unload":
                            if (Level.Find(msg) != null || msg == "empty")
                            {
                                Command.all.Find("unload").Use(null, msg);
                            }
                            else
                            {
                                irc.SendMessage(SendType.Message, e.Data.Nick, "Map not found.");
                            }
                            break;
                        case "save":
                            if (Level.Find(msg) != null)
                            {
                                Command.all.Find("save").Use(null, msg);
                            }
                            else
                            {
                                irc.SendMessage(SendType.Message, e.Data.Nick, "Map not found.");
                            }
                            break;
                        case "map":
                            if (Level.Find(msg.Split(' ')[0]) != null)
                            {
                                Command.all.Find("map").Use(null, msg);
                            }
                            else
                            {
                                irc.SendMessage(SendType.Message, e.Data.Nick, "Map not found.");
                            }
                            break;
                        case "restart":
                            Player.GlobalMessage("Restart initiated by " + e.Data.Nick);
                            IRCBot.Say("Restart initiated by " + e.Data.Nick);
                            Command.all.Find("restart").Use(null, "");
                            break;
                        case "update":
                            Player.GlobalMessage("Update check initiated by " + e.Data.Nick);
                            IRCBot.Say("Update check initiated by " + e.Data.Nick);
                            Command.all.Find("update").Use(null, "");
                            break;
                        default:
                            irc.SendMessage(SendType.Message, e.Data.Nick, "Invalid command."); break;
                    }
                }
                else
                {
                    irc.SendMessage(SendType.Message, e.Data.Nick, "Invalid command format.");
                }
            }
        }
        void OnNickChange(object sender, NickChangeEventArgs e)
        {
            string key;
            if (e.NewNickname.Split('|').Length == 2)
            {
                key = e.NewNickname.Split('|')[1];
                if (key != null && key != "")
                {
                    switch (key)
                    {
                        case "AFK":
                            Player.GlobalMessage("[IRC] " + Server.IRCColour + e.OldNickname + Server.DefaultColor + " is AFK"); Server.afkset.Add(e.OldNickname); break;
                        case "Away":
                            Player.GlobalMessage("[IRC] " + Server.IRCColour + e.OldNickname + Server.DefaultColor + " is Away"); Server.afkset.Add(e.OldNickname); break;
                    }
                }
            }
            else if (Server.afkset.Contains(e.NewNickname))
            {
                Player.GlobalMessage("[IRC] " + Server.IRCColour + e.NewNickname + Server.DefaultColor + " is no longer away");
                Server.afkset.Remove(e.NewNickname);
            }
            else
                Player.GlobalMessage("[IRC] " + Server.IRCColour + e.OldNickname + Server.DefaultColor + " is now known as " + e.NewNickname);

            irc.RfcNames(channel);
            irc.RfcNames(opchannel);
        }
        void OnAction(object sender, ActionEventArgs e)
        {
            Player.GlobalMessage("* " + e.Data.Nick + " " + e.ActionMessage);
        }


        /// <summary>
        /// A simple say method for use outside the bot class
        /// </summary>
        /// <param name="msg">what to send</param>
        public static void Say(string msg, bool opchat = false)
        {
            if (irc != null && irc.IsConnected && Server.irc)
                if (opchat == false)
                {
                    irc.SendMessage(SendType.Message, channel, msg);
                }
                else
                {
                    irc.SendMessage(SendType.Message, opchannel, msg);
                }
        }
        public static bool IsConnected()
        {
            if (irc.IsConnected)
                return true;
            else
                return false;
        }


        public static void Reset()
        {
            if (irc.IsConnected)
                irc.Disconnect();
            ircThread = new Thread(new ThreadStart(delegate
            {
                try { irc.Connect(server, Server.ircPort); }
                catch (Exception e)
                {
                    Server.s.Log("Error Connecting to IRC");
                    Server.s.Log(e.ToString());
                }
            }));
            ircThread.Start();
        }
        public static string[] GetConnectedUsers()
        {
            return names;
        }

        public static void ShutDown()
        {
            irc.Disconnect();
            ircThread.Abort();
        }
    }
}
