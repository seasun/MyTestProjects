using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethodPattern
{
    class PlusOperation : Operation
    {
        public override double GetResult(double numberA, double numberB)
        {
            return numberA + numberB;
        }
    }
}
