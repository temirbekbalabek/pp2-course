using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Battleship
{
    enum PanelPosition
    {
        Left,
        Right
    }
    

    public enum PlayerType
    {
        Human,
        Bot
    }

    class PlayerPanel : Panel
    {
        public Brain brain;
        int cellW = 35;
        PanelPosition panelPosition;
        PlayerType playerType;
        private RibbonUpDown ribbonUpDown1;
        TurnDelegate tDelegate;
        public bool ToggleOn = false;
        public Color ColorToFillBusy;

        public PlayerPanel(PanelPosition panelPosition, PlayerType playerType,TurnDelegate tDelegate, Color ColorToFillBusy)
        {
            this.panelPosition = panelPosition;
            this.playerType = playerType;
            this.tDelegate = tDelegate;
            this.ColorToFillBusy = ColorToFillBusy;

            Initialize();

            //Random rnd1 = new Random(Guid.NewGuid().GetHashCode());
            //Random rnd2 = new Random(Guid.NewGuid().GetHashCode());

            if (playerType == PlayerType.Human)
            {
                //RandomGenerateShips();
            }

            if (playerType == PlayerType.Bot)
            {
                //RandomGenerateShips();
                this.Enabled = false;
            }
        }
        public void RandomGenerateShips()
        {
            Random rnd1 = new Random(Guid.NewGuid().GetHashCode());
            Random rnd2 = new Random(Guid.NewGuid().GetHashCode());
            while (brain.stIndex < brain.st.Length - 1)
            {
                int row = rnd1.Next(0, 10);
                int column = rnd1.Next(0, 10);
                string msg = string.Format("{0}_{1}", row, column);
                brain.Process(msg);
            }
        }
        private void Initialize()
        {
            
            this.Location = new Point(cellW + 10, cellW + 20);

            if (panelPosition == PanelPosition.Right)
            {
                this.Location = new Point(cellW * 10 + cellW + 200, cellW + 20);
            }

            this.BackColor = SystemColors.ActiveCaption;
            this.Size = new Size(cellW * 10, cellW * 10);


            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    Button btn = new Button();
                    btn.Name = i + "_" + j;
                    btn.Click += Btn_Click;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatAppearance.BorderColor = Color.Bisque;
                    btn.Size = new Size(cellW, cellW);
                    btn.Location = new Point(i * cellW, j * cellW);
                    this.Controls.Add(btn);
                }
               
            }
            brain = new Brain(DrawButton);
            
        }



        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (brain.stIndex < brain.st.Length - 1)
            {
                brain.Process(btn.Name);

            }
            else
            {
                if (!brain.ShootingProcess(btn.Name))
                {
                    tDelegate.Invoke();
                }
                else if (brain.ShootingProcess(btn.Name))
                {

                }
            }
        }
       
        private void DrawButton(CellState[,] map)
        {
            SoundPlayer player = new SoundPlayer(@"C:\Users\Dauren\Desktop\vistrel.wav");
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    Color colorToFill = Color.White;
                    bool isEnabled = true;

                    switch (map[i, j])
                    {
                        case CellState.empty:
                            colorToFill = Color.White;
                            break;
                        case CellState.busy:
                            /*if (playerType == PlayerType.Human)
                            {
                                colorToFill = Color.Tan;
                            }
                            else if (playerType == PlayerType.Bot)
                            {
                                colorToFill = Color.White;

                            }*/
                            colorToFill = ColorToFillBusy;
                            break;
                        case CellState.aura:
                            colorToFill = Color.White;
                            break;
                        case CellState.striked:
                            colorToFill = Color.Orange;
                            if (ToggleOn)
                            {
                                player.Play();
                            }
                            else if (!ToggleOn)
                            {

                            }
                            isEnabled = false;
                            break;
                        case CellState.missed:
                            colorToFill = Color.LightBlue;
                            isEnabled = false;
                            break;
                        case CellState.killed:
                            colorToFill = Color.Red;
                            isEnabled = false;
                            break;
                        default:
                            break;
                    }

                    this.Controls[10 * i + j].BackColor = colorToFill;
                    this.Controls[10 * i + j].Enabled = isEnabled;
                }
            }


        }
        private void InitializeComponent()
        {
            this.ribbonUpDown1 = new System.Windows.Forms.RibbonUpDown();
            this.SuspendLayout();
            // 
            // ribbonUpDown1
            // 
            this.ribbonUpDown1.TextBoxText = "";
            this.ribbonUpDown1.TextBoxWidth = 50;
            this.ResumeLayout(false);

        }
    }
}
