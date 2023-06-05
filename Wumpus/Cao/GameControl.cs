using Epshtein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wumpus;
using Wumpus.Epshtein;

namespace Cao
{

    public class GameControl

    {
        private GameLocations Gamelocations { get; set; }
        private Player Player { get; set; } = new Player();
        StartMenu start;
        Credits cred;
        Settings settings;
        private Leaderboard leaderboard;
        private _1095652_Roth_HuntTheWumpus.Form1 form1;
        private DateTime startTime;
        private int difficulty = 1;
        private bool babyMode = true;
        private StartingCutScene cutscene;
        private bool rightToMenu = false;
        bool random;
        bool soundOn = true;

        Random generator = new Random();
        public GameControl()
        {
            //menu, form1, credits
            start = new StartMenu(this);
            form1 = new _1095652_Roth_HuntTheWumpus.Form1(this);
            cred = new Credits();
            leaderboard    = new Leaderboard(this);
            cutscene = new StartingCutScene(this);
            showMenu();
        }

        /// <summary>
        /// Plays trivia. Amount of questions asked and message sent to user beforehand passed in via params
        /// </summary>
        /// <param name="toask">Amount of questions asked to the user</param>
        /// <param name="message">Message shown to the user before starting trivia</param>
        /// <returns></returns>
        private int playTrivia(int toask, string message)
        {
            SubmitAnswerButton ask3 = new SubmitAnswerButton();
            ask3.askNumber = toask;
            ask3.player = Player;
            MessageBox.Show(message);
            ask3.ShowDialog();
            form1.SetMoney(Player.gold);
            return ask3.CorrectNumber;
        }

        
        /// <summary>
        /// Attempts to purchase an arrow. Alerts the user if it fails.
        /// </summary>
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

