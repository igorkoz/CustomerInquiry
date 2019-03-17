using System;
using System.Net.Mail;

namespace CustomerInquiryBusiness.Validators
{
    /// <summary>
    /// Performs EMail validation
    /// </summary>
    public class EMailValidator : IEMailValidator
    {
        /// <inheritdoc/>
        public bool ValidateEMail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
