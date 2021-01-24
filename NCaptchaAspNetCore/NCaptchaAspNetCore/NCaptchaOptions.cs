using Nololiyt.Captcha.Interfaces;
using System;

namespace Nololiyt.NCaptchaExtensions.AspNetCore
{
    /// <summary>
    /// Options of NCaptcha services.
    /// </summary>
    /// <typeparam name="TCaptchaDisplay">Type of captcha display.</typeparam>
    /// <typeparam name="TAnswer">Type of captcha answer.</typeparam>
    public class NCaptchaOptions<TCaptchaDisplay, TAnswer>
    {
        internal void CheckAndThrow()
        {
            if (this.Factory == null)
                throw new NCaptchaServiceAddException("A captcha factory is required.");
            try
            {
                if (this.Factory.TicketFactory == null)
                    throw new NCaptchaServiceAddException(
                        "A captcha factory should have a ticket factory.");
            }
            catch (Exception e)
            {
                throw new NCaptchaServiceAddException(
                        "A captcha factory should have a ticket factory.", e);
            }
        }
        /// <summary>
        /// Set the captcha factory.
        /// </summary>
        public ICaptchaFactory<TCaptchaDisplay, TAnswer> Factory { internal get; set; } = null!;
    }
}
