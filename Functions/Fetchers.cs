using SharpDX.DXGI;
using SharpDX.Direct3D;
using System;
using System.Management;
using System.Windows.Forms;
using System_Fetcher.Functions;
using System.Runtime.CompilerServices;

namespace System_Fetcher.Interfaces
{
    internal class Fetchers
    {
        private static string macaddressonly = "";
    /* Test case
          Console.WriteLine("\nRAM Capacity:");
          
          Console.WriteLine("\nSSD Information:");
          GetHardwareInfo("Win32_DiskDrive", "Model");
         v
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
    
        public static void FetchSystem()
        {
            // Begin, descend

            // CPU
            GlobalVariables.sysInfo.CPU = GetHardwareInfo("Win32_Processor", "Name");

            // GPU
            GlobalVariables.sysInfo.GPU = GetHardwareInfo("Win32_VideoController", "Name");

            // RAM
            GlobalVariables.sysInfo.RAM = GetRAMDetails() + " @" + GetHardwareInfo("Win32_PhysicalMemory", "Speed") + "MHz";

            // Storage
            GlobalVariables.sysInfo.SSD = GetAllDrivesDetails();

            // MOBO
            GlobalVariables.sysInfo.MOBO = GetHardwareInfo("Win32_BaseBoard", "Manufacturer") + " " + GetHardwareInfo("Win32_BaseBoard", "Product");

            // NET
            GlobalVariables.sysInfo.NET = GetCurrentNetworkAdapterInfo();
           

            // Phew that was a lot, now time for the software side of things.... here we go!!!
            GlobalVariables.sysInfo.ID = CalculateHardwareID();


            BuildInfo();

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

        private static string GetAllDrivesDetails()
        {
            try
            {
                string result = "";

                // Query all physical drives from Win32_DiskDrive to get the model and capacity
                string query = "SELECT Model, Size FROM Win32_DiskDrive";

                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        // Fetch the model and size of the drive with null checks
                        string driveModel = obj["Model"]?.ToString();
                        ulong? driveSize = obj["Size"] as ulong?;

                        // Only process the drive if both Model and Size are available
                        if (driveModel != null && driveSize.HasValue && driveSize.Value > 0)
                        {
                            // Convert size to GB
                            string driveCapacity = (driveSize.Value / (1024.0 * 1024.0 * 1024.0)).ToString("F2") + " GB";
                            result += $"{driveModel} @{driveCapacity}\n\t\t";
                        }
                        else
                        {
                            // Skip drives that have no model or size
                            result += $"Unknown Drive Model or Size\n";
                        }
                    }

                    if (string.IsNullOrEmpty(result))
                    {
                        return "No drives found or could not retrieve drive information.";
                    }
                }

                return result.Trim(); // Return the formatted result
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        private static string GetCurrentNetworkAdapterInfo()
        {
            try
            {
                string result = "";

                // Query all network adapters from Win32_NetworkAdapter
                string query = "SELECT Description, MACAddress, NetConnectionStatus FROM Win32_NetworkAdapter";

                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        // Check if the network adapter is currently active (NetConnectionStatus == 2 means connected)
                        int connectionStatus = Convert.ToInt32(obj["NetConnectionStatus"]);
                        if (connectionStatus == 2) // 2 means connected
                        {
                            // Get the Description and MACAddress of the adapter
                            string adapterDescription = obj["Description"]?.ToString();
                            string macAddress = obj["MACAddress"]?.ToString();
                            macaddressonly = macAddress;
                            

                            // Format the result as "Description - MAC Address"
                            result = $"{adapterDescription} - {macAddress}";
                            break; // Only return the first active adapter found
                        }
                    }

                    if (string.IsNullOrEmpty(result))
                    {
                        return "No active network adapter found.";
                    }
                }

                return result.Trim(); // Return the formatted result
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        private static string CalculateHardwareID()
        {
            try
            {
                string mobo = GetHardwareInfo("Win32_BaseBoard", "SerialNumber");
                string cpu = GetHardwareInfo("Win32_Processor", "ProcessorId");
                string gpu = GetHardwareInfo("Win32_VideoController", "PNPDeviceID");
                MessageBox.Show(mobo + cpu + gpu + macaddressonly);
                return Cryptorizer.CalculateHash(mobo+cpu+gpu+macaddressonly);
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
        private static void BuildInfo()
        {
            MessageBox.Show($"Time: {DateTime.Now} \n\n" +
                $"Hardware:\n\t" +
                $"CPU: {GlobalVariables.sysInfo.CPU}\n\t" +
                $"GPU: {GlobalVariables.sysInfo.GPU}\n\t" +
                $"RAM: {GlobalVariables.sysInfo.RAM} \n\t" +
                $"STR: \n\t\t{GlobalVariables.sysInfo.SSD} \n\t" +
                $"PSU: {GlobalVariables.sysInfo.PSU} \n\t" +
                $"FAN: {GlobalVariables.sysInfo.FAN} \n\t"  +
                $"MOBO: {GlobalVariables.sysInfo.MOBO} \n\t" +
                $"NET: {GlobalVariables.sysInfo.NET} \n\n" +
                $"Software:\n\t" +
                $"ID: {GlobalVariables.sysInfo.ID}" , "System Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
   }
}