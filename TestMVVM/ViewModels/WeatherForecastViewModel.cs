using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TestMVVM.Models;
using TestMVVM.Shared.ViewModels;

namespace TestMVVM.ViewModels
{
    public class WeatherForecastViewModel : ViewModelBase, IWeatherForecastViewModel
    {
        private readonly HttpClient _httpClient;

        public WeatherForecastViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private List<WeatherForecast> weatherForecast;
        public List<WeatherForecast> WeatherForecast
        {
            get => weatherForecast;
            set
            {
                weatherForecast = value;
                OnPropertyChanged(nameof(WeatherForecast));
            }
        }

        public void DeleteWeatherForecast(WeatherForecast deletedWeatherForecast)
        {
            weatherForecast.Remove(deletedWeatherForecast);
        }

        public async Task FetchDataAsync()
        {
            WeatherForecast = await _httpClient.GetFromJsonAsync<List<WeatherForecast>>("sample-data/weather.json");
        }
    }
}
