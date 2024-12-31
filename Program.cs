﻿using System;
using System.Management;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            // Test case

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
            // App Launch
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainActivity());
        }

        static void GetHardwareInfo(string hwClass, string syntax)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher($"SELECT * FROM {hwClass}"
                ); foreach (ManagementObject obj in searcher.Get())
            {
                Console.WriteLine($"{syntax}: {obj[syntax]}");
            }
        }

    }
}