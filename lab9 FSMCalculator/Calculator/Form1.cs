using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        Brain brain;
        public CalculatorForm()
        {
            InitializeComponent();
            brain = new Brain();
            display.Text = "0";
            //label.Text = "";
            //labelMemory.Text = "";
            brain.showMessage = ChangeScreen;
            brain.showEquation = ShowLabel;
            brain.change_MS_MC = changeBtnText;
            brain.showMemory = ShowMemoryLabel;
            brain.SetNull();
        }

        private new void Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            brain.Process(btn.Text);
        }

        private void ChangeScreen(string msg)
        {
            display.Text = msg;
        }

        private void ShowLabel(string msg)
        {
            //label1.Text = msg;
        }

        private void ShowMemoryLabel(string msg)
        {
            label1.Text = msg;
        }

        private void changeBtnText(string msg)
        {
            buttonMemoryClear.Text = msg;
        }
    }
}




