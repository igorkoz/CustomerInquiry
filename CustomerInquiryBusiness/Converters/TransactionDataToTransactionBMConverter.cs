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
    /// <summary>
    /// Converts <see cref="Transaction"/> to <see cref="TransactionBM"/> for Get operation
    /// </summary>
    public class TransactionDataToTransactionBMConverter : ITypeConverter<Transaction, TransactionBM>
    {
        /// <summary>
        /// Performs conversion from source to destination type
        /// </summary>
        /// <param name="source">Source object</param>
        /// <param name="destination">Destination object</param>
        /// <param name="context">Resolution context</param>
        /// <returns>Destination object</returns>
        public TransactionBM Convert(Transaction source, TransactionBM destination, ResolutionContext context)
        {
            if (destination == null)
            {
                destination = new TransactionBM();
            }

            if (source == null)
            {
                return destination;
            }

            destination.ID = source.ID;
            destination.Amount = source.Amount;
            destination.CurrencyCode = source.CurrencyCode;
            destination.Status = source.Status;
            destination.TransactionDateTime = source.TransactionDateTime;

            return destination;
        }
    }
}
