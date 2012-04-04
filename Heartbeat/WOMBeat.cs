using System;
using System.IO;
using System.Text;
using System.Net;
using MCLawl;

namespace MCDek
{
    class WOMBeat : Beat
    {
        public string URL { get { return "http://direct.worldofminecraft.com/hb.php"; } }
        public string Parameters { get; set; }
        public bool Log { get { return false; } }
        public static bool SetSettings(string IP, string Port, string Name, string Disc, string flags)
        {
            string url = "http://direct.worldofminecraft.com/server.php";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            string flag = "&flags=%5B" + flags + "%5D";
            if (flags.StartsWith("["))
                flag = "&flags=" + flags;
            string Parameters = "ip=" + IP + "&port=" + Port + "&salt=" + Server.salt + "&alt=" + Name.Replace(' ', '+') + "&desc=" + Disc.Replace(' ', '+') + flag;

            int totalTries = 0;
            int totalTriesStream = 0;
            try
            {
                totalTries++;
                totalTriesStream = 0;
                // Set all the request settings
                //Server.s.Log(beat.Parameters);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
                byte[] formData = Encoding.ASCII.GetBytes(Parameters);
                request.ContentLength = formData.Length;
                request.Timeout = 15000; // 15 seconds
                try
                {
                    totalTriesStream++;
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(formData, 0, formData.Length);
                        requestStream.Flush();
                        requestStream.Close();
                        requestStream.Dispose();
                    }
                    return true;
                }
                catch (Exception e)
                {
                    Server.ErrorLog(e);
                    return false;
                }
            }
            catch (Exception e)
            {
                Server.ErrorLog(e);
                return false;
            }
        }
        public void Prepare()
        {
            Parameters += "&salt=" + Server.salt +
                "&users=" + Player.number +
                "&alt=" + Server.Server_ALT +
                "&desc=" + Server.Server_Disc +
                "&flags=" + Server.Server_Flag;
        }

        public void OnPump(string line)
        {
            // Only run the code below if we receive a response
            /*if (!String.IsNullOrEmpty(line.Trim()))
{
string newHash = line.Substring(line.LastIndexOf('=') + 1);

// Run this code if we don't already have a hash or if the hash has changed
if (String.IsNullOrEmpty(Server.Hash) || !newHash.Equals(Server.Hash))
{
Server.Hash = newHash;
string serverURL = line;

//serverURL = "http://" + serverURL.Substring(serverURL.IndexOf('.') + 1);
//Server.s.UpdateUrl(serverURL);
//File.WriteAllText("text/externalurl.txt", serverURL);
//Server.s.Log("URL found: " + serverURL);
}
}*/
        }
    }
}