using System;
using Microsoft.Data.SqlClient;
using System.Text;

namespace sqltest
{

    class SqlClient
    {
        public string connectionString { get; private set; }
        public SqlClient()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "sajiwebsite-server.database.windows.net";
            builder.Authentication = SqlAuthenticationMethod.ActiveDirectoryInteractive;
            builder.InitialCatalog = "sajiwebsite-database";
            this.connectionString = builder.ConnectionString;
        }
        public void executeQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}