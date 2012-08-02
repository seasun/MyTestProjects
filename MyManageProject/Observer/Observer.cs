using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Observer
{
    /// <summary>
    /// 觀察者（前臺MM）
    /// </summary>
    class Observer
    {
        private static readonly Observable boss = new Observable();
        public Observer(int second = 5)
        {
            boss.ComeBack(second);//老板second(5)秒後回來
        }
        /// <summary>
        /// 快來孝敬過我，老闆回來我第一時間通知你們
        /// </summary>
        /// <param name="notifyObj">孝敬我的對象</param>
        public void Subscribe(NotifyObject notifyObj)
        {
            boss.notify += notifyObj.Receive;//我要通知所有之前有孝敬過我的同事
        }
    }
}
