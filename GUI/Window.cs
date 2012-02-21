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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;
using MCLawl;

namespace MCLawl.Gui
{
    public partial class Window : Form
    {
        Regex regex = new Regex(@"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\." +
                                "([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$");
        // for cross thread use
        delegate void StringCallback(string s);
        delegate void PlayerListCallback(List<Player> players);
        delegate void ReportCallback(Report r);
        delegate void VoidDelegate();

        public static event EventHandler Minimize;
        public NotifyIcon notifyIcon1 = new NotifyIcon();
        //  public static bool Minimized = false;
        
        internal static MCDekMCDekServer s;

        bool shuttingDown = false;
        public Window() {
            InitializeComponent();
        }

        private void Window_Minimize(object sender, EventArgs e)
        {
      /*     if (!Minimized)
            {
                Minimized = true;
                ntf.Text = "MCZall";
                ntf.Icon = this.Icon;
                ntf.Click += delegate
                {
                    try
                    {
                        Minimized = false;
                        this.ShowInTaskbar = true;
                        this.Show();
                        WindowState = FormWindowState.Normal;
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                };
                ntf.Visible = true;
                this.ShowInTaskbar = false;
            } */
        }

        public static Window thisWindow;

        private void Window_Load(object sender, EventArgs e) {
            thisWindow = this;
            MaximizeBox = false;
            this.Text = "<MCDekMCDekServer name here>";
            this.Icon = new Icon(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MCLawl.Lawl.ico"));

            this.Show();
            this.BringToFront();
            WindowState = FormWindowState.Normal;

            s = new MCDekMCDekServer();
            s.OnLog += WriteLine;
            s.OnCommand += newCommand;
            s.OnError += newError;
            s.OnSystem += newSystem;

            foreach (TabPage tP in tabControl1.TabPages)
                tabControl1.SelectTab(tP);
            tabControl1.SelectTab(tabControl1.TabPages[0]);

            s.HeartBeatFail += HeartBeatFail;
            s.OnURLChange += UpdateUrl;
            s.OnPlayerListChange += UpdateClientList;
            s.OnSettingsUpdate += SettingsUpdate;
            s.Start();
            notifyIcon1.Text = ("MCLawl MCDekMCDekServer: " + MCDekMCDekServer.name);

            this.notifyIcon1.ContextMenuStrip = this.iconContext;
            this.notifyIcon1.Icon = this.Icon;
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);

            System.Timers.Timer MapTimer = new System.Timers.Timer(10000);
            MapTimer.Elapsed += delegate {
                UpdateMapList("'");
            }; MapTimer.Start();

            //if (File.Exists(Logger.ErrorLogPath))
                //txtErrors.Lines = File.ReadAllLines(Logger.ErrorLogPath);
            if (File.Exists("extra/Changelog.txt"))
            {
                txtChangelog.Text = "Changelog for " + MCDekMCDekServer.Version + ":";
                foreach (string line in File.ReadAllLines(("extra/Changelog.txt")))
                {
                    txtChangelog.AppendText("\r\n           " + line);
                }            
            }
        }

        void SettingsUpdate()
        {
            if (shuttingDown) return;
            if (txtLog.InvokeRequired)
            {
                VoidDelegate d = new VoidDelegate(SettingsUpdate);
                this.Invoke(d);
            }  else {
                this.Text = MCDekMCDekServer.name + " MCLawl Version: " + MCDekMCDekServer.Version;
            }
        }

        void HeartBeatFail() {
            WriteLine("Recent Heartbeat Failed");
        }

        void newError(string message)
        {
            try
            {
                if (txtErrors.InvokeRequired)
                {
                    LogDelegate d = new LogDelegate(newError);
                    this.Invoke(d, new object[] { message });
                }
                else
                {
                    txtErrors.AppendText(Environment.NewLine + message);
                }
            } catch { }
        }
        void newSystem(string message)
        {
            try
            {
                if (txtSystem.InvokeRequired)
                {
                    LogDelegate d = new LogDelegate(newSystem);
                    this.Invoke(d, new object[] { message });
                }
                else
                {
                    txtSystem.AppendText(Environment.NewLine + message);
                }
            } catch { }
        }

        delegate void LogDelegate(string message);

