using Microsoft.Extensions.Configuration;
using System.IO;
using System;

namespace ConnectionProject
{
    public class Program
    {

        private static IConfiguration? iconfiguration;
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GetAppSettingsFile();
            GetConnString();

        }

        static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            iconfiguration = builder.Build();
        }

        static void GetConnString()
        {
            var connInfo = new BAL.GetConnection(iconfiguration!);
            string conn = connInfo.DisplayConnString();
            Console.WriteLine("connection string: " + conn); 
        }
    }
}