using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollisionAndReaction
{
    public partial class Form1 : Form
    {
        bool moveLeft, moveRight, moveUp, moveDown; // Ορίζουμε τις μεταβλητές για την κίνηση του παίκτη
        int speed = 12;
        public Form1()
        {
            InitializeComponent();
        }

        private void mainTimerEvent(object sender, EventArgs e)
        {
            if(moveLeft == true && player.Left > 0 )
            {
                player.Left -= speed;
            }
            if(moveRight == true && player.Right < 720)            {
                player.Left += speed;
            }    
            if(moveUp == true && player.Top > 0)
            {
                player.Top -= speed;
            }
            if (moveDown == true && player.Top < 400)
            {
                player.Top += speed;
            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "object")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        x.BackColor = Color.Red;
                        label1.Text = "You Hit With " + x.Name;
                    }
                    else
                    {
                        x.BackColor = Color.DarkBlue;
                    }

                }
            }
        }
            

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                moveLeft = true;
            }
            if(e.KeyCode == Keys.Right)
            {
                moveRight = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                moveDown = true;
            }
            if(e.KeyCode == Keys.Up)
            {
                moveUp = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                moveDown = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                moveUp = false;
            }

        }
    }
}
