using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charges_Notification_System.Models
{
    public class TransactionTotal
    {
        public int CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date {get; set;}
        public String GameName { get; set;}
        public int Total { get; set; }
    }
}
