using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Observer
{
    public class ComebackEventArgs : EventArgs
    {
        public bool IsComeback { get; private set; }
        public ComebackEventArgs(bool isComeBack)
        {
            this.IsComeback = isComeBack;
        }
    }

    /// <summary>
    /// 老板是否回來(被觀察者)
    /// </summary>
    class Observable
    {
        //聲明一個通知委託
        public delegate void NotifyEventHandler(object sender, ComebackEventArgs e);
        //聲明通知事件
        public event NotifyEventHandler notify;
        /// <summary>
        /// 倒計時，老板還有多久就回來
        /// </summary>
        public int CountDown { get; private set; }

        public void ComeBack(int secret = 10)
        {
            this.CountDown = secret;
            Console.WriteLine("{0}秒後老闆將回來", this.CountDown);
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            DateTime signalTime = (DateTime)e.SignalTime;
            //Console.Write("{0} ", signalTime.ToLongTimeString());
            Console.Write("{0} ", this.CountDown--);
            if (this.CountDown <= 0)
            {
                Console.WriteLine("");
                ((Timer)sender).Stop();
                ComebackEventArgs comebackEvent = new ComebackEventArgs(true);
                notify(this, comebackEvent);
            }
        }
    }
}
