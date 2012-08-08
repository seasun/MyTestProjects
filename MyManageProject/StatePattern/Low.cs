using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatePattern
{
    class Low : TemperatureState
    {
        public override void Up(Weather weather)
        {
            Console.WriteLine("低温");
            weather.temperatureState = new Normal();
        }
    }
}
