using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerInquiryBusiness.Models
{
    /// <summary>
    /// Defines the Transaction properties
    /// </summary>
    public class TransactionBM
    {
        public int ID { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string Status { get; set; }
    }
}