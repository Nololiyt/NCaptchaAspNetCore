using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nololiyt.Captcha.Interfaces;
using Nololiyt.Captcha.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CaptchaController : ControllerBase
    {
        private readonly ICaptchaFactory<Bitmap, string> captchaFactory;

        public CaptchaController(
            ILogger<WeatherForecastController> logger,
            ICaptchaFactory<Bitmap, string> captchaFactory)
        {
            this.captchaFactory = captchaFactory;
        }

        [HttpGet]
        public async Task<KeyValuePair<string, byte[]>> New()
        {
            var r = await this.captchaFactory.GenerateNewAsync().ConfigureAwait(false);
            using var memory = new MemoryStream();
            using (r.Display)
                r.Display.Save(memory, ImageFormat.Png);
            return new KeyValuePair<string, byte[]>(r.Id, memory.ToArray());
        }

        [HttpPost]
        public async Task<string> GetTicket(StringPair idAndAnswer)
        {
            return await this.captchaFactory.VerifyAndGetTicketAsync(idAndAnswer.Key, idAndAnswer.Value)
                .ConfigureAwait(false);
        }
    }
}
