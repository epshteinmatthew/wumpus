using Epshtein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wumpus;

namespace Cao
{

    public class GameControl

    {
        //implement:
        //move, this should attempt to move the player to some room, then check for wumpus, harzards, and warning, and handle those events accordingly. this should additionally talk to the form
        public GameLocations Gamelocations { get; set; } = new GameLocations(3,3);
        public Player Player { get; set; } = new Player();
        public int LocationUpdate;
        public int ScoringThings;
        public int TriviaTrigger;
        public int ShootingThing;
        public int CoinCount;
        private _1095652_Roth_HuntTheWumpus.Form1 form1;
        public GameControl(_1095652_Roth_HuntTheWumpus.Form1 form)
        {
            form1 = form;
            int[] AdjacentRooms = Gamelocations.generateAdjacentRooms(Gamelocations.getPlayerLocation());
            int[] ConnectedRooms = Gamelocations.generateConnectedRooms(Gamelocations.getPlayerLocation());
            form1.updateRooms(AdjacentRooms, ConnectedRooms);
            string warnings = "";
            warnings += Gamelocations.getWarnings();
            warnings += Gamelocations.playerLocation.ToString();
            form1.SetText(warnings);
            form1.SetMoney(Player.gold);
            form1.SetArrows(Player.arrows);
        }
        
        public int Score(bool wumpusDead)
        {
            return Player.points(wumpusDead);
        }
        
        public void purchaseArrow()
        {
            SubmitAnswerButton ask3 = new SubmitAnswerButton();
            ask3.askNumber = 3;
            ask3.player = Player;
            ask3.ShowDialog();

            if (ask3.CorrectNumber >= 2)
            {
                Player.arrows++;
                form1.SetArrows(Player.arrows);
            }
        }

        public void Shoot(int ShootTo)
        {
            //1. verify that player has enough arrows. Player has a method for this
            //2. call gameLocations's shootarrow method to the target rom and tore the return value in a variable
            //3. if true, kill wumpus and trigger end of game
            //4. if false, decrement arrow from Player Object
            if (Player.arrowsValid() == false)
            {
                Death death = new Death();
                form1.Close();
                death.ShowDialog();
                return;
            }
            bool success = Gamelocations.shootArrow(ShootTo);
            form1.SetText((ShootTo == Gamelocations.wumpusLocation).ToString());
            if(!success)
            {
                Player.arrows--;
                MessageBox.Show("Comrade! The prosecutor has fled from our kinzhal missile strike in terror!");
                Gamelocations.moveWumpus(1);
                form1.SetArrows(Player.arrows);
                return;
               
            }
            Random r = new Random();
            if(r.NextDouble() > 0.7)
            {
                MessageBox.Show("Comrade! Ukranian Air Defenses have intercepted our kinzhal missile strike on the prosecutor, and he has escaped our surveilance network!");
                Player.arrows--; 
                Gamelocations.moveWumpus(1);
                form1.SetArrows(Player.arrows);
                return;
            }
            MessageBox.Show("Comrade! Our kinzhal missile stike was a succsess! The prosecutor is no more!");
            Win win = new Win();
            win.ShowDialog();
            form1.Close();

            //TOTAL WUMPUS DEATH
        }

        public void Move(int moveTo)
        {
            //1. try to move to moveTo using gameLocation's method
            //2. send an array of adjacent rooms to the ui form(can be done later)
            //3. check for hazards in the player's room. methods should also exist to handle each hazard
            //4. check for wumpus in current player's room. method should exists to handle this as well
            //5. generate and send(send can be done later) warnings and hints for current room to ui form
            if (Gamelocations.movePlayer(moveTo))
            {
                Player.turnsTaken++;
                Player.gold++;
                
            }


            //step 2 here
            string warnings = "";
            if (Gamelocations.isWumpusInRoom(Gamelocations.getPlayerLocation()))
            {
                SubmitAnswerButton ask3 = new SubmitAnswerButton();
                ask3.askNumber = 5;
                ask3.player = Player;
                MessageBox.Show("Comrade! The ICC's Chief Prosecutor Karim Khan knows your exact location! Answer 3 out of 5 trivia questions correctly to shake him off your trail!");
                ask3.ShowDialog();
                if(ask3.CorrectNumber >= 3)
                {
                    Gamelocations.moveWumpus(ask3.CorrectNumber);
                }
                else
                {
                    Death death = new Death();
                    form1.Close();
                    death.ShowDialog();
                }

            }
            if (Gamelocations.isBatInRoom(Gamelocations.getPlayerLocation()))
            {
                //random from 1 to 10 if less than 2: trivia
                warnings += "Comrade! the ICC is near! we must airlift you to a safer location! \n";
                Random rand = new Random();
                if(rand.NextDouble() <= 0.05)
                {
                    MessageBox.Show("Comrade! We have been hit by Ukranian Air Defense! We're going doown!");
                    Death death = new Death();
                    form1.Close();
                    death.ShowDialog();
                    return;
                }
                Gamelocations.vdvAirlift();
            }
            if (Gamelocations.isPitInRoom(Gamelocations.getPlayerLocation()))
            {
                SubmitAnswerButton ask3 = new SubmitAnswerButton();
                ask3.askNumber = 3;
                ask3.player = Player;
                MessageBox.Show("Comrade! You've been captured by the ICC! Answer 2 out of 3 trivia questions correctly to escape!");
                ask3.ShowDialog();
                if (ask3.CorrectNumber >= 2)
                {
                    Gamelocations.resetPlayer();
                }
                else
                {

                    Death death = new Death();
                    form1.Close();
                    death.ShowDialog();
                }
            }

            int[] AdjacentRooms = Gamelocations.generateAdjacentRooms(Gamelocations.getPlayerLocation());
            int[] ConnectedRooms = Gamelocations.generateConnectedRooms(Gamelocations.getPlayerLocation());
            form1.updateRooms(AdjacentRooms, ConnectedRooms);
            warnings += Gamelocations.getWarnings();
            warnings += Gamelocations.playerLocation.ToString();
            form1.SetText(warnings);
            form1.SetMoney(Player.gold);
        }

        public void purchaseSecret()
        {
            if(Player.gold < 1)
            {
                MessageBox.Show("Comrade! Gazprom had a bad year. You won't be able top afford a hint!");
                return;
            }
            Player.payGold(1);
            form1.SetText(Gamelocations.getSecret());
            form1.SetMoney(Player.gold);
        }

        public bool Arrows()
        {
            return Player.arrowsValid();
        }
        public int GameLocation(int MoveTo)
        {
            return Gamelocations.getPlayerLocation();
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
