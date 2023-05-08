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

namespace _1095652_Roth_HuntTheWumpus
{
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GraphicsPath hexagon = new GraphicsPath();
            Point[] points = { new Point(0,50), new Point(25, 10), new Point(75, 10), new Point(100, 50), new Point(100, 50), new Point(75, 90), new Point(25, 90), new Point(0, 50) };
            hexagon.AddLines(points);
            button1.Region = new Region(hexagon);
            button2.Region = new Region(hexagon);
            button3.Region = new Region(hexagon);
            button4.Region = new Region(hexagon);
            button5.Region = new Region(hexagon);
            button6.Region = new Region(hexagon);
            button7.Region = new Region(hexagon);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            buttonMove.Enabled = true;
            buttonShoot.Enabled = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            buttonMove.Enabled = true;
            buttonShoot.Enabled = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            buttonMove.Enabled = true;
            buttonShoot.Enabled = true;
            
        }
        private void button6_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            buttonMove.Enabled = true;
            buttonShoot.Enabled = true;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            buttonMove.Enabled = true;
            buttonShoot.Enabled = true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            buttonMove.Enabled = true;
            buttonShoot.Enabled = true;
        }
        private void buttonShoot_Click(object sender, EventArgs e)
        {
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
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            buttonShoot.Enabled = false;
        }
        private void buttonPSecret_Click(object sender, EventArgs e)
        {

        }
        private void buttonPArrow_Click(object sender, EventArgs e)
        {

        }
        private void SetArrows(int arrows)
        {
            textBoxArrows.Text = arrows.ToString();
        }
        private void SetMoney(int money)
        {
            textBoxMoney.Text = money.ToString();
        }
        private void SetText(string text)
        {
            richTextBoxText.Text = text;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
