﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerInquiry.Models
{
    /// <summary>
    /// Defines the Transaction properties
    /// </summary>
    public class Transaction
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("date")]
        public string TransactionDateTime { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("currency")]
        public string CurrencyCode { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}