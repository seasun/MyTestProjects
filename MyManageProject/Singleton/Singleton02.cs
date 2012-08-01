using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singleton
{
    /// <summary>
    /// 第二種單例實現，(雙[判斷]鎖)沒有線程安全問題
    /// </summary>
    public sealed class Singleton02
    {
        /*
         volatile 关键字指示一个字段可以由多个同时执行的线程修改。 声明为 volatile 的字段不受编译器优化（假定由单个线程访问）的限制。 
         * 这样可以确保该字段在任何时间呈现的都是最新的值。volatile 修饰符通常用于由多个线程访问但不使用 lock 语句对访问进行序列化的字段。
         */
        private volatile static Singleton02 me;
        private static object lockObj = new object();
        private string time = string.Empty;
        //就是不讓外面實例化
        private Singleton02()
        {
            time = DateTime.Now.Ticks.ToString();
        }

        public static Singleton02 Instantiation
        {
            get
            {
                if (me == null)
                {
                    lock (lockObj)//上鎖
                    {
                        if (me == null)
                            me = new Singleton02();
                    }

                }
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
