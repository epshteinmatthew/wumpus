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
        private  DateTime startTime;
        private DateTime endTime;
        private Dictionary<string, int> scores = new Dictionary<string, int>();
        private Dictionary<string, TimeSpan> times = new Dictionary<string, TimeSpan>();
        private GameControl gc;
        private ListBox leaderboardListBox;

        public Leaderboard(GameControl gameControl)
        {
            InitializeComponent();
            this.gc = gameControl;
            try
            {
                using (var sr = new StreamReader("scores.txt"))
                {
                    string line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        scores.Add(line.Split(',')[0], int.Parse(line.Split(',')[1]));
                    }
                }
            }
            catch (Exception)
            {
                File.Create("scores.txt");
            }

            try
            {
                using (var sr = new StreamReader("times.txt"))
                {
                    string line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        times.Add(line.Split(',')[0], TimeSpan.Parse(line.Split(',')[1]));
                    }
                }
            }
            catch (Exception)
            {
                File.Create("times.txt");
            }
            
            
            
        }

        private void populateListBox(int type)
        {
            //todo: this does not clear for some unknown reason!! fix!!
            leaderboardListBox.Items.Clear();
            switch (type)
            {
                case 0:
                    //score.
                    foreach (var item in scores.Values.OrderByDescending(x => x))
                    {
                        leaderboardListBox.Items.Add(item.ToString());
                    }
                    return; 
                case 1:
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
        public string endRun(DateTime start)
        {
            startTime = start;
            endTime = DateTime.Now;
            var total = endTime - startTime;
            return total.Days + ":" + total.Hours + ":" + total.Minutes + ":" + total.Seconds;
        }


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
            times.Add((gen == 0 ? name : name + gen), (endTime - startTime));
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
            populateListBox(0);
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
            if (radioButtonScore.Checked)
            {
                populateListBox(0);
            };
        }

        private void radioButtonTime_CheckedChanged_1(object sender, EventArgs e)
        {
           
            if (radioButtonTime.Checked)
            {
                populateListBox(1);
            };
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            gc.showMenu();
        }
    }
}