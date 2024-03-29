﻿using AutoMapper;
using CustomerInquiry.Models;
using CustomerInquiryBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerInquiry.Converters
{
    /// <summary>
    /// Converts <see cref="CustomerBM"/> to <see cref="Customer"/> for Get operation
    /// </summary>
    public class CustomerBMToCustomerConverter : ITypeConverter<CustomerBM, Customer>
    {
        private readonly IMapper mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<TransactionBM, Transaction>().ConvertUsing(new TransactionBMToTransactionConverter());
        }).CreateMapper();

        /// <summary>
        /// Performs conversion from source to destination type
        /// </summary>
        /// <param name="source">Source object</param>
        /// <param name="destination">Destination object</param>
        /// <param name="context">Resolution context</param>
        /// <returns>Destination object</returns>
        public Customer Convert(CustomerBM source, Customer destination, ResolutionContext context)
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
            destination.RecentTransactions = this.mapper.Map<IList<Transaction>>(source.Transactions.OrderByDescending(t => t.TransactionDateTime).Take(5));

            return destination;
        }
    }
}