using CustomerInquiryBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInquiryBusiness.Managers
{
    /// <summary>
    /// Defines methods for managing Customer entities in application
    /// </summary>
    public interface ICustomerManager
    {
        /// <summary>
        /// Gets a Customer
        /// </summary>
        /// <param name="customerID">
        /// Customer ID
        /// </param>
        /// <param name="email">
        /// Customer's email
        /// </param>
        /// <returns>
        /// Returns Customer specified by ID and/or email and his transactions
        /// </returns>
        CustomerBM GetCustomer(int? customerID, string email);
    }
}
