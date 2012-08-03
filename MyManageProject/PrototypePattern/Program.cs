using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace PrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Resume one = new Resume("seasun", 26, "memego");
            ShowResume(one);
            ShowResume((Resume)one.Clone());
            Console.Read();
        }

        private static void ShowResume(Resume resume)
        {
            var properties = typeof(Resume).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var property in properties)
            {
                Console.WriteLine("{0} is {1}", property.Name, property.GetValue(resume, null));
            }
            Console.WriteLine("**************************************************************");
        }
    }
}
