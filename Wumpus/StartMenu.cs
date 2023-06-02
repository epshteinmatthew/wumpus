using _1095652_Roth_HuntTheWumpus;
using Cao;
using Epshtein;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Form1 = _1095652_Roth_HuntTheWumpus.Form1;

namespace Wumpus
{
    public partial class StartMenu : Form
    {
        GameControl gameControl;
        bool closeButtonClicked = false;
        public StartMenu(GameControl gameControl)
        {
            InitializeComponent();

            //makes the buttons look cleaner
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
            InitializeComponent();

            this.gameControl = gameControl;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            closeButtonClicked = true;
            //call start form1 method here
            gameControl.startGamePlay();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //closes all forms
            Environment.Exit(0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void buttonCredits_Click(object sender, EventArgs e)
        {
            closeButtonClicked = true;
            gameControl.showCredits();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            closeButtonClicked = true;
            gameControl.showLeaderboard();
        }

        private void StartMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closeButtonClicked)
            {
                Environment.Exit(0);
            }

        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            closeButtonClicked = true;
            gameControl.showSettings();
        }
    }
}
