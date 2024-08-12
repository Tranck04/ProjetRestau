using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Modèle
{
    public static class TimeAdapter
    {
        private static readonly int timeFactor = 1000 * int.Parse(SettingsReader.ReadSettings("TimeFactor"));

        public static int GetAdaptedMilliseconds(int seconds)
        {
            return seconds * timeFactor;
        }
    }
}
