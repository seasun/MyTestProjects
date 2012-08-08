using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatePattern
{
    public abstract class TemperatureState
    {
        public abstract void Up(Weather weather);
    }
}
