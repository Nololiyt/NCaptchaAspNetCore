using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nololiyt.NCaptchaExtensions.AspNetCore
{
    /// <summary>
    /// Represents exceptions occur when adding a NCaptcha service.
    /// </summary>
    [Serializable]
    public class NCaptchaServiceAddException : Exception
    {
        /// <summary>
        /// Initialize a new instance of <see cref="NCaptchaServiceAddException"/>.
        /// </summary>
        public NCaptchaServiceAddException() { }
        /// <summary>
        /// Initialize a new instance of <see cref="NCaptchaServiceAddException"/>.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public NCaptchaServiceAddException(string? message) : base(message) { }
        /// <summary>
        /// Initialize a new instance of <see cref="NCaptchaServiceAddException"/>.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public NCaptchaServiceAddException(string? message, Exception inner) : base(message, inner) { }
        /// <summary>
        /// Initialize a new instance of <see cref="NCaptchaServiceAddException"/>.
        /// </summary>
        /// <param name="info">The System.Runtime.Serialization.SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The System.Runtime.Serialization.StreamingContext that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/> is null.</exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">The class name is null or <see cref="Exception.HResult"/> is zero (<c>0</c>).</exception>
        protected NCaptchaServiceAddException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
