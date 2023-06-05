using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epshtein
{
    public class Player
    {
        public int arrows { get; set; } = 3;
        public int gold { get; set; } = 0;
        public int turnsTaken { get; set; } = 0;

        /// <summary>
        /// Calculates the points scored in a given playthrough based on params
        /// </summary>
        /// <param name="killedWumpus">Whether or not the wumpus was killed during the playthrough</param>
        /// <param name="difficulty">Difficulty during the playthrough</param>
        /// <returns>Points scored during the playthrough</returns>
        public int CalculatePoints(bool killedWumpus, int difficulty)
        {
            return 100 - turnsTaken + gold + (5 * arrows) + (killedWumpus ? 50 : 0) + (difficulty-1) * 15;
        }

        /// <summary>
        /// Tries to spend one arrow. 
        /// </summary>
        /// <returns>Whether or not the player has enough gold to pay</returns>
        public bool PayArrow()
        {
            if (arrowsValid()) { arrows--; return true; }
            else { return false; }
        }

        public bool arrowsValid() { return arrows > 0; }

        /// <summary>
        /// Tries to spend gold. Amount to spend determined by params
        /// </summary>
        /// <param name="amount">Amount of gold to spend</param>
        /// <returns>Whether or not the player has enough gold to pay</returns>
        public bool payGold(int amount)
        {
            //the more verbose form of validation is required, as the game does not necessarily end if the player runs out of gold
            if (gold < 1)
            {
                return false;
            }
            gold -= amount;
            return true;
        }
    }
}