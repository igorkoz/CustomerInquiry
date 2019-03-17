using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerInquiryDataService.Models;

namespace CustomerInquiryDataService.Repositories
{
    /// <summary>
    /// The Customer SQL Operations
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class
        /// </summary>
        /// <param name="context">DbContext</param>
        public CustomerRepository(IDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            this.context = context;
        }

        /// <inheritdoc/>
        public Customer GetCustomer(int? customerID, string email)
        {
            var customers = context.Customers.Include("Transactions");
            var result = (customerID.HasValue && !string.IsNullOrWhiteSpace(email))
                ? customers.Where(c => c.ID == customerID.Value && string.Compare(c.Email, email, true) == 0)
                : customers.Where(c => (customerID.HasValue && c.ID == customerID.Value) || string.Compare(c.Email, email, true) == 0);

            return result.FirstOrDefault();
        }
    }
}
