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
        //the amount of "printing presses" on at any time
        public int amountOn = 0;
        bool genForNow = false;
        public PressMinigame()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Tries to get a random button out of the 9 in the form
        /// </summary>
        /// <returns>A random button if it exists, otherwise button1</returns>
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

        /// <summary>
        /// Handles a button click, decides what to do next based on program state
        /// </summary>
        /// <param name="button">The button which was hit</param>
        public void buttonHitHandler(Button button)
        {
            if(button.ForeColor == Color.Black)
            {
                return;
            }
            button.ForeColor = Color.Black;
            button.Text = "Printing Press: \nOff";
            amountOn--;
            Button nextUp = getRandomButton();
            if (genForNow)
            {
                genForNow = false;
                return;
            }
            nextUp.ForeColor = Color.Red;
            nextUp.Text = "Printing Press: \nOn";
            amountOn++;
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
             if(generat.NextDouble() > 0.5)
            {
                Button nextUp = getRandomButton();
                if (nextUp.ForeColor == Color.Red) return;
                nextUp.ForeColor = Color.Red;
                nextUp.Text = "Printing Press: \nOn";
                amountOn++;
                genForNow = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if(amountOn > 3)
            {
                //stops all timers, prevents improper disposal
                //https://stackoverflow.com/questions/29626/cannot-access-a-disposed-object-how-to-fix
                timer3.Stop();
                timer2.Stop();
                timer1.Stop();
                this.Close();
            }
        }
    }
}
