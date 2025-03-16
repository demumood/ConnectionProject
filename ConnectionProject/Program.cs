using Microsoft.Extensions.Configuration;
using System.IO;
using System;

namespace ConnectionProject
{
    public class Program
    {
        /// <summary>
        /// The configuration 
        /// </summary>
        private static IConfiguration? iconfiguration;

        /// <summary>
        /// The main program
        /// </summary>
        /// <param name="args">The arguments</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GetAppSettingsFile();
            GetConnString();

        }

        /// <summary>
        /// Get the application settings setup
        /// </summary>
        static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            iconfiguration = builder.Build();
        }

        /// <summary>
        /// Get the connection string
        /// </summary>
        static void GetConnString()
        {
            // Set up the class information
            var connInfo = new BAL.GetConnection(iconfiguration!);

            // Get the connection string
            string conn = connInfo.DisplayConnString();
            Console.WriteLine("connection string: " + conn);
        }
    }
}