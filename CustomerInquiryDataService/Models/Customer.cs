using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInquiryDataService.Models
{
    /// <summary>
    /// Defines the Customer properties
    /// </summary>
    public class Customer
    {
        [Key]
        public int ID { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(25)]
        public string Email { get; set; }
        [StringLength(13)]
        public string MobileNo { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
