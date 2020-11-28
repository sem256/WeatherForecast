using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WeatherForecast.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        static HttpClient client = new HttpClient();

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly string _apiKey;
        private readonly string _url;
        private readonly string _currentCity;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _apiKey = "342c76e803b4bc23dd8883b69715c105";
            _url = @"https://api.openweathermap.org/data/2.5/";
            _currentCity = "Kyiv";
        }

        [HttpGet]
        [Route("{city?}")]
        public async Task<string> Get(string city)
        {
            var param = $"weather?q={city ?? _currentCity}&appid={_apiKey}";
            var path = $"{_url}{param}";

            return await GetWeatheAsync(path);
        }

        async Task<string> GetWeatheAsync(string path)
        {
            string product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsStringAsync();
            }
            return product;
        }
    }
}
