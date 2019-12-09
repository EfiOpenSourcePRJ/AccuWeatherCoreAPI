using System;
using System.Collections.Generic;

namespace AccuWeatherCoreAPI.Model
{
    public partial class CurrentWeatherData
    {
        public long CurrentWeatherId { get; set; }
        public long WeatherTypeId { get; set; }
        public long CityId { get; set; }
        public int Celcius { get; set; }
        public DateTime UpdateTime { get; set; }

        public virtual CityName City { get; set; }
        public virtual WeatherTypes WeatherType { get; set; }
    }
}
