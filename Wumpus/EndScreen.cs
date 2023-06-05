using Cao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wumpus
{
    public partial class EndScreen : Form
    {
        private GameControl gamecControl;
        public EndScreen(GameControl gameControl, bool won)
        {
            InitializeComponent();
            this.gamecControl = gameControl;
            if (won)
            {
                label1.Text = "Comrade Putin!\nWe applaud your great success in destroying the Prosecutor!\nYou truly showed him who's boss!\nHowever, there was something we forgot to account for...\nThe celebration you held immediately after your victory\nattracted a great mass of people.\nSome of those people were ZSU.\nLong story short, you've been arrested\nand taken into custody at Lukyanivska Prison.\nBy the way, this prison had...\n47 inmates with active tuberculosis in 2011.\nBut do not worry, we have already booked your\nplane tickets to the Hague!\n\nxoxo\nMember of the Free Russia Movement\nRecent supporter of Ukraine\nsergei shoigu";
            }
            else
            {
                label1.Text = "Comrade Putin\nYou tried so far,\nand got so far,\nbut in the end, it didn't even matter.\nThat was Pushkin, by the way.\nAs you spend your time in the Hague, make sure to\nlook on the bright side of things!\nAt least you weren't sent to that Ukranian prison with 47\ninmates with tuberculosis in 2011.\n\nxoxo,\nFormer General of the Russian Army\nsergei shoigu ";
            }
        }

        private void EndScreen_Load(object sender, EventArgs e)
        {

        }

        private void buttonRetry_Click(object sender, EventArgs e)
        {
            gamecControl.showMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gamecControl.showCredits();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
