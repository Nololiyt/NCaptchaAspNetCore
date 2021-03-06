﻿using Microsoft.AspNetCore.Mvc;
using Nololiyt.Captcha.Interfaces;
using System;
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

#warning Tip 4: Ticket Factory Only
        // A ticket factory alone is enough to verify tickets.
        // You don't need a captcha factory in your service controllers. 
        private readonly ITicketFactory ticketFactory;

        public WeatherForecastController(ITicketFactory ticketFactory)
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
