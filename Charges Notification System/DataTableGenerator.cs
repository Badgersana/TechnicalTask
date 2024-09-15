using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charges_Notification_System
{
    public class DataTableGenerator
    {
        SQLDataConnector sdq = new SQLDataConnector();
        public DataTable CreateDataTable(string CustomerID)
        {
            String query = "SELECT ch.[ID], ch.[CustomerID], ch.[GameID], g.[Name], ch.[ProductID], ch.[DateOfPurchase], c.[CustomerName]," +
                " p.[Price] FROM [Charges] ch" +
                "\r\nINNER JOIN [Customer] c ON ch.[CustomerID] = c.[CustomerID]" +
                "\r\nINNER JOIN [Game] g ON ch.[GameID] = g.[GameID]" +
                "\r\nINNER JOIN [Product] p ON ch.[ProductID] = p.[ProductID]" +
                "\r\nWHERE ch.[DateOfPurchase]BETWEEN DATEADD(day, DATEDIFF(day, 1, GETDATE()), 0)" +
                "\r\n AND DATEADD(day, DATEDIFF(day, 0, GETDATE()), 0)\r\nAND ch.[CustomerID] =" + CustomerID;

            DataTable dataTable = sdq.ExecuteQuery(query);
            return dataTable;
        }

        public DataTable GetCustomerIDs() {
            String query = "SELECT DISTINCT customerID FROM [Charges]" +
                "WHERE [DateOfPurchase]BETWEEN DATEADD(day, DATEDIFF(day, 1, GETDATE()), 0) " +
                "AND DATEADD(day, DATEDIFF(day, 0, GETDATE()), 0)";

            DataTable dataTable = sdq.ExecuteQuery(query);

            foreach (DataColumn column in dataTable.Columns)
            {
                Console.Write(column.ColumnName + "\t");
            }
            Console.WriteLine();

            return dataTable;
        }
    }        
}
