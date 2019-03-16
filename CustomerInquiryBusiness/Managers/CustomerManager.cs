using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerInquiryBusiness.Models;

namespace CustomerInquiryBusiness.Managers
{
    public class CustomerManager : ICustomerManager
    {
        public CustomerBusinessModel GetCustomer(int? customerID, string email = null)
        {
            throw new NotImplementedException();
        }
    }
}
