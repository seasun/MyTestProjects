using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util.Core
{
    public static class StringHelper
    {
        /// <summary>
        /// 返回指定位置的字符的 Unicode 编码。这个返回值是 0 - 65535 之间的整数
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="index">位置，从0开始</param>
        /// <returns></returns>
        public static int ChartCodeAt(this string str, int index)
        {
            if (str.Length > index)
                return Convert.ToInt32(Convert.ToChar((str.Substring(index, 1))));
            return 0;
        }

        /// <summary>
        /// 截字符串【一个单位长度 = 一个中文占位符】
        /// </summary>
        /// <param name="str"></param>
        /// <param name="len">要截取的单位长度(两个英文符号当一个单位长度)</param>
        /// <param name="extendStr">超过长度所要追加的表示符号，默认为空（如："..."）</param>
        /// <returns></returns>
        public static string SubStringEx(this string str, int len, string extendStr = "")
        {
            if (!string.IsNullOrEmpty(str) && len > 0)
            {
                int a = 0, b = 0, len2 = len * 2;
                bool isExtendStr = false;
                for (int i = 0; i < str.Length; i++)
                {
                    if (a + b >= len2)
                    {
                        isExtendStr = true;
                        break;
                    }
                    if (str.ChartCodeAt(i) < 128)
                    {//小于128表示是英文字符
                        a++;
                    }
                    else
                        b += 2;
                }
                str = isExtendStr ? str.Substring(0, a + b / 2) + extendStr : str.Substring(0, a + b / 2);
            }
            return str;
        }
    }
}
