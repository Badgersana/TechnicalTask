using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charges_Notification_System.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int ProductID { get; set; }
        public int GameID { get; set; }
        public string GameName { get; set; }
        public int Price { get; set; }
        public DateTime DateOfPurchase { get; set; }

    }
}
