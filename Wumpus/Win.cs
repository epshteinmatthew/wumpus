using _1095652_Roth_HuntTheWumpus;
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
    public partial class Win : Form
    {
        public Win(int score)
        {
            InitializeComponent();
            label2.Text = "Your score was: " + score.ToString();
        }

        private void buttonRetry_Click(object sender, EventArgs e)
        {
            this.Close();

            //call control
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //close all forms
            Environment.Exit(0);
        }

    }
}
