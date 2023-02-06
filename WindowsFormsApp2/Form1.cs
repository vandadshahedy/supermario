using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp2
{
    public partial class supermario : Form
    {
        public void block(int X, int Y, int count = 1)
        {
            PictureBox newBlock = new PictureBox();
            newBlock.Size = new Size(37 * count, 30);
            newBlock.Location = new Point(X, Y);
            newBlock.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.block;

            Controls.Add(newBlock);

            blocks.Add(newBlock);
        }
        public supermario()
        {
            InitializeComponent();
        }
        private List<PictureBox> blocks = new List<PictureBox>();

        int hordir = 0;
        int verdir = 0;
        bool jumpf=true;
        int speed = 5;
        int maxjump =200;
        private void keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                hordir = 1;
            else if (e.KeyCode == Keys.Right)
                hordir = -1;
            if (e.KeyCode == Keys.Up)
                verdir = -2;
        }

        private void keyup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
                hordir = 0;

            if (e.KeyCode == Keys.Up)
                verdir = 0;
        }
        private void jump()
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                if (player.Top >= blocks[i].Bottom )
                    maxjump = blocks[i].Bottom;
            }
            if (verdir == -2)
            {
                if (player.Top > maxjump && jumpf)
                    verdir = -2;
                else
                {
                    verdir = 2;
                    jumpf = false;
                }
            }
            else if (player.Top < 325)
                verdir = 2;
            if (player.Top < 325)
                player.Top += verdir * speed;
            else if (player.Top == 325 && verdir == -2)
                player.Top += verdir * speed;
        }
        private void walk()
        {
            bg.Left += speed * hordir;
            for (int i = 0; i < blocks.Count; i++)
                    blocks[i].Left+= speed * hordir;

            if (bg.Left <= 0)
                bg.Width += bg.Width;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            jump();
            walk();
        }

    }
}