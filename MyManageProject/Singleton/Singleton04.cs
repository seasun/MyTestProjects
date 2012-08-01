using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singleton
{
    /// <summary>
    /// (第四種)延迟加载的单例模式(我：斷點跟蹤與Singleton03並無二樣)
    /// </summary>
    public sealed class Singleton04
    {
        private readonly static Singleton04 me = new Singleton04();
        private string time = string.Empty;
        //就是不讓外面實例化
        private Singleton04()
        {
            time = DateTime.Now.Ticks.ToString();
        }

        // 声明静态构造函数就是为了删除IL里的BeforeFieldInit标记(詳看Singleton03)
        // 以防静态自动在使用之前被初始化
        static Singleton04()
        {

        }

        public static Singleton04 Instantiation
        {
            get
            {
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
