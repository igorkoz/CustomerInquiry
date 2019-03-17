using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using CustomerInquiry.Converters;
using CustomerInquiry.Models;
using CustomerInquiryBusiness.Managers;
using CustomerInquiryBusiness.Models;

namespace CustomerInquiry.Adapters
{
    /// <summary>
    /// Adapter for Customer related methods.
    /// </summary>
    public class CustomerAdapter : ICustomerAdapter
    {
        private readonly ICustomerManager customerManager;
        private readonly IMapper mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CustomerBM, Customer>().ConvertUsing(new CustomerBMToCustomerConverter());
        }).CreateMapper();

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerAdapter"/> class
        /// </summary>
        /// <param name="customerManager">The Customer Manager</param>
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
        /// <param name="customerID">Customer ID</param>
        /// <param name="email">Customer's email </param>
        /// <returns>Customer and his related Transactions</returns>
        public Customer GetCustomer(int? customerID, string email)
        {
            var customer = this.customerManager.GetCustomer(customerID, email);

            return this.mapper.Map<Customer>(customer);
        }
    }
}