using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObserverPattern
{
    public class WeatherChangeEventArgs : EventArgs
    {
        public Weather Weather { get; set; }

        public WeatherChangeEventArgs(Weather weather)
        {
            this.Weather = weather;
        }
    }
}
