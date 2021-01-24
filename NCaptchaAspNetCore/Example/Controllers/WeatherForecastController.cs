using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nololiyt.Captcha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ITicketFactory ticketFactory;

        public WeatherForecastController(
            ITicketFactory ticketFactory)
        {
            this.ticketFactory = ticketFactory;
        }

        [HttpGet]
        public async Task<WeatherForecast> Get(string ticket)
        {
            if (!await this.ticketFactory.VerifyAsync(ticket).ConfigureAwait(false))
                return new WeatherForecast {
                    Code = WeatherForecast.ResultCode.NeedTicket
                };
            var rng = new Random();
            return new WeatherForecast {
                Code = WeatherForecast.ResultCode.Success,
                Date = DateTime.Now.AddDays(rng.Next(-10, 10)),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            };
        }
    }
}
