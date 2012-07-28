using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeChange
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person[] pers = new Person[2] {
            new Person{Name="seasun",Age=25},
              new Person{Name="candy",Age=24}
            };
            foreach (Person p in pers)
            {
                Console.WriteLine("姓名：{0}，年龄：{1}", p.Name, p.Age);
            }
            Console.Read();
        }
    }
}
