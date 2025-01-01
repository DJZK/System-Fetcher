using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Fetcher.Functions
{
    internal class GlobalVariables
    {
        public static string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini");
    }
}
