using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MCDek
{
    public static class Updater
    {
        public static void Load(string givenPath)
        {
            if (File.Exists(givenPath))
            {
                string[] lines = File.ReadAllLines(givenPath);

                foreach (string line in lines)
                {
                    if (line != "" && line[0] != '#')
                    {
                        string key = line.Split('=')[0].Trim();
                        string value = line.Split('=')[1].Trim();

                        switch (key.ToLower())
                        {
                            case "autoupdate":
                                Server.autoupdate = (value.ToLower() == "true") ? true : false;
                                break;
                            case "notify":
                                Server.autonotify = (value.ToLower() == "true") ? true : false;
                                break;
                            case "restartcountdown":
                                Server.restartcountdown = value;
                                break;

                        }
                    }
                }
            }
        }

    }
}
