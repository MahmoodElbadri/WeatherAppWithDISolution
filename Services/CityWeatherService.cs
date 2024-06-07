using ServiceContracts;
using Models;

namespace Services;

public class CityWeatherService : ICityWeather
{
    private readonly List<CityWeather> cityWeathers;
    public CityWeatherService()
    {
        cityWeathers = new List<CityWeather>()
        {
            new CityWeather
            {
                CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime( "2030-01-01 8:00"),  TemperatureFahrenheit = 33,
            },
            new CityWeather
            {
                CityUniqueCode = "NYC", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"),  TemperatureFahrenheit = 60
            },
            new CityWeather
            {
                CityUniqueCode = "PAR", CityName = "Paris", DateAndTime =Convert.ToDateTime( "2030-01-01 9:00"),  TemperatureFahrenheit = 82,
            }
        };
    }

    public List<CityWeather> GetCityWeathers()
    {
        return cityWeathers;
    }

    public CityWeather GetWeather(string cityCode)
    {
        if(cityCode == null)
        {
            return null;
        }
        CityWeather cityWeather = cityWeathers.Where(tmp=>tmp.CityUniqueCode == cityCode).FirstOrDefault();
        return cityWeather;
    }
}