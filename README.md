

```markdown
# Weather Application

A simple ASP.NET Core MVC application to display weather information for various cities. The project is organized into three main projects: Models, Service, and Service Contracts.

## Projects

### 1. Models
This project contains the data models used in the application. The main model used is `CityWeather`.

#### CityWeather Model
```csharp
namespace Models
{
    public class CityWeather
    {
        public string CityUniqueCode { get; set; }
        public string CityName { get; set; }
        public DateTime DateAndTime { get; set; }
        public int TemperatureFahrenheit { get; set; }
    }
}
```

### 2. Service
This project contains the business logic for fetching and processing weather data.

#### CityWeatherService
```csharp
using ServiceContracts;
using Models;

namespace Services
{
    public class CityWeatherService : ICityWeather
    {
        private readonly List<CityWeather> cityWeathers;

        public CityWeatherService()
        {
            cityWeathers = new List<CityWeather>()
            {
                new CityWeather
                {
                    CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"), TemperatureFahrenheit = 33,
                },
                new CityWeather
                {
                    CityUniqueCode = "NYC", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"), TemperatureFahrenheit = 60
                },
                new CityWeather
                {
                    CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"), TemperatureFahrenheit = 82,
                }
            };
        }

        public List<CityWeather> GetCityWeathers()
        {
            return cityWeathers;
        }

        public CityWeather GetWeather(string cityCode)
        {
            if (cityCode == null)
            {
                return null;
            }
            CityWeather cityWeather = cityWeathers.Where(tmp => tmp.CityUniqueCode == cityCode).FirstOrDefault();
            return cityWeather;
        }
    }
}
```

### 3. Service Contracts
This project contains the interfaces for the services used in the application.

#### ICityWeather Interface
```csharp
using Models;

namespace ServiceContracts
{
    public interface ICityWeather
    {
        List<CityWeather> GetCityWeathers();
        CityWeather GetWeather(string cityCode);
    }
}
```

## Setup and Run

### Prerequisites
- .NET 8.0 SDK or later
- Visual Studio or any other C# compatible IDE

### Steps to Run

1. **Clone the repository**
    ```sh
    git clone https://github.com/yourusername/weather-app.git
    cd weather-app
    ```

2. **Build the solution**
    Open the solution in Visual Studio and build the project to restore the dependencies.

3. **Run the application**
    Press `F5` in Visual Studio or use the following command to run the application:
    ```sh
    dotnet run
    ```

4. **View the application**
    Open a web browser and navigate to `https://localhost:5001` to view the weather application.

### Usage
- The home page displays a list of cities with their current weather.
- Click on the "Details" link to view more information about the weather in a specific city.

### Example Views

#### Home Page View
```csharp
@model IEnumerable<CityWeather>

@{
    ViewBag.Title = "Home";
}

@functions {
    string GetCssClassByFahrenheit(int TemperatureFahrenheit)
    {
        return TemperatureFahrenheit switch
        {
            < 44 => "blue-back",
            >= 44 and < 75 => "green-back",
            >= 75 => "orange-back",
            _ => ""
        };
    }
}

<div class="margin-top-200 margin-left">
    <div class="flex">
        @foreach (CityWeather city in Model)
        {
            <div class="box cursor-pointer w-30 @GetCssClassByFahrenheit(city.TemperatureFahrenheit)">
                <div class="flex-borderless">
                    <div class="w-50">
                        <h2>@city.CityName</h2>
                        <h4 class="text-dark-grey">@city.DateAndTime.ToString("hh:mm tt")</h4>
                        <a href="~/weather/@city.CityUniqueCode" class="margin-top">Details</a>
                    </div>
                    <div class="w-50 border-left">
                        <h1 class="margin-left">@city.TemperatureFahrenheit <sup class="text-grey">&#8457</sup></h1>
                    </div>
                </div>
            </div>
        }
    </div>
</div>
```

#### City Weather Detail View
```csharp
@model CityWeather

@{
    ViewBag.Title = Model.CityName;
}

@if (Model != null)
{
    <div class="box cursor-pointer w-30 margin-auto margin-top-200">
        <div class="flex-borderless">
            <div class="w-50">
                <h2>@Model.CityName</h2>
                <h4 class="text-grey">@Model.DateAndTime.ToString("dd MMM yyyy")</h4>
                <h4 class="text-grey">@Model.DateAndTime.ToString("hh:mm tt")</h4>
            </div>
            <div class="w-50 border-left">
                <h1 class="margin-left">@Model.TemperatureFahrenheit <sup class="text-grey">&#8457</sup></h1>
            </div>
        </div>
    </div>

    <div class="text-center">
        <a href="~/">Back to Weather Home Page</a>
    </div>
}
else
{
    <h3>City Code is not valid.</h3>
}
```
