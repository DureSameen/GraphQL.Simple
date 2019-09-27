using System.Collections.Generic;

namespace QraphQLSimple.Data.Service
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> GetWeatherForeCast();
    }
}