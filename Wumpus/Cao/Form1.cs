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

namespace Cao
{
    public partial class SubmitAnswerButton : Form
    {
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
        };
        //commit test
        
        public void populate()
        {
            string question = questions.Keys.OrderBy(_ => RandomGenerator.Next()).ToArray()[0];
            string[] answers = questions[question].OrderBy(_ => RandomGenerator.Next()).ToArray();
            //SAVE "ANSWER" SOMEHOW: NEEDS TO BE CHECK AGAINBST
            string answer = questions[question][0];

        }

        public SubmitAnswerButton()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void SubmitAnswerButton_Load(object sender, EventArgs e)
        {

        }
    }
}
