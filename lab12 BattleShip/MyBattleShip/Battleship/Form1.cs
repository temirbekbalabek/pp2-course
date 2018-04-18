using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Battleship
{
    delegate void DelegateForInitialization();
    public partial class Form1 : Form
    {
        GameLogic g1 = new GameLogic();
        public bool clickedCB = false;
        public Form1()
        {
            InitializeComponent();
          
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = true;
            timer1.Start();

        }
        private void SetDirectionToHorizontal(object sender, EventArgs e)
        {
            Ship.direction = ShipDirection.horizontal;
            
        }
        private void SetDirectionToVertical(object sender, EventArgs e)
        {
            Ship.direction = ShipDirection.vertical;

        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            string msg = "Для начала игры вы должны расставить корабли на вашей игровой панели и нажать на кнопку 'READY', после чего бот сам расставит свои корабли и игра вроде как должна начаться. :)";
            MessageBox.Show(msg);
            this.Controls.Add(g1.p1);
            this.Controls.Add(g1.p2);
            button1.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            checkBox1.Visible = true;
            button2.Enabled = false;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = "Вы уверены, что хотите покинуть игру? Предыдущая игра будет не будет сохранена.";
            DialogResult dialogresultForExit = MessageBox.Show(msg, "New Game", MessageBoxButtons.YesNo);
            if (dialogresultForExit == DialogResult.Yes)
            {
                Environment.Exit(1);
            }
            else if (dialogresultForExit == DialogResult.No)
            {
                
            }
        }
        delegate void MyDelegate();
        private void Ready_Click(object sender, EventArgs e)
        {
            if(g1.p1.brain.units.Count == 10)
            {
                g1.p2.Enabled = true;
                button1.Enabled = false;
                g1.p2.RandomGenerateShips();
                MessageBox.Show("Корабли бота были расставлены. Игра начинается!");
            }
            else if (g1.p2.brain.units.Count < 10)
            {
                string msg = "Вы не расставили все корабли.";
                MessageBox.Show(msg);
            }
            timer1.Stop();

            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Enabled = true;
            timer2.Start();
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            string msg = "Программа будет полностью перезапущена. r u sure?";
            DialogResult dr = MessageBox.Show(msg, "restart", MessageBoxButtons.YesNo);
            if(dr == DialogResult.Yes)
            {
                Application.Restart();
            }
            else if (dr == DialogResult.No)
            {

            }


        }
        private void Sound_CheckBox(object sender, EventArgs e)
        {
            if (clickedCB)
            {
                g1.p1.ToggleOn = false;
                g1.p2.ToggleOn = false;
                clickedCB = false;
            }
            else if (!clickedCB)
            {
                g1.p1.ToggleOn = true;
                g1.p2.ToggleOn = true;
                clickedCB = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(g1.p1.brain.units.Count == 10)
            {
                g1.p1.Enabled = false;
            }
           
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (g1.p1.brain.maxShip == 0)
            {
                string msg = "Вы проиграли.";
                MessageBox.Show(msg);
                timer2.Enabled = false;
                timer2.Stop();

            }
            else if (g1.p2.brain.maxShip == 0)
            {
                string msg = "Вы выйграли.";
                MessageBox.Show(msg);
                timer2.Enabled = false;
                timer2.Stop();
            }
        }

        private void horizontalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = horizontalToolStripMenuItem1.Text;
            Ship.direction = ShipDirection.horizontal;
        }

        private void verticalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = verticalToolStripMenuItem1.Text;
            Ship.direction = ShipDirection.vertical;
        }
    }
}
