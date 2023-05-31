using Chan_WumpusTest;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epshtein
{
    public class GameLocations
    {
        public int playerLocation;

        private int wumpusLocation;
        //generate in constructor
        List<int> batLocations = new List<int>(), pitLocations = new List<int>();
        Random generator = new Random();

        private Cave cave;
        public GameLocations(int amountOfBats, int amountOfPits)
        {
            cave = new Cave("1", 1, generator.Next(1,7));
            while(batLocations.Count < amountOfBats)
            {
                int loc = generator.Next(1,30);
                if (!isBatInRoom(loc))
                {
                    batLocations.Add(loc);
                }
            }
            while (pitLocations.Count < amountOfPits)
            {
                int loc = generator.Next(1, 30);
                if (!isPitInRoom(loc))
                {
                    pitLocations.Add(loc);
                }
            }
            wumpusLocation = generator.Next(1,30);
            playerLocation = 1;
        }

        //is the wumpus in the room passed in?
        public bool isWumpusInRoom(int room) { return wumpusLocation == room; }

        //where's the player?
        public int getPlayerLocation() { return playerLocation; }

        //is a bat in the room passed in?
        public bool isBatInRoom(int room) { return batLocations.Contains(room); }

        //is a pit in the room passed in?
        public bool isPitInRoom(int room)  {return pitLocations.Contains(room); }

        //gets a string containing the warnings, to be sent to the player based on their room.
        public string getWarnings()
        {
            bool wump = false; bool pit = false; bool bat = false;
            foreach (int room in generateConnectedRooms(playerLocation))
            {
                if (isWumpusInRoom(room))
                {
                    wump = true;
                }
                if (isBatInRoom(room))
                {
                    bat = true;
                }
                if (isPitInRoom(room))
                {
                    pit = true;
                }
            }
            return (wump ? "I smell a prosecutor!\n" : "") + (bat ? "VDV Transport units nearby\n" : "") + (pit ? "New ICC detention center opened near your location\n" : "");
        }
        public int[] generateAdjacentRooms(int room)
        {
            return cave.GetAdjacentCaves(room);
        }

        public int[] generateConnectedRooms(int room) => cave.GetConnectedCaves(room);

        //shoots an arrow into the target room
        public bool shootArrow(int targetRoom)
        {
            if (isWumpusInRoom(targetRoom))
            {
                return true;
            }
            else { return false; }
        }

        //randomly generate some information about the game locations and return it to the player
        public string getSecret()
        {
            int roll = generator.Next(1, 20);
            if(roll < 1)
            {
                return "According to recent intel, the prosecutor is in room " + wumpusLocation;
            }
            if (roll < 5)
            {
                return "There is a VDV helipad in room " + batLocations[0] + ", according to recent intelligence.";
            }
            if (roll < 10)
            {
                return "There is an ICC detention center in room " + pitLocations[0] + ", according to the FSB.";
            }
            if (roll == 11)
            {
                return "Intel reports that you are in a room";
            }
            return "Room " + generateAdjacentRooms(playerLocation)[0] + " is adjacent to you.";
        }

        public void vdvAirlift()
        {
            //comrade! the ICC is near! we must airlift you to a safer location!
            playerLocation = generator.Next(1, 30);
        }

        //resets the player's location to the entry tile
	    public void resetPlayer()
        {
            playerLocation = 1;
        }

        public bool movePlayer(int targetRoom)
        {
            //attempt to move player to room passed in, return false if fails
            if (generateConnectedRooms(playerLocation).Contains(targetRoom))
            {
                playerLocation = targetRoom;
                return true;
            }
            return false;
        }

        //move the wumpus a certain number of times. each time = move to 1 adjacent room. 
        public void moveWumpus(int turns)
        {
            for (int i = 0; i < turns; i++){
                int[] options = generateConnectedRooms(wumpusLocation).OrderBy(_=>generator.Next()).ToArray();
                if (options[0] == playerLocation)
                {
                    i--;
                    continue;
                }
                wumpusLocation = options[0];
            }

        }

        //timer
        public void keeptime(int time)
        {
            
        }
    }
}