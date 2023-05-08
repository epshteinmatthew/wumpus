using System;
using System.Collections.Generic;
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
        public Player()
        {
        }

        public int points(bool killedWumpus)
        {
            return 100 - turnsTaken + gold + (5 * arrows) + (killedWumpus ? 50 : 0);
        }

        public bool payArrows()
        {
            if (arrows < 1)
            {
                return false;
            }
            arrows--;
            return true;
        }

        public bool arrowsValid() { return arrows > 0; }

        public bool payGold(int amount)
        {
            if (gold < 1)
            {
                return false;
            }
            gold -= amount;
            return true;
        }
    }
}