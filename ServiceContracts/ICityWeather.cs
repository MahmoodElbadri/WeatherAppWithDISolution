using Models;

namespace ServiceContracts;

public interface ICityWeather
{
    List<CityWeather> GetCityWeathers();
    CityWeather GetWeather(string cityCode);
}