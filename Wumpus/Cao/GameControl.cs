using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cao
{
    public class GameControl
    {
        public int LocationUpdate;
        public int ScoringThings;
        public int TriviaTrigger;
        public int ShootingThing;
        public int CoinCount;
        public GameControl()
        {

        }
        
        public int Score()
        {
            return 0;
        }
        public int Shoot(int ShootTo)
        {
            return 0;
        }
        public int GameLocation(int MoveTo)
        {
            return 1;
        }
        public int Trivia()
        {
            return 0;
        } 
        public int Coin()
        {
            return 0;
        }
        public int WumpusLocation()
        {
            return 0;
        }

    }   
}
