using CustomerInquiryDataService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInquiryDataService.Repositories
{
    public interface IDbContext
    {
        DbSet<Customer> Customers { get; set; }
    }
}
