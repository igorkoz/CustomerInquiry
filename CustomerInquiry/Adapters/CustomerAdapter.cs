using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CustomerInquiry.Models;
using CustomerInquiryBusiness.Managers;

namespace CustomerInquiry.Adapters
{
    public class CustomerAdapter : ICustomerAdapter
    {
        private readonly ICustomerManager customerManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerAdapter"/> class.
        /// </summary>
        /// <param name="customerManager">The Customer Manager.</param>
        public CustomerAdapter(ICustomerManager customerManager)
        {
            if (customerManager == null)
            {
                throw new ArgumentNullException(nameof(customerManager));
            }

            this.customerManager = customerManager;
        }

        /// <summary>
        /// Gets Customer and his related Transactions
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public Customer GetCustomer(int? customerID, string email = null)
        {
            throw new NotImplementedException();
        }
    }
}