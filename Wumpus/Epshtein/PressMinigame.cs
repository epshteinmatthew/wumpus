using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wumpus.Epshtein
{
    public partial class PressMinigame : Form
    {
        public int amountHit = 0;
        bool genForNow = false;
        public PressMinigame()
        {
            InitializeComponent();
        }

        private Button getRandomButton()
        {
            Random generator = new Random();
            int nextPop = generator.Next(1,10);
            try
            {
                return this.Controls.Find("button" + nextPop, true)[0] as Button;
            }
            catch
            {
                return button1;
            }
        }

        public void buttonHitHandler(Button button)
        {
            if(button.ForeColor == Color.Black)
            {
                return;
            }
            button.ForeColor = Color.Black;
            button.Text = "Printing Press: \nOff";
            amountHit++;
            Button nextUp = getRandomButton();
            nextUp.ForeColor = Color.Red;
            nextUp.Text = "Printing Press: \nOn";
            genForNow = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buttonHitHandler(sender as Button);
        }

        private void PressMinigame_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random generator = new Random();
            int on = generator.Next();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            buttonHitHandler(sender as Button);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttonHitHandler(sender as Button);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            buttonHitHandler(sender as Button);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buttonHitHandler(sender as Button);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            buttonHitHandler(sender as Button);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            buttonHitHandler(sender as Button);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            buttonHitHandler(sender as Button);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            buttonHitHandler(sender as Button);
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            Random generat = new Random();
            if (genForNow)
            {
                genForNow = false;
                return;
            }
            else if(generat.NextDouble() > 0.5)
            {
                Button nextUp = getRandomButton();
                nextUp.ForeColor = Color.Red;
                nextUp.Text = "Printing Press: \nOn";
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
