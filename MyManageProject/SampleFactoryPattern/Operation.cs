using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleFactoryPattern
{
    public abstract class Operation
    {
        public double numberA { get; set; }
        public double numberB { get; set; }
        protected Operation() { }
        protected Operation(double a, double b)
        {
            this.numberA = a;
            this.numberB = b;
        }
        public abstract double GetResult(double a, double b);
    }
}
