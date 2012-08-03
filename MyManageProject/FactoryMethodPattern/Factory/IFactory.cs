using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethodPattern.Factory
{
    interface IFactory
    {
        Operation Init();
    }
}
