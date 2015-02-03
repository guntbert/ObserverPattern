using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObserverPattern
{
    public class NashvilleMonitor
    {
        public Weather currentCityWeather = null;
        public NashvilleMonitor(CurrentWeather cw)
        {
            cw.WeatherChange += new EventHandler<WeatherChangeEventArgs>(cw_WeatherChange);
        }

        void cw_WeatherChange(object sender, WeatherChangeEventArgs e)
        {
            CheckFilter(e.Weather);
        }

        public void CheckFilter(Weather value)
        {

            if (value.City == "37203" && value.Temp > 1)
            {
                Console.WriteLine("Nashville has a new temperature of {0} degrees fahrenheit", value.Temp);
                currentCityWeather = value;
            }  
        }
    }
}
