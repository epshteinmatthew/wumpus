using System;
using System.Collections.Generic;
using System.IO;

namespace Wumpus.Epshtein
{
    public class LeaderboardManager
    {
        private readonly DateTime startTime;
        private DateTime endTime;
        private Dictionary<string, int> scores;
        private Dictionary<string, DateTime> times;
        
        
        public LeaderboardManager()
        {
            startTime = DateTime.Now;
            using (StreamReader sr = new StreamReader("scores.txt"))
            {
                string line;
                // Read and display lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    scores.Add(line.Split(',')[0], int.Parse(line.Split(',')[1]));
                }
            }
            using (StreamReader sr = new StreamReader("times.txt"))
            {
                string line;
                // Read and display lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    times.Add(line.Split(',')[0], DateTime.Parse(line.Split(',')[1]));
                }
            }
        }

        public string endRun()
        {
            endTime = DateTime.Now;
            var total = endTime - startTime;
            var ret = "";
            //something something
            if (total.Days > 0)
            {
                ret += total.Days + " days";
            }

            if (total.Hours > 0)
            {
                ret += ", " + total.Hours + " hours";
            }
            if (total.Minutes > 0)
            {
                ret += ", " + total.Minutes + " minutes";
            }
            if (total.Seconds > 0)
            {
                ret += ", " + total.Seconds + " seconds";
            }
            return ret;
        }

        public void writeItems(int score, string name)
        {
            scores.Add(name, score);
            times.Add(name, new DateTime() + (endTime - startTime));
            
            //write everything to file now
            
            
        }
        
        
    }
}
