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
using MCDek;
namespace MCLawl
{
    public class CmdAbort : Command
    {
        public override string name { get { return "abort"; } }
        public override string shortcut { get { return "a"; } }
        public override string type { get { return "build"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Builder; } }
        public CmdAbort() { }

        public override void Use(Player p, string message)
        {
            p.ClearBlockchange();
            p.painting = false;
            p.isFlying = false;
            p.BlockAction = 0;
            p.megaBoid = false;
            p.cmdTimer = false;
            p.staticCommands = false; 
            p.deleteMode = false;
            p.ZoneCheck = false;
            p.modeType = 0;
            p.aiming = false;
            p.onTrain = false;
            Player.SendMessage(p, "Every toggle or action was aborted.");
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/abort - Cancels an action.");
        }
    }
}