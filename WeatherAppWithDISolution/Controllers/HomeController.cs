using Microsoft.AspNetCore.Mvc;
using Models;
using ServiceContracts;

namespace WeatherAppWithDISolution.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICityWeather _cityWeather;
        public HomeController(ICityWeather cityWeather)
        {
             _cityWeather = cityWeather;
        }

        [Route("/")]
        public IActionResult Index()
        {
            List<CityWeather> cities = _cityWeather.GetCityWeathers();
            Response.StatusCode = 200;

            return View(cities);
        }
        [Route("/weather/{cityCode?}")]
        public IActionResult City(string cityCode)
        {
            if (_cityWeather.GetWeather(cityCode) == null) {
                Response.StatusCode = 400;
                return View();
            }
            else {
                CityWeather? cityWeather = 
                    _cityWeather.GetWeather(cityCode);
                return View(cityWeather);
            }
        }

    }
}
