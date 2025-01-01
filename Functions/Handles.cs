using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_Fetcher.Functions
{
    internal class Handles
    {

        // General function for initializing the Ini file
        public static void CheckIniFile()
        {
            try
            {
                if (!File.Exists(GlobalVariables.configPath) || IsConfigFileEmptyOrInvalid(GlobalVariables.configPath))
                {
                    MessageBox.Show("Configuration file not found. Please set up the required settings.",
                                   "Configuration Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Launch the initialization form
                    Initialize init = new Initialize();
                    if (init.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Initialization Done. Please launch the Application again!",
                                        "Initialization Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Initialization was not completed. The application will now exit.",
                                        "Initialization Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // EXTERMINATE
                    Application.Exit();
                    Environment.Exit(0);
                }

                else
                {
                    var configData = ReadConfigFile(GlobalVariables.configPath);

                    if (string.IsNullOrEmpty(configData["Handler"]) ||
               string.IsNullOrEmpty(configData["Company"]) ||
               string.IsNullOrEmpty(configData["AppVer"]))
                    {
                        MessageBox.Show("Configuration file is incomplete. Please set up all required settings.",
                                        "Invalid Configuration", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        // Delete the invalid config.ini if it has incomplete keys, get the fuck out of here!
                        File.Delete(GlobalVariables.configPath);

                        // Re-init because it's hot
                        CheckIniFile(); // Recursiveeeeeeeeeeeeee
                    }
                    else
                    {
                        // Successfully read and validated configuration
                        // MessageBox.Show($"Handler: {configData["Handler"]}\nCompany: {configData["Company"]}\nAppVer: {configData["AppVer"]}","Configuration Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (IOException ioEx)
            {
                MessageBox.Show($"File system error: {ioEx.Message}",
                                "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            catch (UnauthorizedAccessException uaEx)
            {
                MessageBox.Show($"Access denied: {uaEx.Message}",
                                "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred while checking configuration: {ex.Message}",
                                "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }


        }

        // Checker of the Ini FIle if it's empty or invalid
        private static bool IsConfigFileEmptyOrInvalid(string configPath)
        {
            try
            {
                string content = File.ReadAllText(configPath).Trim();
                return string.IsNullOrEmpty(content);
            }
            catch (IOException ioEx)
            {
                MessageBox.Show($"Error reading the configuration file: {ioEx.Message}",
                                "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true; // Treat as invalid if an error occurs while reading
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred while validating the configuration file: {ex.Message}",
                                "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true; // Treat as invalid for any unexpected errors
            }
        }


        // The reader of the config.ini
        private static Dictionary<string, string> ReadConfigFile(string configPath)
        {
            var configData = new Dictionary<string, string>
            {
                       { "Handler", string.Empty },
                       { "Company", string.Empty },
                       { "AppVer", string.Empty }
                };

            try
            {
                foreach (var line in File.ReadAllLines(configPath))
                {
                    if (string.IsNullOrWhiteSpace(line) || !line.Contains("="))
                        continue;

                    var parts = line.Split(new[] { '=' }, 2);
                    var key = parts[0].Trim();
                    var value = parts[1].Trim();

                    if (configData.ContainsKey(key))
                        configData[key] = value;
                }
            }
            catch (IOException ioEx)
            {
                MessageBox.Show($"Error reading the configuration file: {ioEx.Message}",
                                "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred while reading the configuration file: {ex.Message}",
                                "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            return configData;
        }

        public static bool SaveConfig(string Name, string company)
        {
            try
            {
                // ALIGN!
                string configContent = $"Handler = {Name.Trim()}\n" +
                                         $"Company = {company.Trim()}\n" +
                                         $"AppVer = {Properties.Resources.appVersion.Trim()}";

                // GO!!!!!
                File.WriteAllText(GlobalVariables.configPath, configContent);
                return true;
            }
            catch (IOException ioEx)
            {
                MessageBox.Show($"File system error: {ioEx.Message}",
                                "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (UnauthorizedAccessException uaEx)
            {
                MessageBox.Show($"Access denied: {uaEx.Message}",
                                "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}",
                                "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
    }


}
