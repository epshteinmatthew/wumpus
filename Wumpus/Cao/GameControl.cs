﻿using Epshtein;
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
        }
        
        public int Score(bool wumpusDead)
        {
            return Player.points(wumpusDead);
        }
        public void Shoot(int ShootTo)
        {
            //1. verify that player has enough arrows. Player has a method for this
            //2. call gameLocations's shootarrow method to the target rom and tore the return value in a variable
            //3. if true, kill wumpus and trigger end of game
            //4. if false, decrement arrow from Player Object
            if (Player.arrowsValid() == false)
            {
                //end game (fail)
                return;
            }
            bool success = Gamelocations.shootArrow(ShootTo);
            if(!success)
            {
                Player.arrows--;
                return;
                

               
            }
            Win win = new Win();
            win.ShowDialog();

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
            int[] AdjacentRooms = Gamelocations.generateAdjacentRooms(Gamelocations.getPlayerLocation());
            int[] ConnectedRooms = Gamelocations.generateConnectedRooms(Gamelocations.getPlayerLocation());
            form1.updateRooms(AdjacentRooms, ConnectedRooms);
            string warnings = "";
            if (Gamelocations.isWumpusInRoom(Gamelocations.getPlayerLocation()))
            {
                //trivia, move wumpus

            }
            if (Gamelocations.isBatInRoom(Gamelocations.getPlayerLocation()))
            {
                //random from 1 to 10 if less than 2: trivia
                warnings += "Comrade! the ICC is near! we must airlift you to a safer location! \n";
                Gamelocations.vdvAirlift();
            }
            if (Gamelocations.isPitInRoom(Gamelocations.getPlayerLocation()))
            {
                //trivia
            }
            warnings += Gamelocations.getWarnings();
            form1.SetText(warnings);
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
