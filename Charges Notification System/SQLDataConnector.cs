using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Charges_Notification_System
{
    public class SQLDataConnector
    {
        private string connectionString;
        public SQLDataConnector()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Charges_Notification_System.Properties.Settings.GamesDBConnectionString"].ConnectionString;
        }

        // Method to execute a SQL query and return a DataTable with the results
        public DataTable ExecuteQuery(String query)
        {
            DataTable dataTable = new DataTable();
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return dataTable;


        }
    }
}
