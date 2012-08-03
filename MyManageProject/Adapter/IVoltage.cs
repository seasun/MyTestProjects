using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adapter
{
    /// <summary>
    /// 增加呢個适配接口
    /// </summary>
    public interface IVoltage
    {
        /// <summary>
        /// 中国式的电压接口
        /// </summary>
        /// <returns></returns>
        string GetCnVoltage();
    }
}
