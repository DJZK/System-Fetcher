using System;
using System.Management;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System_Fetcher.Functions;
using System.Threading;

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

                /* Test case
                Console.WriteLine("CPU Information:");
                GetHardwareInfo("Win32_Processor", "Name");
                Console.WriteLine("\nGPU Information:");
                GetHardwareInfo("Win32_VideoController", "Name");
                Console.WriteLine("\nRAM Capacity:");
                GetHardwareInfo("Win32_PhysicalMemory", "Capacity");
                Console.WriteLine("\nSSD Information:");
                GetHardwareInfo("Win32_DiskDrive", "Model");
                GetHardwareInfo("Win32_DiskDrive", "Size");
                Console.WriteLine("\nBIOS Serial Number:");
                GetHardwareInfo("Win32_BIOS", "SerialNumber");
                Console.WriteLine("\nMotherboard Information:");
                GetHardwareInfo("Win32_BaseBoard", "Manufacturer");
                GetHardwareInfo("Win32_BaseBoard", "Product");
                Console.WriteLine("\nOS Version and Build:");
                GetHardwareInfo("Win32_OperatingSystem", "Version");
                GetHardwareInfo("Win32_OperatingSystem", "BuildNumber");
                Console.WriteLine("\nNetwork Adapter Information:");
                GetHardwareInfo("Win32_NetworkAdapter", "Name");
                Console.WriteLine("\nSecure Boot Status:");
                GetSecureBootStatus();
                Console.WriteLine("\nTPM Version:");
                GetTpmVersion();
                */

                mutex.ReleaseMutex();
            }
        }

      
    }
}