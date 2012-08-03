using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proxy
{
    class MathProxy : IMath
    {

        #region IMath 成员

        public int Add(int a, int b)
        {
            MathServer math = new MathServer();
            return math.Add(a, b);
        }

        #endregion
    }
}
