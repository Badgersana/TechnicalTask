using Charges_Notification_System.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charges_Notification_System
{
    public class DataTableConverter
    {
        public List<Transaction> ConvertDataTableToList(DataTable dataTable)
        {
            List<Transaction> purchases = new List<Transaction>();

            foreach (DataRow row in dataTable.Rows)
            {
                Transaction purchase = new Transaction
                {
                    Id = Convert.ToInt32(row["Id"]),
                    CustomerID = Convert.ToInt32(row["CustomerID"]),
                    CustomerName = Convert.ToString(row["CustomerName"]),
                    ProductID = Convert.ToInt32(row["ProductID"]),
                    GameID = Convert.ToInt32(row["GameID"]),
                    GameName = Convert.ToString(row["Name"]),
                    Price = Convert.ToInt32(row["Price"]),
                    DateOfPurchase = Convert.ToDateTime(row["DateOfPurchase"])
                };

                purchases.Add(purchase);
            }

            return purchases;
        }
    }
}
