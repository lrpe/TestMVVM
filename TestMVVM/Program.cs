using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TestMVVM.ViewModels;

namespace TestMVVM
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            });

            builder.Services.AddScoped<IWeatherForecastViewModel, WeatherForecastViewModel>();
            builder.Services.AddScoped<ICounterViewModel, CounterViewModel>();
            builder.Services.AddScoped<IToDoViewModel, ToDoViewModel>();

            await builder.Build().RunAsync();
        }
    }
}
