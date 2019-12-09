using System;
using System.Collections.Generic;

namespace AccuWeatherCoreAPI.Model
{
    public partial class CityName
    {
        public CityName()
        {
            CurrentWeatherData = new HashSet<CurrentWeatherData>();
        }

        public long CityNameId { get; set; }
        public string CityName1 { get; set; }

        public virtual ICollection<CurrentWeatherData> CurrentWeatherData { get; set; }
    }
}
