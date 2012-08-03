using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethodPattern.Factory
{
    class PlusFactory : IFactory
    {

        #region IFactory 成员

        public Operation Init()
        {
            return new PlusOperation();
        }

        #endregion
    }
}
