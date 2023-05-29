using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Chan_WumpusTest
{
    public class Cave
    {
        private readonly List<int[]> rooms = new List<int[]>();

        //this can still be mutated, but only by the methods of List class
        private readonly List<int[]> connections = new List<int[]>();

        int RoomNumber { get; set; }
        string CaveNumber { get; set; }

        //This is the Cave Class
        //GetCaveSystem will choose one of the five caves and return which cave number
        //GetAdjacentCaves will retrieve the player location and return adjacent rooms
        //GetConnectedCaves will retrieve the player location and return which caves the player can go into

        /// <summary>
        /// This method retrieves the caves adjacent to the player, and also retrieves the caves that the player can actually go into. 
        /// </summary>
        /// <param name="num"></param>
        /// <param name="rum"></param>
        public Cave(string num, int rum)
        {

            this.CaveNumber = num;
            this.RoomNumber = rum;
            using (var sr = new StreamReader("CaveAdjacent.txt"))
            {
                string line;
                // Read and display lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    //split the line at a space, then convert into an integer array
                    //rooms should be a list of type int
                    rooms.Add(line.Split(' ').Where(x => int.TryParse(x, out _)).Select(int.Parse).ToArray());


                }
            }
            
            //decides what cave system is being used at random
            var rnd = new Random();
            var n = 6;
            CaveNumber = "Cave" + n;
            var CaveFile = "Cave1Connections.txt";

            switch (n)
            {
                case 1:
                    CaveFile = "Cave1Connections.txt";
                    break;
                case 2:
                    CaveFile = "Cave2Connections.txt";
                    break;
                case 3:
                    CaveFile = "Cave3Connections.txt";
                    break;
                case 4:
                    CaveFile = "Cave4Connections.txt";
                    break;
                case 5:
                    CaveFile = "Cave5Connections.txt";
                    break;
                case 6:
                    var conns = new int[30, 6];
                    var rand = new Random();
                    var seedling = new int[30];
                    for (var i = 0; i < seedling.Length; i++)
                    {
                        seedling[i] = rand.Next(2, 4);
                    }
                    for (var i = 0; i < conns.GetLength(0); i++)
                    {
                        while (seedling[i] > 0)
                        {
                            var ourNextConnection = rand.Next(0, 6);
                            //reroll-the space has already been filled
                            if(conns[i, ourNextConnection] == 1)continue;
                            //get the room we want to access, remembering 0-indexing
                            var ourNextConnectionLocation = rooms[i][ourNextConnection] - 1;
                            //we want to give space for other rooms to generate
                            if (seedling[ourNextConnectionLocation] == 1 && i > ourNextConnectionLocation) continue;
                            for (var j = 0; j < rooms[ourNextConnectionLocation].Length; j++)
                            {
                                if (rooms[ourNextConnectionLocation][j] != i + 1) continue;
                                seedling[ourNextConnectionLocation]--;
                                seedling[i]--;
                                conns[ourNextConnectionLocation, j] = 1;
                                conns[i, ourNextConnection] = 1;
                            }
                        }
                       
                        connections.Add(Enumerable.Range(0, conns.GetLength(1))
                            .Select(x => conns[i, x])
                            .ToArray());
                    }
                    Debug.WriteLine(connections);
                    break;
            }
            //withdraws which rooms the player can go into from a file
            if (n == 6)
            {
                return;
            }
            using (var sr = new StreamReader(CaveFile))
            {
                string lines;
                // Read and display lines from the file until the end of
                // the file is reached.
                while ((lines = sr.ReadLine()) != null)
                {
                    //split the line at a space, then convert into an integer array
                    //rooms should be a list of type int
                    connections.Add(lines.Split(' ').Where(x => int.TryParse(x, out _)).Select(int.Parse).ToArray());


                }
            }
        }

        /// <summary>
        /// Retrieving from the cave method, this method returns what number cave system is being used to the game control
        /// </summary>
        /// <returns></returns>
        public string GetCaveSystem()
        {

            return CaveNumber;


        }


        /// <summary>
        /// This method returns the caves next to the player after retrieving the room number from game control
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public int[] GetAdjacentCaves(int room)
        {
            return rooms[room - 1];

        }


        /// <summary>
        /// This method returns the caves that the player can enter based off the room number they are currently in
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public int[] GetConnectedCaves(int room)
        {
            var connected = new List<int>();
            for (var i = 0; i < connections[room-1].Length; i++)
            {
                if (connections[room - 1][i] == 1)
                {
                    connected.Add(GetAdjacentCaves(room)[i]);
                }
            }
            return connected.ToArray();
        }

    }
}
