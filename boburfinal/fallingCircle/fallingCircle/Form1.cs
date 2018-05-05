using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fallingCircle
{
    public partial class Form1 : Form
    {
        int x, y = 0;
        int score = 0, scoreOut = 0;
        int speed = 10;
        int xc, yc;
        int eF = 50;
        List<Drop> drops = new List<Drop>();
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            
            Drop drop = new Drop(x = rnd.Next(70, 600), y, RandomColor(rnd.Next(0, 7)));
            drops.Add(drop);

            timer1.Tick += new EventHandler(timer_Tick);
            timer1.Enabled = true;
            timer1.Interval = 100;
            timer1.Start();

            timer2.Tick += timer2_Tick;
            timer2.Enabled = true;
            timer2.Interval = 600;
            timer2.Start();

        }
        private Color RandomColor(int colorID)
        {
            Color color = new Color();
            switch (colorID)
            {
                case 1:
                    color = Color.Red;
                    break;
                case 2:
                    color = Color.Blue;
                    break;
                case 3:
                    color = Color.Green;
                    break;
                case 4:
                    color = Color.Yellow;
                    break;
                case 5:
                    color = Color.Black;
                    break;
                case 6:
                    color = Color.Orange;
                    break;
                default:
                    break;
            }
            return color;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Drop p in drops)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.FillEllipse(new SolidBrush(p.color), p.X, p.Y, eF, eF);
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            xc = e.X;
            yc = e.Y;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int x1 = rnd.Next(70, 600);
            int y1 = 0;
            Drop drop = new Drop(x1, y1, RandomColor(rnd.Next(0, 7)));
            drops.Add(drop);
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            if (scoreOut <= 20)
            {
                for (int i = 0; i < drops.Count; i++)
                {
                    drops[i].Y += speed;
                    if (drops[i].Y > this.Height + 25)
                    {
                        drops.Remove(drops[i]);
                        scoreOut++;
                        label4.Text = scoreOut.ToString();
                    }
                }
            }
            else
            {
                timer1.Stop();
                timer2.Stop();
                MessageBox.Show("GAME OVER!");
            }

            Refresh();
        }
    }
}
