using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MCLawl.Gui;
using MCDek;
using MCLawl;

namespace MCDek.Gui
{
    public partial class PropertyWindow : Form
    {
        public PropertyWindow() {
            InitializeComponent();
        }

        private void PropertyWindow_Load(object sender, EventArgs e)
        {
            Icon = Gui.Window.ActiveForm.Icon;

            Object[] colors = new Object[16];
            colors[0] = ("black"); colors[1] = ("navy");
            colors[2] = ("green"); colors[3] = ("teal");
            colors[4] = ("maroon"); colors[5] = ("purple");
            colors[6] = ("gold"); colors[7] = ("silver");
            colors[8] = ("gray"); colors[9] = ("blue");
            colors[10] = ("lime"); colors[11] = ("aqua");
            colors[12] = ("red"); colors[13] = ("pink");
            colors[14] = ("yellow"); colors[15] = ("white");
            cmbDefaultColour.Items.AddRange(colors);
            cmbIRCColour.Items.AddRange(colors);
            cmbColor.Items.AddRange(colors);

            string opchatperm = "";
            foreach (Group grp in Group.GroupList)
            {
                cmbDefaultRank.Items.Add(grp.name);
                cmbOpChat.Items.Add(grp.name);
                if (grp.Permission == Server.opchatperm)
                {
                    opchatperm = grp.name;
                }
            }
            cmbDefaultRank.SelectedIndex = 1;
            cmbOpChat.SelectedIndex = (opchatperm != "") ? cmbOpChat.Items.IndexOf(opchatperm) : 1;

            //Load server stuff
            LoadProp("properties/server.properties");
            LoadRanks();
            try
            {
                LoadCommands();
                LoadBlocks();
            }
            catch
            {
                Server.s.Log("Failed to load commands and blocks!");
            }
        }

        private void PropertyWindow_Unload(object sender, EventArgs e) {
            Window.prevLoaded = false;
        }

        List<Group> storedRanks = new List<Group>();
        List<GrpCommands.rankAllowance> storedCommands = new List<GrpCommands.rankAllowance>();
        List<Block.Blocks> storedBlocks = new List<Block.Blocks>();

        public void LoadRanks()
        {
            txtCmdRanks.Text = "The following ranks are available: \r\n\r\n";
            listRanks.Items.Clear();
            storedRanks.Clear();
            storedRanks.AddRange(Group.GroupList);
            foreach (Group grp in storedRanks)
            {
                txtCmdRanks.Text += "\t" + grp.name + " (" + (int)grp.Permission + ")\r\n";
                listRanks.Items.Add(grp.trueName + "  =  " + (int)grp.Permission);
            }
            txtBlRanks.Text = txtCmdRanks.Text;
            listRanks.SelectedIndex = 0;
        }
        public void SaveRanks()
        {
            Group.saveGroups(storedRanks);
            Group.InitAll();
            LoadRanks();
        }

        public void LoadCommands() 
        {
            listCommands.Items.Clear();
            storedCommands.Clear();
            foreach (GrpCommands.rankAllowance aV in GrpCommands.allowedCommands) 
            {
                storedCommands.Add(aV);
                listCommands.Items.Add(aV.commandName);
            }
            if (listCommands.SelectedIndex == -1)
                listCommands.SelectedIndex = 0;
        }
        public void SaveCommands()
        {
            GrpCommands.Save(storedCommands);
            GrpCommands.fillRanks();
            LoadCommands();
        }

        public void LoadBlocks()
        {
            listBlocks.Items.Clear();
            storedBlocks.Clear();
            storedBlocks.AddRange(Block.BlockList);
            foreach (Block.Blocks bs in storedBlocks)
            {
                if (Block.Name(bs.type) != "unknown")
                    listBlocks.Items.Add(Block.Name(bs.type));
            }
            if (listBlocks.SelectedIndex == -1)
                listBlocks.SelectedIndex = 0;
        }
        public void SaveBlocks()
        {
            Block.SaveBlocks(storedBlocks);
            Block.SetBlocks();
            LoadBlocks();
        }

