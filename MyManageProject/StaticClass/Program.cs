using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StaticClass
{
    class A
    {
        public static int X = A.X + 1;
        static A()
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(A.X);
            Console.Read();
        }
    }

    /*
     
	class A
	{
		public static int X;
		static A()
		{
			X = B.Y + 1;
		}
	}
	class B
	{
		public static int Y = A.X + 1;
		static B()
		{
		}
		static void Main()
		{
			Console.WriteLine("X={0}, Y={1}", A.X, B.Y);
		}
	}
     */
}
