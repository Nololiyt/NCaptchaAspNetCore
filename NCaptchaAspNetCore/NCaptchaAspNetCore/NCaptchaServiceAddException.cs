using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nololiyt.NCaptchaExtensions.AspNetCore
{

    [Serializable]
    public class NCaptchaServiceAddException : Exception
    {
        public NCaptchaServiceAddException() { }
        public NCaptchaServiceAddException(string message) : base(message) { }
        public NCaptchaServiceAddException(string message, Exception inner) : base(message, inner) { }
        protected NCaptchaServiceAddException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
