using Nololiyt.Captcha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nololiyt.NCaptchaExtensions.AspNetCore
{
    public class NCaptchaOptions<TCaptchaDisplay, TAnswer>
    {
        internal void CheckAndThrow()
        {
            if (Factory == null)
                throw new NCaptchaServiceAddException("A captcha factory is required.");
            try
            {
                if (Factory.TicketFactory == null)
                    throw new NCaptchaServiceAddException(
                        "A captcha factory should have a ticket factory.");
            }
            catch(Exception e)
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
