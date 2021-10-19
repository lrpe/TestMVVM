using System.Collections.Generic;
using System.Threading.Tasks;
using TestMVVM.Models;
using TestMVVM.Shared.ViewModels;

namespace TestMVVM.ViewModels
{
    public interface IWeatherForecastViewModel : IViewModel
    {
        List<WeatherForecast> WeatherForecast { get; set; }

        void DeleteWeatherForecast(WeatherForecast deletedWeatherForecast);
        Task FetchDataAsync();
    }
}