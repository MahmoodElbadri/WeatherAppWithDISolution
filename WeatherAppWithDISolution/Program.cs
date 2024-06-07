
using Models;
using ServiceContracts;
using Services;

namespace WeatherAppWithDISolution;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services.AddSingleton<ICityWeather, CityWeatherService>(); 
        var app = builder.Build();

        app.UseStaticFiles();
        app.UseRouting();
        app.MapControllers();

        app.Run();
    }
}