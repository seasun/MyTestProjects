using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            NotifyObject staff1 = new NotifyObject("seasun");
            NotifyObject staff2 = new NotifyObject("dong");
            Observer miss = new Observer(3);
            miss.Subscribe(staff1);
            miss.Subscribe(staff2);

            Console.Read();
        }
    }
}
