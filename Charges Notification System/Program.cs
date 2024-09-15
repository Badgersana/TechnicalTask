using Charges_Notification_System.Models;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charges_Notification_System
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            String CustomerName;
            QuestPDF.Settings.License = LicenseType.Community;
            DataTableConverter dataTableConverter = new DataTableConverter();
            DataTableGenerator dataTableGenerator = new DataTableGenerator();
            InvoiceDocument pdf = new InvoiceDocument();
            TransactionListConverter totalTransactions = new TransactionListConverter();

            DataTable customerIDCount = dataTableGenerator.GetCustomerIDs();

            foreach (DataRow row in customerIDCount.Rows)
            {
                string id = Convert.ToString(row["customerID"]);

                DataTable trans = dataTableGenerator.CreateDataTable(id);

                CustomerName = trans.Rows[0]["customerName"].ToString(); ;

                List<Transaction> transactions = dataTableConverter.ConvertDataTableToList(trans);
                

                List<TransactionTotal> totalTransactionsList = totalTransactions.ConvertTransactionToTotalTransaction(transactions);


                pdf.GeneratePdf(totalTransactionsList, $"C:\\Users\\Jacob Howard\\Desktop\\PDF\\{CustomerName}.pdf");
            }
        }
    }
}
