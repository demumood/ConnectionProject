using Microsoft.Data.SqlClient;

using System.Data.SqlTypes;
using System.Text;

namespace DAL
{
    /// <summary>
    /// The connection string class
    /// </summary>
    public class Connect
    {
        /// <summary>
        /// The connection string builder
        /// </summary>
        /// <param name="userName">The base64 username</param>
        /// <param name="userPassword">The base64 password</param>
        /// <param name="userServer">The base64 server</param>
        /// <param name="userDB">The base64 database</param>
        /// <returns>The connection string</returns>
        public string WebConnectionBuilder(string userName, string userPassword, string userServer, string userDB)
        {
            //get the connection username
            byte[] connUserName64 = Convert.FromBase64String(userName!.ToString());
            string connUser = Encoding.UTF8.GetString(connUserName64);

            //get the connection password
            byte[] connUserPass64 = Convert.FromBase64String(userPassword!.ToString());
            string connPass = Encoding.UTF8.GetString(connUserPass64);

            //get the connection server
            byte[] connServer64 = Convert.FromBase64String(userServer!.ToString());
            string connServer = Encoding.UTF8.GetString(connServer64);

            //get the connection Database
            byte[] connDB64 = Convert.FromBase64String(userDB!.ToString());
            string connDB = Encoding.UTF8.GetString(connDB64);

            // build the connection string
            var builder = new SqlConnectionStringBuilder() 
            {
                UserID = connUser,
                Password = connPass,
                InitialCatalog = connDB,
                DataSource = connServer,
                TrustServerCertificate = true,
            };

            // return the connection string
            return builder.ConnectionString;
        }
    }
}
