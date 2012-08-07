using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IEnumerableExperience
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test1();
            //Test2();
            Test3();
            Console.Read();
        }

        /// <summary>
        /// 普通实体数组
        /// </summary>
        private static void Test1()
        {
            Person[] persons = new Person[2];
            persons[0] = new Person { Name = "seasun", Age = 26 };
            persons[1] = new Person { Name = "candy", Age = 25 };
            foreach (var p in persons)
            {
                Console.WriteLine("{0} is {1}", p.Name, p.Age);
            }
        }

        /// <summary>
        /// 迭代
        /// </summary>
        private static void Test2()
        {
            foreach (Person p in Classes.GetClasses())
            {
                Console.WriteLine("{0} is {1}", p.Name, p.Age);
            }
        }

        /// <summary>
        /// 实现IEnumerable, IEnumerator
        /// </summary>
        private static void Test3()
        {
            Person[] persons = new Person[3];
            persons[0] = new Person { Name = "seasun", Age = 26 };
            persons[1] = new Person { Name = "candy", Age = 25 };
            persons[2] = new Person { Name = "qing", Age = 27 };
            //People people = new People(persons);
            foreach (Person p in new People(persons))
            {
                Console.WriteLine("{0} is {1}", p.Name, p.Age);
            }
        }
    }
}
