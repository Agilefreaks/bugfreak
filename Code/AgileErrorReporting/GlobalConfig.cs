using System;
using System.ComponentModel.Design;

namespace AgileErrorReporting
{
    public class GlobalConfig
    {
        public class Settings
        {
            public static string ServiceEndPoint { get; set; }

            public static string AppName { get; set; }

            public static string InstanceIdentifier { get; set; }
        }

        public static IServiceProvider ServiceProvider { get; set; }
    }
}
