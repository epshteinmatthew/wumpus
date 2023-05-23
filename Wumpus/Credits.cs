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
    public partial class Credits : Form
    {
        GameControl gameControl;
        public Credits(GameControl gc)
        {
            gameControl = gc;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            gameControl.menu();
        }

        private void Credits_Load(object sender, EventArgs e)
        {

        }
    }
}
