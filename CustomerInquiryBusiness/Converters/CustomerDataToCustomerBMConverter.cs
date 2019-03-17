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
    /// Converts <see cref="Customer"/> to <see cref="CustomerBM"/> for Get operation
    /// </summary>
    public class CustomerDataToCustomerBMConverter : ITypeConverter<Customer, CustomerBM>
    {
        private readonly IMapper mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Transaction, TransactionBM>().ConvertUsing(new TransactionDataToTransactionBMConverter());
        }).CreateMapper();

        /// <summary>
        /// Performs conversion from source to destination type
        /// </summary>
        /// <param name="source">Source object</param>
        /// <param name="destination">Destination object</param>
        /// <param name="context">Resolution context</param>
        /// <returns>Destination object</returns>
        public CustomerBM Convert(Customer source, CustomerBM destination, ResolutionContext context)
        {
            if (destination == null)
            {
                destination = new CustomerBM();
            } 

            if (source == null)
            {
                return destination;
            }

            destination.ID = source.ID;
            destination.Email = source.Email;
            destination.Name = source.Name;
            destination.MobileNo = source.MobileNo;
            destination.Transactions = this.mapper.Map< IList<TransactionBM>>(source.Transactions);

            return destination;
        }
    }
}
