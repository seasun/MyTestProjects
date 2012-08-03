using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethodPattern
{
    class NPowerOperation : Operation
    {
        /// <summary>
        /// 返回a的b次方减1
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public override double GetResult(double a, double b)
        {
            return Math.Pow(a, b) - 1;
        }
    }
}
