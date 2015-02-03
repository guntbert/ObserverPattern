using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            CurrentWeather cw = new CurrentWeather();

            NashvilleMonitor nw = new NashvilleMonitor(cw);

            BrentwoodMonitor bw = new BrentwoodMonitor(cw);

            foreach (var s in SampleData.getNext())
            {
                cw.Weather = s;
            }

        }
    }
}
