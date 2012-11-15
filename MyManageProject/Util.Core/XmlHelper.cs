using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Util.Core
{
    public class XmlHelper
    {
        /// <summary>
        /// 序列化为XML文件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlPath"></param>
        /// <param name="t"></param>
        public static void Serialize<T>(string xmlPath, T t) where T : class
        {
            if (string.IsNullOrEmpty(xmlPath))
                throw new ArgumentNullException("xmlPath is null or Empty!");
            XmlSerializer xml = new XmlSerializer(typeof(T));
            using (StreamWriter sw = File.CreateText(xmlPath))
            {
                xml.Serialize(sw, t);
            }
        }

        /// <summary>
        /// 将文件反序列化为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlPath"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string xmlPath) where T : class
        {
            T t = null;
            if (string.IsNullOrEmpty(xmlPath))
                throw new ArgumentNullException("xmlPath is null or Empty!");
            if (!File.Exists(xmlPath))
                return null;
            XmlSerializer xml = new XmlSerializer(typeof(T));
            using (FileStream sr = File.OpenRead(xmlPath))
            {
                t = (T)xml.Deserialize(sr);
            }
            return t;
        }
    }
}