        /// <summary>
        /// Does the same as Console.Write() only in the form
        /// </summary>
        /// <param name="s">The string to write</param>
        public void Write(string s) {
            if (shuttingDown) return;
            if (txtLog.InvokeRequired) {
                LogDelegate d = new LogDelegate(Write);
                this.Invoke(d, new object[] { s });
            } else {
                txtLog.AppendText(s);
            }
        }
        /// <summary>
        /// Does the same as Console.WriteLine() only in the form
        /// </summary>
        /// <param name="s">The line to write</param>
        public void WriteLine(string s)
        {
            if (shuttingDown) return;
            if (this.InvokeRequired) {
                LogDelegate d = new LogDelegate(WriteLine);
                this.Invoke(d, new object[] { s });
            } else {
                txtLog.AppendText("\r\n" + s);
            }
        }
        /// <summary>
        /// Updates the list of client names in the window
        /// </summary>
        /// <param name="players">The list of players to add</param>
        public void UpdateClientList(List<Player> players) {
            if (this.InvokeRequired) {
                PlayerListCallback d = new PlayerListCallback(UpdateClientList);
                this.Invoke(d, new object[] { players });
            } else {
                liClients.Items.Clear();
                Player.players.ForEach(delegate(Player p) { liClients.Items.Add(p.name); });
            }
        }

        public void UpdateMapList(string blah) {            
            if (this.InvokeRequired) {
                LogDelegate d = new LogDelegate(UpdateMapList);
                this.Invoke(d, new object[] { blah });
            } else {
                liMaps.Items.Clear();
                foreach (Level level in MCDekMCDekServer.levels) {
                    liMaps.Items.Add(level.name + " - " + level.physics);
                }
            }
        }

        /// <summary>
        /// Places the MCDekMCDekServer's URL at the top of the window
        /// </summary>
        /// <param name="s">The URL to display</param>
        public void UpdateUrl(string s)
        {
            if (this.InvokeRequired)
            {
                StringCallback d = new StringCallback(UpdateUrl);
                this.Invoke(d, new object[] { s });
            }
            else
                txtUrl.Text = s;
        }

