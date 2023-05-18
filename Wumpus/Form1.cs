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

        public Form1()
        {
            control = new GameControl(this);
            InitializeComponent();
        }

        //TODO: This
        public void updateRooms(int[] adj, int[] con)
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
            //drawes the hexagon buttons
            GraphicsPath hexagon = new GraphicsPath();
            Point[] points = { new Point(0, 50), new Point(25, 10), new Point(75, 10), new Point(100, 50), new Point(100, 50), new Point(75, 90), new Point(25, 90), new Point(0, 50) };
            hexagon.AddLines(points);
            button3.Region = new Region(hexagon);
            button2.Region = new Region(hexagon);
            button1.Region = new Region(hexagon);
            button4.Region = new Region(hexagon);
            button123.Region = new Region(hexagon);
            button6.Region = new Region(hexagon);
            button5.Region = new Region(hexagon);
        }
        public void button1_Click(object sender, EventArgs e)
        {
            if (buttonShoot.Enabled == false)
            {
                control.Move(int.Parse(button1.Text));
                MoveButtonClicked();

            }
            else if (buttonMove.Enabled == false)
            {
                control.Shoot(int.Parse(button1.Text));
                MoveButtonClicked();
            }
            
        }
        public void button2_Click(object sender, EventArgs e)
        {
            if (buttonShoot.Enabled == false)
            {
                control.Move(int.Parse(button2.Text));
                MoveButtonClicked();
            }
            else if (buttonMove.Enabled == false)
            {
                control.Shoot(int.Parse(button2.Text));
                MoveButtonClicked();
            }
            
        }
        public void button3_Click(object sender, EventArgs e)
        {
            if (buttonShoot.Enabled == false)
            {
                control.Move(int.Parse(button3.Text));
                MoveButtonClicked();
            }
            else if (buttonMove.Enabled == false)
            {
                control.Shoot(int.Parse(button3.Text));
                MoveButtonClicked();
            }
            
        }
        public void button4_Click(object sender, EventArgs e)
        {
            if (buttonShoot.Enabled == false)
            {
                control.Move(int.Parse(button4.Text));
                MoveButtonClicked();
            }
            else if (buttonMove.Enabled == false)
            {
                control.Shoot(int.Parse(button4.Text));
                MoveButtonClicked();
            }
            
        }
        public void button5_Click(object sender, EventArgs e)
        {
            if (buttonShoot.Enabled == false)
            {
                control.Move(int.Parse(button5.Text));
                MoveButtonClicked();
            }
            else if (buttonMove.Enabled == false)
            {
                control.Shoot(int.Parse(button5.Text));
                MoveButtonClicked();
            }
            
        }
        public void button6_Click(object sender, EventArgs e)
        {
            if (buttonShoot.Enabled == false)
            {
                control.Move(int.Parse(button6.Text));
                MoveButtonClicked();
            }
            else if (buttonMove.Enabled == false)
            {
                control.Shoot(int.Parse(button6.Text));
                MoveButtonClicked();
            }
            
        }
        private void buttonShoot_Click(object sender, EventArgs e)
        {
            buttonMove.Enabled = false;
        }
        private void buttonMove_Click(object sender, EventArgs e)
        {
            
            buttonShoot.Enabled = false;
        }
        private void MoveButtonClicked()
        {
            buttonMove.Enabled = true;
            buttonShoot.Enabled = true;
        }
        public void buttonPSecret_Click(object sender, EventArgs e)
        {
            //answer questions for a secret

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
        public void Win()
        {
            //hides this form and opens the winning form
            this.Hide();
            Win win = new Win();
            win.ShowDialog();

            this.Close();
        }
        public void Die()
        {
            //hides this form and opens the death/lose form
            this.Hide();
            Death dead = new Death();
            dead.ShowDialog();

            this.Close();
        }
        private void buttonMenu_Click(object sender, EventArgs e)
        {
            //hides this form and reopens the menu form
            this.Hide();
            StartMenu menu = new StartMenu();
            menu.ShowDialog();

            this.Close();

            //code to reset variables here:
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            //closes all forms
            Environment.Exit(0);
        }
    }
}
