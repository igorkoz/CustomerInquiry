using CustomerInquiryDataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInquiryDataService.Repositories
{
    /// <summary>
    /// Defines methods for managing Customer records in DB
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Get Customer from DB
        /// </summary>
        /// <param name="customerID">Customer ID</param>
        /// <param name="email">Customer email</param>
        /// <returns>Customer info with his transactions</returns>
        Customer GetCustomer(int? customerID, string email);
    }
}
