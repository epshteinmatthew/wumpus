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

namespace _1095652_Roth_HuntTheWumpus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        //TODO: This
        public void updateRooms(int[] adj, int[] con)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //drawes the hexagon buttons
            GraphicsPath hexagon = new GraphicsPath();
            Point[] points = { new Point(0, 50), new Point(25, 10), new Point(75, 10), new Point(100, 50), new Point(100, 50), new Point(75, 90), new Point(25, 90), new Point(0, 50) };
            hexagon.AddLines(points);
            button1.Region = new Region(hexagon);
            button2.Region = new Region(hexagon);
            button3.Region = new Region(hexagon);
            button4.Region = new Region(hexagon);
            button5.Region = new Region(hexagon);
            button6.Region = new Region(hexagon);
            button7.Region = new Region(hexagon);
        }
        public void button1_Click(object sender, EventArgs e)
        {
            MoveButtonClicked();
        }
        public void button2_Click(object sender, EventArgs e)
        {
            MoveButtonClicked();
        }
        public void button3_Click(object sender, EventArgs e)
        {
            MoveButtonClicked();
        }
        public void button6_Click(object sender, EventArgs e)
        {
            MoveButtonClicked();
        }
        public void button7_Click(object sender, EventArgs e)
        {
            MoveButtonClicked();
        }
        public void button4_Click(object sender, EventArgs e)
        {
            MoveButtonClicked();
        }
        private void buttonShoot_Click(object sender, EventArgs e)
        {
            //enables the hexagon buttons disables the move button
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            buttonMove.Enabled = false;
        }
        private void buttonMove_Click(object sender, EventArgs e)
        {
            //enables the hexagon buttons disables the shoot button
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            buttonShoot.Enabled = false;
        }
        private void MoveButtonClicked()
        {
            //disables hexagon buttons and enables the move/shoot buttons
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
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
    }
}
