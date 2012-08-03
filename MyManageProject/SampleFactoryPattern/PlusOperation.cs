using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleFactoryPattern
{
    class PlusOperation : Operation
    {
        public PlusOperation() { }
        public PlusOperation(double a, double b) : base(a, b) { }

        public override double GetResult(double numberA, double numberB)
        {
            return numberA + numberB;
        }
    }
}
