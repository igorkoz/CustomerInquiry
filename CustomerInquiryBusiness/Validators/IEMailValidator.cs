using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInquiryBusiness.Validators
{
    /// <summary>
    /// The interface for EMail validation
    /// </summary>
    public interface IEMailValidator
    {
        /// <summary>
        /// Validates email object
        /// </summary>
        /// <param name="email">
        /// Email string
        /// </param>
        /// <returns>
        /// Validation result
        /// </returns>
        bool ValidateEMail(string email);
    }
}
