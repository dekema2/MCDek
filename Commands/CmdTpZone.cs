using System;
using System.Collections.Generic;
//using MySql.Data.MySqlClient;
//using MySql.Data.Types;
using MCDek;
namespace MCLawl
{
    public class CmdTpZone : Command
    {
        public override string name { get { return "tpzone"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Builder; } }
        public CmdTpZone() { }

        public override void Use(Player p, string message)
        {
            if (message == "") message = "list";

            string[] parameters = message.Split(' ');

            if (parameters[0].ToLower() == "list")
            {
                if (parameters.Length > 1)
                {
                    int pageNum, currentNum;
                    try
                    {
                        pageNum = int.Parse(parameters[1]) * 10; currentNum = pageNum - 10;
                    }
                    catch { Help(p); return; }

                    if (currentNum < 0) { Player.SendMessage(p, "Must be greater than 0"); return; }
                    if (pageNum > p.level.ZoneList.Count) pageNum = p.level.ZoneList.Count;
                    if (currentNum > p.level.ZoneList.Count) { Player.SendMessage(p, "No Zones beyond number " + (p.level.ZoneList.Count - 1)); return; }

                    Player.SendMessage(p, "Zones (" + currentNum + " to " + (pageNum - 1) + "):");
                    for (int i = currentNum; i < pageNum; i++)
                    {
                        Level.Zone zone = p.level.ZoneList[i];
                        Player.SendMessage(p, "&c" + i + " &b(" +
                            zone.smallX + "-" + zone.bigX + ", " +
                            zone.smallY + "-" + zone.bigY + ", " +
                            zone.smallZ + "-" + zone.bigZ + ") &f" +
                            zone.Owner);
                    }
                }
                else
                {
                    for (int i = 0; i < p.level.ZoneList.Count; i++)
                    {
                        Level.Zone zone = p.level.ZoneList[i];
                        Player.SendMessage(p, "&c" + i + " &b(" +
                            zone.smallX + "-" + zone.bigX + ", " +
                            zone.smallY + "-" + zone.bigY + ", " +
                            zone.smallZ + "-" + zone.bigZ + ") &f" +
                            zone.Owner);
                    }
                    Player.SendMessage(p, "For a more structured list, use /tpzone list <1/2/3/..>");
                }
            }
            else
            {
                int zoneID;
                try
                {
                    zoneID = int.Parse(message);
                }
                catch { Help(p); return; }

                if (zoneID < 0 || zoneID > p.level.ZoneList.Count)
                {
                    Player.SendMessage(p, "This zone doesn't exist");
                    return;
                }

                Level.Zone zone = p.level.ZoneList[zoneID];
                unchecked { p.SendPos((byte)-1, (ushort)(zone.bigX * 32 + 16), (ushort)(zone.bigY * 32 + 32), (ushort)(zone.bigZ * 32 + 16), p.rot[0], p.rot[1]); }

                Player.SendMessage(p, "Teleported to zone &c" + zoneID + " &b(" +
                    zone.bigX + ", " + zone.bigY + ", " + zone.bigZ + ") &f" +
                    zone.Owner);
            }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/tpzone <id> - Teleports to the zone with ID equal to <id>");
            Player.SendMessage(p, "/tpzone list - Lists all zones");
        }
    }
}