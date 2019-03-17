using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInquiryBusiness.Models
{
    /// <summary>
    /// Defines the Customer properties
    /// </summary>
    public class CustomerBM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public ICollection<TransactionBM> Transactions { get; set; }
    }
}
