using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleFactoryPattern
{
    /*简单工厂模式，没什么好说的*/
    class Program
    {
        static void Main(string[] args)
        {
            Factory factory = new Factory();
            Operation opera = factory.InitOperation("+");
            Console.WriteLine(opera.GetResult(10, 20.2));
            opera = factory.InitOperation("-");
            Console.WriteLine(opera.GetResult(.85, 20.2));

            opera = new PlusOperation(1, 2);
            Console.WriteLine(opera.numberB);
            Console.Read();
        }
    }
}
