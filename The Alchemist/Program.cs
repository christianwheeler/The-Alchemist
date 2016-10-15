using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace The_Alchemist
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMainMenu());
        }
    }
#endif
}
