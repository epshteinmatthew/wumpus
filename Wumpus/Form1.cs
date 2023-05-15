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

namespace _1095652_Roth_HuntTheWumpus
{
    public partial class Form1 : Form
    {
        Epshtein.GameLocations locations;

        public Form1()
        {
            locations = new GameLocations(1, 1);
            InitializeComponent();
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
            if (buttonMove.Enabled == true)
            {
                Debug.WriteLine(locations.generateAdjacentRooms(1).ToString());
                button1.Text = locations.generateAdjacentRooms(1)[1].ToString();
                MoveButtonClicked();

            }
            else if (buttonShoot.Enabled == false)
            {
                MoveButtonClicked();
            }
            else
            {
                
            }
            
        }
        public void button2_Click(object sender, EventArgs e)
        {
            if (buttonMove.Enabled == true)
            {
                Debug.WriteLine(locations.generateAdjacentRooms(2).ToString());
                button2.Text = "0";
                MoveButtonClicked();
            }
            else if (buttonShoot.Enabled == false)
            {
                MoveButtonClicked();
            }
            else
            {

            }
            
        }
        public void button3_Click(object sender, EventArgs e)
        {
            if (buttonMove.Enabled == true)
            {
                Debug.WriteLine(locations.generateAdjacentRooms(3).ToString());
                button3.Text = "0";
                MoveButtonClicked();
            }
            else if (buttonShoot.Enabled == false)
            {
                MoveButtonClicked();
            }
            else
            {

            }
            
        }
        public void button4_Click(object sender, EventArgs e)
        {
            if (buttonMove.Enabled == true)
            {
                Debug.WriteLine(locations.generateAdjacentRooms(4).ToString());
                button4.Text = "0";
                MoveButtonClicked();
            }
            else if (buttonShoot.Enabled == false)
            {
                MoveButtonClicked();
            }
            else
            {

            }
            
        }
        public void button5_Click(object sender, EventArgs e)
        {
            if (buttonMove.Enabled == true)
            {
                Debug.WriteLine(locations.generateAdjacentRooms(5).ToString());
                button5.Text = "0";
                MoveButtonClicked();
            }
            else if (buttonShoot.Enabled == false)
            {
                MoveButtonClicked();
            }
            else
            {

            }
            
        }
        public void button6_Click(object sender, EventArgs e)
        {
            if (buttonMove.Enabled == true)
            {
                Debug.WriteLine(locations.generateAdjacentRooms(6).ToString());
                button6.Text = "0";
                MoveButtonClicked();
            }
            else if (buttonShoot.Enabled == false)
            {
                MoveButtonClicked();
            }
            else
            {
                //leave blank
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }
    }
}
