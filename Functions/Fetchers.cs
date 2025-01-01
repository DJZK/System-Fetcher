using SharpDX.DXGI;
using SharpDX.Direct3D;
using System;
using System.Management;
using System.Windows.Forms;
using System_Fetcher.Functions;

namespace System_Fetcher.Interfaces
{
    internal class Fetchers

    /* Test case
          Console.WriteLine("\nRAM Capacity:");
          
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
    {
        public static void FetchSystem()
        {
            // Begin, descend

            // CPU
            GlobalVariables.sysInfo.CPU = GetHardwareInfo("Win32_Processor", "Name");
            MessageBox.Show(GlobalVariables.sysInfo.CPU);

            // GPU
            GlobalVariables.sysInfo.GPU = GetHardwareInfo("Win32_VideoController", "Name");
            MessageBox.Show(GlobalVariables.sysInfo.GPU);

            // RAM
            GlobalVariables.sysInfo.RAM = GetRAMDetails() + " @"+GetHardwareInfo("Win32_PhysicalMemory", "Speed") + "MHz";
            MessageBox.Show(GlobalVariables.sysInfo.RAM);

        }
        private static string GetHardwareInfo(string hwClass, string syntax)
        {
            string result = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher($"SELECT * FROM {hwClass}"
                ); foreach (ManagementObject obj in searcher.Get())
            {
                result = ($"{obj[syntax]}");
            }
            return result;
        }

        private static void GetTpmVersion()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMv2\\Security\\MicrosoftTpm", "SELECT * FROM Win32_Tpm");
                foreach (ManagementObject obj in searcher.Get())
                {
                    Console.WriteLine("TPM Version: " + obj["SpecVersion"]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching TPM information: " + ex.Message);
            }
        }

        private static void GetSecureBootStatus()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMv2\\Security\\MicrosoftTpm", "SELECT * FROM Win32_SecureBoot");
                foreach (ManagementObject obj in searcher.Get())
                {
                    var secureBootEnabled = obj["SecureBootEnabled"];
                    Console.WriteLine(secureBootEnabled != null && (bool)secureBootEnabled ? "Secure Boot is enabled." : "Secure Boot is disabled.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching Secure Boot status: " + ex.Message);
            }
        }

        private static string GetRAMDetails()
        {
            try
            {
                string result = "";
                ulong totalMemoryBytes = 0;

                // Querying the Win32_PhysicalMemory class
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Capacity FROM Win32_PhysicalMemory"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        // Capacity is in bytes
                        ulong capacityBytes = (ulong)obj["Capacity"];
                        totalMemoryBytes += capacityBytes;
                    }
                }

                // Convert total memory to GB
                double totalMemoryGB = totalMemoryBytes / (1024.0 * 1024.0 * 1024.0);
                return $"{totalMemoryGB:F2} GB";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

    }
}
