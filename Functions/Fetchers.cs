using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace System_Fetcher.Interfaces
{
    internal class Fetchers
    {
        static void GetHardwareInfo(string hwClass, string syntax)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher($"SELECT * FROM {hwClass}"
                ); foreach (ManagementObject obj in searcher.Get())
            {
                Console.WriteLine($"{syntax}: {obj[syntax]}");
            }
        }

        static void GetTpmVersion()
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
        static void GetSecureBootStatus()
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
    }
}
