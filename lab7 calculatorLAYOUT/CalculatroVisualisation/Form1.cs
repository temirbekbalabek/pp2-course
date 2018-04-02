using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatroVisualisation
{
    public partial class Form1 : Form
    {
        double value = 0;
        string operation = "";
        string copy = "";
        bool operation_pressed = false;
        bool result = false;
        bool MemoryIsPressed = false;
        public Form1()
        {
            InitializeComponent();
        }
       
        private void button_Click(object sender, EventArgs e)
        {


            Button btn = sender as Button;
            if (btn.Text == ",")
            {
                if (!display.Text.Contains(","))
                {
                    operation_pressed = false;
                    display.Text = display.Text + btn.Text;
                }
                else
                {

                }
            }
            else
            {
                if (display.Text == "0" || operation_pressed || result)
                {
                    display.Clear();
                    result = false;
                }

                operation_pressed = false;
                display.Text = display.Text + btn.Text;
            }
           
        }


        private void ClearEntry_Click(object sender, EventArgs e)
        {
            display.Text = "0";
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(btn.Text == "xⁿ")
            {
                operation = "^";
                value = Double.Parse(display.Text);
                operation_pressed = true;
                backgroundtext.Text = value + " " + operation;
            }
            else
            {

                operation = btn.Text;
                value = Double.Parse(display.Text);
                operation_pressed = true;
                backgroundtext.Text = value + " " + operation;
            }
            
        }

        private void FullClear_Click(object sender, EventArgs e)
        {
            display.Clear();
            backgroundtext.Text = "";
            value = 0;
            display.Text = "0";
        }

        private void equal_Click(object sender, EventArgs e)
        {
            backgroundtext.Text = "";
            switch (operation)
            {
                case "+":
                    display.Text = (value + Double.Parse(display.Text)).ToString();
                    result = true;
                    break;
                case "-":
                    display.Text = (value - Double.Parse(display.Text)).ToString();
                    result = true;
                    break;
                case "*":
                    display.Text = (value * Double.Parse(display.Text)).ToString();
                    result = true;
                    break;
                case "/":
                    display.Text = (value / Double.Parse(display.Text)).ToString();
                    result = true;
                    break;
                case "^":
                    display.Text = (Math.Pow(value, double.Parse(display.Text))).ToString();
                    result = true;
                    break;
                default:
                    break;
            }
        }


        private void Power_Click(object sender, EventArgs e)
        {
            value = double.Parse(display.Text);
            display.Text = (Math.Pow(value, 2)).ToString();
        }

        private void inverse_Click(object sender, EventArgs e)
        {
            value = double.Parse(display.Text);
            display.Text = (1/value).ToString();
        }

        private void squareroot_Click(object sender, EventArgs e)
        {
            value = double.Parse(display.Text);
            backgroundtext.Text = "√(" + value + ")";
            display.Text = (Math.Sqrt(value)).ToString();
        }

        private void negate_Click(object sender, EventArgs e)
        {
            display.Text = (-1 * (double.Parse(display.Text))).ToString();
        }

        private void копироватьCtrlCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copy = display.Text;
            display.Text = "0";
        }

        private void вставитьCtrlVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            display.Text = copy;
        }

        private void CopyPaste_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && e.Control)
            {
                copy = display.Text;
                //display.Text = "0";
            }
            else if (e.KeyCode == Keys.V && e.Control)
            {
                display.Text = copy;
            }
        }

        private void erase_Click(object sender, EventArgs e)
        {
            if (display.Text != "0") 
            {
                string s = display.Text;
                s = s.Remove(s.Length - 1);
                display.Text = s;
            }
            if (display.Text == "")
            {
                display.Text = "0";
            }
        }

        private void Memory_Click(object sender, EventArgs e)
        {
            if (!MemoryIsPressed)
            {
                MemoryIsPressed = true;
                button25.Enabled = true; // MC, MR, MS
                button27.Enabled = true;
                button29.Enabled = true;
            }
          
        }

        private void MemoryClear_Click(object sender, EventArgs e)
        {
            MemoryIsPressed = false;
            button25.Enabled = false; // MC, MR, MS
            button27.Enabled = false;
            button29.Enabled = false;
        }
    }
}
