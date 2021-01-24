using Microsoft.Extensions.DependencyInjection;
using System;

namespace Nololiyt.NCaptchaExtensions.AspNetCore
{
    /// <summary>
    /// Extensions for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add a NCaptcha service.
        /// </summary>
        /// <typeparam name="TCaptchaDisplay">Type of captcha display.</typeparam>
        /// <typeparam name="TAnswer">Type of captcha answer.</typeparam>
        /// <param name="services">The service collection.</param>
        /// <param name="setupAction">The setup action.</param>
        /// <returns>The service collection.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="services"/> or <paramref name="setupAction"/> is <c>null</c>.</exception>
        /// <exception cref="NCaptchaServiceAddException">Something is invalid.</exception>
        public static IServiceCollection AddNCaptcha<TCaptchaDisplay, TAnswer>(
            this IServiceCollection services,
            Action<NCaptchaOptions<TCaptchaDisplay, TAnswer>> setupAction)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (setupAction == null)
                throw new ArgumentNullException(nameof(setupAction));

            var options = new NCaptchaOptions<TCaptchaDisplay, TAnswer>();
            setupAction(options);

            options.CheckAndThrow();
            services.AddSingleton(options.Factory.TicketFactory);
            services.AddSingleton(options.Factory);
            return services;
        }
    }
}
