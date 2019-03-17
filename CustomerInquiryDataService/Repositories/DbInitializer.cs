using CustomerInquiryDataService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInquiryDataService.Repositories
{
    public class DbInitializer : CreateDatabaseIfNotExists<CustomerDBContext>
    {
        protected override void Seed(CustomerDBContext context)
        {
            new List<Customer> {
                new Customer() { Name = "Peter Jones", Email = "PeterJones@google.com", MobileNo = "+380551234577",
                    Transactions = new List<Transaction>
                    {
                        new Transaction() { Amount = 100.01m, CurrencyCode = "USD", TransactionDateTime = DateTime.Now.AddYears(-2), Status = "Canceled" },
                        new Transaction() { Amount = 200.02m, CurrencyCode = "EUR", TransactionDateTime = DateTime.Now, Status = "Success" },
                        new Transaction() { Amount = 300.03m, CurrencyCode = "UAH", TransactionDateTime = DateTime.Now.AddYears(-1), Status = "Failed" }
                    }
                 },
                new Customer() { Name = "Avraam Goldman", Email = "AvraamGoldman@google.com", MobileNo = "+380951234577",
                    Transactions = new List<Transaction>
                    {
                        new Transaction() { Amount = 100.01m, CurrencyCode = "USD", TransactionDateTime = DateTime.Now.AddYears(-2), Status = "Canceled" },
                        new Transaction() { Amount = 200.02m, CurrencyCode = "EUR", TransactionDateTime = DateTime.Now.AddSeconds(-400), Status = "Success" },
                        new Transaction() { Amount = 220.02m, CurrencyCode = "EUR", TransactionDateTime = DateTime.Now.AddSeconds(-300), Status = "Canceled" },
                        new Transaction() { Amount = 203.02m, CurrencyCode = "EUR", TransactionDateTime = DateTime.Now.AddSeconds(-200), Status = "Success" },
                        new Transaction() { Amount = 204.02m, CurrencyCode = "EUR", TransactionDateTime = DateTime.Now.AddSeconds(-100), Status = "Canceled" },
                        new Transaction() { Amount = 290.02m, CurrencyCode = "EUR", TransactionDateTime = DateTime.Now, Status = "Success" },
                        new Transaction() { Amount = 300.03m, CurrencyCode = "UAH", TransactionDateTime = DateTime.Now.AddYears(-1), Status = "Failed" }
                    }
                 },
                new Customer() { Name = "Alice Smith", Email = "AliceSmith@google.com", MobileNo = "+380551234567", Transactions = null }
            }.ForEach(customer => context.Customers.Add(customer));

            context.SaveChanges();
        }
    }
}
