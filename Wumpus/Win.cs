using _1095652_Roth_HuntTheWumpus;
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
        public Win()
        {
            InitializeComponent();
        }

        private void buttonRetry_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();

            this.Close();

            //code to reset variables here:
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Win_Load(object sender, EventArgs e)
        {

        }
    }
}