        public void LoadProp(string givenPath) {
            if (File.Exists(givenPath)) {
                string[] lines = File.ReadAllLines(givenPath);

                foreach (string line in lines) {
                    if (line != "" && line[0] != '#') {
                        //int index = line.IndexOf('=') + 1; // not needed if we use Split('=')
                        string key = line.Split('=')[0].Trim();
                        string value = line.Split('=')[1].Trim();
                        string color = "";

                        switch (key.ToLower())
                        {
                            case "server-name":
                                if (ValidString(value, "![]:.,{}~-+()?_/\\ ")) txtName.Text = value;
                                else txtName.Text = "[MCDek] Minecraft Server";
                                break;
                            case "motd":
                                if (ValidString(value, "![]&:.,{}~-+()?_/\\ ")) txtMOTD.Text = value;
                                else txtMOTD.Text = "Welcome to my MCDekServer!";
                                break;
                            case "port":
                                try { txtPort.Text = Convert.ToInt32(value).ToString(); }
                                catch { txtPort.Text = "25565"; }
                                break;
                            case "verify-names":
                                chkVerify.Checked = (value.ToLower() == "true") ? true : false;
                                break;
                            case "public":
                                chkPublic.Checked = (value.ToLower() == "true") ? true : false;
                                break;
                            case "world-chat":
                                chkWorld.Checked = (value.ToLower() == "true") ? true : false;
                                break;
                            case "max-players":
                                try
                                {
                                    if (Convert.ToByte(value) > 128)
                                    {
                                        value = "128";
                                    }
                                    else if (Convert.ToByte(value) < 1)
                                    {
                                        value = "1";
                                    }
                                    txtPlayers.Text = value;
                                }
                                catch
                                {
                                    Server.s.Log("max-players invalid! setting to default.");
                                    txtPlayers.Text = "12";
                                }
                                break;
                            case "max-maps":
                                try
                                {
                                    if (Convert.ToByte(value) > 100)
                                    {
                                        value = "100";
                                    }
                                    else if (Convert.ToByte(value) < 1)
                                    {
                                        value = "1";
                                    }
                                    txtMaps.Text = value;
                                }
                                catch
                                {
                                    Server.s.Log("max-maps invalid! setting to default.");
                                    txtMaps.Text = "5";
                                }
                                break;
                            case "irc":
                                chkIRC.Checked = (value.ToLower() == "true") ? true : false;
                                break;
                            case "irc-MCDekServer":
                                txtIRCMCDekServer.Text = value;
                                break;
                            case "irc-nick":
                                txtNick.Text = value;
                                break;
                            case "irc-channel":
                                txtChannel.Text = value;
                                break;
                            case "irc-opchannel":
                                txtOpChannel.Text = value;
                                break;
                            case "anti-tunnels":
                                ChkTunnels.Checked = (value.ToLower() == "true") ? true : false;
                                break;
                            case "max-depth":
                                txtDepth.Text= value;
                                break;

                            case "rplimit":
                                try { txtRP.Text = value; } catch { txtRP.Text = "500"; }
                                break;
                            case "rplimit-norm":
                                try { txtNormRp.Text = value; } catch { txtNormRp.Text = "10000"; }
                                break;

                            case "log-heartbeat":
                                chkLogBeat.Checked = (value.ToLower() == "true") ? true : false;
                                break;

                            case "force-cuboid":
                                chkForceCuboid.Checked = (value.ToLower() == "true") ? true : false;
                                break;

                            case "backup-time":
                                if (Convert.ToInt32(value) > 1) txtBackup.Text = value; else txtBackup.Text = "300";
                                break;

                            case "backup-location":
                                if (!value.Contains("System.Windows.Forms.TextBox, Text:"))
                                    txtBackupLocation.Text = value;
                                break;

                            case "physicsrestart":
                                chkPhysicsRest.Checked = (value.ToLower() == "true") ? true : false;
                                break;
                            case "deathcount":
                                chkDeath.Checked = (value.ToLower() == "true") ? true : false;
                                break;

                            case "defaultcolor":
                                color = c.Parse(value);
                                if (color == "") {
                                    color = c.Name(value); if (color != "") color = value; else { MCDek.Server.s.Log("Could not find " + value); return; }
                                }
                                cmbDefaultColour.SelectedIndex = cmbDefaultColour.Items.IndexOf(c.Name(value)); break;

                            case "irc-color":
                                color = c.Parse(value);
                                if (color == "") {
                                    color = c.Name(value); if (color != "") color = value; else { MCDek.Server.s.Log("Could not find " + value); return; }
                                }
                                cmbIRCColour.SelectedIndex = cmbIRCColour.Items.IndexOf(c.Name(value)); break;
                            case "default-rank":
                                try {
                                    if (cmbDefaultRank.Items.IndexOf(value.ToLower()) != -1)
                                        cmbDefaultRank.SelectedIndex = cmbDefaultRank.Items.IndexOf(value.ToLower());
                                } catch { cmbDefaultRank.SelectedIndex = 1; }
                                break;

                            case "cheapmessage":
                                chkCheap.Checked = (value.ToLower() == "true") ? true : false;
                                break;
                            case "cheap-message-given":
                                txtCheap.Text = value;
                                break;

                            case "rank-super":
                                chkrankSuper.Checked = (value.ToLower() == "true") ? true : false;
                                break;

                            case "custom-ban":
                                chkBanMessage.Checked = (value.ToLower() == "true") ? true : false;
                                break;

                            case "custom-ban-message":
                                txtBanMessage.Text = value;
                                break;

                            case "custom-shutdown":
                                chkShutdown.Checked = (value.ToLower() == "true") ? true : false;
                                break;

                            case "custom-shutdown-message":
                                txtShutdown.Text = value;
                                break;

                            case "auto-restart":
                                chkRestartTime.Checked = (value.ToLower() == "true") ? true : false;
                                break;
                            case "restarttime":
                                txtRestartTime.Text = value;
                                break;
                            case "afk-minutes":
                                try { txtafk.Text = Convert.ToInt16(value).ToString(); } catch { txtafk.Text = "10"; }
                                break;

                            case "afk-kick":
                                try { txtAFKKick.Text = Convert.ToInt16(value).ToString(); } catch { txtAFKKick.Text = "45"; }
                                break;

                            case "check-updates":
                                chkUpdates.Checked = (value.ToLower() == "true") ? true : false;
                                break;
                            case "autoload":
                                chkAutoload.Checked = (value.ToLower() == "true") ? true : false;
                                break;
                            case "main-name":
                                txtMain.Text = value;
                                break;
                            case "dollar-before-dollar":
                                chk17Dollar.Checked = (value.ToLower() == "true") ? true : false;
                                break;
                            case "money-name":
                                txtMoneys.Text = value;
                                break;
                            case "restart-on-error":
                                chkRestart.Checked = (value.ToLower() == "true") ? true : false;
                                break;
                            case "repeat-messages":
                                chkRepeatMessages.Checked = (value.ToLower() == "true") ? true : false;
                                break;
                            case "host-state":
                                if (value != "") txtHost.Text = value;
                                break;
                        }
                    }
                }
                Save(givenPath);
            }
            else Save(givenPath);
        }
        public bool ValidString(string str, string allowed) {
            string allowedchars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz01234567890" + allowed;
            foreach (char ch in str) {
                if (allowedchars.IndexOf(ch) == -1) {
                    return false;
                }
            } return true;
        }

