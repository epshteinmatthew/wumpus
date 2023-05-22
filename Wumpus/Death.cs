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
        public Death(int score)
        {
            label2.Text = score.ToString();
            InitializeComponent();
        }

        private void buttonRetry_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //closes all forms
            Environment.Exit(0);
        }
    }
}
