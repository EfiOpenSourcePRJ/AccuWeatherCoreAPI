using System;
using System.Collections.Generic;

namespace AccuWeatherCoreAPI.Model
{
    public partial class WeatherTypes
    {
        public WeatherTypes()
        {
            CurrentWeatherData = new HashSet<CurrentWeatherData>();
        }

        public long WeatherTypeId { get; set; }
        public string WeatherTypeName { get; set; }

        public virtual ICollection<CurrentWeatherData> CurrentWeatherData { get; set; }
    }
}
