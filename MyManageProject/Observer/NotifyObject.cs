using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Observer
{
    class NotifyObject
    {
        public NotifyObject(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public virtual void Receive(object sender, ComebackEventArgs e)
        {
            Console.WriteLine("老板回來了，{0}快坐好！", this.Name);
        }
    }
}
