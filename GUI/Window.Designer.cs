﻿/*
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
using System.Windows.Forms;
using MCLawl;

namespace MCDek.Gui
{
    public partial class Window
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void WndProc(ref Message msg)
        {
            /*const int WM_SIZE = 0x0005;
const int SIZE_MINIMIZED = 1;

if ((msg.Msg == WM_SIZE) && ((int)msg.WParam == SIZE_MINIMIZED) && (Window.Minimize != null))
{
this.Window_Minimize(this, EventArgs.Empty);
}*/

            base.WndProc(ref msg);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mapsStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.physicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.physicsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.finiteModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomFlowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edgeWaterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.growingGrassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeGrowingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leafDecayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autpPhysicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unloadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadOngotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miscToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animalAIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.survivalDeathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.killerBlocksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instantBuildingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rPChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gunsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actiondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.whoisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.banToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clonesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.promoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.demoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iconContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openConsole = new System.Windows.Forms.ToolStripMenuItem();
            this.shutdownServer = new System.Windows.Forms.ToolStripMenuItem();
            this.restartServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnProperties = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.Restart = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.LogsTxtBox = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtErrors = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtChangelog = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtSystem = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.Unloadempty_button = new System.Windows.Forms.Button();
            this.killphysics_button = new System.Windows.Forms.Button();
            this.button_saveall = new System.Windows.Forms.Button();
            this.gBCommands = new System.Windows.Forms.GroupBox();
            this.txtCommandsUsed = new System.Windows.Forms.TextBox();
            this.dgvMaps = new System.Windows.Forms.DataGridView();
            this.gBChat = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCommands = new System.Windows.Forms.TextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.dgvPlayers = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.UnloadedList = new System.Windows.Forms.ListBox();
            this.ldmapbt = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.AutoLoadChk = new System.Windows.Forms.CheckBox();
            this.label23 = new System.Windows.Forms.Label();
            this.drownNumeric = new System.Windows.Forms.NumericUpDown();
            this.Fallnumeric = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Aicombo = new System.Windows.Forms.ComboBox();
            this.edgewaterchk = new System.Windows.Forms.CheckBox();
            this.grasschk = new System.Windows.Forms.CheckBox();
            this.finitechk = new System.Windows.Forms.CheckBox();
            this.Killerbloxchk = new System.Windows.Forms.CheckBox();
            this.SurvivalStyleDeathchk = new System.Windows.Forms.CheckBox();
            this.chatlvlchk = new System.Windows.Forms.CheckBox();
            this.physlvlnumeric = new System.Windows.Forms.NumericUpDown();
            this.MOTDtxt = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SaveMap = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.seedtxtbox = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.xtxtbox = new System.Windows.Forms.ComboBox();
            this.ytxtbox = new System.Windows.Forms.ComboBox();
            this.ztxtbox = new System.Windows.Forms.ComboBox();
            this.nametxtbox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.maptypecombo = new System.Windows.Forms.ComboBox();
            this.CreateNewMap = new System.Windows.Forms.Button();
            this.dgvMapsTab = new System.Windows.Forms.DataGridView();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.PlayersTextBox = new System.Windows.Forms.TextBox();
            this.PlyersListBox = new System.Windows.Forms.ListBox();
            this.StatusTxt = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.LoggedinForTxt = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.Kickstxt = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.TimesLoggedInTxt = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.Blockstxt = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.DeathsTxt = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.IPtxt = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.SpawnBt = new System.Windows.Forms.Button();
            this.UndoTxt = new System.Windows.Forms.TextBox();
            this.UndoBt = new System.Windows.Forms.Button();
            this.SlapBt = new System.Windows.Forms.Button();
            this.SendRulesTxt = new System.Windows.Forms.Button();
            this.MimicORSendCmdTxt = new System.Windows.Forms.TextBox();
            this.MimicORSendCmdBt = new System.Windows.Forms.Button();
            this.KillBt = new System.Windows.Forms.Button();
            this.JailBt = new System.Windows.Forms.Button();
            this.DemoteBt = new System.Windows.Forms.Button();
            this.PromoteBt = new System.Windows.Forms.Button();
            this.LoginTxt = new System.Windows.Forms.TextBox();
            this.LogoutTxt = new System.Windows.Forms.TextBox();
            this.TitleTxt = new System.Windows.Forms.TextBox();
            this.ColorCombo = new System.Windows.Forms.ComboBox();
            this.ColorBt = new System.Windows.Forms.Button();
            this.TitleBt = new System.Windows.Forms.Button();
            this.LogoutBt = new System.Windows.Forms.Button();
            this.LoginBt = new System.Windows.Forms.Button();
            this.FreezeBt = new System.Windows.Forms.Button();
            this.VoiceBt = new System.Windows.Forms.Button();
            this.JokerBt = new System.Windows.Forms.Button();
            this.WarnBt = new System.Windows.Forms.Button();
            this.MessageBt = new System.Windows.Forms.Button();
            this.PLayersMessageTxt = new System.Windows.Forms.TextBox();
            this.HideBt = new System.Windows.Forms.Button();
            this.IPBanBt = new System.Windows.Forms.Button();
            this.BanBt = new System.Windows.Forms.Button();
            this.KickBt = new System.Windows.Forms.Button();
            this.MapCombo = new System.Windows.Forms.ComboBox();
            this.MapBt = new System.Windows.Forms.Button();
            this.MuteBt = new System.Windows.Forms.Button();
            this.RankTxt = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.MapTxt = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.NameTxtPlayersTab = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Chat = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label33 = new System.Windows.Forms.Label();
            this.txtOpInput = new System.Windows.Forms.TextBox();
            this.txtOpLog = new System.Windows.Forms.TextBox();
            this.mapsStrip.SuspendLayout();
            this.playerStrip.SuspendLayout();
            this.iconContext.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gBCommands.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaps)).BeginInit();
            this.gBChat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drownNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Fallnumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.physlvlnumeric)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMapsTab)).BeginInit();
            this.tabPage7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.Chat.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapsStrip
            // 
            this.mapsStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.physicsToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.actiondToolStripMenuItem,
            this.toolStripSeparator1,
            this.infoToolStripMenuItem});
            this.mapsStrip.Name = "mapsStrip";
            this.mapsStrip.Size = new System.Drawing.Size(144, 98);
            // 
            // physicsToolStripMenuItem
            // 
            this.physicsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7});
            this.physicsToolStripMenuItem.Name = "physicsToolStripMenuItem";
            this.physicsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.physicsToolStripMenuItem.Text = "Physics Level";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(128, 22);
            this.toolStripMenuItem2.Text = "Off";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click_1);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(128, 22);
            this.toolStripMenuItem3.Text = "Normal";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click_1);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(128, 22);
            this.toolStripMenuItem4.Text = "Advanced";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click_1);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(128, 22);
            this.toolStripMenuItem5.Text = "Hardcore";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click_1);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(128, 22);
            this.toolStripMenuItem6.Text = "Instant";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click_1);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(128, 22);
            this.toolStripMenuItem7.Text = "Doors-Only";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click_1);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.physicsToolStripMenuItem1,
            this.loadingToolStripMenuItem,
            this.miscToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // physicsToolStripMenuItem1
            // 
            this.physicsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.finiteModeToolStripMenuItem,
            this.randomFlowToolStripMenuItem,
            this.edgeWaterToolStripMenuItem,
            this.growingGrassToolStripMenuItem,
            this.treeGrowingToolStripMenuItem,
            this.leafDecayToolStripMenuItem,
            this.autpPhysicsToolStripMenuItem});
            this.physicsToolStripMenuItem1.Name = "physicsToolStripMenuItem1";
            this.physicsToolStripMenuItem1.Size = new System.Drawing.Size(111, 22);
            this.physicsToolStripMenuItem1.Text = "Physics";
            // 
            // finiteModeToolStripMenuItem
            // 
            this.finiteModeToolStripMenuItem.Name = "finiteModeToolStripMenuItem";
            this.finiteModeToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.finiteModeToolStripMenuItem.Text = "Finite Mode";
            this.finiteModeToolStripMenuItem.Click += new System.EventHandler(this.finiteModeToolStripMenuItem_Click);
            // 
            // randomFlowToolStripMenuItem
            // 
            this.randomFlowToolStripMenuItem.Name = "randomFlowToolStripMenuItem";
            this.randomFlowToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.randomFlowToolStripMenuItem.Text = "Random Flow";
            this.randomFlowToolStripMenuItem.Click += new System.EventHandler(this.randomFlowToolStripMenuItem_Click);
            // 
            // edgeWaterToolStripMenuItem
            // 
            this.edgeWaterToolStripMenuItem.Name = "edgeWaterToolStripMenuItem";
            this.edgeWaterToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.edgeWaterToolStripMenuItem.Text = "Edge Water";
            this.edgeWaterToolStripMenuItem.Click += new System.EventHandler(this.edgeWaterToolStripMenuItem_Click);
            // 
            // growingGrassToolStripMenuItem
            // 
            this.growingGrassToolStripMenuItem.Name = "growingGrassToolStripMenuItem";
            this.growingGrassToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.growingGrassToolStripMenuItem.Text = "Grass Growing";
            this.growingGrassToolStripMenuItem.Click += new System.EventHandler(this.growingGrassToolStripMenuItem_Click);
            // 
            // treeGrowingToolStripMenuItem
            // 
            this.treeGrowingToolStripMenuItem.Name = "treeGrowingToolStripMenuItem";
            this.treeGrowingToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.treeGrowingToolStripMenuItem.Text = "Tree Growing";
            this.treeGrowingToolStripMenuItem.Click += new System.EventHandler(this.treeGrowingToolStripMenuItem_Click);
            // 
            // leafDecayToolStripMenuItem
            // 
            this.leafDecayToolStripMenuItem.Name = "leafDecayToolStripMenuItem";
            this.leafDecayToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.leafDecayToolStripMenuItem.Text = "Leaf Decay";
            this.leafDecayToolStripMenuItem.Click += new System.EventHandler(this.leafDecayToolStripMenuItem_Click);
            // 
            // autpPhysicsToolStripMenuItem
            // 
            this.autpPhysicsToolStripMenuItem.Name = "autpPhysicsToolStripMenuItem";
            this.autpPhysicsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.autpPhysicsToolStripMenuItem.Text = "Auto Physics";
            this.autpPhysicsToolStripMenuItem.Click += new System.EventHandler(this.autpPhysicsToolStripMenuItem_Click);
            // 
            // loadingToolStripMenuItem
            // 
            this.loadingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unloadToolStripMenuItem1,
            this.loadOngotoToolStripMenuItem});
            this.loadingToolStripMenuItem.Name = "loadingToolStripMenuItem";
            this.loadingToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.loadingToolStripMenuItem.Text = "Loading";
            // 
            // unloadToolStripMenuItem1
            // 
            this.unloadToolStripMenuItem1.Name = "unloadToolStripMenuItem1";
            this.unloadToolStripMenuItem1.Size = new System.Drawing.Size(141, 22);
            this.unloadToolStripMenuItem1.Text = "Auto Unload";
            this.unloadToolStripMenuItem1.Click += new System.EventHandler(this.unloadToolStripMenuItem1_Click);
            // 
            // loadOngotoToolStripMenuItem
            // 
            this.loadOngotoToolStripMenuItem.Name = "loadOngotoToolStripMenuItem";
            this.loadOngotoToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.loadOngotoToolStripMenuItem.Text = "Load on /goto";
            this.loadOngotoToolStripMenuItem.Click += new System.EventHandler(this.loadOngotoToolStripMenuItem_Click);
            // 
            // miscToolStripMenuItem
            // 
            this.miscToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.animalAIToolStripMenuItem,
            this.survivalDeathToolStripMenuItem,
            this.killerBlocksToolStripMenuItem,
            this.instantBuildingToolStripMenuItem,
            this.rPChatToolStripMenuItem,
            this.gunsToolStripMenuItem});
            this.miscToolStripMenuItem.Name = "miscToolStripMenuItem";
            this.miscToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.miscToolStripMenuItem.Text = "Misc";
            // 
            // animalAIToolStripMenuItem
            // 
            this.animalAIToolStripMenuItem.Name = "animalAIToolStripMenuItem";
            this.animalAIToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.animalAIToolStripMenuItem.Text = "Animal AI";
            this.animalAIToolStripMenuItem.Click += new System.EventHandler(this.animalAIToolStripMenuItem_Click);
            // 
            // survivalDeathToolStripMenuItem
            // 
            this.survivalDeathToolStripMenuItem.Name = "survivalDeathToolStripMenuItem";
            this.survivalDeathToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.survivalDeathToolStripMenuItem.Text = "Survival Death";
            this.survivalDeathToolStripMenuItem.Click += new System.EventHandler(this.survivalDeathToolStripMenuItem_Click);
            // 
            // killerBlocksToolStripMenuItem
            // 
            this.killerBlocksToolStripMenuItem.Name = "killerBlocksToolStripMenuItem";
            this.killerBlocksToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.killerBlocksToolStripMenuItem.Text = "Killer Blocks";
            this.killerBlocksToolStripMenuItem.Click += new System.EventHandler(this.killerBlocksToolStripMenuItem_Click);
            // 
            // instantBuildingToolStripMenuItem
            // 
            this.instantBuildingToolStripMenuItem.Name = "instantBuildingToolStripMenuItem";
            this.instantBuildingToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.instantBuildingToolStripMenuItem.Text = "Instant Building";
            this.instantBuildingToolStripMenuItem.Click += new System.EventHandler(this.instantBuildingToolStripMenuItem_Click);
            // 
            // rPChatToolStripMenuItem
            // 
            this.rPChatToolStripMenuItem.Name = "rPChatToolStripMenuItem";
            this.rPChatToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.rPChatToolStripMenuItem.Text = "RP Chat";
            this.rPChatToolStripMenuItem.Click += new System.EventHandler(this.rPChatToolStripMenuItem_Click);
            // 
            // gunsToolStripMenuItem
            // 
            this.gunsToolStripMenuItem.Name = "gunsToolStripMenuItem";
            this.gunsToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.gunsToolStripMenuItem.Text = "Guns";
            this.gunsToolStripMenuItem.Click += new System.EventHandler(this.gunsToolStripMenuItem_Click);
            // 
            // actiondToolStripMenuItem
            // 
            this.actiondToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.reloadToolStripMenuItem,
            this.unloadToolStripMenuItem,
            this.moveAllToolStripMenuItem});
            this.actiondToolStripMenuItem.Name = "actiondToolStripMenuItem";
            this.actiondToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.actiondToolStripMenuItem.Text = "Actions";
            this.actiondToolStripMenuItem.Click += new System.EventHandler(this.actiondToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click_1);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.reloadToolStripMenuItem.Text = "Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // unloadToolStripMenuItem
            // 
            this.unloadToolStripMenuItem.Name = "unloadToolStripMenuItem";
            this.unloadToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.unloadToolStripMenuItem.Text = "Unload";
            this.unloadToolStripMenuItem.Click += new System.EventHandler(this.unloadToolStripMenuItem_Click_1);
            // 
            // moveAllToolStripMenuItem
            // 
            this.moveAllToolStripMenuItem.Name = "moveAllToolStripMenuItem";
            this.moveAllToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.moveAllToolStripMenuItem.Text = "Move All";
            this.moveAllToolStripMenuItem.Click += new System.EventHandler(this.moveAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(140, 6);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // playerStrip
            // 
            this.playerStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.whoisToolStripMenuItem,
            this.kickToolStripMenuItem,
            this.banToolStripMenuItem,
            this.voiceToolStripMenuItem,
            this.clonesToolStripMenuItem,
            this.promoteToolStripMenuItem,
            this.demoteToolStripMenuItem});
            this.playerStrip.Name = "playerStrip";
            this.playerStrip.Size = new System.Drawing.Size(121, 158);
            // 
            // whoisToolStripMenuItem
            // 
            this.whoisToolStripMenuItem.Name = "whoisToolStripMenuItem";
            this.whoisToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.whoisToolStripMenuItem.Text = "Whois";
            this.whoisToolStripMenuItem.Click += new System.EventHandler(this.whoisToolStripMenuItem_Click);
            // 
            // kickToolStripMenuItem
            // 
            this.kickToolStripMenuItem.Name = "kickToolStripMenuItem";
            this.kickToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.kickToolStripMenuItem.Text = "Kick";
            this.kickToolStripMenuItem.Click += new System.EventHandler(this.kickToolStripMenuItem_Click);
            // 
            // banToolStripMenuItem
            // 
            this.banToolStripMenuItem.Name = "banToolStripMenuItem";
            this.banToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.banToolStripMenuItem.Text = "Ban";
            this.banToolStripMenuItem.Click += new System.EventHandler(this.banToolStripMenuItem_Click);
            // 
            // voiceToolStripMenuItem
            // 
            this.voiceToolStripMenuItem.Name = "voiceToolStripMenuItem";
            this.voiceToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.voiceToolStripMenuItem.Text = "Voice";
            this.voiceToolStripMenuItem.Click += new System.EventHandler(this.voiceToolStripMenuItem_Click);
            // 
            // clonesToolStripMenuItem
            // 
            this.clonesToolStripMenuItem.Name = "clonesToolStripMenuItem";
            this.clonesToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.clonesToolStripMenuItem.Text = "Clones";
            this.clonesToolStripMenuItem.Click += new System.EventHandler(this.clonesToolStripMenuItem_Click);
            // 
            // promoteToolStripMenuItem
            // 
            this.promoteToolStripMenuItem.Name = "promoteToolStripMenuItem";
            this.promoteToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.promoteToolStripMenuItem.Text = "Promote";
            this.promoteToolStripMenuItem.Click += new System.EventHandler(this.promoteToolStripMenuItem_Click);
            // 
            // demoteToolStripMenuItem
            // 
            this.demoteToolStripMenuItem.Name = "demoteToolStripMenuItem";
            this.demoteToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.demoteToolStripMenuItem.Text = "Demote";
            this.demoteToolStripMenuItem.Click += new System.EventHandler(this.demoteToolStripMenuItem_Click);
            // 
            // iconContext
            // 
            this.iconContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openConsole,
            this.shutdownServer,
            this.restartServerToolStripMenuItem});
            this.iconContext.Name = "iconContext";
            this.iconContext.Size = new System.Drawing.Size(164, 70);
            // 
            // openConsole
            // 
            this.openConsole.Name = "openConsole";
            this.openConsole.Size = new System.Drawing.Size(163, 22);
            this.openConsole.Text = "Open Console";
            this.openConsole.Click += new System.EventHandler(this.openConsole_Click);
            // 
            // shutdownServer
            // 
            this.shutdownServer.Name = "shutdownServer";
            this.shutdownServer.Size = new System.Drawing.Size(163, 22);
            this.shutdownServer.Text = "Shutdown Server";
            this.shutdownServer.Click += new System.EventHandler(this.shutdownServer_Click);
            // 
            // restartServerToolStripMenuItem
            // 
            this.restartServerToolStripMenuItem.Name = "restartServerToolStripMenuItem";
            this.restartServerToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.restartServerToolStripMenuItem.Text = "Restart Server";
            this.restartServerToolStripMenuItem.Click += new System.EventHandler(this.restartServerToolStripMenuItem_Click);
            // 
            // btnProperties
            // 
            this.btnProperties.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProperties.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProperties.Location = new System.Drawing.Point(447, 7);
            this.btnProperties.Name = "btnProperties";
            this.btnProperties.Size = new System.Drawing.Size(246, 23);
            this.btnProperties.TabIndex = 34;
            this.btnProperties.Text = "Map Viewer";
            this.btnProperties.UseVisualStyleBackColor = true;
            this.btnProperties.Click += new System.EventHandler(this.btnProperties_Click_1);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(612, 426);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 23);
            this.btnClose.TabIndex = 35;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // Restart
            // 
            this.Restart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Restart.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Restart.Location = new System.Drawing.Point(447, 426);
            this.Restart.Name = "Restart";
            this.Restart.Size = new System.Drawing.Size(63, 23);
            this.Restart.TabIndex = 36;
            this.Restart.Text = "Restart";
            this.Restart.UseVisualStyleBackColor = true;
            this.Restart.Click += new System.EventHandler(this.Restart_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage5.Controls.Add(this.label3);
            this.tabPage5.Controls.Add(this.dateTimePicker1);
            this.tabPage5.Controls.Add(this.LogsTxtBox);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(698, 488);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Logs";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "View logs from:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(92, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1.TabIndex = 2;
            this.dateTimePicker1.Value = new System.DateTime(2011, 7, 20, 18, 31, 50, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.DatePicker1_ValueChanged);
            // 
            // LogsTxtBox
            // 
            this.LogsTxtBox.BackColor = System.Drawing.SystemColors.Window;
            this.LogsTxtBox.Location = new System.Drawing.Point(3, 32);
            this.LogsTxtBox.Name = "LogsTxtBox";
            this.LogsTxtBox.ReadOnly = true;
            this.LogsTxtBox.Size = new System.Drawing.Size(687, 453);
            this.LogsTxtBox.TabIndex = 0;
            this.LogsTxtBox.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Transparent;
            this.tabPage3.Controls.Add(this.txtErrors);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(698, 488);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Errors";
            // 
            // txtErrors
            // 
            this.txtErrors.BackColor = System.Drawing.Color.White;
            this.txtErrors.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtErrors.Location = new System.Drawing.Point(7, 6);
            this.txtErrors.Multiline = true;
            this.txtErrors.Name = "txtErrors";
            this.txtErrors.ReadOnly = true;
            this.txtErrors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtErrors.Size = new System.Drawing.Size(683, 471);
            this.txtErrors.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.txtChangelog);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(698, 488);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Changelog";
            // 
            // txtChangelog
            // 
            this.txtChangelog.BackColor = System.Drawing.Color.White;
            this.txtChangelog.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtChangelog.Location = new System.Drawing.Point(7, 6);
            this.txtChangelog.Multiline = true;
            this.txtChangelog.Name = "txtChangelog";
            this.txtChangelog.ReadOnly = true;
            this.txtChangelog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChangelog.Size = new System.Drawing.Size(683, 471);
            this.txtChangelog.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.Transparent;
            this.tabPage4.Controls.Add(this.txtSystem);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(698, 488);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "System";
            // 
            // txtSystem
            // 
            this.txtSystem.BackColor = System.Drawing.Color.White;
            this.txtSystem.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtSystem.Location = new System.Drawing.Point(7, 6);
            this.txtSystem.Multiline = true;
            this.txtSystem.Name = "txtSystem";
            this.txtSystem.ReadOnly = true;
            this.txtSystem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSystem.Size = new System.Drawing.Size(683, 471);
            this.txtSystem.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.Unloadempty_button);
            this.tabPage1.Controls.Add(this.killphysics_button);
            this.tabPage1.Controls.Add(this.button_saveall);
            this.tabPage1.Controls.Add(this.Restart);
            this.tabPage1.Controls.Add(this.gBCommands);
            this.tabPage1.Controls.Add(this.btnClose);
            this.tabPage1.Controls.Add(this.dgvMaps);
            this.tabPage1.Controls.Add(this.btnProperties);
            this.tabPage1.Controls.Add(this.gBChat);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtCommands);
            this.tabPage1.Controls.Add(this.txtInput);
            this.tabPage1.Controls.Add(this.txtUrl);
            this.tabPage1.Controls.Add(this.dgvPlayers);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(698, 488);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(519, 426);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 42;
            this.button1.Text = "Properties";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Unloadempty_button
            // 
            this.Unloadempty_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Unloadempty_button.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Unloadempty_button.Location = new System.Drawing.Point(612, 229);
            this.Unloadempty_button.Name = "Unloadempty_button";
            this.Unloadempty_button.Size = new System.Drawing.Size(81, 23);
            this.Unloadempty_button.TabIndex = 41;
            this.Unloadempty_button.Text = "Unload Empty";
            this.Unloadempty_button.UseVisualStyleBackColor = true;
            this.Unloadempty_button.Click += new System.EventHandler(this.Unloadempty_button_Click);
            // 
            // killphysics_button
            // 
            this.killphysics_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.killphysics_button.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.killphysics_button.Location = new System.Drawing.Point(519, 229);
            this.killphysics_button.Name = "killphysics_button";
            this.killphysics_button.Size = new System.Drawing.Size(88, 23);
            this.killphysics_button.TabIndex = 40;
            this.killphysics_button.Text = "Kill All Physics";
            this.killphysics_button.UseVisualStyleBackColor = true;
            this.killphysics_button.Click += new System.EventHandler(this.killphysics_button_Click);
            // 
            // button_saveall
            // 
            this.button_saveall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_saveall.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_saveall.Location = new System.Drawing.Point(447, 229);
            this.button_saveall.Name = "button_saveall";
            this.button_saveall.Size = new System.Drawing.Size(63, 23);
            this.button_saveall.TabIndex = 39;
            this.button_saveall.Text = "Save All";
            this.button_saveall.UseVisualStyleBackColor = true;
            this.button_saveall.Click += new System.EventHandler(this.button_saveall_Click);
            // 
            // gBCommands
            // 
            this.gBCommands.Controls.Add(this.txtCommandsUsed);
            this.gBCommands.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBCommands.Location = new System.Drawing.Point(13, 326);
            this.gBCommands.Name = "gBCommands";
            this.gBCommands.Size = new System.Drawing.Size(428, 123);
            this.gBCommands.TabIndex = 34;
            this.gBCommands.TabStop = false;
            this.gBCommands.Text = "Commands";
            // 
            // txtCommandsUsed
            // 
            this.txtCommandsUsed.BackColor = System.Drawing.Color.White;
            this.txtCommandsUsed.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtCommandsUsed.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommandsUsed.Location = new System.Drawing.Point(9, 16);
            this.txtCommandsUsed.Multiline = true;
            this.txtCommandsUsed.Name = "txtCommandsUsed";
            this.txtCommandsUsed.ReadOnly = true;
            this.txtCommandsUsed.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCommandsUsed.Size = new System.Drawing.Size(413, 100);
            this.txtCommandsUsed.TabIndex = 0;
            // 
            // dgvMaps
            // 
            this.dgvMaps.AllowUserToAddRows = false;
            this.dgvMaps.AllowUserToDeleteRows = false;
            this.dgvMaps.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMaps.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMaps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaps.ContextMenuStrip = this.mapsStrip;
            this.dgvMaps.Location = new System.Drawing.Point(447, 258);
            this.dgvMaps.MultiSelect = false;
            this.dgvMaps.Name = "dgvMaps";
            this.dgvMaps.ReadOnly = true;
            this.dgvMaps.RowHeadersVisible = false;
            this.dgvMaps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaps.Size = new System.Drawing.Size(246, 150);
            this.dgvMaps.TabIndex = 38;
            this.dgvMaps.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaps_CellContentClick);
            // 
            // gBChat
            // 
            this.gBChat.Controls.Add(this.txtLog);
            this.gBChat.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBChat.Location = new System.Drawing.Point(13, 33);
            this.gBChat.Name = "gBChat";
            this.gBChat.Size = new System.Drawing.Size(428, 287);
            this.gBChat.TabIndex = 32;
            this.gBChat.TabStop = false;
            this.gBChat.Text = "Chat";
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.SystemColors.Window;
            this.txtLog.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtLog.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(6, 19);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(413, 262);
            this.txtLog.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(444, 462);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Command:";
            // 
            // txtCommands
            // 
            this.txtCommands.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommands.Location = new System.Drawing.Point(507, 459);
            this.txtCommands.Name = "txtCommands";
            this.txtCommands.Size = new System.Drawing.Size(183, 21);
            this.txtCommands.TabIndex = 28;
            this.txtCommands.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCommands_KeyDown);
            // 
            // txtInput
            // 
            this.txtInput.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(57, 459);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(375, 21);
            this.txtInput.TabIndex = 27;
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
            //
            //
            //
            //
            // HERE SOCCER THIS IS WHERE THE URL IS 
            // txtUrl
            //
            //
            //
            // 
            //
            this.txtUrl.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtUrl.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUrl.Location = new System.Drawing.Point(13, 7);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.ReadOnly = true;
            this.txtUrl.Size = new System.Drawing.Size(428, 21);
            this.txtUrl.TabIndex = 25;
            this.txtUrl.DoubleClick += new System.EventHandler(this.txtUrl_DoubleClick);
            // 
            // dgvPlayers
            // 
            this.dgvPlayers.AllowUserToAddRows = false;
            this.dgvPlayers.AllowUserToDeleteRows = false;
            this.dgvPlayers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPlayers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlayers.ContextMenuStrip = this.playerStrip;
            this.dgvPlayers.Location = new System.Drawing.Point(447, 33);
            this.dgvPlayers.MultiSelect = false;
            this.dgvPlayers.Name = "dgvPlayers";
            this.dgvPlayers.ReadOnly = true;
            this.dgvPlayers.RowHeadersVisible = false;
            this.dgvPlayers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlayers.Size = new System.Drawing.Size(246, 190);
            this.dgvPlayers.TabIndex = 37;
            this.dgvPlayers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlayers_CellContentClick);
            this.dgvPlayers.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvPlayers_RowPrePaint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 462);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Chat:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.Chat);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControl1.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.tabControl1.Location = new System.Drawing.Point(1, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(706, 514);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.panel3);
            this.tabPage6.Controls.Add(this.panel2);
            this.tabPage6.Controls.Add(this.panel1);
            this.tabPage6.Controls.Add(this.dgvMapsTab);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(698, 488);
            this.tabPage6.TabIndex = 6;
            this.tabPage6.Text = "Maps";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.UnloadedList);
            this.panel3.Controls.Add(this.ldmapbt);
            this.panel3.Location = new System.Drawing.Point(7, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(164, 207);
            this.panel3.TabIndex = 49;
            // 
            // UnloadedList
            // 
            this.UnloadedList.FormattingEnabled = true;
            this.UnloadedList.Location = new System.Drawing.Point(4, 4);
            this.UnloadedList.Name = "UnloadedList";
            this.UnloadedList.Size = new System.Drawing.Size(155, 160);
            this.UnloadedList.TabIndex = 1;
            this.UnloadedList.SelectedIndexChanged += new System.EventHandler(this.UnloadedList_SelectedIndexChanged);
            // 
            // ldmapbt
            // 
            this.ldmapbt.Location = new System.Drawing.Point(4, 168);
            this.ldmapbt.Name = "ldmapbt";
            this.ldmapbt.Size = new System.Drawing.Size(155, 35);
            this.ldmapbt.TabIndex = 0;
            this.ldmapbt.Text = "Load Map";
            this.ldmapbt.UseVisualStyleBackColor = true;
            this.ldmapbt.Click += new System.EventHandler(this.ldmapbt_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.AutoLoadChk);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.drownNumeric);
            this.panel2.Controls.Add(this.Fallnumeric);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.Aicombo);
            this.panel2.Controls.Add(this.edgewaterchk);
            this.panel2.Controls.Add(this.grasschk);
            this.panel2.Controls.Add(this.finitechk);
            this.panel2.Controls.Add(this.Killerbloxchk);
            this.panel2.Controls.Add(this.SurvivalStyleDeathchk);
            this.panel2.Controls.Add(this.chatlvlchk);
            this.panel2.Controls.Add(this.physlvlnumeric);
            this.panel2.Controls.Add(this.MOTDtxt);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.SaveMap);
            this.panel2.Location = new System.Drawing.Point(318, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(372, 207);
            this.panel2.TabIndex = 48;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // AutoLoadChk
            // 
            this.AutoLoadChk.AutoSize = true;
            this.AutoLoadChk.Location = new System.Drawing.Point(76, 118);
            this.AutoLoadChk.Name = "AutoLoadChk";
            this.AutoLoadChk.Size = new System.Drawing.Size(15, 14);
            this.AutoLoadChk.TabIndex = 38;
            this.AutoLoadChk.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(4, 118);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(58, 13);
            this.label23.TabIndex = 37;
            this.label23.Text = "Auto-Load:";
            // 
            // drownNumeric
            // 
            this.drownNumeric.Location = new System.Drawing.Point(281, 144);
            this.drownNumeric.Name = "drownNumeric";
            this.drownNumeric.Size = new System.Drawing.Size(77, 21);
            this.drownNumeric.TabIndex = 36;
            // 
            // Fallnumeric
            // 
            this.Fallnumeric.Location = new System.Drawing.Point(281, 116);
            this.Fallnumeric.Name = "Fallnumeric";
            this.Fallnumeric.Size = new System.Drawing.Size(77, 21);
            this.Fallnumeric.TabIndex = 35;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(234, 142);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(41, 13);
            this.label22.TabIndex = 34;
            this.label22.Text = "Drown:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(234, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Fall:";
            // 
            // Aicombo
            // 
            this.Aicombo.FormattingEnabled = true;
            this.Aicombo.Items.AddRange(new object[] {
            "Hunt",
            "Flee"});
            this.Aicombo.Location = new System.Drawing.Point(29, 144);
            this.Aicombo.Name = "Aicombo";
            this.Aicombo.Size = new System.Drawing.Size(62, 21);
            this.Aicombo.TabIndex = 30;
            // 
            // edgewaterchk
            // 
            this.edgewaterchk.AutoSize = true;
            this.edgewaterchk.Location = new System.Drawing.Point(344, 87);
            this.edgewaterchk.Name = "edgewaterchk";
            this.edgewaterchk.Size = new System.Drawing.Size(15, 14);
            this.edgewaterchk.TabIndex = 29;
            this.edgewaterchk.UseVisualStyleBackColor = true;
            // 
            // grasschk
            // 
            this.grasschk.AutoSize = true;
            this.grasschk.Location = new System.Drawing.Point(76, 61);
            this.grasschk.Name = "grasschk";
            this.grasschk.Size = new System.Drawing.Size(15, 14);
            this.grasschk.TabIndex = 28;
            this.grasschk.UseVisualStyleBackColor = true;
            // 
            // finitechk
            // 
            this.finitechk.AutoSize = true;
            this.finitechk.Location = new System.Drawing.Point(343, 59);
            this.finitechk.Name = "finitechk";
            this.finitechk.Size = new System.Drawing.Size(15, 14);
            this.finitechk.TabIndex = 27;
            this.finitechk.UseVisualStyleBackColor = true;
            // 
            // Killerbloxchk
            // 
            this.Killerbloxchk.AutoSize = true;
            this.Killerbloxchk.Location = new System.Drawing.Point(343, 8);
            this.Killerbloxchk.Name = "Killerbloxchk";
            this.Killerbloxchk.Size = new System.Drawing.Size(15, 14);
            this.Killerbloxchk.TabIndex = 26;
            this.Killerbloxchk.UseVisualStyleBackColor = true;
            // 
            // SurvivalStyleDeathchk
            // 
            this.SurvivalStyleDeathchk.AutoSize = true;
            this.SurvivalStyleDeathchk.Location = new System.Drawing.Point(343, 34);
            this.SurvivalStyleDeathchk.Name = "SurvivalStyleDeathchk";
            this.SurvivalStyleDeathchk.Size = new System.Drawing.Size(15, 14);
            this.SurvivalStyleDeathchk.TabIndex = 25;
            this.SurvivalStyleDeathchk.UseVisualStyleBackColor = true;
            // 
            // chatlvlchk
            // 
            this.chatlvlchk.AutoSize = true;
            this.chatlvlchk.Location = new System.Drawing.Point(76, 87);
            this.chatlvlchk.Name = "chatlvlchk";
            this.chatlvlchk.Size = new System.Drawing.Size(15, 14);
            this.chatlvlchk.TabIndex = 24;
            this.chatlvlchk.UseVisualStyleBackColor = true;
            // 
            // physlvlnumeric
            // 
            this.physlvlnumeric.Location = new System.Drawing.Point(76, 36);
            this.physlvlnumeric.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.physlvlnumeric.Name = "physlvlnumeric";
            this.physlvlnumeric.Size = new System.Drawing.Size(106, 21);
            this.physlvlnumeric.TabIndex = 22;
            // 
            // MOTDtxt
            // 
            this.MOTDtxt.Location = new System.Drawing.Point(76, 8);
            this.MOTDtxt.Name = "MOTDtxt";
            this.MOTDtxt.Size = new System.Drawing.Size(152, 21);
            this.MOTDtxt.TabIndex = 21;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(4, 146);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(19, 13);
            this.label21.TabIndex = 20;
            this.label21.Text = "AI:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(234, 88);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(89, 13);
            this.label20.TabIndex = 19;
            this.label20.Text = "Edge water flows:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(234, 60);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(68, 13);
            this.label19.TabIndex = 18;
            this.label19.Text = "Finite Liquid:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(234, 34);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(103, 13);
            this.label18.TabIndex = 17;
            this.label18.Text = "Survival-style death:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(235, 8);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 13);
            this.label17.TabIndex = 16;
            this.label17.Text = "Killer blocks:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(4, 62);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 13);
            this.label16.TabIndex = 15;
            this.label16.Text = "Grass:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(4, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 13);
            this.label15.TabIndex = 14;
            this.label15.Text = "MOTD:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 88);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "World-Chat:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Physics Level:";
            // 
            // SaveMap
            // 
            this.SaveMap.Location = new System.Drawing.Point(3, 168);
            this.SaveMap.Name = "SaveMap";
            this.SaveMap.Size = new System.Drawing.Size(364, 35);
            this.SaveMap.TabIndex = 9;
            this.SaveMap.Text = "Save Map Properties";
            this.SaveMap.UseVisualStyleBackColor = true;
            this.SaveMap.Click += new System.EventHandler(this.SaveMap_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.seedtxtbox);
            this.panel1.Controls.Add(this.label34);
            this.panel1.Controls.Add(this.xtxtbox);
            this.panel1.Controls.Add(this.ytxtbox);
            this.panel1.Controls.Add(this.ztxtbox);
            this.panel1.Controls.Add(this.nametxtbox);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.maptypecombo);
            this.panel1.Controls.Add(this.CreateNewMap);
            this.panel1.Location = new System.Drawing.Point(177, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(135, 207);
            this.panel1.TabIndex = 45;
            // 
            // seedtxtbox
            // 
            this.seedtxtbox.Location = new System.Drawing.Point(45, 142);
            this.seedtxtbox.Name = "seedtxtbox";
            this.seedtxtbox.Size = new System.Drawing.Size(84, 21);
            this.seedtxtbox.TabIndex = 16;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(4, 146);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(33, 13);
            this.label34.TabIndex = 15;
            this.label34.Text = "Seed:";
            // 
            // xtxtbox
            // 
            this.xtxtbox.FormattingEnabled = true;
            this.xtxtbox.Items.AddRange(new object[] {
            "16",
            "32",
            "64",
            "128",
            "256",
            "512",
            "1024"});
            this.xtxtbox.Location = new System.Drawing.Point(45, 34);
            this.xtxtbox.Name = "xtxtbox";
            this.xtxtbox.Size = new System.Drawing.Size(84, 21);
            this.xtxtbox.TabIndex = 14;
            // 
            // ytxtbox
            // 
            this.ytxtbox.FormattingEnabled = true;
            this.ytxtbox.Items.AddRange(new object[] {
            "16",
            "32",
            "64",
            "128",
            "256",
            "512",
            "1024"});
            this.ytxtbox.Location = new System.Drawing.Point(45, 61);
            this.ytxtbox.Name = "ytxtbox";
            this.ytxtbox.Size = new System.Drawing.Size(84, 21);
            this.ytxtbox.TabIndex = 13;
            // 
            // ztxtbox
            // 
            this.ztxtbox.FormattingEnabled = true;
            this.ztxtbox.Items.AddRange(new object[] {
            "16",
            "32",
            "64",
            "128",
            "256",
            "512",
            "1024"});
            this.ztxtbox.Location = new System.Drawing.Point(45, 88);
            this.ztxtbox.Name = "ztxtbox";
            this.ztxtbox.Size = new System.Drawing.Size(84, 21);
            this.ztxtbox.TabIndex = 12;
            // 
            // nametxtbox
            // 
            this.nametxtbox.Location = new System.Drawing.Point(45, 7);
            this.nametxtbox.Name = "nametxtbox";
            this.nametxtbox.Size = new System.Drawing.Size(84, 21);
            this.nametxtbox.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Size Y:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Size Z:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Size X:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Type:";
            // 
            // maptypecombo
            // 
            this.maptypecombo.FormattingEnabled = true;
            this.maptypecombo.Items.AddRange(new object[] {
            "Island",
            "Mountains",
            "Forest",
            "Ocean",
            "Flat",
            "Pixel",
            "Desert",
            "Space",
            "Rainbow",
            "Hell"});
            this.maptypecombo.Location = new System.Drawing.Point(45, 115);
            this.maptypecombo.Name = "maptypecombo";
            this.maptypecombo.Size = new System.Drawing.Size(84, 21);
            this.maptypecombo.TabIndex = 1;
            // 
            // CreateNewMap
            // 
            this.CreateNewMap.Location = new System.Drawing.Point(4, 168);
            this.CreateNewMap.Name = "CreateNewMap";
            this.CreateNewMap.Size = new System.Drawing.Size(125, 35);
            this.CreateNewMap.TabIndex = 0;
            this.CreateNewMap.Text = "Create New Map";
            this.CreateNewMap.UseVisualStyleBackColor = true;
            this.CreateNewMap.Click += new System.EventHandler(this.CreateNewMap_Click);
            // 
            // dgvMapsTab
            // 
            this.dgvMapsTab.AllowUserToAddRows = false;
            this.dgvMapsTab.AllowUserToDeleteRows = false;
            this.dgvMapsTab.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMapsTab.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMapsTab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMapsTab.Location = new System.Drawing.Point(7, 220);
            this.dgvMapsTab.MultiSelect = false;
            this.dgvMapsTab.Name = "dgvMapsTab";
            this.dgvMapsTab.ReadOnly = true;
            this.dgvMapsTab.RowHeadersVisible = false;
            this.dgvMapsTab.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMapsTab.Size = new System.Drawing.Size(683, 262);
            this.dgvMapsTab.TabIndex = 39;
            this.dgvMapsTab.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMapsTab_CellClick);
            this.dgvMapsTab.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMapsTab_CellClick);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.PlayersTextBox);
            this.tabPage7.Controls.Add(this.PlyersListBox);
            this.tabPage7.Controls.Add(this.StatusTxt);
            this.tabPage7.Controls.Add(this.label25);
            this.tabPage7.Controls.Add(this.LoggedinForTxt);
            this.tabPage7.Controls.Add(this.label31);
            this.tabPage7.Controls.Add(this.Kickstxt);
            this.tabPage7.Controls.Add(this.label30);
            this.tabPage7.Controls.Add(this.TimesLoggedInTxt);
            this.tabPage7.Controls.Add(this.label29);
            this.tabPage7.Controls.Add(this.Blockstxt);
            this.tabPage7.Controls.Add(this.label28);
            this.tabPage7.Controls.Add(this.DeathsTxt);
            this.tabPage7.Controls.Add(this.label27);
            this.tabPage7.Controls.Add(this.IPtxt);
            this.tabPage7.Controls.Add(this.label26);
            this.tabPage7.Controls.Add(this.panel4);
            this.tabPage7.Controls.Add(this.RankTxt);
            this.tabPage7.Controls.Add(this.label24);
            this.tabPage7.Controls.Add(this.MapTxt);
            this.tabPage7.Controls.Add(this.label14);
            this.tabPage7.Controls.Add(this.NameTxtPlayersTab);
            this.tabPage7.Controls.Add(this.label12);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(698, 488);
            this.tabPage7.TabIndex = 7;
            this.tabPage7.Text = "Players";
            // 
            // PlayersTextBox
            // 
            this.PlayersTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.PlayersTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.PlayersTextBox.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayersTextBox.Location = new System.Drawing.Point(306, 304);
            this.PlayersTextBox.Multiline = true;
            this.PlayersTextBox.Name = "PlayersTextBox";
            this.PlayersTextBox.ReadOnly = true;
            this.PlayersTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.PlayersTextBox.Size = new System.Drawing.Size(386, 173);
            this.PlayersTextBox.TabIndex = 63;
            // 
            // PlyersListBox
            // 
            this.PlyersListBox.FormattingEnabled = true;
            this.PlyersListBox.Location = new System.Drawing.Point(8, 304);
            this.PlyersListBox.Name = "PlyersListBox";
            this.PlyersListBox.Size = new System.Drawing.Size(291, 173);
            this.PlyersListBox.TabIndex = 62;
            this.PlyersListBox.Click += new System.EventHandler(this.PlyersListBox_Click);
            // 
            // StatusTxt
            // 
            this.StatusTxt.Location = new System.Drawing.Point(612, 4);
            this.StatusTxt.Name = "StatusTxt";
            this.StatusTxt.ReadOnly = true;
            this.StatusTxt.Size = new System.Drawing.Size(80, 21);
            this.StatusTxt.TabIndex = 61;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(566, 7);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(40, 13);
            this.label25.TabIndex = 60;
            this.label25.Text = "Status:";
            // 
            // LoggedinForTxt
            // 
            this.LoggedinForTxt.Location = new System.Drawing.Point(537, 31);
            this.LoggedinForTxt.Name = "LoggedinForTxt";
            this.LoggedinForTxt.ReadOnly = true;
            this.LoggedinForTxt.Size = new System.Drawing.Size(76, 21);
            this.LoggedinForTxt.TabIndex = 59;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(505, 34);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(25, 13);
            this.label31.TabIndex = 58;
            this.label31.Text = "For:";
            // 
            // Kickstxt
            // 
            this.Kickstxt.Location = new System.Drawing.Point(658, 31);
            this.Kickstxt.Name = "Kickstxt";
            this.Kickstxt.ReadOnly = true;
            this.Kickstxt.Size = new System.Drawing.Size(34, 21);
            this.Kickstxt.TabIndex = 57;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(619, 34);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(34, 13);
            this.label30.TabIndex = 56;
            this.label30.Text = "Kicks:";
            // 
            // TimesLoggedInTxt
            // 
            this.TimesLoggedInTxt.Location = new System.Drawing.Point(412, 31);
            this.TimesLoggedInTxt.Name = "TimesLoggedInTxt";
            this.TimesLoggedInTxt.ReadOnly = true;
            this.TimesLoggedInTxt.Size = new System.Drawing.Size(92, 21);
            this.TimesLoggedInTxt.TabIndex = 55;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(352, 34);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(54, 13);
            this.label29.TabIndex = 54;
            this.label29.Text = "Logged in:";
            // 
            // Blockstxt
            // 
            this.Blockstxt.Location = new System.Drawing.Point(281, 31);
            this.Blockstxt.Name = "Blockstxt";
            this.Blockstxt.ReadOnly = true;
            this.Blockstxt.Size = new System.Drawing.Size(65, 21);
            this.Blockstxt.TabIndex = 53;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(228, 34);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(52, 13);
            this.label28.TabIndex = 52;
            this.label28.Text = "Modified:";
            // 
            // DeathsTxt
            // 
            this.DeathsTxt.Location = new System.Drawing.Point(188, 31);
            this.DeathsTxt.Name = "DeathsTxt";
            this.DeathsTxt.ReadOnly = true;
            this.DeathsTxt.Size = new System.Drawing.Size(34, 21);
            this.DeathsTxt.TabIndex = 51;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(137, 34);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(44, 13);
            this.label27.TabIndex = 50;
            this.label27.Text = "Deaths:";
            // 
            // IPtxt
            // 
            this.IPtxt.Location = new System.Drawing.Point(42, 31);
            this.IPtxt.Name = "IPtxt";
            this.IPtxt.ReadOnly = true;
            this.IPtxt.Size = new System.Drawing.Size(89, 21);
            this.IPtxt.TabIndex = 49;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(5, 34);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(19, 13);
            this.label26.TabIndex = 48;
            this.label26.Text = "IP:";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.SpawnBt);
            this.panel4.Controls.Add(this.UndoTxt);
            this.panel4.Controls.Add(this.UndoBt);
            this.panel4.Controls.Add(this.SlapBt);
            this.panel4.Controls.Add(this.SendRulesTxt);
            this.panel4.Controls.Add(this.MimicORSendCmdTxt);
            this.panel4.Controls.Add(this.MimicORSendCmdBt);
            this.panel4.Controls.Add(this.KillBt);
            this.panel4.Controls.Add(this.JailBt);
            this.panel4.Controls.Add(this.DemoteBt);
            this.panel4.Controls.Add(this.PromoteBt);
            this.panel4.Controls.Add(this.LoginTxt);
            this.panel4.Controls.Add(this.LogoutTxt);
            this.panel4.Controls.Add(this.TitleTxt);
            this.panel4.Controls.Add(this.ColorCombo);
            this.panel4.Controls.Add(this.ColorBt);
            this.panel4.Controls.Add(this.TitleBt);
            this.panel4.Controls.Add(this.LogoutBt);
            this.panel4.Controls.Add(this.LoginBt);
            this.panel4.Controls.Add(this.FreezeBt);
            this.panel4.Controls.Add(this.VoiceBt);
            this.panel4.Controls.Add(this.JokerBt);
            this.panel4.Controls.Add(this.WarnBt);
            this.panel4.Controls.Add(this.MessageBt);
            this.panel4.Controls.Add(this.PLayersMessageTxt);
            this.panel4.Controls.Add(this.HideBt);
            this.panel4.Controls.Add(this.IPBanBt);
            this.panel4.Controls.Add(this.BanBt);
            this.panel4.Controls.Add(this.KickBt);
            this.panel4.Controls.Add(this.MapCombo);
            this.panel4.Controls.Add(this.MapBt);
            this.panel4.Controls.Add(this.MuteBt);
            this.panel4.Location = new System.Drawing.Point(8, 59);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(684, 235);
            this.panel4.TabIndex = 47;
            // 
            // SpawnBt
            // 
            this.SpawnBt.Location = new System.Drawing.Point(553, 148);
            this.SpawnBt.Name = "SpawnBt";
            this.SpawnBt.Size = new System.Drawing.Size(122, 23);
            this.SpawnBt.TabIndex = 43;
            this.SpawnBt.Text = "Spawn";
            this.SpawnBt.UseVisualStyleBackColor = true;
            this.SpawnBt.Click += new System.EventHandler(this.SpawnBt_Click);
            // 
            // UndoTxt
            // 
            this.UndoTxt.Location = new System.Drawing.Point(131, 148);
            this.UndoTxt.Name = "UndoTxt";
            this.UndoTxt.Size = new System.Drawing.Size(288, 21);
            this.UndoTxt.TabIndex = 42;
            this.UndoTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UndoTxt_KeyDown);
            // 
            // UndoBt
            // 
            this.UndoBt.Location = new System.Drawing.Point(4, 148);
            this.UndoBt.Name = "UndoBt";
            this.UndoBt.Size = new System.Drawing.Size(121, 23);
            this.UndoBt.TabIndex = 41;
            this.UndoBt.Text = "Undo:";
            this.UndoBt.UseVisualStyleBackColor = true;
            this.UndoBt.Click += new System.EventHandler(this.UndoBt_Click);
            // 
            // SlapBt
            // 
            this.SlapBt.Location = new System.Drawing.Point(425, 148);
            this.SlapBt.Name = "SlapBt";
            this.SlapBt.Size = new System.Drawing.Size(122, 23);
            this.SlapBt.TabIndex = 40;
            this.SlapBt.Text = "Slap";
            this.SlapBt.UseVisualStyleBackColor = true;
            this.SlapBt.Click += new System.EventHandler(this.SlapBt_Click);
            // 
            // SendRulesTxt
            // 
            this.SendRulesTxt.Location = new System.Drawing.Point(553, 119);
            this.SendRulesTxt.Name = "SendRulesTxt";
            this.SendRulesTxt.Size = new System.Drawing.Size(122, 23);
            this.SendRulesTxt.TabIndex = 39;
            this.SendRulesTxt.Text = "Send Rules";
            this.SendRulesTxt.UseVisualStyleBackColor = true;
            this.SendRulesTxt.Click += new System.EventHandler(this.SendRulesTxt_Click);
            // 
            // MimicORSendCmdTxt
            // 
            this.MimicORSendCmdTxt.Location = new System.Drawing.Point(132, 207);
            this.MimicORSendCmdTxt.Name = "MimicORSendCmdTxt";
            this.MimicORSendCmdTxt.Size = new System.Drawing.Size(543, 21);
            this.MimicORSendCmdTxt.TabIndex = 38;
            this.MimicORSendCmdTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MimicORSendCmdTxt_KeyDown);
            // 
            // MimicORSendCmdBt
            // 
            this.MimicORSendCmdBt.Location = new System.Drawing.Point(3, 206);
            this.MimicORSendCmdBt.Name = "MimicORSendCmdBt";
            this.MimicORSendCmdBt.Size = new System.Drawing.Size(122, 23);
            this.MimicORSendCmdBt.TabIndex = 37;
            this.MimicORSendCmdBt.Text = "Mimic/Cmd:";
            this.MimicORSendCmdBt.UseVisualStyleBackColor = true;
            this.MimicORSendCmdBt.Click += new System.EventHandler(this.MimicORSendCmdBt_Click);
            // 
            // KillBt
            // 
            this.KillBt.Location = new System.Drawing.Point(425, 89);
            this.KillBt.Name = "KillBt";
            this.KillBt.Size = new System.Drawing.Size(122, 23);
            this.KillBt.TabIndex = 36;
            this.KillBt.Text = "Kill";
            this.KillBt.UseVisualStyleBackColor = true;
            this.KillBt.Click += new System.EventHandler(this.KillBt_Click);
            // 
            // JailBt
            // 
            this.JailBt.Location = new System.Drawing.Point(425, 119);
            this.JailBt.Name = "JailBt";
            this.JailBt.Size = new System.Drawing.Size(122, 23);
            this.JailBt.TabIndex = 34;
            this.JailBt.Text = "Jail";
            this.JailBt.UseVisualStyleBackColor = true;
            this.JailBt.Click += new System.EventHandler(this.JailBt_Click);
            // 
            // DemoteBt
            // 
            this.DemoteBt.Location = new System.Drawing.Point(297, 89);
            this.DemoteBt.Name = "DemoteBt";
            this.DemoteBt.Size = new System.Drawing.Size(122, 23);
            this.DemoteBt.TabIndex = 33;
            this.DemoteBt.Text = "Demote";
            this.DemoteBt.UseVisualStyleBackColor = true;
            this.DemoteBt.Click += new System.EventHandler(this.DemoteBt_Click);
            // 
            // PromoteBt
            // 
            this.PromoteBt.Location = new System.Drawing.Point(297, 60);
            this.PromoteBt.Name = "PromoteBt";
            this.PromoteBt.Size = new System.Drawing.Size(122, 23);
            this.PromoteBt.TabIndex = 32;
            this.PromoteBt.Text = "Promote";
            this.PromoteBt.UseVisualStyleBackColor = true;
            this.PromoteBt.Click += new System.EventHandler(this.PromoteBt_Click);
            // 
            // LoginTxt
            // 
            this.LoginTxt.Location = new System.Drawing.Point(131, 3);
            this.LoginTxt.Name = "LoginTxt";
            this.LoginTxt.Size = new System.Drawing.Size(288, 21);
            this.LoginTxt.TabIndex = 31;
            this.LoginTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginTxt_KeyDown);
            // 
            // LogoutTxt
            // 
            this.LogoutTxt.Location = new System.Drawing.Point(131, 31);
            this.LogoutTxt.Name = "LogoutTxt";
            this.LogoutTxt.Size = new System.Drawing.Size(288, 21);
            this.LogoutTxt.TabIndex = 30;
            this.LogoutTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LogoutTxt_KeyDown);
            // 
            // TitleTxt
            // 
            this.TitleTxt.Location = new System.Drawing.Point(131, 60);
            this.TitleTxt.Name = "TitleTxt";
            this.TitleTxt.Size = new System.Drawing.Size(159, 21);
            this.TitleTxt.TabIndex = 29;
            this.TitleTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TitleTxt_KeyDown);
            // 
            // ColorCombo
            // 
            this.ColorCombo.FormattingEnabled = true;
            this.ColorCombo.Items.AddRange(new object[] {
            "",
            "Black",
            "Navy",
            "Green",
            "Teal",
            "Maroon",
            "Purple",
            "Gold",
            "Silver",
            "Gray",
            "Blue",
            "Lime",
            "Aqua",
            "Red",
            "Pink",
            "Yellow",
            "White"});
            this.ColorCombo.Location = new System.Drawing.Point(131, 89);
            this.ColorCombo.Name = "ColorCombo";
            this.ColorCombo.Size = new System.Drawing.Size(159, 21);
            this.ColorCombo.TabIndex = 28;
            this.ColorCombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ColorCombo_KeyDown);
            // 
            // ColorBt
            // 
            this.ColorBt.Location = new System.Drawing.Point(3, 89);
            this.ColorBt.Name = "ColorBt";
            this.ColorBt.Size = new System.Drawing.Size(122, 23);
            this.ColorBt.TabIndex = 27;
            this.ColorBt.Text = "Color:";
            this.ColorBt.UseVisualStyleBackColor = true;
            this.ColorBt.Click += new System.EventHandler(this.ColorBt_Click);
            // 
            // TitleBt
            // 
            this.TitleBt.Location = new System.Drawing.Point(3, 60);
            this.TitleBt.Name = "TitleBt";
            this.TitleBt.Size = new System.Drawing.Size(122, 23);
            this.TitleBt.TabIndex = 26;
            this.TitleBt.Text = "Title:";
            this.TitleBt.UseVisualStyleBackColor = true;
            this.TitleBt.Click += new System.EventHandler(this.TitleBt_Click);
            // 
            // LogoutBt
            // 
            this.LogoutBt.Location = new System.Drawing.Point(3, 31);
            this.LogoutBt.Name = "LogoutBt";
            this.LogoutBt.Size = new System.Drawing.Size(122, 23);
            this.LogoutBt.TabIndex = 25;
            this.LogoutBt.Text = "Logout:";
            this.LogoutBt.UseVisualStyleBackColor = true;
            this.LogoutBt.Click += new System.EventHandler(this.LogoutBt_Click);
            // 
            // LoginBt
            // 
            this.LoginBt.Location = new System.Drawing.Point(3, 3);
            this.LoginBt.Name = "LoginBt";
            this.LoginBt.Size = new System.Drawing.Size(122, 23);
            this.LoginBt.TabIndex = 24;
            this.LoginBt.Text = "Login:";
            this.LoginBt.UseVisualStyleBackColor = true;
            this.LoginBt.Click += new System.EventHandler(this.LoginBt_Click);
            // 
            // FreezeBt
            // 
            this.FreezeBt.Location = new System.Drawing.Point(425, 31);
            this.FreezeBt.Name = "FreezeBt";
            this.FreezeBt.Size = new System.Drawing.Size(122, 23);
            this.FreezeBt.TabIndex = 14;
            this.FreezeBt.Text = "Freeze";
            this.FreezeBt.UseVisualStyleBackColor = true;
            this.FreezeBt.Click += new System.EventHandler(this.FreezeBt_Click);
            // 
            // VoiceBt
            // 
            this.VoiceBt.Location = new System.Drawing.Point(425, 3);
            this.VoiceBt.Name = "VoiceBt";
            this.VoiceBt.Size = new System.Drawing.Size(122, 23);
            this.VoiceBt.TabIndex = 12;
            this.VoiceBt.Text = "Voice";
            this.VoiceBt.UseVisualStyleBackColor = true;
            this.VoiceBt.Click += new System.EventHandler(this.VoiceBt_Click);
            // 
            // JokerBt
            // 
            this.JokerBt.Location = new System.Drawing.Point(0, 0);
            this.JokerBt.Name = "JokerBt";
            this.JokerBt.Size = new System.Drawing.Size(75, 23);
            this.JokerBt.TabIndex = 44;
            // 
            // WarnBt
            // 
            this.WarnBt.Location = new System.Drawing.Point(553, 2);
            this.WarnBt.Name = "WarnBt";
            this.WarnBt.Size = new System.Drawing.Size(122, 23);
            this.WarnBt.TabIndex = 10;
            this.WarnBt.Text = "Warn";
            this.WarnBt.UseVisualStyleBackColor = true;
            this.WarnBt.Click += new System.EventHandler(this.WarnBt_Click);
            // 
            // MessageBt
            // 
            this.MessageBt.Location = new System.Drawing.Point(3, 177);
            this.MessageBt.Name = "MessageBt";
            this.MessageBt.Size = new System.Drawing.Size(122, 23);
            this.MessageBt.TabIndex = 9;
            this.MessageBt.Text = "Message:";
            this.MessageBt.UseVisualStyleBackColor = true;
            this.MessageBt.Click += new System.EventHandler(this.MessageBt_Click);
            // 
            // PLayersMessageTxt
            // 
            this.PLayersMessageTxt.Location = new System.Drawing.Point(131, 179);
            this.PLayersMessageTxt.Name = "PLayersMessageTxt";
            this.PLayersMessageTxt.Size = new System.Drawing.Size(544, 21);
            this.PLayersMessageTxt.TabIndex = 8;
            this.PLayersMessageTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PLayersMessageTxt_KeyDown);
            // 
            // HideBt
            // 
            this.HideBt.Location = new System.Drawing.Point(297, 119);
            this.HideBt.Name = "HideBt";
            this.HideBt.Size = new System.Drawing.Size(122, 23);
            this.HideBt.TabIndex = 7;
            this.HideBt.Text = "Hide";
            this.HideBt.UseVisualStyleBackColor = true;
            this.HideBt.Click += new System.EventHandler(this.HideBt_Click);
            // 
            // IPBanBt
            // 
            this.IPBanBt.Location = new System.Drawing.Point(553, 89);
            this.IPBanBt.Name = "IPBanBt";
            this.IPBanBt.Size = new System.Drawing.Size(122, 23);
            this.IPBanBt.TabIndex = 6;
            this.IPBanBt.Text = "IP Ban";
            this.IPBanBt.UseVisualStyleBackColor = true;
            this.IPBanBt.Click += new System.EventHandler(this.IPBanBt_Click);
            // 
            // BanBt
            // 
            this.BanBt.Location = new System.Drawing.Point(553, 60);
            this.BanBt.Name = "BanBt";
            this.BanBt.Size = new System.Drawing.Size(122, 23);
            this.BanBt.TabIndex = 5;
            this.BanBt.Text = "Ban";
            this.BanBt.UseVisualStyleBackColor = true;
            this.BanBt.Click += new System.EventHandler(this.BanBt_Click);
            // 
            // KickBt
            // 
            this.KickBt.Location = new System.Drawing.Point(553, 31);
            this.KickBt.Name = "KickBt";
            this.KickBt.Size = new System.Drawing.Size(122, 23);
            this.KickBt.TabIndex = 4;
            this.KickBt.Text = "Kick";
            this.KickBt.UseVisualStyleBackColor = true;
            this.KickBt.Click += new System.EventHandler(this.KickBt_Click);
            // 
            // MapCombo
            // 
            this.MapCombo.FormattingEnabled = true;
            this.MapCombo.Location = new System.Drawing.Point(131, 119);
            this.MapCombo.Name = "MapCombo";
            this.MapCombo.Size = new System.Drawing.Size(159, 21);
            this.MapCombo.TabIndex = 3;
            this.MapCombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MapCombo_KeyDown);
            // 
            // MapBt
            // 
            this.MapBt.Location = new System.Drawing.Point(3, 119);
            this.MapBt.Name = "MapBt";
            this.MapBt.Size = new System.Drawing.Size(122, 23);
            this.MapBt.TabIndex = 2;
            this.MapBt.Text = "Map:";
            this.MapBt.UseVisualStyleBackColor = true;
            this.MapBt.Click += new System.EventHandler(this.MapBt_Click);
            // 
            // MuteBt
            // 
            this.MuteBt.Location = new System.Drawing.Point(425, 60);
            this.MuteBt.Name = "MuteBt";
            this.MuteBt.Size = new System.Drawing.Size(122, 23);
            this.MuteBt.TabIndex = 13;
            this.MuteBt.Text = "Mute";
            this.MuteBt.UseVisualStyleBackColor = true;
            this.MuteBt.Click += new System.EventHandler(this.MuteBt_Click);
            // 
            // RankTxt
            // 
            this.RankTxt.Location = new System.Drawing.Point(426, 4);
            this.RankTxt.Name = "RankTxt";
            this.RankTxt.ReadOnly = true;
            this.RankTxt.Size = new System.Drawing.Size(134, 21);
            this.RankTxt.TabIndex = 44;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(387, 7);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(33, 13);
            this.label24.TabIndex = 43;
            this.label24.Text = "Rank:";
            // 
            // MapTxt
            // 
            this.MapTxt.Location = new System.Drawing.Point(238, 4);
            this.MapTxt.Name = "MapTxt";
            this.MapTxt.ReadOnly = true;
            this.MapTxt.Size = new System.Drawing.Size(143, 21);
            this.MapTxt.TabIndex = 42;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(201, 7);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 41;
            this.label14.Text = "Map:";
            // 
            // NameTxtPlayersTab
            // 
            this.NameTxtPlayersTab.Location = new System.Drawing.Point(45, 4);
            this.NameTxtPlayersTab.Name = "NameTxtPlayersTab";
            this.NameTxtPlayersTab.ReadOnly = true;
            this.NameTxtPlayersTab.Size = new System.Drawing.Size(150, 21);
            this.NameTxtPlayersTab.TabIndex = 40;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 39;
            this.label12.Text = "Name:";
            // 
            // Chat
            // 
            this.Chat.Controls.Add(this.groupBox1);
            this.Chat.Location = new System.Drawing.Point(4, 22);
            this.Chat.Name = "Chat";
            this.Chat.Padding = new System.Windows.Forms.Padding(3);
            this.Chat.Size = new System.Drawing.Size(698, 488);
            this.Chat.TabIndex = 8;
            this.Chat.Text = "Chat";
            this.Chat.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.txtOpInput);
            this.groupBox1.Controls.Add(this.txtOpLog);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(683, 477);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Op Chat";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(6, 451);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(44, 13);
            this.label33.TabIndex = 31;
            this.label33.Text = "OpChat:";
            // 
            // txtOpInput
            // 
            this.txtOpInput.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOpInput.Location = new System.Drawing.Point(68, 448);
            this.txtOpInput.Name = "txtOpInput";
            this.txtOpInput.Size = new System.Drawing.Size(602, 21);
            this.txtOpInput.TabIndex = 30;
            this.txtOpInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOpInput_KeyDown);
            // 
            // txtOpLog
            // 
            this.txtOpLog.BackColor = System.Drawing.SystemColors.Window;
            this.txtOpLog.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtOpLog.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOpLog.Location = new System.Drawing.Point(13, 20);
            this.txtOpLog.Multiline = true;
            this.txtOpLog.Name = "txtOpLog";
            this.txtOpLog.ReadOnly = true;
            this.txtOpLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOpLog.Size = new System.Drawing.Size(664, 422);
            this.txtOpLog.TabIndex = 29;
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 523);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Window";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Window_FormClosing);
            this.Load += new System.EventHandler(this.Window_Load);
            this.Resize += new System.EventHandler(this.Window_Resize);
            this.mapsStrip.ResumeLayout(false);
            this.playerStrip.ResumeLayout(false);
            this.iconContext.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.gBCommands.ResumeLayout(false);
            this.gBCommands.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaps)).EndInit();
            this.gBChat.ResumeLayout(false);
            this.gBChat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drownNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Fallnumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.physlvlnumeric)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMapsTab)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.Chat.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnProperties;
        private Button btnClose;
        private ContextMenuStrip iconContext;
        private ToolStripMenuItem openConsole;
        private ToolStripMenuItem shutdownServer;
        private ContextMenuStrip playerStrip;
        private ToolStripMenuItem whoisToolStripMenuItem;
        private ToolStripMenuItem kickToolStripMenuItem;
        private ToolStripMenuItem banToolStripMenuItem;
        private ToolStripMenuItem voiceToolStripMenuItem;
        private ContextMenuStrip mapsStrip;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem finiteModeToolStripMenuItem;
        private ToolStripMenuItem animalAIToolStripMenuItem;
        private ToolStripMenuItem edgeWaterToolStripMenuItem;
        private ToolStripMenuItem growingGrassToolStripMenuItem;
        private ToolStripMenuItem survivalDeathToolStripMenuItem;
        private ToolStripMenuItem killerBlocksToolStripMenuItem;
        private ToolStripMenuItem rPChatToolStripMenuItem;
        private ToolStripMenuItem clonesToolStripMenuItem;
        private Button Restart;
        private ToolStripMenuItem restartServerToolStripMenuItem;
        private TabPage tabPage5;
        private Label label3;
        private TabPage tabPage3;
        private TextBox txtErrors;
        private TabPage tabPage2;
        private TextBox txtChangelog;
        private TabPage tabPage4;
        private TextBox txtSystem;
        private TabPage tabPage1;
        private GroupBox gBCommands;
        private TextBox txtCommandsUsed;
        private DataGridView dgvMaps;
        private GroupBox gBChat;
        private TextBox txtLog;
        private Label label2;
        private TextBox txtCommands;
        private TextBox txtInput;
        private TextBox txtUrl;
        private DataGridView dgvPlayers;
        private Label label1;
        private TabControl tabControl1;
        private TabPage tabPage6;
        private Panel panel1;
        private Label label11;
        private Button SaveMap;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label4;
        private ComboBox maptypecombo;
        private Button CreateNewMap;
        private DataGridView dgvMapsTab;
        private Panel panel2;
        private Label label13;
        private Label label17;
        private Label label15;
        private Label label19;
        private Label label18;
        private Label label20;
        private Label label21;
        private ToolStripMenuItem promoteToolStripMenuItem;
        private ToolStripMenuItem demoteToolStripMenuItem;
        private Panel panel3;
        private Button ldmapbt;
        private ComboBox xtxtbox;
        private ComboBox ytxtbox;
        private ComboBox ztxtbox;
        private TextBox nametxtbox;
        private ComboBox Aicombo;
        private CheckBox edgewaterchk;
        private CheckBox grasschk;
        private CheckBox finitechk;
        private CheckBox Killerbloxchk;
        private CheckBox SurvivalStyleDeathchk;
        private CheckBox chatlvlchk;
        private NumericUpDown physlvlnumeric;
        private TextBox MOTDtxt;
        private NumericUpDown drownNumeric;
        private NumericUpDown Fallnumeric;
        private Label label22;
        private Label label6;
        private CheckBox AutoLoadChk;
        private Label label23;
        public ListBox UnloadedList;
        private TabPage tabPage7;
        internal RichTextBox LogsTxtBox;
        private DateTimePicker dateTimePicker1;
        private Panel panel4;
        private TextBox RankTxt;
        private Label label24;
        private TextBox MapTxt;
        private Label label14;
        private TextBox NameTxtPlayersTab;
        private Label label12;
        private Button IPBanBt;
        private Button BanBt;
        private Button KickBt;
        private ComboBox MapCombo;
        private Button MapBt;
        private TextBox IPtxt;
        private Label label26;
        private Button MessageBt;
        private TextBox PLayersMessageTxt;
        private Button HideBt;
        private Label label30;
        private TextBox TimesLoggedInTxt;
        private Label label29;
        private TextBox Blockstxt;
        private Label label28;
        private TextBox DeathsTxt;
        private Label label27;
        private TextBox LoggedinForTxt;
        private Label label31;
        private TextBox Kickstxt;
        private Button WarnBt;
        private Button VoiceBt;
        private Button JokerBt;
        private Button MuteBt;
        private Button FreezeBt;
        private Button LogoutBt;
        private Button LoginBt;
        private TextBox LoginTxt;
        private TextBox LogoutTxt;
        private TextBox TitleTxt;
        private ComboBox ColorCombo;
        private Button ColorBt;
        private Button TitleBt;
        private Button JailBt;
        private Button DemoteBt;
        private Button PromoteBt;
        private Button KillBt;
        private TextBox StatusTxt;
        private Label label25;
        private TextBox MimicORSendCmdTxt;
        private Button MimicORSendCmdBt;
        private Button SpawnBt;
        private TextBox UndoTxt;
        private Button UndoBt;
        private Button SlapBt;
        private Button SendRulesTxt;
        private TextBox PlayersTextBox;
        private ListBox PlyersListBox;
        private TabPage Chat;
        private GroupBox groupBox1;
        private Label label33;
        private TextBox txtOpInput;
        private TextBox txtOpLog;
        private Button button_saveall;
        private Button Unloadempty_button;
        private Button killphysics_button;
        private ToolStripMenuItem unloadToolStripMenuItem1;
        private ToolStripMenuItem loadOngotoToolStripMenuItem;
        private ToolStripMenuItem autpPhysicsToolStripMenuItem;
        private ToolStripMenuItem instantBuildingToolStripMenuItem;
        private ToolStripMenuItem gunsToolStripMenuItem;
        private ToolStripMenuItem infoToolStripMenuItem;
        private ToolStripMenuItem actiondToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem unloadToolStripMenuItem;
        private ToolStripMenuItem moveAllToolStripMenuItem;
        private ToolStripMenuItem reloadToolStripMenuItem;
        private TextBox seedtxtbox;
        private Label label34;
        private Label label16;
        private ToolStripMenuItem randomFlowToolStripMenuItem;
        private ToolStripMenuItem leafDecayToolStripMenuItem;
        private ToolStripMenuItem treeGrowingToolStripMenuItem;
        private ToolStripMenuItem physicsToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripMenuItem physicsToolStripMenuItem1;
        private ToolStripMenuItem loadingToolStripMenuItem;
        private ToolStripMenuItem miscToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private Button button1;
    }
}