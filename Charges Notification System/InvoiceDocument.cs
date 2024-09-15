using Charges_Notification_System.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charges_Notification_System
{
    public class InvoiceDocument
    {
        public void GeneratePdf(List<TransactionTotal> transactions, string filePath)
        {
            var customerId = transactions.First().CustomerNumber;
            var customerName = transactions.First().CustomerName;
            var totalSum = transactions.Sum(t => t.Total);

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(12));
                    page.Content().Column(column =>
                    {
                        column.Item().Text("Invoice").FontSize(18).SemiBold().AlignCenter();

                        column.Item().Text($"Customer ID: {customerId}").FontSize(14).SemiBold().AlignLeft();
                        column.Item().Text($"Customer Name: {customerName}").FontSize(14).SemiBold().AlignLeft();

                        column.Item().LineHorizontal(1f).LineColor(Colors.Black);

                        column.Item().Table(table =>
                        {
                            // Define columns
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(1); // Date column
                                columns.RelativeColumn(2); // Game column
                                columns.RelativeColumn(1); // Price column
                            });

                            // Header row
                            table.Header(header =>
                            {
                                header.Cell().Text("Date").SemiBold();
                                header.Cell().Text("Game").SemiBold();
                                header.Cell().Text("Price (pence)").SemiBold();
                            });

                            // Data rows
                            foreach (var transaction in transactions)
                            {
                                table.Cell().Text(transaction.Date.ToShortDateString());
                                table.Cell().Text(transaction.GameName);
                                table.Cell().Text($"{transaction.Total}"); // Format as currency
                            }

                            table.Cell().ColumnSpan(3).PaddingTop(5).LineHorizontal(1f).LineColor(Colors.Black);
                            table.Cell().ColumnSpan(2).AlignLeft().Text("Total:").SemiBold(); // Span first two columns
                            table.Cell().Text($"{totalSum}").SemiBold(); // Display total sum
                        });
                    });
                });
            })
            .GeneratePdf(filePath);
        }
    }
}
