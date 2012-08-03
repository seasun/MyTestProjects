using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethodPattern.Factory
{
    class NPowerFactory : IFactory
    {
        #region IFactory 成员

        public Operation Init()
        {
            return new NPowerOperation();
        }

        #endregion
    }
}
