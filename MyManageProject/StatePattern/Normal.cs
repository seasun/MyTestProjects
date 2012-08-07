using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatePattern
{
    class Normal : TemperatureState
    {
        internal override void Up()
        {
            Console.WriteLine("正常");
        }
    }
}
