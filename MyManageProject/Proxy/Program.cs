using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proxy
{
    /*在客户程序和目标对象之间增加一层中间层，让代理对象来代替目标对象打点一切。*/
    class Program
    {
        static void Main(string[] args)
        {
            MathProxy math = new MathProxy();
            Console.WriteLine(math.Add(1, 2));
            Console.Read();
        }
    }
}
