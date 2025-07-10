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
        private const string ApiKey = "2078b89f9c6821322283cad0f4066630";
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

            var weather = doc.RootElement.GetProperty("weather")[0];
            string description = weather.GetProperty("description").GetString();
            string icon = weather.GetProperty("icon").GetString();
            double temp = doc.RootElement.GetProperty("main").GetProperty("temp").GetDouble();
            string cityName = doc.RootElement.GetProperty("name").GetString();

            return new WeatherInfo
            {
                Description = description,
                Temperature = temp,
                Icon = icon,
                City = cityName
            };
        }
    }
}
