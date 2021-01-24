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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Example", Version = "v1" });
            });

            services.AddNCaptcha<Bitmap, string>((options) =>
            {
                options.Factory = new ImageCaptchaFactory(
                    new GuidDictionaryStringAnswerSaver(new TimeSpan(0, 10, 0)),
                    new GuidDictionaryTicketFactory(new TimeSpan(0, 10, 0)),
                    new ImageCaptchaFactory.Settings(), true);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
