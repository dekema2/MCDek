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
using MCLawl.Commands;
using MCDek;

namespace MCLawl
{
    public abstract class Command
    {
        public abstract string name { get; }
        public abstract string shortcut { get; }
        public abstract string type { get; }
        public abstract bool museumUsable { get; }
        public abstract LevelPermission defaultRank { get; }
        public abstract void Use(Player p, string message);
        public abstract void Help(Player p);

        public static CommandList all = new CommandList();
        public static CommandList core = new CommandList();
        public static void InitAll()
        {
            all.Add(new CmdAbort());
            all.Add(new CmdAbout());
            all.Add(new CmdAfk());
            all.Add(new CmdBan());
            all.Add(new CmdBanip());
            all.Add(new CmdBind());
            all.Add(new CmdBlocks());
            all.Add(new CmdBlockSet());
            all.Add(new CmdBotAdd());
            all.Add(new CmdBotAI());
            all.Add(new CmdBotRemove());
            all.Add(new CmdBots());
            all.Add(new CmdBotSet());
            all.Add(new CmdBotSummon());
            all.Add(new CmdClearBlockChanges());
            all.Add(new CmdClick());
            all.Add(new CmdClones());
            all.Add(new CmdCmdBind());
            all.Add(new CmdCmdCreate());
            all.Add(new CmdCmdLoad());
            all.Add(new CmdCmdSet());
            all.Add(new CmdCmdUnload());
            all.Add(new CmdCompile());
            all.Add(new CmdColor());
            all.Add(new CmdCopy());
            all.Add(new CmdAutoC()); 
            all.Add(new CmdAirRaid()); 
            all.Add(new CmdChristmasTree());
            all.Add(new CmdCuboid());
            all.Add(new CmdDelete());
            all.Add(new CmdDeleteLvl());
            all.Add(new CmdDevs());
            all.Add(new CmdDrop());
            all.Add(new CmdEmote());
            all.Add(new CmdFill());
            all.Add(new CmdFixGrass());
            all.Add(new CmdFlipHeads());
            all.Add(new CmdFly());
            all.Add(new CmdFollow());
            all.Add(new CmdFreeze());
            all.Add(new CmdGive());
            all.Add(new CmdGoto());
            all.Add(new CmdGun());
            all.Add(new CmdHacks());
            all.Add(new CmdHasirc());
            // all.Add(new CmdHeartbeat()); DEBUG COMMAND DO NOT USE
            all.Add(new CmdHelp());
            all.Add(new CmdHide());
            all.Add(new CmdHighlight());
            all.Add(new CmdHollow());
            all.Add(new CmdHost());
            all.Add(new CmdImport());
            all.Add(new CmdImageprint());
            all.Add(new CmdInbox());
            all.Add(new CmdInfo());
            all.Add(new CmdInvincible());
            all.Add(new CmdJail());
            all.Add(new CmdJoker());
            all.Add(new CmdKick());
            all.Add(new CmdKickban());
            all.Add(new CmdKill());
            all.Add(new CmdLastCmd());
            all.Add(new CmdLevels());
            all.Add(new CmdLimit());
            all.Add(new CmdLine());
            all.Add(new CmdLoad());
            all.Add(new CmdLowlag());
            all.Add(new CmdMap());
            all.Add(new CmdMapInfo());
            all.Add(new CmdMe());
            all.Add(new CmdMeasure());
            all.Add(new CmdMegaboid());
            all.Add(new CmdMessageBlock());
            all.Add(new CmdMissile());
            all.Add(new CmdMode());
            all.Add(new CmdModerate());
            all.Add(new CmdMove());
            all.Add(new CmdMuseum());
            all.Add(new CmdMute());
            all.Add(new CmdNewLvl());
            all.Add(new CmdOpChat());
            all.Add(new CmdOutline());
            all.Add(new CmdPaint());
            all.Add(new CmdPaste());
            all.Add(new CmdPause());
            all.Add(new CmdPay());
            all.Add(new CmdPCount());
            all.Add(new CmdPermissionBuild());
            all.Add(new CmdPermissionVisit());
            all.Add(new CmdPhysics());
            all.Add(new CmdPlace());
            all.Add(new CmdPlayers());
            all.Add(new CmdPortal());
            all.Add(new CmdPossess());
            all.Add(new CmdRainbow());
            all.Add(new CmdRedo());
            all.Add(new CmdRenameLvl());
            all.Add(new CmdRepeat());
            all.Add(new CmdReplace());
            all.Add(new CmdReplaceAll());
            all.Add(new CmdReplaceNot());
            all.Add(new CmdResetBot());
            all.Add(new CmdRestart());
            all.Add(new CmdRestartPhysics());
            all.Add(new CmdRestore());
            all.Add(new CmdRetrieve());
            all.Add(new CmdReveal());
            all.Add(new CmdRide());
            all.Add(new CmdRoll());
            all.Add(new CmdRules());
            all.Add(new CmdSave());
            all.Add(new CmdSay());
            all.Add(new CmdSend());
            all.Add(new CmdServerReport());
            all.Add(new CmdSetRank());
            all.Add(new CmdSetspawn());
            all.Add(new CmdSlap());
            all.Add(new CmdSpawn());
            all.Add(new CmdSpheroid());
            all.Add(new CmdSpin());
            all.Add(new CmdStairs());
            all.Add(new CmdStatic());
            all.Add(new CmdStore());
            all.Add(new CmdSummon());
            all.Add(new CmdTake());
            all.Add(new CmdTColor());
            all.Add(new CmdTeam());
            all.Add(new CmdTempBan());
            all.Add(new CmdText());
            all.Add(new CmdTime());
            all.Add(new CmdTimer());
            all.Add(new CmdTitle());
            all.Add(new CmdTnt());
            all.Add(new CmdTp());
            all.Add(new CmdTpZone());
            all.Add(new CmdTree());
            all.Add(new CmdTrust());
            all.Add(new CmdUnban());
            all.Add(new CmdUnbanip());
            all.Add(new CmdUndo());
            all.Add(new CmdUnload());
            all.Add(new CmdUnloaded());
            all.Add(new CmdUpdate());
            all.Add(new CmdView());
            all.Add(new CmdViewRanks());
            all.Add(new CmdVoice());
            all.Add(new CmdWhisper());
            if (Server.useWhitelist) { all.Add(new CmdWhitelist()); }
            all.Add(new CmdWhoip());
            all.Add(new CmdWhois());
            all.Add(new CmdWhowas());
            all.Add(new CmdWrite());
            all.Add(new CmdZone());
            all.Add(new CmdCrashServer());
            all.Add(new CmdPromote());
            all.Add(new CmdDemote());
            all.Add(new CmdDrill());
            all.Add(new CmdAward());
            all.Add(new CmdAwards());
            all.Add(new CmdAwardMod());
            all.Add(new CmdDetonate());
            all.Add(new CmdMimic());
            all.Add(new CmdUban());
            all.Add(new CmdHome());
            all.Add(new CmdOpTest());
            all.Add(new CmdAirRaid());
            all.Add(new CmdAutoC());
            all.Add(new CmdPush());
            all.Add(new CmdGriefPatrol());
            all.Add(new CmdFastHouse());
            all.Add(new CmdVote());
            all.Add(new CmdConverse());
            all.Add(new CmdXhide());
            all.Add(new CmdPass());
            all.Add(new CmdSetPass());
            all.Add(new CmdResetPass());


            core.commands = new List<Command>(all.commands);

            Scripting.Autoload();
        }
    }
}