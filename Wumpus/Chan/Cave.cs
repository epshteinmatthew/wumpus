using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Chan
{
    public class Cave
    {
        List<int[]> rooms = new List<int[]>();

        List<int[]> connections = new List<int[]>();

        public int RoomNumber { get; set; }
        public string CaveNumber { get; set; }

        //This is the Cave Class
        //GetCaveSystem will choose one of the five caves and return which cave number
        //GetAdjacentCaves will retrieve the player location and return adjacent rooms
        //GetConnectedCaves will retrieve the player location and return which caves the player can go into

        public Cave(string cavenumber, int room)
        {
            CaveNumber = cavenumber;
            RoomNumber = room;
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

            using (StreamReader sr = new StreamReader("Cave1Connections.txt"))
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

        public string GetCaveSystem()
        {
            string CaveNumber;
            Random rnd = new Random();
            int n = rnd.Next(1, 6);
            CaveNumber = "Cave" + n;
            return CaveNumber;

            
        }

        public int[] GetAdjacentCaves(int room)
        {
            return rooms[room - 1];
                
        }

        public int[] GetConnectedCaves(int room)
        {
            return connections[room - 1];
        }

    }
}
