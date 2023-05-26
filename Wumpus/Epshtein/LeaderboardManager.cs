using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wumpus.Epshtein
{
    public class LeaderboardManager
    {
        private DateTime startTime;
        public LeaderboardManager()
        {
            startTime = DateTime.Now;
        }

        public string endRun(int score)
        {
            TimeSpan total = DateTime.Now - startTime;
            string ret = "";
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
        
    }
}
