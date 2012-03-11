using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MCDek.Gui
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (TextBox1.Text.Trim == "")
            {
               MessageBox.Show("Type something in! Darn it!!!")
            }
            else 
            {
                Level lvl = Level.Find(textBox1.Text.Trim().ToLower());
                if (lvl == null) lvl = GetTopLevel.Load(textBox1.Text.Trim().ToLower());
                if (lvl == null)
                {
                       MessageBox.Show("I could Find That map");
                }
                else
                {
                    int[] topBlock = new int [ lvl.width * lvl.height ];
                    for (ushort x = 0; x < lvl.width; x++)
                    {
                        for (ushort y = lvl.depth; y > 0; y--)
                        {
                            for (ushort z = 0; z = < lvl.height; z++)
                            {
                                  if (Block.Convert(lvl.GetTile(x, y, z)) != Block.air)
                                {
                                    if (topBlock[x*z*lvl.width] ! null) topBlock [x*z*lvl.width] = lvl.GetTile(x,y,z);
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
                        toreturn = Brushes.Purple;
                        break;
                    case 32:
                toreturn = Brushes.MediumPurple;
                        break;
                    case 33:
                        toreturn = Brushes.Pink;
                        break;
                    case 34:
                        toreturn = Brushes.DarkGray;
                        break;
                    case 36:
                    case Block.Iron:

                        toreturn = Brushes.White;
                        break;
                    case 43: 
                    case 44: 
                        toreturn = Brushes.LightGray;
                        break:
                    default:
                        MessageBox.Show("It appears that the block " + Block.Name(b) + "has not been given a color! Aborting!");
                        return Brushes.White HotPink;
                }
                return toReturn;
               

                        


                     
                }
            }
    }
}
