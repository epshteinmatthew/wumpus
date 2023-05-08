using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cao
{
    public partial class GameControlMain : Form
    {
        private Control ControlVar;
        public GameControlMain()
        {
            InitializeComponent();
        }

        private void ConstructorButton_Click(object sender, EventArgs e)
        {
            ControlVar = new Control();
        }

        private void GameControlMain_Load(object sender, EventArgs e)
        {

        }
    }
}
