using Cao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wumpus;
using Wumpus.Epshtein;

namespace _1095652_Roth_HuntTheWumpus
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GameControl gc = new GameControl();
            Application.Run();
        }
    }
}
