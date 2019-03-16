using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using CustomerInquiry.Models;
using CustomerInquiryBusiness.Managers;

namespace CustomerInquiry.Adapters
{
    /// <summary>
    /// Adapter for Customer related methods.
    /// </summary>
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
        /// Gets Customer and its related Transactions
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="email"></param>
        /// <returns>Customer and his related Transactions</returns>
        public Customer GetCustomer(int? customerID, string email = null)
        {
            var customer = this.customerManager.GetCustomer(customerID, email);

            return Mapper.Map<Customer>(customer);
        }
    }
}