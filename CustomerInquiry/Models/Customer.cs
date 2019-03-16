﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerInquiry.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public ICollection<Transaction> RecentTransactions { get; set; }
    }
}