using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatePattern
{
    class Low : TemperatureState
    {
        internal override void Up()
        {
            Console.WriteLine("低温");
        }
    }
}
