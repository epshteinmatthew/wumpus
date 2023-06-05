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
        private int wumpusLocation = 1;
        private Cave cave;
        private List<int> batLocations = new List<int>(), pitLocations = new List<int>();

        private Random generator = new Random();

        //generates pits, bats, wumpus
        public GameLocations(int amountOfBats, int amountOfPits, bool random)
        {
            cave = random ? new Cave(6) : new Cave(generator.Next(1, 6));
            while(batLocations.Count < amountOfBats)
            {
                int loc = generator.Next(1,30);
                //bats are generated first, so we dont need to check for conflicts with the pits here
                if (!isBatInRoom(loc) || loc != 1)
                {
                    batLocations.Add(loc);
                }
            }
            while (pitLocations.Count < amountOfPits)
            {
                int loc = generator.Next(1, 30);
                if (!isPitInRoom(loc) && loc != 1 && !isBatInRoom(loc))
                {
                    pitLocations.Add(loc);
                }
            }
            while (wumpusLocation == 1)
            {
                wumpusLocation = generator.Next(1, 30);
            }
            playerLocation = 1;
        }

        //is the wumpus in the room passed in?
        public bool isWumpusInRoom(int room) { return wumpusLocation == room; }

        public void teleportWumpusToPlayer()
        {
            wumpusLocation = playerLocation;
        }

        //where's the player?
        public int getPlayerLocation() { return playerLocation; }

        //is a bat in the room passed in?
        public bool isBatInRoom(int room) { return batLocations.Contains(room); }

        //is a pit in the room passed in?
        public bool isPitInRoom(int room)  {return pitLocations.Contains(room); }

        //gets a string containing the warnings, to be sent to the player based on their room.
        public string getWarnings(bool isBabyMode)
        {
            bool wump = false; bool pit = false; bool bat = false;
            foreach (int room in generateConnectedRooms(playerLocation, isBabyMode))
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

        /// <summary>
        /// A function to generate conncted rooms based on passed in params
        /// </summary>
        /// <param name="room">The room you are trying to find connections of</param>
        /// <param name="isBabyMode">whether "baby mode" is on/off. "baby mode" just means that all adjacent rooms are treated as connected</param>
        /// <returns>An integer array of all rooms connected to the room passed in</returns>
        public int[] generateConnectedRooms(int room, bool isBabyMode) => !isBabyMode ? cave.GetConnectedCaves(room) : cave.GetAdjacentCaves(room);

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
            return "Room " + generateAdjacentRooms(playerLocation)[generator.Next(0,7)] + " is adjacent to you.";
        }

        //sends the player to a random location on the map
        public void vdvAirlift()
        {
            playerLocation = generator.Next(1, 31);
        }

        //resets the player's location to the entry tile(room 1)
	    public void resetPlayer()
        {
            playerLocation = 1;
        }

        /// <summary>
        /// Attempts to move the player to the target room 
        /// </summary>
        /// <param name="targetRoom">The room to move the player to</param>
        /// <param name="isBabyMode">Whether "baby mode" is on/off. See line 94</param>
        /// <returns></returns>
        public bool movePlayer(int targetRoom, bool isBabyMode)
        {
            if (generateConnectedRooms(playerLocation, isBabyMode).Contains(targetRoom))
            {
                playerLocation = targetRoom;
                return true;
            }
            return false;
        }

        //move the wumpus a certain number of times. each time = move to 1 connected room. 
        public void moveWumpus(int turns)
        {
            for (int i = 0; i < turns; i++){
                int[] options = generateConnectedRooms(wumpusLocation, false).OrderBy(_=>generator.Next()).ToArray();
                if (options[0] == playerLocation)
                {
                    i--;
                    continue;
                }
                wumpusLocation = options[0];
            }

        }
    }
}