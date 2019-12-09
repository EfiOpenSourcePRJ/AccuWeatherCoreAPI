using AccuWeatherCoreAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AccuWeatherCoreAPI.DataProviders
{

    public interface IAccuWeatherDataProvider
    {
        object GetCityDataByCityID(int cityID);
    }
    public class AccuWeatherDataProvider: IAccuWeatherDataProvider
    {
        public AccuWeatherDataProvider(AccuWeatherContext dBContext)
        {
           this.dBContext = dBContext;
        }

        public AccuWeatherContext dBContext { get; }

        public object GetCityDataByCityID(int cityID)
        {

            //var data = dBContext.Database.ExecuteSqlCommand("GetWeatherDataByCityID @p0", parameters: cityID );

           var data = from weatherData in dBContext.Set<CurrentWeatherData>()
            join weatherType in dBContext.Set<WeatherTypes>()
                on weatherData.WeatherTypeId equals weatherType.WeatherTypeId
               select new { weatherData.Celcius, weatherType.WeatherTypeName };
            return data;
            
        }
    }
}
