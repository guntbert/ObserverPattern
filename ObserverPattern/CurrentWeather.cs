using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObserverPattern
{
    public class CurrentWeather
    {
        private Weather weather;
        public Weather Weather
        {
            get { return weather; }
            set
            {
                weather = value;
                this.OnWeatherChange(new WeatherChangeEventArgs(this.weather));
            }
        }
        public event EventHandler<WeatherChangeEventArgs> WeatherChange;

        protected virtual void OnWeatherChange(WeatherChangeEventArgs e)
        {
            if (WeatherChange != null)
            {
                WeatherChange(this, e);
            }
        }
    }
}
