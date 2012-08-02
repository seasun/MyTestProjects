using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            IVoltage adapter = new Adapter();
            string _voltage = adapter.Voltage();
            Console.WriteLine("美國佬電壓系{0}", _voltage);
            Console.Read();
        }
    }
}
