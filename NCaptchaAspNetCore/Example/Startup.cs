using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Nololiyt.Captcha.AnswerSavers.InMemoryGuidDictionary;
using Nololiyt.Captcha.CaptchaFactories.Image;
using Nololiyt.Captcha.TicketFactories.InMemoryGuidDictionary;
using Nololiyt.NCaptchaExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Example
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Example", Version = "v1" });
            });

#warning A tip here: Add the service here.
            services.AddNCaptcha<Bitmap, string>((options) =>
            {
                // You can customize the factories and the saver.

                options.Factory = new ImageCaptchaFactory(
                    // ImageCaptchaFactory: In Nololiyt.Captcha.CaptchaFactories.Image
                    new GuidDictionaryStringAnswerSaver(new TimeSpan(0, 10, 0)),
                    // GuidDictionaryStringAnswerSaver: In Nololiyt.Captcha.AnswerSavers.InMemoryGuidDictionary
                    new GuidDictionaryTicketFactory(new TimeSpan(0, 10, 0)),
                    // GuidDictionaryTicketFactory: In Nololiyt.Captcha.TicketFactories.InMemoryGuidDictionary
                    new ImageCaptchaFactory.Settings(),
                    // Here we use the default settings.
                    true);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Example v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
