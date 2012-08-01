using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singleton
{
    /// <summary>
    /// 第一種單例實現，不過有線程安全問題
    /// </summary>
    public sealed class Singleton01
    {
        private static Singleton01 me;
        private string time = string.Empty;
        //就是不讓外面實例化
        private Singleton01()
        {
            time = DateTime.Now.Ticks.ToString();
        }

        public static Singleton01 Instantiation
        {
            get
            {
                if (me == null)
                    me = new Singleton01();
                return me;
            }
        }
        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("{0} : {1}", this.Name, time);
        }
    }
}
