using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MCLawl;

namespace MCDek
{
    class MCDekBeat : Beat
    {
        public string URL { get { return ServerSettings.HeartbeatAnnounce; } }
        public string Parameters { get; set; }
        public bool Log { get { return false; } }

        public void Prepare()
        {
            if (String.IsNullOrEmpty(Server.Hash))
            {
                Server.Hash = "";
                // THIS IS TEMPORARILY COMMENTED OUT SO PEOPLE CAN STILL HEARTBEAT WITH US USING A SAVED HASH!!
                //throw new Exception("Hash not set");
            }

            int hidden = 0;
            if (Player.number > 0)
            {
                string players = "";

                foreach (Player p in Player.players)
                {
                    if (p.hidden)
                    {
                        hidden++;
                        continue;
                    }
                    players += p.name + " (" + p.group.name + ")" + ",";
                }
                if (Player.number - hidden > 0)
                    Parameters += "&players=" + players.Substring(0, players.Length - 1);
            }

            if (Server.levels != null && Server.levels.Count > 0)
            {
                IEnumerable<string> worlds = from l in Server.levels select l.name;
                Parameters += "&worlds=" + String.Join(", ", worlds.ToArray());
            }

            Parameters += "&motd=" + Heart.UrlEncode(Server.motd) +
                    "&lvlcount=" + (byte)Server.levels.Count +
                    "&serverversion=" + Server.Version/*.Replace(".0", "")*/ +
                    "&hash=" + Server.URL + // Don't mind this, the server list wants the whole URL now. Blame Mojang!
                    "&users=" + (Player.number - hidden) +
                    "&permalinkhash=" + Permalink.UniqueHash +
                    "&globalchat=" + (Server.UseGlobalChat ? Server.GlobalChatNick : String.Empty);
        }

        public void OnPump(string line)
        {
            line = line.Trim();
            if (!String.IsNullOrEmpty(line))
            {
                try
                {
                    Uri oldURL = Permalink.URL;
                    Uri newUrl = new Uri(line);
                    if (oldURL == null && newUrl != null)
                    {
                        // We got the URL!
                        Permalink.URL = newUrl;
                        // TODO: Place this in the UI somewhere
                    }
                }
                catch { }
            }
            return;
        }

    }
}


