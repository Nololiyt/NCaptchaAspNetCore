using Microsoft.AspNetCore.Mvc;
using Nololiyt.Captcha.Interfaces;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

namespace Example.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CaptchaController : ControllerBase
    {
#warning Tip 2: Captcha Factory Here
        // You need a captcha factory to produce captcha here.
        private readonly ICaptchaFactory<Bitmap, string> captchaFactory;

        public CaptchaController(ICaptchaFactory<Bitmap, string> captchaFactory)
        {
            this.captchaFactory = captchaFactory;
        }

        [HttpGet]
        public async Task<KeyValuePair<string, byte[]>> New()
        {
#warning Tip 3: Conversion Logics Needed
            // Response is in png format currently because of the conversion logics here.
            // And different captcha factories may also need different conversion logics.
            var r = await this.captchaFactory.GenerateNewAsync().ConfigureAwait(false);
            using var memory = new MemoryStream();
            using (r.Display)
                r.Display.Save(memory, ImageFormat.Png);
            return new KeyValuePair<string, byte[]>(r.Id, memory.ToArray());
        }

        [HttpPost]
        public async Task<string?> GetTicket([FromBody] StringPair idAndAnswer)
        {
            return await this.captchaFactory.VerifyAndGetTicketAsync(idAndAnswer.Key, idAndAnswer.Value)
                .ConfigureAwait(false);
        }
    }
}
