using System;
using Microsoft.Extensions.Configuration;

namespace Demo_ProductApp.Utility
{
    public static class PropertyUtil
    {
        private static IConfiguration _iconfiguration;


        public static string GetConnectionString()
        {
            return _iconfiguration.GetConnectionString("LocalConnectionString");
        }


        private static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");
            _iconfiguration = builder.Build();

        }

        static PropertyUtil()

        {
            GetAppSettingsFile();
        }

    }
}

//Microsoft.Extensions.Configuration
//Microsoft.Extensions.Configuration.FileExtension
//Microst.extensions.Configuration.json

