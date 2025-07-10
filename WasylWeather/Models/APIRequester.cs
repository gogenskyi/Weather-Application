using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace WasylWeather.Models
{
    public class APIRequester
    {
        private const string ApiKey = "YOUR_API_KEY"; // заміни на свій ключ
        private readonly HttpClient _httpClient;

        public APIRequester()
        {
            _httpClient = new HttpClient();
        }

        public async Task<WeatherInfo> GetWeatherAsync(string city)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={ApiKey}&units=metric&lang=ua";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);

            string description = doc.RootElement.GetProperty("weather")[0].GetProperty("description").GetString();
            double temperature = doc.RootElement.GetProperty("main").GetProperty("temp").GetDouble();

            return new WeatherInfo
            {
                Description = description,
                Temperature = temperature
            };
        }
    }
}
