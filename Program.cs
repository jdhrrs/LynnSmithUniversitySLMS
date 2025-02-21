using System;
using System.Windows.Forms;

namespace LynnSmithUniversitySLMS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles(); // Ensure modern UI rendering
            Application.SetCompatibleTextRenderingDefault(false); //  Improve text rendering

            // Ensure "MainForm" exists in your project
            Application.Run(new MainForm());
        }
    }
}
