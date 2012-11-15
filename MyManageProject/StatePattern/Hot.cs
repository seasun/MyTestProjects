using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatePattern
{
    class Hot : TemperatureState
    {
        public override void Up(Weather weather)
        {
            Console.WriteLine("高温");
        }
    }
}
