using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleFactoryPattern
{
    class Factory
    {
        public Operation InitOperation(string _operator)
        {
            switch (_operator)
            {
                case "+":
                    return new PlusOperation();
                case "-":
                    return new SubductionOperation();
                default:
                    throw new Exception("没有此实例");
            }
        }
    }
}
