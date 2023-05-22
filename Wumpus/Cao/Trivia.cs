using _1095652_Roth_HuntTheWumpus;
using Epshtein;
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
using Wumpus;

namespace Cao
{
    public partial class SubmitAnswerButton : Form
    {
        string answer;
         int QuestionNumber  = 0;
        public Player player { get; set; }
        public int askNumber { get; set; } = 0;
        public int CorrectNumber { get; set; } = 0;

        Random RandomGenerator = new Random();
        //.OrderBy(_=>generator.Next()).ToArray();
        Dictionary<string, List<string>> questions = new Dictionary<string, List<string>>()
        {
            {"When was the KGB founded?",  new List<string> {"1953", "1954", "1955", "1964" } },
            {"Who plays Lavrentiy Beria in the movie The Death of Stalin",  new List<string> {"George Beale Russell", "Jeffery Tambor", "Steve Buscemi", "Jason Isaacs" } },
            {"In what bomber did Putin fly in during an inspection?", new List<string>{"Tu-160M2", "Tu-160M", "Tu-160S", "Tu-160" } },
            {"What is Putin's shoe size?", new List<string>{"9", "8", "7", "10"} },
            {"Which KGB directorate did Putin work for?", new List<string>{"2nd", "1st", "3rd", "4th" } },
            {"Which of these countries did not withdraw its signature from the Rome Statute?", new List<string>{"China", "Russia", "USA", "Sudan" } },
            {"How many countries are state parties to the Rome Statute?", new List<string>{"123", "139", "112", "90"} },
            {"What discipline did Putin receive his PhD in?", new List<string>{"Economics", "Finance", "Business", "Mechanical Engineering" } },
            {"Who is the chief of Wagner Group?", new List<string>{"Yevgeny Prigozhin", "Dimitry Utkin", "Andrei Troshev", "Konstantin Pikalov" } },
            {"How many Kinzhal missiles did Ukraine claim to have shot down?", new List<string>{"7", "6", "5", "0" } },
            {"Which airport did Russia attack in the opening days of the invasion?", new List<string>{"Antonov Airport", "Odessa Airport", "Mikolayev Airport", "Mariupol Airport"} },
            { }
        };
        //commit test
        
        public void populate()
        {
            string question = questions.Keys.OrderBy(_ => RandomGenerator.Next()).ToArray()[0];
            string[] answers = questions[question].OrderBy(_ => RandomGenerator.Next()).ToArray();
            //SAVE "ANSWER" SOMEHOW: NEEDS TO BE CHECK AGAINST
            answer = questions[question][0];
         

            TriviaQuestion.Text = question;
            //prevent duplicate questions
            questions.Remove(question);
            Answer1.Text = answers[0];
            Answer2.Text = answers[1];
            Answer3.Text = answers[2];
            Answer4.Text = answers[3];

            label4.Text = (QuestionNumber + 1).ToString();
            label5.Text = CorrectNumber.ToString();
            label6.Text = (QuestionNumber - CorrectNumber).ToString();


        }

        public SubmitAnswerButton()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (player.gold >= 1)
            {
                player.payGold(1);
            }
            else
            {
                MessageBox.Show("Comrade, you've ran out of oil money and won't be able to answer any more questions!");
                this.Close();
            }
            if (Answer1.Checked == true && Answer1.Text == answer)
            {
;
                CorrectNumber++;
            }
            if (Answer2.Checked == true && Answer2.Text == answer)
            {

                CorrectNumber++;
            }
            if (Answer3.Checked == true && Answer3.Text == answer)
            {

                CorrectNumber++;
            }
            if (Answer4.Checked == true && Answer4.Text == answer)
            { 
                CorrectNumber++;
            }
            QuestionNumber++;
            
            if (QuestionNumber == askNumber)
            {
                this.Close();
            }
            populate();

        }

        private void SubmitAnswerButton_Load(object sender, EventArgs e)
        {
            label4.Text = (QuestionNumber + 1).ToString();
            label5.Text = CorrectNumber.ToString();
            label6.Text = ( QuestionNumber - CorrectNumber ) .ToString();
        }

        private void SubmitAnswerButton_Activated(object sender, EventArgs e)
        {
            populate();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
