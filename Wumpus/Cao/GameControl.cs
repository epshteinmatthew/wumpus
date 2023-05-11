using Epshtein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cao
{

    public class GameControl

    {
        //implement:
        //move, this should attempt to move the player to some room, then check for wumpus, harzards, and warning, and handle those events accordingly. this should additionally talk to the form
        public GameLocations Gamelocations { get; set; } = new GameLocations(0,0);
        public Player Player { get; set; } = new Player();
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
        public bool Shoot(int ShootTo)
        {
            if (Player.arrowsValid() == false)
            {
                return false;
            }
            
            //1. verify that player has enough arrows. Player has a method for this
            //2. call gameLocations's shootarrow method to the target rom and tore the return value in a variable
            //3. if true, kill wumpus and trigger end of game
            //4. if false, decrement arrow from Player Object
            return Gamelocations.shootArrow(ShootTo);
        }
        public bool Arrows()
        {
            return Player.arrowsValid();
        }
        public int GameLocation(int MoveTo)
        {
            return Gamelocations.getPlayerLocation();
        }
        public int Trivia()
        {
            return 0;
        } 
        public int Coin()
        {
            return Player.gold;
        }
        public int WumpusLocation()
        {
            return Gamelocations.wumpusLocation;
        }

    }   
}
