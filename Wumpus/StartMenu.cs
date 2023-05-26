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
        public StartMenu(GameControl gameControl)
        {
            InitializeComponent();

            //makes the buttons look cleaner
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
            InitializeComponent();

            //plays audio
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\1229.wav";
            player.PlayLooping();
            this.gameControl = gameControl;
        }
        private void button1_Click(object sender, EventArgs e)
        {
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
            gameControl.credits();
        }

    }
}
