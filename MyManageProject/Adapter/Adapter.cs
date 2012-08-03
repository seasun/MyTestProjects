using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adapter
{
    /// <summary>
    /// (對象)適配器（其實就是增加一個中間件達到間接調用效果）
    /// </summary>
    class Adapter : AmericaVoltage, IVoltage
    {
        #region IVoltage 成员

        /// <summary>
        /// 起到的是變壓作用(客戶想用的是中國式的電壓方法簽名GetCnVoltage)
        /// </summary>
        /// <returns></returns>
        public string GetCnVoltage()
        {
            return base.GetEnVoltage();
        }

        #endregion
    }
}
