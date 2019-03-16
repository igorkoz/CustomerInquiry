using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerInquiryDataService.Models;

namespace CustomerInquiryDataService.Repositories
{
    /// <summary>
    /// The Customer SQL Operations.
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        //private CustomerDBContext context = new CustomerDBContext();
        private readonly IDbContext context;

        public CustomerRepository(IDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            this.context = context;
        }

        public Customer GetCustomer(int? customerID, string email = null)
        {
            //var customers = context.Customers.ToList();
            var result = (customerID.HasValue && !string.IsNullOrWhiteSpace(email))
                ? context.Customers.Where(c => c.ID == customerID.Value && c.Email == email).FirstOrDefault()
                : context.Customers.Where(c => (customerID.HasValue && c.ID == customerID.Value) || c.Email == email).FirstOrDefault();

            return result;
        }
    }
}
