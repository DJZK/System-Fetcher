using SharpDX.DXGI;
using SharpDX.Direct3D;
using System;
using System.Management;
using System.Windows.Forms;
using System_Fetcher.Functions;
using System.Runtime.CompilerServices;
using NetFwTypeLib;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;

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

            // MOBO, MOBO KA RIN!! ABA
            GlobalVariables.sysInfo.MOBO = GetHardwareInfo("Win32_BaseBoard", "Manufacturer") + " " + GetHardwareInfo("Win32_BaseBoard", "Product");

            // NET
            GlobalVariables.sysInfo.NET = GetCurrentNetworkAdapterInfo();
           

            // Phew that was a lot, now time for the software side of things.... here we go!!!
            GlobalVariables.sysInfo.ID = CalculateHardwareID();

            // OS.. obvious....
            GlobalVariables.sysInfo.OS = GetOSVersion();

            // TI, Timedate Install of the OS
            GlobalVariables.sysInfo.TI = GetOSInstallDate();

            // UN, Username of the users
            GlobalVariables.sysInfo.UN = GetUsername();

            // UAC, User Account Control 
            GlobalVariables.sysInfo.UAC = GetUACLevel();

            // JAVA .. apparently still runs on billion devices (assuming they are taking credit for the Android installs)
            GlobalVariables.sysInfo.JAVA = GetJavaVersion();

            // Python esssssssssssssssss
            GlobalVariables.sysInfo.PYTHON = GetPythonVersion();

            // dotNet... aka Microsoft JAVA
            GlobalVariables.sysInfo.DOTNET = GetDotNetVersion();

            // DX... Direct X, nothing much. You'll be surprised many people forget to install this and then wonder the game doesnt work
            GlobalVariables.sysInfo.DX = GetDirectXVersion();

            // AT FINALLY LAST, THE LAST PART IS HERE, only two remains
            // What you mean there's none? Ohhhh right i forgot to mention that it is manual input
            // ... and is to be done at the program's GUI

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
                            result += $"Unknown Drive Model or Size\n\t\t";
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
                // MessageBox.Show(mobo + cpu + gpu + macaddressonly);
                return Cryptorizer.CalculateHash(mobo+cpu+gpu+macaddressonly);
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        private static string GetOSVersion()
        {
            try
            {
                string osName = "Unknown";
                string version = "";
                string buildNumber = "";

                // Use WMI to fetch OS version and build info
                string query = "SELECT Version, ProductType, BuildNumber FROM Win32_OperatingSystem";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                ManagementObjectCollection queryCollection = searcher.Get();

                foreach (ManagementObject obj in queryCollection)
                {
                    version = obj["Version"].ToString();
                    buildNumber = obj["BuildNumber"].ToString();

                    // Check for Windows 11 first, as it starts from build 22000 onwards
                    if (version.StartsWith("10.0") && int.TryParse(buildNumber, out int build) && build >= 22000)
                    {
                        osName = "Windows 11";
                    }
                    // Check for Windows 10 if build is less than 22000
                    else if (version.StartsWith("10"))
                    {
                        osName = "Windows 10";
                    }
                    else
                    {
                        osName = "Unknown Windows Version";
                    }
                }

                return $"{osName} - Build {buildNumber}";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        private static string GetOSInstallDate()
        {
            try
            {
                string installDate = "";

                // Use WMI to fetch OS Install Date
                string query = "SELECT InstallDate FROM Win32_OperatingSystem";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                ManagementObjectCollection queryCollection = searcher.Get();

                foreach (ManagementObject obj in queryCollection)
                {
                    installDate = obj["InstallDate"].ToString();
                    DateTime installDateTime = ManagementDateTimeConverter.ToDateTime(installDate);

                    // Format install date in a readable form (e.g., "yyyy-MM-dd HH:mm:ss")
                    installDate = installDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                }

                return installDate;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        private static string GetUsername()
        {
            try
            {
                // Fetch the current username of the logged-in user
                string username = Environment.UserName;
                return username;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        private static string GetUACLevel()
        {
            try
            {
                // Access the registry to check the UAC setting
                string uacKeyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System";
                RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(uacKeyPath);

                if (registryKey != null)
                {
                    object uacSetting = registryKey.GetValue("EnableLUA");
                    if (uacSetting != null && uacSetting.ToString() == "1")
                    {
                        return "UAC Enabled";
                    }
                    else
                    {
                        return "UAC Disabled";
                    }
                }

                return "UAC Setting Not Found";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        private static string GetJavaVersion()
        {
            try
            {
                // Create a new process to run the 'java --version' command
                Process process = new Process();
                process.StartInfo.FileName = "java";
                process.StartInfo.Arguments = "--version";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.Start();

                // Capture the output from the 'java --version' command
                string versionOutput = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                // Check if the output contains version information
                if (!string.IsNullOrEmpty(versionOutput))
                {
                    // Extract the version line (e.g., "java 21.0.5 2024-10-15 LTS")
                    string[] outputLines = versionOutput.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.None);
                    foreach (var line in outputLines)
                    {
                        if (line.StartsWith("java"))
                        {
                            return line.Trim();  // Return the version line
                        }
                    }
                }

                return "N/A";  // If no version found, return N/A
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        private static string GetPythonVersion()
        {
            try
            {
                // Create a new process to run the 'python --version' command
                Process process = new Process();
                process.StartInfo.FileName = "python";  // Use "python3" if needed
                process.StartInfo.Arguments = "--version";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.Start();

                // Capture the output from the 'python --version' command
                string versionOutput = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                // Check if the output contains version information
                if (!string.IsNullOrEmpty(versionOutput))
                {
                    // Extract the version line (e.g., "Python 3.10.5")
                    string[] outputLines = versionOutput.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.None);
                    foreach (var line in outputLines)
                    {
                        if (line.StartsWith("Python"))
                        {
                            return line.Trim();  // Return the version line
                        }
                    }
                }

                return "N/A";  // If no version found, return N/A
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        private static string GetDotNetVersion()
        {
            try
            {
                // Create a new process to run the 'dotnet --version' command
                Process process = new Process();
                process.StartInfo.FileName = "dotnet";
                process.StartInfo.Arguments = "--version";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.Start();

                // Capture the output from the 'dotnet --version' command
                string versionOutput = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                // Check if the output contains version information
                if (!string.IsNullOrEmpty(versionOutput))
                {
                    // Return the version output (e.g., "7.0.0")
                    return versionOutput.Trim();
                }

                return "N/A";  // If no version found, return N/A
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public static string GetDirectXVersion()
        {
            try
            {
                // Access the registry key for DirectX
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\DirectX"))
                {
                    if (key != null)
                    {
                        object version = key.GetValue("Version");
                        if (version != null)
                        {
                            return version.ToString();
                        }
                    }
                }
                return "DirectX Version: Not Found";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        private static void BuildInfo()
        {
            GlobalVariables.SystemInfo =
                $"Time: {DateTime.Now} \n\n" +

                $"Personnel:\n\t" +
                $"Handler: {GlobalVariables.currentUser.Name} \n\t" +
                $"Company: {GlobalVariables.currentUser.Company} \n\n" +

                $"Hardware:\n\t" +
                $"CPU: {GlobalVariables.sysInfo.CPU}\n\t" +
                $"GPU: {GlobalVariables.sysInfo.GPU}\n\t" +
                $"RAM: {GlobalVariables.sysInfo.RAM} \n\t" +
                $"STR: \n\t\t{GlobalVariables.sysInfo.SSD} \n\t" +
                $"PSU: {GlobalVariables.sysInfo.PSU} \n\t" +
                $"FAN: {GlobalVariables.sysInfo.FAN} \n\t" +
                $"MOBO: {GlobalVariables.sysInfo.MOBO} \n\t" +
                $"CASE: {GlobalVariables.sysInfo.CHASSIS} \n\t " +
                $"NET: {GlobalVariables.sysInfo.NET} \n\n" +

                $"Software:\n\t" +
                $"ID: {GlobalVariables.sysInfo.ID} \n\t" +
                $"OS: {GlobalVariables.sysInfo.OS} \n\t" +
                $"TI: {GlobalVariables.sysInfo.TI} \n\t" +
                $"UN: {GlobalVariables.sysInfo.UN} \n\t" +
                $"UAC: {GlobalVariables.sysInfo.UAC} \n\n\t" +

                $"DX: {GlobalVariables.sysInfo.DX} \n\t" +
                $"JAVA: {GlobalVariables.sysInfo.JAVA} \n\t" +
                $"PY: {GlobalVariables.sysInfo.PYTHON} \n\t" +
                $"DOTNET: {GlobalVariables.sysInfo.DOTNET} \n\n" +

                $"Action Taken:\n\t" +
                $"AT: {GlobalVariables.sysInfo.AT} \n\t" +
                $"Owner: {GlobalVariables.sysInfo.OWNER}";

            // MessageBox.Show(GlobalVariables.SystemInfo, "System Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Console.WriteLine(GlobalVariables.SystemInfo);
        }
   }
}