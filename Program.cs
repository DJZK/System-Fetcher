using System;
using System.Threading;
using System.Windows.Forms;
using System_Fetcher.Functions;

namespace System_Fetcher
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Begin
            using (var mutex = new Mutex(false, "System Fetcher"))
            {
                bool isAnotherInstanceOpen = !mutex.WaitOne(TimeSpan.Zero);
                if(isAnotherInstanceOpen)
                {
                    MessageBox.Show("Application is already running!", "Application Running", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            
            
                // Startup
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // App Launch
                var SF = new MainActivity();
                SF.Show();
                Application.Run(SF);

              

                mutex.ReleaseMutex();
            }
        }

      
    }
}