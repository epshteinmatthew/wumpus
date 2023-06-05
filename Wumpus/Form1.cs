using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wumpus;
using System.Media;
using Chan_WumpusTest;
using System.Diagnostics;
using Epshtein;
using Cao;

namespace _1095652_Roth_HuntTheWumpus
{
    public partial class Form1 : Form
    {
        Cao.GameControl control;
        public bool closeButtonClicked = false;

        public Form1(GameControl gameControl)
        {
            InitializeComponent();
            control = gameControl;
        }

        /// <summary>
        /// Updates room buttons based on connected and adjacent room arrays taken from params
        /// </summary>
        /// <param name="adj">Rooms adjacent to the user</param>
        /// <param name="con">Rooms connected to the user</param>
        public void UpdateRoomButtons(int[] adj, int[] con)
        {
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            //logic?
            button1.Text = adj[0].ToString();
            if (!con.Contains(adj[0]))
            {
                button1.Visible = false;
            }
            button2.Text = adj[1].ToString();
            if (!con.Contains(adj[1]))
            {
                button2.Visible = false;
            }
            button3.Text = adj[2].ToString();
            if (!con.Contains(adj[2]))
            {
                button3.Visible = false;
            }
            button4.Text = adj[3].ToString();
            if (!con.Contains(adj[3]))
            {
                button4.Visible = false;
            }
            button5.Text = adj[4].ToString();
            if (!con.Contains(adj[4]))
            {
                button5.Visible = false;
            }
            button6.Text = adj[5].ToString();
            if (!con.Contains(adj[5]))
            {
                button6.Visible = false;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //draws the hexagon buttons
            GraphicsPath hexagon = new GraphicsPath();

            Point[] points = { new Point(0, 50), new Point(25, 10), new Point(75, 10), new Point(100, 50), new Point(100, 50), new Point(75, 90), new Point(25, 90)};
            hexagon.AddLines(points);
            button3.Region = new Region(hexagon);
            button2.Region = new Region(hexagon);
            button1.Region = new Region(hexagon);
            button4.Region = new Region(hexagon);
            button123.Region = new Region(hexagon);
            button6.Region = new Region(hexagon);
            button5.Region = new Region(hexagon);
        }

        /// <summary>
        /// Handles a click of the Hexagon-shaped buttons. The specific button which is clicked is taken from params
        /// </summary>
        /// <param name="button">The button clicked by the user</param>
        public void HexagonButtonClickHandler(Button button)
        {
            if (!buttonShoot.Enabled)
            {
                control.Move(int.Parse(button.Text));
                ReenableButtons();
            }
            else if (!buttonMove.Enabled)
            {
                control.Shoot(int.Parse(button.Text));
                ReenableButtons();
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            HexagonButtonClickHandler(sender as Button);
            
        }
        public void button2_Click(object sender, EventArgs e)
        {
            HexagonButtonClickHandler(sender as Button);

        }
        public void button3_Click(object sender, EventArgs e)
        {
            HexagonButtonClickHandler(sender as Button);
        }
        public void button4_Click(object sender, EventArgs e)
        {
            HexagonButtonClickHandler(sender as Button);
        }
        public void button5_Click(object sender, EventArgs e)
        {
            HexagonButtonClickHandler(sender as Button);
        }
        public void button6_Click(object sender, EventArgs e)
        {
            HexagonButtonClickHandler(sender as Button);
        }
        private void buttonShoot_Click(object sender, EventArgs e)
        {
            buttonMove.Enabled = !buttonMove.Enabled;
        }
        private void buttonMove_Click(object sender, EventArgs e)
        {
            buttonShoot.Enabled = !buttonShoot.Enabled;
        }
        private void ReenableButtons()
        {
            buttonMove.Enabled = true;
            buttonShoot.Enabled = true;
        }
        public void buttonPSecret_Click(object sender, EventArgs e)
        {
            control.purchaseSecret();

        }
        public void buttonPArrow_Click(object sender, EventArgs e)
        {
            //answer questions for an arrow
            control.purchaseArrow();

        }
        public void SetArrows(int arrows)
        {
            //sets the total arrows displayed to the variable "arrows"
            textBoxArrows.Text = arrows.ToString();
        }
        public void SetMoney(int money)
        {
            //sets the total money displayed to the variable "money"
            textBoxMoney.Text = money.ToString();
        }
        public void SetText(string text)
        {
            //writes out the text required in the rich textbox through the variable "text"
            richTextBoxText.Text = text;
        }
        private void buttonMenu_Click(object sender, EventArgs e)
        {
            closeButtonClicked = true;
            control.showMenu();

            //code to reset variables here:
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            //closes all forms
            Environment.Exit(0);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (!closeButtonClicked)
            {
                Environment.Exit(0);
            }
        }
    }
}
