using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singleton
{
    /// <summary>
    /// (第三種)最簡單的
    /// <para>标记类为sealed是好的，可以防止被繼承，然后在子类实例化（其實如果不標記sealed會編譯出錯，因為父類的無參構造函數是私有的，子類訪問不了），
    /// 使用在静态私有字段上通过new的形式，来保证在该类第一次被调用的时候创建实例，是不错的方式。</para>
    /// <para>但有一点需要注意的是，C#其实并不保证实例创建的时机，因为C#规范只是在IL里标记该静态字段是BeforeFieldInit，
    /// 也就是说静态字段可能在第一次被使用的时候创建，也可能你没使用了，它也帮你创建了，也就是周期更早，
    /// 我们不能确定到底是什么创建的实例。</para>
    /// </summary>
    public sealed class Singleton03
    {
        private readonly static Singleton03 me = new Singleton03();
        private string time = string.Empty;
        //就是不讓外面實例化
        private Singleton03()
        {
            time = DateTime.Now.Ticks.ToString();
        }

        public static Singleton03 Instantiation
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

    ////測試代碼
    //public class SubSingleton03 : Singleton03 {
    //    public string SubName { get; set; }
    //}
}
