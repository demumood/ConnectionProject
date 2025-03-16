using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Microsoft.Extensions.Configuration;

namespace ConnectionProject.BAL
{
    /// <summary>
    /// The Get connection class
    /// </summary>
    public class GetConnection
    {
        // varibales for connection
        private string? webUserName;
        private string? webPassword;
        private string? webServer;
        private string? webDB;

        // setup a connection to the DAL
        private Connect connect = new Connect();

        public GetConnection(IConfiguration configuration)
        {
            webUserName = configuration.GetSection("ConnData:UserName").Value;
            webPassword = configuration.GetSection("ConnData:UserPass").Value;
            webServer = configuration.GetSection("ConnData:Server").Value;
            webDB = configuration.GetSection("ConnData:DataBase").Value;
        }

        public string DisplayConnString()
        {
            return connect.WebConnectionBuilder(webUserName!, webPassword!, webServer!, webDB!);
        }
    }
}
