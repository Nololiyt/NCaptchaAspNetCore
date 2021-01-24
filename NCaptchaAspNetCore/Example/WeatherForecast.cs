using System;

namespace Example
{
    public class WeatherForecast
    {
        public enum ResultCode
        {
            Success = 0,
            NeedTicket = 1
        }
        public ResultCode Code { get; set; }

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(this.TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}
