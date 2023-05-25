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
        public GameLocations Gamelocations { get; set; } = new GameLocations(3,3);
        public Player Player { get; set; } = new Player();
        public int LocationUpdate;
        public int ScoringThings;
        public int TriviaTrigger;
        public int ShootingThing;
        public int CoinCount;
        StartMenu start;
        Credits cred;
        private _1095652_Roth_HuntTheWumpus.Form1 form1;
        public GameControl()
        {
            //menu, form1, credits
            start = new StartMenu(this);
            form1 = new _1095652_Roth_HuntTheWumpus.Form1(this);
            cred = new Credits(this);
            start.ShowDialog();
        }

        public int playTrivia(int toask, string message)
        {
            SubmitAnswerButton ask3 = new SubmitAnswerButton();
            ask3.askNumber = toask;
            ask3.player = Player;
            MessageBox.Show(message);
            ask3.ShowDialog();
            return ask3.CorrectNumber;
        }

        public int Score(bool wumpusDead)
        {
            return Player.points(wumpusDead);
        }
        
        public void purchaseArrow()
        {
            if (playTrivia(2, "Comrade! The R&D department is ready to produce another kinzhal missile! Unfortunately, we have forgotten the launch codes. Answer a trivia question correctly to help us ready the missile!") >= 1)
            {
                MessageBox.Show("Comrade! Your extreme intellect has made it possible for us to produce one more kinzhal missile! Excellent work!");
                Player.arrows++;
                form1.SetArrows(Player.arrows);
            }
            else
            {
                MessageBox.Show("Comrade! It seems that even your massive brain could not help us here. You'll have to subside on the missiles we have now.");
            }
            form1.SetMoney(Player.gold);
        }

        public void Shoot(int ShootTo)
        {
            //1. verify that player has enough arrows. Player has a method for this
            //2. call gameLocations's shootarrow method to the target rom and tore the return value in a variable
            //3. if true, kill wumpus and trigger end of game
            //4. if false, decrement arrow from Player Object
            if (Player.arrowsValid() == false)
            {
                death();
                return;
            }
            bool success = Gamelocations.shootArrow(ShootTo);
            if(!success)
            {
                Player.arrows--;
                MessageBox.Show("Comrade! The prosecutor has fled from our kinzhal missile strike in terror!");
                Gamelocations.moveWumpus(1);
                form1.SetArrows(Player.arrows);
                Move(Gamelocations.playerLocation);
                return;
               
            }
            Random r = new Random();
            if(r.NextDouble() > 0.7)
            {
                MessageBox.Show("Comrade! Ukranian Air Defenses have intercepted our kinzhal missile strike on the prosecutor, and he has escaped our surveilance network!");
                Player.arrows--; 
                Gamelocations.moveWumpus(1);
                form1.SetArrows(Player.arrows);
                Move(Gamelocations.playerLocation);
                return;
            }
            MessageBox.Show("Comrade! Our kinzhal missile stike was a success! The prosecutor is no more!");

            win();
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
                int c = playTrivia(5, "Comrade! The ICC's Chief Prosecutor Karim Khan knows your exact location! Answer 3 out of 5 trivia questions correctly to shake him off your trail!");
                if (c >= 3)
                {
                    MessageBox.Show("Comrade! Your intellectual prowess has forced the Prosecutor to flee!");
                    Gamelocations.moveWumpus(c);
                }
                else
                {
                    MessageBox.Show("Comrade! The prosecutor's got you dead to rights! You'll be heading to court soon!");
                    death();
                }

            }
            if (Gamelocations.isBatInRoom(Gamelocations.getPlayerLocation()))
            {
                //random from 1 to 10 if less than 2: trivia
                MessageBox.Show("Comrade! the ICC is near! we must airlift you to a safer location!");
                Random rand = new Random();
                if(rand.NextDouble() <= 0.05)
                {
                    MessageBox.Show("Comrade! We have been hit by Ukranian Air Defense! We're going doown!");
                    death();
                    return;
                }
                Gamelocations.vdvAirlift();
            }
            if (Gamelocations.isPitInRoom(Gamelocations.getPlayerLocation()))
            {
                if (playTrivia(3, "Comrade! You've been captured by the ICC! Answer 2 out of 3 trivia questions correctly to escape!") >= 2)
                {
                    MessageBox.Show("Comrade! You managed to escape the ICC officers!");
                    Gamelocations.resetPlayer();
                }
                else
                {
                    MessageBox.Show("Comrade! ICC officers have arrested you, and you're heading to court soon!");
                    death();
                }

            }

            int[] AdjacentRooms = Gamelocations.generateAdjacentRooms(Gamelocations.getPlayerLocation());
            int[] ConnectedRooms = Gamelocations.generateConnectedRooms(Gamelocations.getPlayerLocation());
            form1.updateRooms(AdjacentRooms, ConnectedRooms);
            warnings += Gamelocations.getWarnings();
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
        
        //restart gameplay
        public void startGamePlay()
        {
            form1 = new _1095652_Roth_HuntTheWumpus.Form1(this);
            start.Close();
            Player = new Player();
            Gamelocations = new GameLocations(3, 3);
            int[] AdjacentRooms = Gamelocations.generateAdjacentRooms(Gamelocations.getPlayerLocation());
            int[] ConnectedRooms = Gamelocations.generateConnectedRooms(Gamelocations.getPlayerLocation());
            form1.updateRooms(AdjacentRooms, ConnectedRooms);
            string warnings = "";
            warnings += Gamelocations.getWarnings();
            form1.SetText(warnings);
            form1.SetMoney(Player.gold);
            form1.SetArrows(Player.arrows);
            form1.Show();
        }

        //exit gameplay->credits
        public void death()
        {
            Death death = new Death(Player.points(false));
            death.ShowDialog();
            menu();
        }

        public void win()
        {
            Win win = new Win(Player.points(true));
            win.ShowDialog();
            menu();
        }

        //open menu
        public void menu()
        {
            start = new StartMenu(this);
            form1.Close();
            cred.Close();
            start.Show();
        }
        //show credits
        public void credits()
        {
            start.Close();
            cred.Show();
        }
    }   
}