        public void Save(string givenPath) {
            try {
                StreamWriter w = new StreamWriter(File.Create(givenPath));
                if (givenPath.IndexOf("MCDekServer") != -1) {
                    w.WriteLine("# Edit the settings below to modify how your MCDekServer operates. This is an explanation of what each setting does.");
                    w.WriteLine("#   MCDekServer-name\t=\tThe name which displays on minecraft.net");
                    w.WriteLine("#   motd\t=\tThe message which displays when a player connects");
                    w.WriteLine("#   port\t=\tThe port to operate from");
                    w.WriteLine("#   console-only\t=\tRun without a GUI (useful for Linux MCDekServers with mono)");
                    w.WriteLine("#   verify-names\t=\tVerify the validity of names");
                    w.WriteLine("#   public\t=\tSet to true to appear in the public MCDekServer list");
                    w.WriteLine("#   max-players\t=\tThe maximum number of connections");
                    w.WriteLine("#   max-maps\t=\tThe maximum number of maps loaded at once");
                    w.WriteLine("#   world-chat\t=\tSet to true to enable world chat");
                    w.WriteLine("#   guest-goto\t=\tSet to true to give guests goto and levels commands");
                    w.WriteLine("#   irc\t=\tSet to true to enable the IRC bot");
                    w.WriteLine("#   irc-nick\t=\tThe name of the IRC bot");
                    w.WriteLine("#   irc-MCDekServer\t=\tThe MCDekServer to connect to");
                    w.WriteLine("#   irc-channel\t=\tThe channel to join");
                    w.WriteLine("#   irc-opchannel\t=\tThe channel to join (posts OpChat)");
                    w.WriteLine("#   irc-port\t=\tThe port to use to connect");
                    w.WriteLine("#   irc-identify\t=(true/false)\tDo you want the IRC bot to Identify itself with nickserv. Note: You will need to register it's name with nickserv manually.");
                    w.WriteLine("#   irc-password\t=\tThe password you want to use if you're identifying with nickserv");
                    w.WriteLine("#   anti-tunnels\t=\tStops people digging below max-depth");
                    w.WriteLine("#   max-depth\t=\tThe maximum allowed depth to dig down");
                    w.WriteLine("#   backup-time\t=\tThe number of seconds between automatic backups");
                    w.WriteLine("#   overload\t=\tThe higher this is, the longer the physics is allowed to lag. Default 1500");
                    w.WriteLine("#   use-whitelist\t=\tSwitch to allow use of a whitelist to override IP bans for certain players.  Default false.");
                    w.WriteLine("#   force-cuboid\t=\tRun cuboid until the limit is hit, instead of canceling the whole operation.  Default false.");
                    w.WriteLine();
                    w.WriteLine("#   Host\t=\tThe host name for the database (usually 127.0.0.1)");
                    w.WriteLine("#   SQLPort\t=\tPort number to be used for MySQL.  Unless you manually changed the port, leave this alone.  Default 3306.");
                    w.WriteLine("#   Username\t=\tThe username you used to create the database (usually root)");
                    w.WriteLine("#   Password\t=\tThe password set while making the database");
                    w.WriteLine("#   DatabaseName\t=\tThe name of the database stored (Default = MCZall)");
                    w.WriteLine();
                    w.WriteLine("#   defaultColor\t=\tThe color code of the default messages (Default = &e)");
                    w.WriteLine();
                    w.WriteLine();
                    w.WriteLine("# MCDekServer options");
                    w.WriteLine("MCDekServer-name = " + txtName.Text);
                    w.WriteLine("motd = " + txtMOTD.Text);
                    w.WriteLine("port = " + txtPort.Text);
                    w.WriteLine("verify-names = " + chkVerify.Checked.ToString().ToLower());
                    w.WriteLine("public = " + chkPublic.Checked.ToString().ToLower());
                    w.WriteLine("max-players = " + txtPlayers.Text);
                    w.WriteLine("max-maps = " + txtMaps.Text);
                    w.WriteLine("world-chat = " + chkWorld.Checked.ToString().ToLower());
                    w.WriteLine("check-updates = " + chkUpdates.Checked.ToString().ToLower());
                    w.WriteLine("autoload = " + chkAutoload.Checked.ToString().ToLower());
                    w.WriteLine("auto-restart = " + chkRestartTime.Checked.ToString().ToLower());
                    w.WriteLine("restarttime = " + txtRestartTime.Text);
                    w.WriteLine("restart-on-error = " + chkRestart.Checked);
                    if (Player.ValidName(txtMain.Text)) w.WriteLine("main-name = " + txtMain.Text);
                    else w.WriteLine("main-name = main");
                    w.WriteLine();
                    w.WriteLine("# irc bot options");
                    w.WriteLine("irc = " + chkIRC.Checked.ToString());
                    w.WriteLine("irc-nick = " + txtNick.Text);
                    w.WriteLine("irc-MCDekServer = " + txtIRCMCDekServer.Text);
                    w.WriteLine("irc-channel = " + txtChannel.Text);
                    w.WriteLine("irc-opchannel = " + txtOpChannel.Text);
                    w.WriteLine("irc-port = " + MCDek.Server.ircPort.ToString());
                    w.WriteLine("irc-identify = " + MCDek.Server.ircIdentify.ToString());
                    w.WriteLine("irc-password = " + MCDek.Server.ircPassword);
                    w.WriteLine();
                    w.WriteLine("# other options");
                    w.WriteLine("anti-tunnels = " + ChkTunnels.Checked.ToString().ToLower());
                    w.WriteLine("max-depth = " + txtDepth.Text);
                    w.WriteLine("rplimit = " + txtRP.Text);
                    w.WriteLine("physicsrestart = " + chkPhysicsRest.Checked.ToString().ToLower());
                    w.WriteLine("old-help = " + chkHelp.Checked.ToString().ToLower());
                    w.WriteLine("deathcount = " + chkDeath.Checked.ToString().ToLower());
                    w.WriteLine("afk-minutes = " + txtafk.Text);
                    w.WriteLine("afk-kick = " + txtAFKKick.Text);
                    w.WriteLine("dollar-before-dollar = " + chk17Dollar.Checked.ToString().ToLower());
                    w.WriteLine("use-whitelist = " + MCDek.Server.useWhitelist.ToString().ToLower());
                    w.WriteLine("money-name = " + txtMoneys.Text);
                    w.WriteLine("opchat-perm = " + ((sbyte)Group.GroupList.Find(grp => grp.name == cmbOpChat.Items[cmbOpChat.SelectedIndex].ToString()).Permission).ToString());
                    w.WriteLine("log-heartbeat = " + chkLogBeat.Checked.ToString().ToLower());
                    w.WriteLine("force-cuboid = " + chkForceCuboid.Checked.ToString().ToLower());
                    w.WriteLine("repeat-messages = " + chkRepeatMessages.Checked.ToString());
                    w.WriteLine("host-state = " + txtHost.Text.ToString());
                    w.WriteLine();
                    w.WriteLine("# backup options");
                    w.WriteLine("backup-time = " + txtBackup.Text);
                    w.WriteLine("backup-location = " + txtBackupLocation.Text);
                    w.WriteLine();
                    w.WriteLine("#Error logging");
                    w.WriteLine("report-back = " + MCDek.Server.reportBack.ToString().ToLower());
                    w.WriteLine();
                    w.WriteLine("#MySQL information");
                    w.WriteLine("UseMySQL = " + MCDek.Server.useMySQL);
                    w.WriteLine("Host = " + MCDek.Server.MySQLHost);
                    w.WriteLine("SQLPort = " + MCDek.Server.MySQLPort);
                    w.WriteLine("Username = " + MCDek.Server.MySQLUsername);
                    w.WriteLine("Password = " + MCDek.Server.MySQLPassword);
                    w.WriteLine("DatabaseName = " + MCDek.Server.MySQLDatabaseName);
                    w.WriteLine("Pooling = " + MCDek.Server.MySQLPooling);
                    w.WriteLine();
                    w.WriteLine("#Colors");
                    w.WriteLine("defaultColor = " + cmbDefaultColour.Items[cmbDefaultColour.SelectedIndex].ToString());
                    w.WriteLine("irc-color = " + cmbIRCColour.Items[cmbIRCColour.SelectedIndex].ToString());
                    w.WriteLine();
                    w.WriteLine("#Running on mono?");
                    w.WriteLine("mono = " + chkMono.Checked.ToString().ToLower());
                    w.WriteLine();
                    w.WriteLine("#Custom Messages");
                    w.WriteLine("custom-ban = " + chkBanMessage.Checked.ToString().ToLower());
                    w.WriteLine("custom-ban-message = " + txtBanMessage.Text);
                    w.WriteLine("custom-shutdown = " + chkShutdown.Checked.ToString().ToLower());
                    w.WriteLine("custom-shutdown-message = " + txtShutdown.Text);
                    w.WriteLine();
                    w.WriteLine("cheapmessage = " + chkCheap.Checked.ToString().ToLower());
                    w.WriteLine("cheap-message-given = " + txtCheap.Text);
                    w.WriteLine("rank-super = " + chkrankSuper.Checked.ToString().ToLower());
                    w.WriteLine("default-rank = " + cmbDefaultRank.Items[cmbDefaultRank.SelectedIndex].ToString());
                }
                w.Flush();
                w.Close();
                w.Dispose();
            }
            catch
            {
                MCDek.Server.s.Log("SAVE FAILED! " + givenPath);
            }
        }

