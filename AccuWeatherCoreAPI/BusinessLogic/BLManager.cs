using AccuWeatherCoreAPI.DataProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccuWeatherCoreAPI.BusinessLogic
{
    public interface IBLManager
    {
        object GetCityDataByCityID(int cityID);
    }
    public class BLManager : IBLManager
    {
        public IAccuWeatherDataProvider DataProvider { get; }
        public BLManager(IAccuWeatherDataProvider  dataProvider)
        {
            DataProvider = dataProvider;
        }

        

        public object GetCityDataByCityID(int cityID)
        {
            return DataProvider.GetCityDataByCityID(cityID);
        }
    }
}
