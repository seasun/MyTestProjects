using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proxy
{
    interface IMath
    {
        /// <summary>
        /// 兩數相加
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        int Add(int a, int b);
    }
}