        /// <summary>
        /// Attempts to shoot an arrow(called "kinzhal missile" ingame) into the target room. Shows the user a message detailing the results of the action
        /// </summary>
        /// <param name="target">Room in which user wants to shoot an orrow to</param>
        public void Shoot(int target)
        {
            //1. verify that player has enough arrows. Player has a method for this
            //2. call gameLocations's shootarrow method to the target rom and tore the return value in a variable
            //3. if true, kill wumpus and trigger end of game
            //4. if false, decrement arrow from Player Object
            if (Player.PayArrow() == false)
            {
                MessageBox.Show("Comrade! You've exhausted your entire supply of kinzhal missiles! The prosecutor has now learned of your exact location due to your dry-fire! Brace yourself, he'll be here to arrest you in no time!");
                Gamelocations.teleportWumpusToPlayer();
                Move(Gamelocations.playerLocation);
                return;
            }
            if(!Gamelocations.isWumpusInRoom(target))
            {
                MessageBox.Show("Comrade! The prosecutor has fled from our kinzhal missile strike in terror!");
                Gamelocations.moveWumpus(1);
                form1.SetArrows(Player.arrows);
                Move(Gamelocations.playerLocation);
                return;
               
            }
            //air defenses may intercept your missile, and the likelyhood that they do increases with each difficulty up
            double chanceToBeat = 0.15 * (difficulty * difficulty) + 0.15;
            if(generator.NextDouble() < chanceToBeat)
            {
                MessageBox.Show("Comrade! Ukranian Air Defenses have intercepted our kinzhal missile strike on the prosecutor, and he has escaped our surveilance network!");
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
            bool diffMove = moveTo != Gamelocations.playerLocation;
            if (diffMove && Gamelocations.movePlayer(moveTo, babyMode))
            {
                //only add to turns taken and gold if you moved somewhere new and the move was succsessful
                Player.turnsTaken++;
                Player.gold++;
                form1.SetMoney(Player.gold);
            }       
            //step 2 here
            if (Player.turnsTaken % 5 == 0 && difficulty > 1 && generator.NextDouble() > 0.3 && diffMove)
            {
                //play the press minigame every 5 or 10 turns (on the highest difficulty)
                PressMinigame press = new PressMinigame();
                MessageBox.Show("Comrade! It appears that independent news outlets have been rambling on about your location! You must squash them before the ICC finds out! Turn off as many printing presses as you can in 15 seconds!");
                press.ShowDialog();
                if (press.amountOn < 4)
                {
                    MessageBox.Show("Good work Comrade! The Prosecutor will have no clue where you are now!");
                    return;
                }
                MessageBox.Show("Comrade! You weren't able to stop enough presses, and now the Prosecutor knows your exact location! Brace youself, he'll be here to arrest you in no time!");
                Gamelocations.teleportWumpusToPlayer();
            }
            //play trivias depending on what the player encounters
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
                //generate a number your random number must beat based on the difficulty
                MessageBox.Show("Comrade! the ICC is near! we must airlift you to a safer location!");
                double chanceToBeat = 0.025 * (difficulty * difficulty) + 0.025;
                if(generator.NextDouble() <= chanceToBeat)
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
            //warnings and such must be generated one all encounters are done, otherwise you will get outdated info
            form1.UpdateRoomButtons(
                              Gamelocations.generateAdjacentRooms(Gamelocations.getPlayerLocation()),
                              Gamelocations.generateConnectedRooms(Gamelocations.getPlayerLocation(), babyMode)
            );
            form1.SetText(Gamelocations.getWarnings(babyMode));


        }

        /// <summary>
        /// Attempts to purchase a hint/secret
        /// </summary>
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
        
        /// <summary>
        /// Starts Gameplay with selected settings. Calling this method will regenerate the player, cave, gamelocations, and form1
        /// </summary>
        public void startGamePlay()
        {
            rightToMenu = false;
            form1 = new _1095652_Roth_HuntTheWumpus.Form1(this);
            start.Close();
            Player = new Player();
            cutscene = new StartingCutScene(this);
            cutscene.ShowDialog();
            difficulty = cutscene.SelectedMode;
            babyMode = cutscene.babyMode;
            //bats are actually useful, so increasing difficulty generates less, while generating more pits
            Gamelocations = new GameLocations(4 - difficulty, 2 + difficulty, random);
            int[] AdjacentRooms = Gamelocations.generateAdjacentRooms(Gamelocations.getPlayerLocation());
            int[] ConnectedRooms = Gamelocations.generateConnectedRooms(Gamelocations.getPlayerLocation(), babyMode);
            form1.UpdateRoomButtons(AdjacentRooms, ConnectedRooms);
            string warnings = "";
            warnings += Gamelocations.getWarnings(babyMode);
            form1.SetText(warnings);
            form1.SetMoney(Player.gold);
            form1.SetArrows(Player.arrows);
            startTime = DateTime.Now;
            SoundPlayer player = new SoundPlayer();
            //plays audio
            if (soundOn)
            {
                if (difficulty == 2)
                {
                    player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\1230.wav";
                    player.PlayLooping();
                }
                else
                {
                    player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\1229.wav";
                    player.PlayLooping();
                }
            }
            else player.Stop();
            if (!rightToMenu) form1.Show();
        }

        //exit gameplay->menu
        private void death()
        {
            Death death = new Death(Player.CalculatePoints(false, difficulty), this);
            form1.closeButtonClicked = true;
            death.ShowDialog();
        }

        //exit gameplay(but with "you win" as the message)->menu
        private void win()
        {
            //only successful runs get a leaderboard position
            Win win = new Win(Player.CalculatePoints(true,difficulty), leaderboard, startTime, this);
            form1.closeButtonClicked = true;
            win.ShowDialog();
        }

        //"Show X" methods
        //Main thing of note here is the closing of all other forms and the reinstantiation of the requisite forms for opening
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
        public void showCredits()
        {
            form1.Close();
            start.Close();
            cred = new Credits();
            cred.ShowDialog();
            showMenu();
        }
        public void showSettings()
        {
            start.Close();
            settings = new Settings();
            settings.ShowDialog();
            if (settings.doAnything)
            {
                random = settings.randomcave;
                soundOn = settings.music;
            }
            showMenu();
        }
        public void showLeaderboard()
        {
            start.Close();
            leaderboard = new Leaderboard(this);
            leaderboard.Show();
        }

        public void showEnd(bool won)
        {
            EndScreen end = new EndScreen(this,won );
            end.ShowDialog();
        }
        
        
    }   
}
