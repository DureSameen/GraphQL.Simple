using System;
using System.Collections.Generic;
using System.Text;
using GraphQL;
using GraphQL.Types;
using QraphQLSimple.QraphQL.Query;

namespace QraphQLSimple.QraphQL.WeatherSchema
{
    public class WeatherForecastSchema :  Schema
    {
        public WeatherForecastSchema(IDependencyResolver resolver):base (resolver)
        {
            
            
            Query = resolver.Resolve<WeatherForecastQuery>();
        
        }

    }
}
