using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Cao;

namespace Wumpus.Epshtein
{
    public partial class Leaderboard : Form
    {
        private TimeSpan runTime;
        private Dictionary<string, int> scores = new Dictionary<string, int>();
        private Dictionary<string, TimeSpan> times = new Dictionary<string, TimeSpan>();
        private GameControl gc;
        private ListBox leaderboardListBox = new ListBox();
        bool closeButtonClicked = false;

        public Leaderboard(GameControl gameControl)
        {
            InitializeComponent();
            this.gc = gameControl;
            try
            {
                using (var sr = new StreamReader("scores.txt"))
                {
                    string line;
                    // Read lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        scores.Add(line.Split(',')[0], int.Parse(line.Split(',')[1]));
                    }
                }
            }
            catch
            {
                File.Create("scores.txt");
            }

            try
            {
                using (var sr = new StreamReader("times.txt"))
                {
                    string line;
                    // Read lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        times.Add(line.Split(',')[0], TimeSpan.Parse(line.Split(',')[1]));
                    }
                }
            }
            catch 
            {
                File.Create("times.txt");
            }
            
            
            
        }

        /// <summary>
        /// Populates leaderboard list box with data about runs. Times are ordered lowest -> highest, and Scores are ordered highest -> lowest.
        /// </summary>
        private void populateListBox()
        {
            leaderboardListBox.Items.Clear();
            switch (radioButtonScore.Checked)
            {
                case true:
                    //score.
                    foreach (var item in scores.Values.OrderByDescending(x => x))
                    {
                        leaderboardListBox.Items.Add(item.ToString());
                    }
                    return; 
                case false:
                    //time
                    foreach (var item in times.Values.OrderBy(x => x))
                    {
                        leaderboardListBox.Items.Add(item.ToString());   
                    }
                    return;
                default:
                    return;
            }
        }

        /// <summary>
        /// Ends the run and saves the time spent to a variable
        /// </summary>
        /// <param name="start">The time when the run started</param>
        /// <returns>A formatted string conatining the run time</returns>
        public string endRun(DateTime start)
        {
            runTime = DateTime.Now - start;
            return runTime.Days + ":" + runTime.Hours + ":" + runTime.Minutes + ":" + runTime.Seconds;
        }

        /// <summary>
        /// Writes data about the run to the disk, such as time, score, and name
        /// </summary>
        /// <param name="score">Points scored during the run</param>
        /// <param name="name">Name of person who completed the run</param>
        public void writeItemsToFile(int score, string name)
        {
            var rand = new Random();
            var gen = 0;
            var adder = 0;
            while (scores.ContainsKey(gen == 0 ? name : name + gen) || times.ContainsKey((gen == 0 ? name : name + gen)))
            {
                gen = rand.Next(1, 10000);
            }
            while (scores.ContainsValue(score+adder))
            {
                adder++;
            }
            times.Add((gen == 0 ? name : name + gen), (runTime));
            scores.Add((gen == 0 ? name : name + gen), score+adder);

            //write everything to file now
             using (var sw = new StreamWriter(new FileStream("scores.txt", FileMode.Create)))
             {
                 foreach (string key in scores.Keys)
                 {
                     sw.WriteLine(key + "," + scores[key].ToString());
                 }
             }
             
             using (var sw = new StreamWriter(new FileStream("times.txt", FileMode.Create)))
             {
                 foreach (string key in times.Keys)
                 {
                     sw.WriteLine(key + "," + times[key].ToString());
                 }
             }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void Leaderboard_Load(object sender, EventArgs e)
        {
            radioButtonScore.Checked = true;
            populateListBox();
        }

        private void leaderboardList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (leaderboardListBox.SelectedIndex == -1)
            {
                return;
            }
            string name = radioButtonScore.Checked ? scores.FirstOrDefault(x => x.Value == int.Parse(leaderboardListBox.SelectedItem.ToString())).Key : times.FirstOrDefault(x => x.Value == TimeSpan.Parse(leaderboardListBox.SelectedItem.ToString())).Key;

            textBoxName.Text = name;
            textBoxScore.Text = (scores.ContainsKey(name) ? scores[name].ToString()  : " ");
            textBoxTime.Text = (times.ContainsKey(name) ? times[name].ToString()  : " ");
        }

        private void radioButtonTime_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButtonScore_CheckedChanged(object sender, EventArgs e)
        {
                populateListBox();
        }

        private void radioButtonTime_CheckedChanged_1(object sender, EventArgs e)
        {
                populateListBox();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            closeButtonClicked = true;
            gc.showMenu();
        }

        private void Leaderboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closeButtonClicked)
            {
                Environment.Exit(0);
            }
        }
    }
}