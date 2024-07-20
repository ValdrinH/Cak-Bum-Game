using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CakBum.UserControls
{
    public partial class PictureOfGame : UserControl
    {
        public EventHandler MouseClick = null;
        public PictureOfGame()
        {
            InitializeComponent();
        }

        public Image img { get => pictureBox1.Image; set => pictureBox1.Image = value; }
        public int Player { get; set; }
        public Color BckColor { get => pictureBox1.BackColor; set => pictureBox1.BackColor = value; }
        public BorderStyle Border { get => pictureBox1.BorderStyle; set => pictureBox1.BorderStyle = value; }
        public string Parent { get; set; }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseClick?.Invoke(this,e);
        }
    }

}
