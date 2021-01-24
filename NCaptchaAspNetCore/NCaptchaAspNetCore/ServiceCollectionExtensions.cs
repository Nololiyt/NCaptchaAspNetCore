using Microsoft.Extensions.DependencyInjection;
using Nololiyt.Captcha.Interfaces;
using System;

namespace Nololiyt.NCaptchaExtensions.AspNetCore
{
    public static class ServiceCollectionExtensions
    {
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
