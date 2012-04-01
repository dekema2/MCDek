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
using System.Threading;

namespace MCDek.Gui
{
    public partial class Form3 : Form
    {
        delegate void StringCallback(string s);
        delegate void PlayerListCallback(List<Player> players);
        delegate void ReportCallback(Report r);
        delegate void VoidDelegate();
        public static bool fileexists = false;
        bool mapgen = false;

        PlayerCollection pc = new PlayerCollection(new PlayerListView());
        LevelCollection lc = new LevelCollection(new LevelListView());
        LevelCollection lcTAB = new LevelCollection(new LevelListViewForTab());

        //public static event EventHandler Minimize;
        public NotifyIcon notifyIcon1 = new NotifyIcon();
        // public static bool Minimized = false;

        Level prpertiesoflvl;
        Player prpertiesofplyer;

        internal static Server s;

        readonly System.Timers.Timer UpdateListTimer = new System.Timers.Timer(10000);
        
        public Form3()
        {
            InitializeComponent();
        }

        public void UpdateMapList()
        {
            if (InvokeRequired)
                Invoke(new MCDek.Gui.Window.UpdateList(UpdateMapList));
            else
            {

                if (dgvMaps.DataSource == null)
                    dgvMaps.DataSource = lc;

                string selected = null;
                if (lc.Count > 0 && dgvMaps.SelectedRows.Count > 0)
                {
                    selected = (from DataGridViewRow row in dgvMaps.Rows where row.Selected select lc[row.Index]).First().name;
                }

                lc.Clear();
                lc = new LevelCollection(new LevelListView());
                Server.levels.ForEach(l => lc.Add(l));

                dgvMaps.DataSource = null;
                dgvMaps.DataSource = lc;
                if (selected != null)
                {
                    foreach (DataGridViewRow row in Server.levels.SelectMany(l => dgvMaps.Rows.Cast<DataGridViewRow>().Where(row => (string)row.Cells[0].Value == selected)))
                        row.Selected = true;
                }

                dgvMaps.Refresh();

            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
        }

        private void dgvMaps_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Level lvl = Level.Find(textBox1.Text.Trim().ToLower());
                if (lvl == null) lvl = Level.Load(textBox1.Text.Trim().ToLower());
                if (lvl == null)
                {
                    MessageBox.Show("I could not find that map!");
                }
                else
                {
                    int[] topBlock = new int[lvl.width * lvl.height * lvl.depth];
                    for (ushort x = 0; x < lvl.width; x++)
                    {
                        for (ushort y = lvl.depth; y > 0; y--)
                        {
                            for (ushort z = 0; z <= lvl.height; z++)
                            {
                                if (Block.Convert(lvl.GetTile(x, y, z)) != Block.air)
                                {
                                    if (topBlock[x * z * lvl.width] != 0) topBlock[x * z * lvl.width] = lvl.GetTile(x, y, z);
                                }
                            }
                        }
                    }
                }
            }
        }
        private Brush GetBrush(Byte b)
        {
            switch (Block.Convert(b))
            {
                case 1: //normal stone which is just a mclawl glitch
                case Block.stone: //cobblestone
                case Block.gravel:
                case Block.coal:
                case Block.ironrock:
                case Block.goldrock:
                case 35:
                    toReturn = Brushes.Gray;
                    break;
                case Block.grass:
                case Block.green:
                case Block.leaf:
                    toReturn = Brushes.Green;
                    break;
                case Block.dirt:
                case Block.wood:
                case Block.trunk:
                case Block.bookcase:
                    toReturn = Brushes.Brown;
                    break;
                case Block.blackrock:
                case Block.obsidian:
                    toReturn = Brushes.Black;
                    break;
                case 8: //the blue blocks
                case 9:
                case 28:
                    toReturn = Brushes.Blue;
                    break;
                case 10: //orange blocks
                case 11:
                case 22:
                    toReturn = Brushes.Orange;
                    break;
                case Block.sand:
                    toReturn = Brushes.PeachPuff;
                    break;
                case Block.sponge:
                case Block.yellow:
                case Block.goldsolid:
                    toReturn = Brushes.Yellow;
                    break;
                case Block.red:
                case Block.brick:
                case Block.tnt:
                    toReturn = Brushes.Red;
                    break;
                case 24: //lime
                    toReturn = Brushes.LimeGreen;
                    break;
                case 26://aqua-green
                    toReturn = Brushes.SeaGreen;
                    break;
                case 27: //cyan
                    toReturn = Brushes.Cyan;
                    break;
                case 29:
                case 30:
                case 31:
                    toReturn = Brushes.Purple;
                    break;
                case 32:
                    toReturn = Brushes.MediumPurple;
                    break;
                case 33:
                    toReturn = Brushes.Pink;
                    break;
                case 34:
                    toReturn = Brushes.DarkGray;
                    break;
                case 36:
                case Block.iron:

                    toReturn = Brushes.White;
                    break;
                case 43:
                case 44:
                    toReturn = Brushes.LightGray;
                    break;
                default:
                    MessageBox.Show("It appears that the block " + Block.Name(b) + "has not been given a color! Aborting!");
                    return Brushes.HotPink;
            }
            return toReturn;






        }

        public Brush toReturn { get; set; }

        private void PropertyWindow_Unload(object sender, EventArgs e)
        {
            Window.previousLoaded = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


    }
}