        private void cmbDefaultColour_SelectedIndexChanged(object sender, EventArgs e) {
            lblDefault.BackColor = Color.FromName(cmbDefaultColour.Items[cmbDefaultColour.SelectedIndex].ToString());
        }

        private void cmbIRCColour_SelectedIndexChanged(object sender, EventArgs e) {
            lblIRC.BackColor = Color.FromName(cmbIRCColour.Items[cmbIRCColour.SelectedIndex].ToString());
        }

        void removeDigit(TextBox foundTxt) {
            try {
                int lastChar = int.Parse(foundTxt.Text[foundTxt.Text.Length - 1].ToString());
            } catch {
                foundTxt.Text = "";
            }
        }

        private void txtPort_TextChanged(object sender, EventArgs e) { removeDigit(txtPort); }
        private void txtPlayers_TextChanged(object sender, EventArgs e) { removeDigit(txtPlayers); }
        private void txtMaps_TextChanged(object sender, EventArgs e) { removeDigit(txtMaps); }
        private void txtBackup_TextChanged(object sender, EventArgs e) { removeDigit(txtBackup); }
        private void txtDepth_TextChanged(object sender, EventArgs e) { removeDigit(txtDepth); }

        private void btnSave_Click(object sender, EventArgs e) { saveStuff(); Dispose(); }
        private void btnApply_Click(object sender, EventArgs e) { saveStuff(); }

