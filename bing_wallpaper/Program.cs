using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bing_wallpaper
{
    static class Program
    {

        private static bool LaunchedOnStartup = false;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            LaunchedOnStartup = args.Length > 0 && args[0].Equals("/s");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run( new Form1(LaunchedOnStartup) );
           
        }
    }
}