        private void Window_FormClosing(object sender, FormClosingEventArgs e) {
            if (notifyIcon1 != null) {
                notifyIcon1.Visible = false;
            }
            MCLawl_.Gui.Program.ExitProgram(false);
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtInput.Text == null || txtInput.Text.Trim()=="") { return; }
                string text = txtInput.Text.Trim();
                string newtext = text;
                if (txtInput.Text[0] == '#')
                {
                    newtext = text.Remove(0, 1).Trim();
                    Player.GlobalMessageOps("To Ops &f-"+MCDekMCDekServer.DefaultColor +"Console [&a" + MCDekMCDekServer.ZallState + MCDekMCDekServer.DefaultColor + "]&f- " + newtext);
                    MCDekMCDekServer.s.Log("(OPs): Console: " + newtext);
                    IRCBot.Say("Console: " + newtext, true);
                 //   WriteLine("(OPs):<CONSOLE> " + txtInput.Text);
                    txtInput.Clear();
                }
                else
                {
                    Player.GlobalMessage("Console [&a" + MCDekMCDekServer.ZallState + MCDekMCDekServer.DefaultColor + "]: &f" + txtInput.Text);
                    IRCBot.Say("Console [" + MCDekMCDekServer.ZallState + "]: " + txtInput.Text);
                    WriteLine("<CONSOLE> " + txtInput.Text);
                    txtInput.Clear();
                }
            }
        }

        private void txtCommands_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                string sentCmd = "", sentMsg = "";

                if (txtCommands.Text == null || txtCommands.Text.Trim() == "")
                {
                    newCommand("CONSOLE: Whitespace commands are not allowed.");
                    txtCommands.Clear();
                    return;
                }

                if (txtCommands.Text[0] == '/')
                    if (txtCommands.Text.Length > 1)
                        txtCommands.Text = txtCommands.Text.Substring(1);

                if (txtCommands.Text.IndexOf(' ') != -1) {
                    sentCmd = txtCommands.Text.Split(' ')[0];
                    sentMsg = txtCommands.Text.Substring(txtCommands.Text.IndexOf(' ') + 1);
                } else if (txtCommands.Text != "") {
                    sentCmd = txtCommands.Text;
                } else {
                    return;
                }

                try { 
                    Command.all.Find(sentCmd).Use(null, sentMsg);
                    newCommand("CONSOLE: USED /" + sentCmd + " " + sentMsg);
                } catch (Exception ex) {
                    MCDekMCDekServer.ErrorLog(ex);
                    newCommand("CONSOLE: Failed command."); 
                }

                txtCommands.Clear();
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e) { 
            if (notifyIcon1 != null) {
                notifyIcon1.Visible = false;
            }
            MCLawl_.Gui.Program.ExitProgram(false); 
        }

        public void newCommand(string p) { 
            if (txtCommandsUsed.InvokeRequired)
            {
                LogDelegate d = new LogDelegate(newCommand);
                this.Invoke(d, new object[] { p });
            }
            else
            {
                txtCommandsUsed.AppendText("\r\n" + p); 
            }
        }

        void ChangeCheck(string newCheck) { MCDekMCDekServer.ZallState = newCheck; }

        private void txtHost_TextChanged(object sender, EventArgs e)
        {
            if (txtHost.Text != "") ChangeCheck(txtHost.Text);
        }

        private void btnProperties_Click_1(object sender, EventArgs e) {
            if (!prevLoaded) { PropertyForm = new PropertyWindow(); prevLoaded = true; }
            PropertyForm.Show();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e) {
            if (!MCLawl_.Gui.Program.CurrentUpdate)
                MCLawl_.Gui.Program.UpdateCheck();
            else {
                Thread messageThread = new Thread(new ThreadStart(delegate {
                    MessageBox.Show("Already checking for updates.");
                })); messageThread.Start();
            }
        }

        public static bool prevLoaded = false;
        Form PropertyForm;
        Form UpdateForm;

        private void gBChat_Enter(object sender, EventArgs e)
        {

        }

        private void btnExtra_Click_1(object sender, EventArgs e) {
            if (!prevLoaded) { PropertyForm = new PropertyWindow(); prevLoaded = true; }
            PropertyForm.Show();
            PropertyForm.Top = this.Top + this.Height - txtCommandsUsed.Height;
            PropertyForm.Left = this.Left;
        }

        private void Window_Resize(object sender, EventArgs e) {
            this.Hide();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e) {
            this.Show();
            this.BringToFront();
            WindowState = FormWindowState.Normal;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            UpdateForm = new UpdateWindow();
            UpdateForm.Show();
        }

        private void tmrRestart_Tick(object sender, EventArgs e)
        {
            if (MCDekMCDekServer.autorestart)
            {
                if (DateTime.Now.TimeOfDay.CompareTo(MCDekMCDekServer.restarttime.TimeOfDay) > 0 && (DateTime.Now.TimeOfDay.CompareTo(MCDekMCDekServer.restarttime.AddSeconds(1).TimeOfDay)) < 0) {
                    Player.GlobalMessage("The time is now " + DateTime.Now.TimeOfDay);
                    Player.GlobalMessage("The MCDekMCDekServer will now begin auto restart procedures.");
                    MCDekMCDekServer.s.Log("The time is now " + DateTime.Now.TimeOfDay);
                    MCDekMCDekServer.s.Log("The MCDekMCDekServer will now begin auto restart procedures.");

                    if (notifyIcon1 != null) {
                        notifyIcon1.Icon = null;
                        notifyIcon1.Visible = false;
                    }
                    MCLawl_.Gui.Program.ExitProgram(true);
                }
            }
        }

        private void openConsole_Click(object sender, EventArgs e)
        {
            // Yes, it's a hacky fix.  Don't ask :v
            this.Show();
            this.BringToFront();
            WindowState = FormWindowState.Normal;
            this.Show();
            this.BringToFront();
            WindowState = FormWindowState.Normal;
        }

        private void shutdownMCDekMCDekServer_Click(object sender, EventArgs e)
        {
            if (notifyIcon1 != null)
            {
                notifyIcon1.Visible = false;
            }
            MCLawl_.Gui.Program.ExitProgram(false); 
        }

        private void voiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.liClients.SelectedIndex != -1)
            {
                Command.all.Find("voice").Use(null, this.liClients.SelectedItem.ToString());
            }
        }

        private void whoisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.liClients.SelectedIndex != -1)
            {
                Command.all.Find("whois").Use(null, this.liClients.SelectedItem.ToString());
            }
        }

        private void kickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.liClients.SelectedIndex != -1)
            {
                Command.all.Find("kick").Use(null, this.liClients.SelectedItem.ToString() + " You have been kicked by the console.");
            }
        }


        private void banToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.liClients.SelectedIndex != -1)
            {
                Command.all.Find("ban").Use(null, this.liClients.SelectedItem.ToString());
            }
        }

        private void liClients_MouseDown(object sender, MouseEventArgs e)
        {
            int i;
            i = liClients.IndexFromPoint(e.X, e.Y);
            liClients.SelectedIndex = i;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (this.liMaps.SelectedIndex != -1)
            {
                Command.all.Find("physics").Use(null, this.liMaps.SelectedItem.ToString().Remove((this.liMaps.SelectedItem.ToString().Length - 4)) + " 0");
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (this.liMaps.SelectedIndex != -1)
            {
                Command.all.Find("physics").Use(null, this.liMaps.SelectedItem.ToString().Remove((this.liMaps.SelectedItem.ToString().Length - 4)) + " 1");
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (this.liMaps.SelectedIndex != -1)
            {
                Command.all.Find("physics").Use(null, this.liMaps.SelectedItem.ToString().Remove((this.liMaps.SelectedItem.ToString().Length - 4)) + " 2");
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (this.liMaps.SelectedIndex != -1)
            {
                Command.all.Find("physics").Use(null, this.liMaps.SelectedItem.ToString().Remove((this.liMaps.SelectedItem.ToString().Length - 4)) + " 3");
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (this.liMaps.SelectedIndex != -1)
            {
                Command.all.Find("physics").Use(null, this.liMaps.SelectedItem.ToString().Remove((this.liMaps.SelectedItem.ToString().Length - 4)) + " 4");
            }
        }

        private void unloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.liMaps.SelectedIndex != -1)
            {
                Command.all.Find("unload").Use(null, this.liMaps.SelectedItem.ToString().Remove((this.liMaps.SelectedItem.ToString().Length - 4)));
            }
        }

        private void finiteModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.liMaps.SelectedIndex != -1)
            {
                Command.all.Find("map").Use(null, this.liMaps.SelectedItem.ToString().Remove((this.liMaps.SelectedItem.ToString().Length - 4)) + " finite");
            }
        }

        private void animalAIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.liMaps.SelectedIndex != -1)
            {
                Command.all.Find("map").Use(null, this.liMaps.SelectedItem.ToString().Remove((this.liMaps.SelectedItem.ToString().Length - 4)) + " ai");
            }
        }

        private void edgeWaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.liMaps.SelectedIndex != -1)
            {
                Command.all.Find("map").Use(null, this.liMaps.SelectedItem.ToString().Remove((this.liMaps.SelectedItem.ToString().Length - 4)) + " edge");
            }
        }

        private void growingGrassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.liMaps.SelectedIndex != -1)
            {
                Command.all.Find("map").Use(null, this.liMaps.SelectedItem.ToString().Remove((this.liMaps.SelectedItem.ToString().Length - 4)) + " grass");
            }
        }

        private void survivalDeathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.liMaps.SelectedIndex != -1)
            {
                Command.all.Find("map").Use(null, this.liMaps.SelectedItem.ToString().Remove((this.liMaps.SelectedItem.ToString().Length - 4)) + " death");
            }
        }

        private void killerBlocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.liMaps.SelectedIndex != -1)
            {
                Command.all.Find("map").Use(null, this.liMaps.SelectedItem.ToString().Remove((this.liMaps.SelectedItem.ToString().Length - 4)) + " killer");
            }
        }

        private void rPChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.liMaps.SelectedIndex != -1)
            {
                Command.all.Find("map").Use(null, this.liMaps.SelectedItem.ToString().Remove((this.liMaps.SelectedItem.ToString().Length - 4)) + " chat");
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.liMaps.SelectedIndex != -1)
            {
                Command.all.Find("save").Use(null, this.liMaps.SelectedItem.ToString().Remove((this.liMaps.SelectedItem.ToString().Length - 4)));
            }
        }

        private void liMaps_MouseDown(object sender, MouseEventArgs e)
        {
            int i;
            i = liMaps.IndexFromPoint(e.X, e.Y);
            liMaps.SelectedIndex = i;
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            foreach (TabPage tP in tabControl1.TabPages)
            {
                foreach (Control ctrl in tP.Controls)
                {
                    if (ctrl is TextBox)
                    {
                        TextBox txtBox = (TextBox)ctrl;
                        txtBox.Update();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
