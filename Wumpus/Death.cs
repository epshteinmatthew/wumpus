using _1095652_Roth_HuntTheWumpus;
using Cao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wumpus
{
    public partial class Death : Form
    {
        private GameControl gameControl;
        public Death(int score, GameControl gameControl)
        {
            InitializeComponent();
            label2.Text = "Your score was: " + score.ToString();
            this.gameControl = gameControl;
        }

        private void buttonRetry_Click(object sender, EventArgs e)
        {
            gameControl.showMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //closes all forms
            Environment.Exit(0);
        }

        private void Death_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            gameControl.showCredits();
        }
    }
}
