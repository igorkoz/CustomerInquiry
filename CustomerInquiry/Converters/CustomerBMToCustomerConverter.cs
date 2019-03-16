using AutoMapper;
using CustomerInquiry.Models;
using CustomerInquiryBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerInquiry.Converters
{
    public class CustomerBMToCustomerConverter : ITypeConverter<CustomerBusinessModel, Customer>
    {
        public Customer Convert(CustomerBusinessModel source, Customer destination, ResolutionContext context)
        {
            if (destination == null)
            {
                destination = new Customer();
            }

            if (source == null)
            {
                return destination;
            }

            destination.CustomerID = source.ID;
            destination.Email = source.Email;
            destination.Name = source.Name;
            destination.MobileNo = source.MobileNo;
            destination.RecentTransactions = new List<Transaction>();

            return destination;
        }
    }
}