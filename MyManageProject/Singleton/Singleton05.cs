using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singleton
{
    /// <summary>
    /// (第五種)延迟加载的单例模式，利用Lazy&lt;T&gt;
    /// <para>Lazy&lt;T&gt;默认的设置就是线程安全</para>
    ///  </summary>
    public sealed class Singleton05
    {
        //這樣寫會有問題，會提示沒有公共的无参构造函数(我：细想一下就知道，Lazy访问不了Singleton05类的私有构造函数)
        //private readonly static Lazy<Singleton05> me = new Lazy<Singleton05>();
        private static readonly Lazy<Singleton05> me = new Lazy<Singleton05>(() => new Singleton05());
        private string time = string.Empty;
        //就是不讓外面實例化
        private Singleton05()
        {
            time = DateTime.Now.Ticks.ToString();
        }

        public static Singleton05 Instantiation
        {
            get
            {
                return me.Value;
            }
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("{0} : {1}", this.Name, time);
        }
    }
}