        void saveStuff() {
            foreach (Control tP in tabControl.Controls)
                if (tP is TabPage && tP != tabPage3 && tP != tabPage5) 
                    foreach (Control ctrl in tP.Controls)
                        if (ctrl is TextBox) 
                            if (ctrl.Text == "") {
                                MessageBox.Show("A textbox has been left empty. It must be filled.\n" + ctrl.Name);
                                return; 
                            }

            Save("properties/MCDekServer.properties");
            SaveRanks();
            SaveCommands();
            SaveBlocks();

            Properties.Load("properties/MCDekServer.properties", true);
            GrpCommands.fillRanks();
        }

        private void btnDiscard_Click(object sender, EventArgs e) {
            this.Dispose();
        }

        private void toolTip_Popup(object sender, PopupEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void chkPhysicsRest_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkGC_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnBackup_Click(object sender, EventArgs e) {
            /*FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.Description = "Select Folder";
            if (folderDialog.ShowDialog() == DialogResult.OK) {
                txtBackupLocation.Text = folderDialog.SelectedPath;
            }*/
            MessageBox.Show("Currently glitchy! Just type in the location by hand.");
        }

#region rankTab
        private void cmbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblColor.BackColor = Color.FromName(cmbColor.Items[cmbColor.SelectedIndex].ToString());
            storedRanks[listRanks.SelectedIndex].color = c.Parse(cmbColor.Items[cmbColor.SelectedIndex].ToString());
        }

