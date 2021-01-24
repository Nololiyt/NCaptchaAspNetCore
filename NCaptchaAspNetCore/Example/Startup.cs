using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Nololiyt.Captcha.AnswerSavers.InMemoryGuidDictionary;
using Nololiyt.Captcha.CaptchaFactories.Image;
using Nololiyt.Captcha.TicketFactories.InMemoryGuidDictionary;
using Nololiyt.NCaptchaExtensions.AspNetCore;
using System.Drawing;

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

#warning Tip 1: Add Service
            // Here shows how to read 'appsettings.json' to add the service.
            // You can customize the factories and the saver.
            var settings = this.Configuration.GetSection("NCaptcha").Get<NCaptchaSettings>();
            var factorySettings = settings.AllowedCharacters == null
                ? new ImageCaptchaFactory.Settings()
                : new ImageCaptchaFactory.Settings() {
                    AllowedCharacters = settings.AllowedCharacters
                };
            services.AddNCaptcha<Bitmap, string>((options) =>
            {
                options.Factory = new ImageCaptchaFactory(
                    new GuidDictionaryStringAnswerSaver(settings.ConvertedAnswersLifeTime),
                    new GuidDictionaryTicketFactory(settings.ConvertedTicketsLifeTime),
                    settings: factorySettings, disposeSaverAndFactory: true);
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
