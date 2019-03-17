using CustomerInquiryDataService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace CustomerInquiryDataService.Repositories
{
    public class CustomerDBContext : DbContext, IDbContext
    {
        public CustomerDBContext() : base("name = DBConnectionString")
        {
            Database.SetInitializer<CustomerDBContext>(new DbInitializer());
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
