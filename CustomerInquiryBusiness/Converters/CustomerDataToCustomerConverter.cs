using AutoMapper;
using CustomerInquiryBusiness.Models;
using CustomerInquiryDataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInquiryBusiness.Converters
{
    class CustomerDataToCustomerConverter : ITypeConverter<CustomerDBModel, CustomerBusinessModel>
    {
        public CustomerBusinessModel Convert(CustomerDBModel source, CustomerBusinessModel destination, ResolutionContext context)
        {
            if (destination == null)
            {
                destination = new CustomerBusinessModel();
            } 

            if (source == null)
            {
                return destination;
            }

            destination.ID = source.ID;
            destination.Email = source.Email;
            destination.Name = source.Name;
            destination.MobileNo = source.MobileNo;

            return destination;
        }
    }
}
