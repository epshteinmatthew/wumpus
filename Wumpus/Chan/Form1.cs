using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chan
{
    

    public partial class FormCaveTestForm : Form
    {

        List<Cave> caves = new List<Cave>();
        public FormCaveTestForm()
        {
            InitializeComponent();
        }

        private void buttonRandomNumber_Click(object sender, EventArgs e)
        {
            string cavenumber = "cave";
            int room = 1;
            Cave cave = new Cave(cavenumber, room);
            labelNumber.Text = cave.GetCaveSystem();
        }

        private void buttons_Click(object sender, EventArgs e)
        {
            string cavenumber = "cave";
            int room = 30; //I need to retrieve current room number from game locations
            Cave cave = new Cave(cavenumber, room);
            labels.Text = cave.GetAdjacentCaves(room)[0].ToString() + " " + cave.GetAdjacentCaves(room)[1].ToString() + " " +
                cave.GetAdjacentCaves(room)[2].ToString() + " " + cave.GetAdjacentCaves(room)[3].ToString() + " " +
                cave.GetAdjacentCaves(room)[4].ToString() + " " + cave.GetAdjacentCaves(room)[5].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cavenumber = "cave";
            int room = 30; //I need to retrieve current room number from game locations
            Cave cave = new Cave(cavenumber, room);
            labelconnections.Text = cave.GetConnectedCaves(room)[0].ToString() + " " + cave.GetConnectedCaves(room)[1].ToString() + " " +
            cave.GetConnectedCaves(room)[2].ToString() + " " + cave.GetConnectedCaves(room)[3].ToString() + " " +
            cave.GetConnectedCaves(room)[4].ToString() + " " + cave.GetConnectedCaves(room)[5].ToString();

        }

        private void FormCaveTestForm_Load(object sender, EventArgs e)
        {

        }
    }
}
