using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;

namespace QraphQLSimple.QraphQL.Types
{
   public class WeatherForcastType : ObjectGraphType<WeatherForecast>
    {
        public WeatherForcastType()
        {
            Field(t => t.Summary);
            Field(t => t.TemperatureC);
            Field(t => t.TemperatureF);
            Field(t => t.Date);
        }
    }
}
