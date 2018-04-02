using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics1
{
    public partial class Form1 : Form
    {
        /*Point firstPoint = default(Point);
        Point secondPoint = default(Point);
        Graphics gfx = default(Graphics);
        Pen pen = new Pen(Color.Red, 3);*/
        Graphics gr;
        Pen myPen = new Pen(Color.Black, 1);
        float GameWidth = 1000;
        float GameHeight = 600;

        public Form1()
        {
            InitializeComponent();
            gr = CreateGraphics();
            
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            myPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            myPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //
            // Setting up background
            //
            DrawBackground(GameWidth, GameHeight);

            //
            // Drawing some stars
            //
            DrawStar(50, 70, 14);
            DrawStar(350, 65, 14);
            DrawStar(650, 125, 14);
            DrawStar(850, 305, 14);
            DrawStar(50, 450, 14);
            DrawStar(350, 400, 14);
            DrawStar(720, 410, 14);
            DrawStar(900, 380, 14);

            //
            // Setting up Information table
            //
            DrawInfoTable(700, 30, 250, 40);

            //
            // Drawing SpaceShip
            //
            DrawSpaceship(450, 250);

            // 
            // Drawing some asteroids
            //
            DrawAsteroid(150, 220);
            DrawAsteroid(270, 350);
            DrawAsteroid(850, 170);
            DrawAsteroid(650, 520);

            //
            // Drawing bullet
            //
            DrawBullet(480, 190);




        }

        private void DrawBackground(float x, float y)
        {
            Brush myBrush = new SolidBrush(Color.BlueViolet);
            RectangleF BackgroundRectangle = new RectangleF(new Point(0, 0), new SizeF(x, y));
            gr.FillRectangle(myBrush, BackgroundRectangle);

            myPen.Width = 25;
            gr.DrawRectangle(myPen, 0, 0, x, y);
        }
        private void DrawInfoTable(float x, float y, float w, float h)
        {
            RectangleF InfoTable = new RectangleF(new PointF(x, y), new SizeF(w, h));
            gr.FillRectangle(Brushes.White, InfoTable);

            myPen.Width = 2;
            myPen.Color = Color.Orange;
            gr.DrawRectangle(myPen, x, y, w, h);

            string DrawString = "Level: 1 Score: 200 Live: ***";
            Font DrawFont = new Font("Arial", 14);
            Brush DrawBrush = new SolidBrush(Color.Red);
            PointF DrawPoint = new PointF(x+2, y+9);
            gr.DrawString(DrawString, DrawFont, DrawBrush, DrawPoint);

        }

        private void DrawStar(float x, float y, float size)
        {
            RectangleF star = new RectangleF(new PointF(x, y), new SizeF(size*3, size*3));
            gr.FillEllipse(Brushes.White, star);

           
        }

        private void DrawSpaceship(float x, float y)
        {
            PointF[] spaceshipPoints = {
                new PointF(x, y),
                new PointF(x + 60, y - 20),
                new PointF(x + 120, y),
                new PointF(x + 120, y + 50),
                new PointF(x + 60, y + 70),
                new PointF(x, y + 50) };  

            gr.FillPolygon(Brushes.Yellow, spaceshipPoints);
            DrawGun(x+50, y+24);

        }
        private void DrawGun(float x, float y)
        {
            PointF[] gunPoints = {
                new PointF(x, y),
                new PointF(x - 7, y),
                new PointF(x + 10, y - 22),
                new PointF(x + 27, y),
                new PointF(x + 20, y),
                new PointF(x + 20, y + 22),
                new PointF(x, y + 22)};

            gr.FillPolygon(Brushes.Green, gunPoints);
        }

        private void DrawAsteroid(float x, float y)
        {
            PointF[] trianglePoints1 =
            {new PointF(x,y),
            new PointF(x + 35, y - 50),
            new PointF(x + 70, y)

            };

            PointF[] trianglePoints2 =
            {new PointF(x, y - 30),
            new PointF(x + 70, y - 30),
            new PointF(x + 35, y + 20)

            };

            gr.FillPolygon(Brushes.Red, trianglePoints1);
            gr.FillPolygon(Brushes.Red, trianglePoints2);



        }

        private void DrawBullet(float x, float y)
        {
            PointF[] bulletPoints =
            {
                new PointF(x, y),
                new PointF(x + 15, y - 5),
                new PointF(x + 25, y - 20),
                new PointF(x + 35, y - 5),
                new PointF(x + 50, y),
                new PointF(x + 35, y + 5),
                new PointF(x + 25, y + 20),
                new PointF(x + 15, y + 5)
            };

            gr.FillPolygon(Brushes.LightGreen, bulletPoints);
        }
    }
}