        bool skip = false;
        private void listRanks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (skip) return;
            Group foundRank = storedRanks.Find(grp => grp.trueName == listRanks.Items[listRanks.SelectedIndex].ToString().Split('=')[0].Trim());
            if (foundRank.Permission == LevelPermission.Nobody) { listRanks.SelectedIndex = 0; return; }
            
            txtRankName.Text = foundRank.trueName;
            txtPermission.Text = ((int)foundRank.Permission).ToString();
            txtLimit.Text = foundRank.maxBlocks.ToString();
            cmbColor.SelectedIndex = cmbColor.Items.IndexOf(c.Name(foundRank.color));
            txtFileName.Text = foundRank.fileName;
        }

        private void txtRankName_TextChanged(object sender, EventArgs e)
        {
            if (txtRankName.Text != "" && txtRankName.Text.ToLower() != "nobody")
            {
                storedRanks[listRanks.SelectedIndex].trueName = txtRankName.Text;
                skip = true;
                listRanks.Items[listRanks.SelectedIndex] = txtRankName.Text + "  =  " + (int)storedRanks[listRanks.SelectedIndex].Permission;
                skip = false;
            }
        }

        private void txtPermission_TextChanged(object sender, EventArgs e)
        {
            if (txtPermission.Text != "")
            {
                int foundPerm;
                try
                {
                    foundPerm = int.Parse(txtPermission.Text);
                }
                catch
                {
                    if (txtPermission.Text != "-")
                        txtPermission.Text = txtPermission.Text.Remove(txtPermission.Text.Length - 1);
                    return;
                }

                if (foundPerm < -50) { txtPermission.Text = "-50"; return; }
                else if (foundPerm > 119) { txtPermission.Text = "119"; return; }

                storedRanks[listRanks.SelectedIndex].Permission = (LevelPermission)foundPerm;
                skip = true;
                listRanks.Items[listRanks.SelectedIndex] = storedRanks[listRanks.SelectedIndex].trueName + "  =  " + foundPerm;
                skip = false;
            }
        }

