using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using Util.Core;
using System.Web;

namespace XmlTest
{
    [Serializable]
    [XmlRoot("reply")]
    public class Reply
    {
        [XmlElement("username")]
        public string UserName { get; set; }
        [XmlElement("date")]
        public string Date { get; set; }

        private string content = string.Empty;
        [XmlElement("content")]
        public XmlCDataSection Content
        {
            get
            {
                XmlDocument xdoc = new XmlDocument();
                return xdoc.CreateCDataSection(content);
            }
            set
            {
                //HttpUtility.UrlEncode(value.Value);
                content = value.Value;
            }
        }
    }

    [Serializable]
    [XmlRoot("root")]
    public class ReplyList
    {
        [XmlArray("replys")]
        [XmlArrayItem("reply")]
        // [XmlElement("replys")]
        public List<Reply> Replys { get; set; }
    }

    public class Entity<T> where T : class
    {
        public Entity() {
            Console.WriteLine("进来了");
        }

        private static Entity<T> _install = null;
        public static Entity<T> Install
        {
            get
            {
                if (_install == null)
                {
                    _install = new Entity<T>();
                }
                return _install;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region xml测试
            /*
            //string text = "唔係喺吉隆坡";
            string xmlPath = Environment.CurrentDirectory + @"\xml\reply.xml";//Path.GetFullPath(@"~\xml\reply.xml");
            //写
            ReplyList replys = new ReplyList();
            replys.Replys = new List<Reply>();
            XmlDocument doc = new XmlDocument();
            Regex reg = new Regex(@"[^\w.\s\f\n\r\v\u4e00-\u9fa5\xAC00-\xD7A3\u0800-\u4e00~!@#\$%\^&*()+-=\.,/\\'"":;~！@#￥%……&*（）—
×÷±≈≠∧∨∑∪∩∈⊙⌒⊥∥∠√∨∧≯≮≥≤＞＜≌∽﹙﹚﹛﹜∫∮∝∞⊙∏∶₄·₃₁₂ⁿ⁴³²¹º½⅓⅔¼¾⅛⅜⅝⅞∵∵∷μλκιθη
ζ￡＄￥Pa㏒㏑molml㏎㎥㎡℉℃°〒¤○㏕〖〗』『︻︼﹄﹃︽︾㈠㈡㈢㈣㈤㈥㈦㈧㈨㈩ⅩⅨⅧⅦⅥⅤⅣⅢⅡⅠ
❶❷❸❹❺❻❼❽❾❿⑩⑨⑧⑦⑥⑤③④②①⑪⑫⑬⑭⑮⑯⑰⑱⑲⑳
]", RegexOptions.IgnoreCase);

            //唔係后面有一个非常特别的字符，导致XML解析错误，用notepad++可以睇到
            replys.Replys.Add(new Reply
            {
                UserName = "seasun",
                Content = doc.CreateCDataSection(reg.Replace(@"私は翼で待っている唔係喺吉^&*()+-=\.,/\\'"":;~！@#￥%……&*（）—
×÷±≈≠∧∨∑∪∩∈⊙⌒⊥∥∠√∨∧≯≮≥≤＞＜≌∽﹙﹚﹛﹜∫∮∝∞⊙∏∶₄·₃₁₂ⁿ⁴³²¹º½⅓⅔¼¾⅛⅜⅝⅞∵∵∷μλκιθη
ζ￡＄￥Pa㏒㏑molml㏎㎥㎡℉℃°〒¤○㏕〖〗』『︻︼﹄﹃︽︾㈠㈡㈢㈣㈤㈥㈦㈧㈨㈩ⅩⅨⅧⅦⅥⅤⅣⅢⅡⅠ
❶❷❸❹❺❻❼❽❾❿⑩⑨⑧⑦⑥⑤③④②①⑪⑫⑬⑭⑮⑯⑰⑱⑲⑳隆!坡容", "*")),
                Date = "201209171503"
            });
            replys.Replys.Add(new Reply { UserName = "kk", Content = doc.CreateCDataSection("sdfsdfsdfsdfsdf"), Date = "201209171516" });
            XmlHelper.Serialize<ReplyList>(xmlPath, replys);
          * */
            /*读*/
            //List<Reply> replyList = XmlHelper.Deserialize<List<Reply>>(xmlPath);
            //Console.Read(); 
            #endregion

            //Entity<ReplyList> me = Entity<ReplyList>.Install;
            //Entity<ReplyList> me2 = Entity<ReplyList>.Install;

            Console.WriteLine((int)Convert.ToChar("語"));
            Console.Read();
        }
    }
}
