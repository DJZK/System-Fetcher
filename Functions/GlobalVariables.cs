﻿using System;
using System.IO;

namespace System_Fetcher.Functions
{
    internal class GlobalVariables
    {
        public static string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini");

        public static User currentUser = new User();

    }

}
