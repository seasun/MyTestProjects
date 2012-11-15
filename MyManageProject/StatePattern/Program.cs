using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatePattern
{
    class Program
    {
        /* 状态模式，其实就是减少判断分支 */
        static void Main(string[] args)
        {
            Weather weather = new Weather(new Low());
            weather.Up();
            weather.Up();
            weather.Up();
            Console.Read();
        }
    }
}
