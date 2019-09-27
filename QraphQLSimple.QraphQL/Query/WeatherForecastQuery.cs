using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;
using QraphQLSimple.Data.Service;
using QraphQLSimple.QraphQL.Types;

namespace QraphQLSimple.QraphQL.Query
{
    public class WeatherForecastQuery : ObjectGraphType
    {

        public WeatherForecastQuery(IWeatherForecastService service)
        {
            Field<ListGraphType<WeatherForcastType>>(
                "forecast"
                , resolve: context => service.GetWeatherForeCast()
                );
        
        }
    }
}