        private void txtLimit_TextChanged(object sender, EventArgs e)
        {
            if (txtLimit.Text != "")
            {
                int foundLimit;
                try
                {
                    foundLimit = int.Parse(txtLimit.Text);
                }
                catch
                {
                    txtLimit.Text = txtLimit.Text.Remove(txtLimit.Text.Length - 1);
                    return;
                }

                if (foundLimit < 1) { txtLimit.Text = "1"; return; }

                storedRanks[listRanks.SelectedIndex].maxBlocks = foundLimit;
            }
        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {
            if (txtFileName.Text != "")
            {
                storedRanks[listRanks.SelectedIndex].fileName = txtFileName.Text;
            }
        }

        private void btnAddRank_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            Group newGroup = new Group((LevelPermission)5, 600, "CHANGEME", '1', "CHANGEME.txt");
            storedRanks.Add(newGroup);
            listRanks.Items.Add(newGroup.trueName + "  =  " + (int)newGroup.Permission);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listRanks.Items.Count > 1)
            {
                storedRanks.RemoveAt(listRanks.SelectedIndex);
                skip = true;
                listRanks.Items.RemoveAt(listRanks.SelectedIndex);
                skip = false;

                listRanks.SelectedIndex = 0;
            }
        }
#endregion

#region commandTab
        private void listCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            Command cmd = Command.all.Find(listCommands.SelectedItem.ToString());
            GrpCommands.rankAllowance allowVar = storedCommands.Find(aV => aV.commandName == cmd.name);

            if (Group.findPerm(allowVar.lowestRank) == null) allowVar.lowestRank = cmd.defaultRank;
            txtCmdLowest.Text = (int)allowVar.lowestRank + "";

            bool foundOne = false;
            txtCmdDisallow.Text = "";
            foreach (LevelPermission perm in allowVar.disallow)
            {
                foundOne = true;
                txtCmdDisallow.Text += "," + (int)perm;
            }
            if (foundOne) txtCmdDisallow.Text = txtCmdDisallow.Text.Remove(0, 1);
            
            foundOne = false;
            txtCmdAllow.Text = "";
            foreach (LevelPermission perm in allowVar.allow)
            {
                foundOne = true;
                txtCmdAllow.Text += "," + (int)perm;
            }
            if (foundOne) txtCmdAllow.Text = txtCmdAllow.Text.Remove(0, 1);
        }
        private void txtCmdLowest_TextChanged(object sender, EventArgs e)
        {
            fillLowest(ref txtCmdLowest, ref storedCommands[listCommands.SelectedIndex].lowestRank);
        }
        private void txtCmdDisallow_TextChanged(object sender, EventArgs e)
        {
            fillAllowance(ref txtCmdDisallow, ref storedCommands[listCommands.SelectedIndex].disallow);
        }
        private void txtCmdAllow_TextChanged(object sender, EventArgs e)
        {
            fillAllowance(ref txtCmdAllow, ref storedCommands[listCommands.SelectedIndex].allow);
        }
