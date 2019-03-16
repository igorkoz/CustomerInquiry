using CustomerInquiry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerInquiry.Adapters
{
    public interface ICustomerAdapter
    {
        /// <summary>
        /// Gets a Customer.
        /// </summary>
        /// <param name="customerID">
        /// Customer's ID.
        /// </param>
        /// <param name="email">
        /// Customer's email.
        /// </param>
        /// <returns>
        /// Returns Customer by ID and/or email.
        /// </returns>
        Customer GetCustomer(int? customerID, string email = null);
    }
}