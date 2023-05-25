using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Chan_WumpusTest
{
    public class Cave
    {
        List<int[]> rooms = new List<int[]>();

        List<int[]> connections = new List<int[]>();

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
            using (StreamReader sr = new StreamReader("CaveAdjacent.txt"))
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
            Random rnd = new Random();
            int n = rnd.Next(1, 6);
            CaveNumber = "Cave" + n;
            string CaveFile = "Cave1Connections.txt";

            if (n == 1)
            {
                CaveFile = "Cave1Connections.txt";
            }
            else if (n == 2)
            {
                CaveFile = "Cave2Connections.txt";
            }
            else if (n == 3)
            {
                CaveFile = "Cave3Connections.txt";
            }
            else if (n == 4)
            {
                CaveFile = "Cave4Connections.txt";
            }
            else if (n == 5)
            {
                CaveFile = "Cave5Connections.txt";
            }



            //withdraws which rooms the player can go into from a file
            using (StreamReader sr = new StreamReader(CaveFile))
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
            List<int> connected = new List<int>();
            for (int i = 0; i < connections[room-1].Length; i++)
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
