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
        public Form1()
        {
            InitializeComponent();

        }
        /*private void AddLabelPlayer()
        {
            int SIZE = 20;
            Label LblPlayer = new Label();
            LblPlayer.Text = "Player";
            LblPlayer.AutoSize = true;
            LblPlayer.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            Location = new Point(this.Location.X + (SIZE * 10) / 2 - LblPlayer.Width / 2 + SIZE, Location.Y - 5);
        }*/
        private void RandomGeneration(object sender, EventArgs e)
        {
            //this.Controls.IndexOf()
        }
        private void SetDirectionToLeft(object sender, EventArgs e)
        {
            Ship.direction = ShipDirection.left;
            
        }
        private void SetDirectionToRight(object sender, EventArgs e)
        {
            Ship.direction = ShipDirection.right;

        }
        private void SetDirectionToUpt(object sender, EventArgs e)
        {
            Ship.direction = ShipDirection.up;

        }
        private void SetDirectionToDown(object sender, EventArgs e)
        {
            Ship.direction = ShipDirection.down;

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void humanVShumanMODE(object sender, EventArgs e)
        {

        }

        private void humanVSbotMODE(object sender, EventArgs e)
        {

        }
        GameLogic g1 = new GameLogic();
        private void StartGame_Click(object sender, EventArgs e)
        {
            string msg = "Вы уверены, что хотите начать новую игру? Предыдущая игра будет законченаза вас.";
            DialogResult dialogresult = MessageBox.Show(msg, "New Game", MessageBoxButtons.YesNo);
            if (dialogresult == DialogResult.Yes)
            {
                //GameLogic g1 = new GameLogic();
                this.Controls.Add(g1.p1);
                this.Controls.Add(g1.p2);
                button1.Visible = true;
            }
            else if (dialogresult == DialogResult.No)
            {

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = "Вы уверены, что хотите покинуть игру? Предыдущая игра будет закончена за вас.";
            DialogResult dialogresultForExit = MessageBox.Show(msg, "New Game", MessageBoxButtons.YesNo);
            if (dialogresultForExit == DialogResult.Yes)
            {

            }
            else if (dialogresultForExit == DialogResult.No)
            {
                Environment.Exit(1);
            }
        }
        delegate void MyDelegate();
        private void button1_Click(object sender, EventArgs e)
        {
            g1.p2.RandomGenerateShips();
            g1.p1.RandomGenerateShips();
            
        }
    }
}
