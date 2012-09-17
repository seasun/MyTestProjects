using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StaticClass
{
    public class Parent
    {
        public void write()
        {
            Console.WriteLine("dddddd");
        }
    }

    class A
    {
        private static Parent _parent;
        public A()
        {
            if (_parent == null)
                _parent = new Parent();
            _parent.write();
        }

        //public static int X = A.X + 1;
        //static A()
        //{

        //}
    }

    class C
    {
        private static Parent _parent;
        public C()
        {
            // _parent = new Parent();
            _parent.write();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine(A.X);
            A a = new A();
            A a2 = new A();
            C c = new C();
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