#endregion

#region BlockTab
        private void listBlocks_SelectedIndexChanged(object sender, EventArgs e)
        {
            byte b = Block.Byte(listBlocks.SelectedItem.ToString());
            Block.Blocks bs = storedBlocks.Find(bS => bS.type == b);

            txtBlLowest.Text = (int)bs.lowestRank + "";

            bool foundOne = false;
            txtBlDisallow.Text = "";
            foreach (LevelPermission perm in bs.disallow)
            {
                foundOne = true;
                txtBlDisallow.Text += "," + (int)perm;
            }
            if (foundOne) txtBlDisallow.Text = txtBlDisallow.Text.Remove(0, 1);

            foundOne = false;
            txtBlAllow.Text = "";
            foreach (LevelPermission perm in bs.allow)
            {
                foundOne = true;
                txtBlAllow.Text += "," + (int)perm;
            }
            if (foundOne) txtBlAllow.Text = txtBlAllow.Text.Remove(0, 1);
        }
        private void txtBlLowest_TextChanged(object sender, EventArgs e)
        {
            fillLowest(ref txtBlLowest, ref storedBlocks[listBlocks.SelectedIndex].lowestRank);
        }
        private void txtBlDisallow_TextChanged(object sender, EventArgs e)
        {
            fillAllowance(ref txtBlDisallow, ref storedBlocks[listBlocks.SelectedIndex].disallow);
        }
        private void txtBlAllow_TextChanged(object sender, EventArgs e)
        {
            fillAllowance(ref txtBlAllow, ref storedBlocks[listBlocks.SelectedIndex].allow);
        }
#endregion
        private void fillAllowance(ref TextBox txtBox, ref List<LevelPermission> addTo)
        {
            addTo.Clear();
            if (txtBox.Text != "")
            {
                string[] perms = txtBox.Text.Split(',');
                for (int i = 0; i < perms.Length; i++)
                {
                    perms[i] = perms[i].Trim().ToLower();
                    int foundPerm;
                    try
                    {
                        foundPerm = int.Parse(perms[i]);
                    }
                    catch
                    {
                        Group foundGroup = Group.Find(perms[i]);
                        if (foundGroup != null) foundPerm = (int)foundGroup.Permission;
                        else { MCDek.Server.s.Log("Could not find " + perms[i]); continue; }
                    }
                    addTo.Add((LevelPermission)foundPerm);
                }

                txtBox.Text = "";
                foreach (LevelPermission p in addTo)
                {
                    txtBox.Text += "," + (int)p;
                }
                if (txtBox.Text != "") txtBox.Text = txtBox.Text.Remove(0, 1);
            }
        }
        private void fillLowest(ref TextBox txtBox, ref LevelPermission toChange)
        {
            if (txtBox.Text != "")
            {
                txtBox.Text = txtBox.Text.Trim().ToLower();
                int foundPerm = -100;
                try
                {
                    foundPerm = int.Parse(txtBox.Text);
                }
                catch
                {
                    Group foundGroup = Group.Find(txtBox.Text);
                    if (foundGroup != null) foundPerm = (int)foundGroup.Permission;
                    else { MCDek.Server.s.Log("Could not find " + txtBox.Text); }
                }

                txtBox.Text = "";
                if (foundPerm < -99) txtBox.Text = (int)toChange + "";
                else txtBox.Text = foundPerm + "";

                toChange = (LevelPermission)Convert.ToInt16(txtBox.Text);
            }
        }

        private void btnBlHelp_Click(object sender, EventArgs e)
        {
            getHelp(listBlocks.SelectedItem.ToString());
        }
        private void btnCmdHelp_Click(object sender, EventArgs e)
        {
            getHelp(listCommands.SelectedItem.ToString());
        }
        private void getHelp(string toHelp)
        {
            Player.storedHelp = "";
            Player.storeHelp = true;
            Command.all.Find("help").Use(null, toHelp);
            Player.storeHelp = false;
            string messageInfo = "Help information for " + toHelp + ":\r\n\r\n";
            messageInfo += Player.storedHelp;
            MessageBox.Show(messageInfo);
        }

    }
}
