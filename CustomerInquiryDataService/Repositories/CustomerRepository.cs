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
        public CustomerDBModel GetCustomer(int? customerID, string email = null)
        {
            throw new NotImplementedException();
        }
    }
}
