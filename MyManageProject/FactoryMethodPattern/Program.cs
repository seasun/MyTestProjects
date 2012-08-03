using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FactoryMethodPattern.Factory;

namespace FactoryMethodPattern
{
    /* 工厂方法模式；其实就是去掉“简单工厂模式”中违反“开放-封闭原则”的缺点。就是对创建对象的封装而已，还有解耦作用
     * 将原本由Factory工厂类中的对象创建判断交由客户端来做判断
     */
    class Program
    {
        static void Main(string[] args)
        {
            IFactory plus = new PlusFactory();
            Operation opera = plus.Init();
            Console.WriteLine(opera.GetResult(10, 20.2));
            plus = new SubFactory();
            opera = plus.Init();
            Console.WriteLine(opera.GetResult(100, 20.2));
            Console.WriteLine("--------------------- 以下是一个N次方功能的扩展 -----------------");
            Console.WriteLine("添加一个继承Operation抽象类的NPowerOperation子类并实现求N次方的功能");
            Console.WriteLine("再添加一个实现IFactory接口的NPowerFactory工厂类，其目的是实例化NPowerOperation类");
            plus = new NPowerFactory();
            opera = plus.Init();
            Console.WriteLine("效果：2的4次方减1是 {0}", opera.GetResult(2, 4));
            Console.Read();
        }
    }
}
