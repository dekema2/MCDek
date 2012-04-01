using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCDek
{
    public static class ServerSettings
    {
        // Don't even try referencing this from Program.cs, you'll break the updater and it will fail miserably.
        public static string HeartbeatAnnounce = "http://mcforge.mc-mycraft.com/heartbeat.php";

    }
}
