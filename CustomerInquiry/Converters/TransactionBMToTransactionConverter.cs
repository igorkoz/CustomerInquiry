using AutoMapper;
using CustomerInquiry.Models;
using CustomerInquiryBusiness.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInquiry.Converters
{
    /// <summary>
    /// Converts <see cref="TransactionBM"/> to <see cref="Transaction"/> for Get operation
    /// </summary>
    public class TransactionBMToTransactionConverter : ITypeConverter<TransactionBM, Transaction>
    {
        /// <summary>
        /// Performs conversion from source to destination type
        /// </summary>
        /// <param name="source">Source object</param>
        /// <param name="destination">Destination object</param>
        /// <param name="context">Resolution context</param>
        /// <returns>Destination object</returns>
        public Transaction Convert(TransactionBM source, Transaction destination, ResolutionContext context)
        {
            if (destination == null)
            {
                destination = new Transaction();
            }

            if (source == null)
            {
                return destination;
            }

            destination.ID = source.ID;
            destination.Amount = source.Amount;
            destination.CurrencyCode = source.CurrencyCode;
            destination.Status = source.Status;
            destination.TransactionDateTime = source.TransactionDateTime.ToString("dd/MM/yy HH:mm", CultureInfo.InvariantCulture);

            return destination;
        }
    }
}
