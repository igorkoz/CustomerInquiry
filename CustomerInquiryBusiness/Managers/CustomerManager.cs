using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CustomerInquiryBusiness.Converters;
using CustomerInquiryBusiness.Models;
using CustomerInquiryDataService.Models;
using CustomerInquiryDataService.Repositories;

namespace CustomerInquiryBusiness.Managers
{
    /// <summary>
    /// Represents methods for managing Customer entities in application.
    /// </summary>
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository customerRepository;

        private readonly IMapper mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Customer, CustomerBusinessModel>().ConvertUsing(new CustomerDataToCustomerConverter());
        }).CreateMapper();

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerManager"/> class.
        /// </summary>
        /// <param name="customerRepository">
        /// The Customer Repository.
        /// </param>
        public CustomerManager(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public CustomerBusinessModel GetCustomer(int? customerID, string email = null)
        {
            var customer = this.customerRepository.GetCustomer(customerID, email);

            return this.mapper.Map<CustomerBusinessModel>(customer);
        }
    }
}
