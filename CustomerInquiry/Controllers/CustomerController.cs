using CustomerInquiry.Adapters;
using CustomerInquiryBusiness.Validators;
using System;
using System.Web.Http;

namespace CustomerInquiry.Controllers
{
    /// <summary>
    /// API controller for Customer related methods
    /// </summary>
    public class CustomerController : ApiController
    {
        private readonly ICustomerAdapter customerAdapter;
        private readonly IEMailValidator emailValidator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController"/> class
        /// </summary>
        /// <param name="customerAdapter">The Customer Adapter</param>
        /// <param name="emailValidator">The EMail Validator</param>
        public CustomerController(ICustomerAdapter customerAdapter, IEMailValidator emailValidator)
        {
            if (customerAdapter == null)
            {
                throw new ArgumentNullException(nameof(customerAdapter));
            }

            if (emailValidator == null)
            {
                throw new ArgumentNullException(nameof(emailValidator));
            }

            this.customerAdapter = customerAdapter;
            this.emailValidator = emailValidator;
        }

        /// <summary>
        /// Get a Customer
        /// </summary>
        /// <param name="customerID">
        /// The ID of the Customer
        /// </param>
        /// <param name="email">
        /// The Customer's email
        /// </param>
        /// <returns>
        /// Customer with his Transactions in System
        /// </returns>
        [HttpGet]
        [Route("api/customer")]
        public IHttpActionResult GetCustomer([FromUri] int? customerID = null, [FromUri] string email = null)
        {
            if (customerID is null && String.IsNullOrWhiteSpace(email))
                return (IHttpActionResult)BadRequest($"{nameof(customerID)} and/or {nameof(email)} should not be NULL");

            if (customerID.HasValue && customerID < 1)
                return (IHttpActionResult)BadRequest($"Invalid {nameof(customerID)}");
            
            if (!String.IsNullOrWhiteSpace(email) && !this.emailValidator.ValidateEMail(email))
                return (IHttpActionResult)BadRequest($"Invalid {nameof(email)}");

            var result = this.customerAdapter.GetCustomer(customerID, email);

            return result == null ? (IHttpActionResult)NotFound() : Ok(result);
        }
    }
}
