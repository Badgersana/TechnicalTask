using Charges_Notification_System.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charges_Notification_System
{
    public class TransactionListConverter
    {

        public List<TransactionTotal> ConvertTransactionToTotalTransaction(List<Transaction> transaction)
        {
            List<TransactionTotal> purchasesByGame = new List<TransactionTotal>();

            int customerNumber = transaction.First().CustomerID;
            string customerName = transaction.First().CustomerName;
            DateTime date = transaction.First().DateOfPurchase;

            Dictionary<string, int> totalByGame = CalculateTotalsByGame(transaction);

            foreach (var kvp in totalByGame)
            {
                var transactionTotal = new TransactionTotal
                {
                    CustomerNumber = customerNumber,
                    CustomerName = customerName,
                    Date = date,
                    GameName = kvp.Key,
                    Total = kvp.Value
                };

                purchasesByGame.Add(transactionTotal);
            }

            return purchasesByGame;
        }


        public static Dictionary<string, int> CalculateTotalsByGame(List<Transaction> transactions)
        {
            Dictionary<string, int> gameTotals = new Dictionary<string, int>();

            foreach (var transaction in transactions)
            {
                string gameName = transaction.GameName;          
                int total = transaction.Price;  

                
                if (gameTotals.ContainsKey(gameName))
                {
                    gameTotals[gameName] += total;
                }
                
                else
                {
                    gameTotals[gameName] = total;
                }
            }

            return gameTotals;
        }
    }
}
