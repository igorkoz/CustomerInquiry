using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerInquiry.Models
{
    /// <summary>
    /// Defines the Customer properties
    /// </summary>
    public class Customer
    {
        [JsonProperty("customerID")]
        public int CustomerID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("mobile")]
        public string MobileNo { get; set; }

        [JsonProperty("transactions")]
        public IEnumerable<Transaction> RecentTransactions { get; set; }
    }
}