using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task33
{
    public partial class Form1 : Form
    {
        int cellW = 150, cellH = 150;
        int cnt;
        int[,] btns = new int[3, 3];
        Button startButton;
        public Form1()
        {
            InitializeComponent();
            startButton = new Button();
            startButton.Size = new Size(250, 150);
            startButton.Text = "START NEW GAME";
            startButton.Location = new Point(110, 160);
            startButton.Click += button1_Click;
            this.Controls.Add(startButton);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            startButton.Visible = false;
            cnt = 0;
            int k = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    k++;
                    Button btn = new Button();
                    btn.Name = i + "_" + j;
                    btns[i, j] = k;
                    btn.Size = new Size(cellW, cellH);
                    btn.Location = new Point(i * cellW, j * cellH);
                    btn.Click += btn_Click;
                    this.Controls.Add(btn);

                }
            }
        }
        private void btn_Click(object sender, EventArgs e)
        {
            cnt++;
            Button btn = sender as Button;
            int i = int.Parse(btn.Name[0].ToString());
            int j = int.Parse(btn.Name[2].ToString());
            if (cnt % 2 == 1)
            {
                btn.Text = "X";
                btn.Font = new Font("Arial", 80, FontStyle.Bold);
                btns[i, j] = 1;
            }
            else if (cnt % 2 == 0)
            {
                btn.Text = "O";
                btn.Font = new Font("Arial", 80, FontStyle.Bold);
                btns[i, j] = 0;
            }
            btn.Enabled = false;
            if (GameOverCheck(btns, btn))
            {
                this.Controls.Clear();

                startButton = new Button();
                startButton.Size = new Size(250, 150);
                startButton.Text = "START NEW GAME";
                startButton.Location = new Point(110, 160);
                startButton.Click += button1_Click;
                this.Controls.Add(startButton);
            }

        }
        private static bool GameOverCheck(int[,] btns, Button btn)
        {
            for (int i = 0; i < 3; i++)
            {
                if (btns[i, 0] == btns[i, 1] && btns[i, 0] == btns[i, 2])
                {
                    MessageBox.Show(btn.Text + " wins!");
                    return true;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (btns[0, i] == btns[1, i] && btns[0, i] == btns[2, i])
                {
                    MessageBox.Show(btn.Text + " wins!");
                    return true;
                }
            }
            if (btns[0, 0] == btns[1, 1] && btns[0, 0] == btns[2, 2])
            {
                MessageBox.Show(btn.Text + " wins!");
                return true;
            }
            else if (btns[0, 2] == btns[1, 1] && btns[0, 2] == btns[2, 0])
            {
                MessageBox.Show(btn.Text + " wins!");
                return true;
            }

            return false;
        }
    }
}
