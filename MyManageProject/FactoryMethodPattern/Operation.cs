using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethodPattern
{
    public abstract class Operation
    {
        public abstract double GetResult(double a, double b);
    }
}
