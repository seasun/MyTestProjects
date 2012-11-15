using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatePattern
{
    class Normal : TemperatureState
    {
        public override void Up(Weather weather)
        {
            Console.WriteLine("正常");
            weather.temperatureState = new Hot();
        }
    }
}
