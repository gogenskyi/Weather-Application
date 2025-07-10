using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WasylWeather.Models;

namespace WasylWeather.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {

        private readonly APIRequester request = new();
        private string _city;
        private string _weatherText;
        private string _weatherIconUrl;
        private string _location;
        public string WeatherIconUrl
        {
            get => _weatherIconUrl;
            set { _weatherIconUrl = value; OnPropertyChanged(); }
        }

        public string Location
        {
            get => _location;
            set { _location = value; OnPropertyChanged(); }
        }

        public string City
        {
            get => _city;
            set { _city = value; OnPropertyChanged(); }
        }
        public string WeatherText
        {
            get => _weatherText;
            set { _weatherText = value; OnPropertyChanged(); }
        }
        public ICommand GetWeatherCommand { get; }
        public MainViewModel()
        {
            GetWeatherCommand = new RelayCommand(async _ => await LoadWeatherAsync());
        }

        private async Task LoadWeatherAsync()
        {
            if (string.IsNullOrWhiteSpace(City))
            {
                WeatherText = "Введіть назву міста.";
                return;
            }

            var weather = await request.GetWeatherAsync(City);

            if (weather == null)
            {
                WeatherText = "Не вдалося отримати дані.";
                return;
            }

            WeatherText = $"Погода: {weather.Description}\nТемпература: {weather.Temperature:F1}°C";
            WeatherIconUrl = $"http://openweathermap.org/img/wn/{weather.Icon}@2x.png";
            Location = weather.City;
        }





        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
