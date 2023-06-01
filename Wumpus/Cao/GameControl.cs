using Epshtein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wumpus;
using Wumpus.Epshtein;

namespace Cao
{

    public class GameControl

    {
        private GameLocations Gamelocations { get; set; } = new GameLocations(3,3);
        private Player Player { get; set; } = new Player();
        StartMenu start;
        Credits cred;
        private Leaderboard leaderboard;
        private _1095652_Roth_HuntTheWumpus.Form1 form1;
        private DateTime startTime;
        private int difficulty = 1;
        private StartingCutScene cutscene;
        private bool rightToMenu = false;
        public GameControl()
        {
            //menu, form1, credits
            start = new StartMenu(this);
            form1 = new _1095652_Roth_HuntTheWumpus.Form1(this);
            cred = new Credits(this);
            leaderboard    = new Leaderboard(this);
            cutscene = new StartingCutScene(this);
            start.ShowDialog();
        }

        private int playTrivia(int toask, string message)
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
            return Player.points(wumpusDead, difficulty);
        }
        
        public void purchaseArrow()
        {
            //this doesnt get affected by difficulty-its already quite easy
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
            double chanceToBeat = 0.15 * (difficulty * difficulty) + 0.15;
            if(r.NextDouble() < chanceToBeat)
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
                int c = playTrivia(5, "Comrade! The ICC's Chief Prosecutor Karim Khan knows your exact location! Answer "+ (2+difficulty )+ " out of 5 trivia questions correctly to shake him off your trail!");
                if (c >= 2+difficulty)
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
                //random from 1 to 10 if less than 2: dead
                MessageBox.Show("Comrade! the ICC is near! we must airlift you to a safer location!");
                Random rand = new Random();
                double chanceToBeat = 0.025 * (difficulty * difficulty) + 0.025;
                if(rand.NextDouble() <= chanceToBeat)
                {
                    MessageBox.Show("Comrade! We have been hit by Ukranian Air Defense! We're going doown!");
                    death();
                    return;
                }
                Gamelocations.vdvAirlift();
            }
            if (Gamelocations.isPitInRoom(Gamelocations.getPlayerLocation()))
            {
                if (playTrivia(3, "Comrade! You've been captured by the ICC! Answer "+ (1 + difficulty) + " out of 3 trivia questions correctly to escape!") >= 1 + difficulty)
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
            rightToMenu = false;
            form1 = new _1095652_Roth_HuntTheWumpus.Form1(this);
            start.Close();
            Player = new Player();
            //bats are actually useful, so increasing difficulty generates less, while generating more pits
            Gamelocations = new GameLocations(4 - difficulty, 2 + difficulty);
            int[] AdjacentRooms = Gamelocations.generateAdjacentRooms(Gamelocations.getPlayerLocation());
            int[] ConnectedRooms = Gamelocations.generateConnectedRooms(Gamelocations.getPlayerLocation());
            form1.updateRooms(AdjacentRooms, ConnectedRooms);
            string warnings = "";
            warnings += Gamelocations.getWarnings();
            form1.SetText(warnings);
            form1.SetMoney(Player.gold);
            form1.SetArrows(Player.arrows);
            startTime = DateTime.Now;
            cutscene = new StartingCutScene(this);
            cutscene.ShowDialog();
            difficulty = cutscene.SelectedMode;
            if (!rightToMenu) form1.Show();
        }

        //exit gameplay->credits
        private void death()
        {
            Death death = new Death(Player.points(false, difficulty));
            death.ShowDialog();
            showMenu();
        }

        private void win()
        {
            //only successful runs get a leaderboard position
            Win win = new Win(Player.points(true,difficulty), leaderboard, startTime);
            win.ShowDialog();
            showMenu();
            
        }

        //open menu
        public void showMenu()
        {
            rightToMenu = true;
            start = new StartMenu(this);
            form1.Close();
            cutscene.Close();
            cred.Close();
            leaderboard.Close();
            start.Show();
        }
        //show credits
        public void showCredits()
        {
            start.Close();
            cred = new Credits(this);
            cred.Show();
        }

        public void showLeaderboard()
        {
            start.Close();
            leaderboard = new Leaderboard(this);
            leaderboard.Show();
        }
        
        
    }   
}
