using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerInquiryDataService.Models
{
    /// <summary>
    /// Defines the Transaction properties
    /// </summary>
    public class Transaction
    {
        [Key]
        public int ID { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public decimal Amount { get; set; }
        [StringLength(3)]
        public string CurrencyCode { get; set; }
        [StringLength(20)]
        public string Status { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}