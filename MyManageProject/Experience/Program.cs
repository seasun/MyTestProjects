using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Experience
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(p_PropertyChanged);
            p.Name = "seasun";
            p.Name = "seasunK";
            Console.Read();
        }

        static void p_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Console.WriteLine("名稱已修改為{0}", ((Person)sender).Name);
        }
    }
}
