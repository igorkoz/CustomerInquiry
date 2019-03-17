using CustomerInquiry.Adapters;
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

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController"/> class.
        /// </summary>
        /// <param name="customerAdapter">The Customer Adapter.</param>
        public CustomerController(ICustomerAdapter customerAdapter)
        {
            if (customerAdapter == null)
            {
                throw new ArgumentNullException(nameof(customerAdapter));
            }

            this.customerAdapter = customerAdapter;
        }

        /// <summary>
        /// Get a Customer.
        /// </summary>
        /// <param name="customerID">
        /// The ID of the Customer.
        /// </param>
        /// <param name="email">
        /// The Customer's email.
        /// </param>
        /// <returns>
        /// Customer with his Transactions in System.
        /// </returns>
        [HttpGet]
        [Route("api/customer")]
        public IHttpActionResult GetCustomer([FromUri] int? customerID = null, [FromUri] string email = null)
        {
            if (customerID is null && String.IsNullOrWhiteSpace(email))
                return (IHttpActionResult)BadRequest($"{nameof(customerID)} and/or {nameof(email)} should not be NULL");

            var result = this.customerAdapter.GetCustomer(customerID, email);

            return result == null ? (IHttpActionResult)NotFound() : Ok(result);
        }
    }
}
