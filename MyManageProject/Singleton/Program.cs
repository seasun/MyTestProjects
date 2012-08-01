using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test1();
            //Test2();
            //Test3();
            //Test4();
            //Test5();
            Test6();
            Console.Read();
        }

        //普通多次調用
        private static void Test1()
        {
            int i = 0;
            while (i < 10)
            {
                Singleton01 s01 = Singleton01.Instantiation;
                Console.WriteLine(s01.ToString());
                i++;
            }
        }

        //多線程調用(比較難測試到線程安全問題)
        private static void Test2()
        {
            Thread t1 = new Thread((m) =>
            {
                Singleton01 s01 = Singleton01.Instantiation;
                s01.Name = "Thread 1";
                Console.WriteLine(s01.ToString());
            });

            Thread t2 = new Thread((m) =>
            {
                Singleton01 s01 = Singleton01.Instantiation;
                s01.Name = "Thread 2";
                Console.WriteLine(s01.ToString());
            });

            Thread t3 = new Thread((m) =>
            {
                Singleton01 s01 = Singleton01.Instantiation;
                s01.Name = "Thread 3";
                Console.WriteLine(s01.ToString());
            });
            t1.Start();
            t2.Start();
            t3.Start();
        }

        //普通多次調用
        private static void Test3()
        {
            int i = 0;
            while (i < 10)
            {
                Singleton03 s01 = Singleton03.Instantiation;
                Console.WriteLine(s01.ToString());
                i++;
            }
        }

        //多線程線程安全測試
        private static void Test4()
        {
            Thread t1 = new Thread((m) =>
            {
                Singleton02 s01 = Singleton02.Instantiation;
                s01.Name = "Thread 1";
                Console.WriteLine(s01.ToString());
            });

            Thread t2 = new Thread((m) =>
            {
                Singleton02 s01 = Singleton02.Instantiation;
                //s01.Name = "Thread 2";
                Console.WriteLine(s01.ToString());
            });

            Thread t3 = new Thread((m) =>
            {
                Singleton02 s01 = Singleton02.Instantiation;
                s01.Name = "Thread 3";
                Console.WriteLine(s01.ToString());
            });
            t1.Start();
            t2.Start();
            t3.Start();
        }

        //普通多次調用
        private static void Test5()
        {
            int i = 0;
            while (i < 1)
            {
                Singleton04 s01 = Singleton04.Instantiation;
                Console.WriteLine(s01.ToString());
                i++;
            }
        }

        //普通多次調用
        private static void Test6()
        {
            int i = 0;
            while (i < 10)
            {
                Singleton05 s01 = Singleton05.Instantiation;
                Console.WriteLine(s01.ToString());
                i++;
            }
        }
    }
}
