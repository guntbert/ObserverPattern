using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    class SampleData
    {
        private static int[] sampleTemps = new int[] { 61, 48, 41, 48, 50, 48, 46, 43 };
        private static string[] sampleCities = new string[] { "37203", "37203", "37027", "37203", "37027", "37027", "37203", "37027" };

        public static IEnumerable<Weather> getNext()
        {
            for (int i = 0; i < sampleTemps.Length; i++)
            {
                Weather w = new Weather();
                w.City = sampleCities[i];
                w.Temp = sampleTemps[i];
                yield return w;
            }
        }
    }
}
