using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adapter
{
    /*  http://www.cnblogs.com/terrylee/archive/2006/02/18/333000.html
     * 适配器模式把一个类的接口变换成客户端所期待的另一种接口，从而使原本接口不匹配而无法在一起工作的两个类能够在一起工作。
     * 有一种“亡羊补牢”的坏味道
     */
    class Program
    {
        static void Main(string[] args)
        {
            IVoltage adapter = new Adapter();
            string _voltage = adapter.GetCnVoltage();
            Console.WriteLine("美國佬電壓系{0}", _voltage);
            Console.Read();
        }
    }
}
