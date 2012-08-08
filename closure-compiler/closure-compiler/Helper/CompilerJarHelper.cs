using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using closure_compiler.Enum;

namespace closure_compiler.Helper
{
    public struct FileName
    {
        public const string CompressFolder = "Compress/";
        //public const string TempFile = "tempJs.js";
        //public const string CompressFile = "tempJs.min.js";
        //public const string ExcuteBat = "Compress.bat";
    }

    public class CompilerJarHelper : IDisposable
    {
        private string _fileName = Guid.NewGuid().ToString();
        private string _tempFile = string.Empty, fullTempFile = string.Empty;
        private string _compressFile = string.Empty, fullCompressFile = string.Empty;
        private string _excuteBat = string.Empty, fullExcuteBat = string.Empty;
        private HttpContextBase context = null;

        public CompilerJarHelper(HttpContextBase context)
        {
            this.context = context;
            this._tempFile = string.Format("{0}.js", _fileName);//未压缩时的文件名称
            this._compressFile = string.Format("{0}.min.js", _fileName);//压缩后的文件名称
            this._excuteBat = string.Format("{0}.bat", _fileName);//执行压缩的命令文件名称
            this.fullTempFile = context.Server.MapPath("~/" + FileName.CompressFolder + this._tempFile);
            this.fullCompressFile = context.Server.MapPath("~/" + FileName.CompressFolder + this._compressFile);
            this.fullExcuteBat = context.Server.MapPath("~/" + FileName.CompressFolder + this._excuteBat);
        }

        /// <summary>
        /// 執行bat文件，壓縮JS代碼
        /// </summary>
        /// <param name="context"></param>
        /// <param name="excetion">異常信息</param>
        /// <returns></returns>
        public bool ExcuteBat(out bool haveError, ref string orderError, ref string excetion)
        {
            haveError = false;
            try
            {
                string WorkingDirectory = context.Server.MapPath("~/" + FileName.CompressFolder);
                using (Process proc = new Process())
                {
                    proc.StartInfo.WorkingDirectory = WorkingDirectory;
                    proc.StartInfo.FileName = Path.Combine(WorkingDirectory, this._excuteBat);
                    proc.StartInfo.UseShellExecute = false;
                    //proc.StartInfo.CreateNoWindow = true;
                    proc.StartInfo.RedirectStandardError = true;
                    //proc.StartInfo.RedirectStandardOutput = true;
                    proc.Start();
                    orderError = proc.StandardError.ReadToEnd().Replace("句柄无效。\r\n", "");
                    Regex reg = new Regex(@"[1-9]+\s+error\(s\),\s+[\d]+\s+warning\(s\)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    haveError = reg.IsMatch(orderError);
                    //1 error(s), 1 warning(s)
                    //orderError = proc.StandardOutput.ReadToEnd();
                    proc.WaitForExit();
                }
            }
            catch (Exception e)
            {
                excetion = e.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 將要壓縮的JS代碼寫入臨時文件
        /// </summary>
        /// <param name="context"></param>
        /// <param name="jsContent">要壓縮的JS代碼</param>
        /// <param name="excetion">異常信息</param>
        /// <param name="fileSize">文件大小</param>
        /// <returns></returns>
        public bool WriteFile(string jsContent, ref string excetion, ref double fileSize)
        {
            if (string.IsNullOrEmpty(jsContent))
                return false;
            try
            {
                FileInfo file = new FileInfo(fullTempFile);
                //if (!file.Exists)
                //{
                //    using (file.Create()) { };
                //}
                byte[] jsStream = Encoding.UTF8.GetBytes(jsContent);
                using (FileStream filestream = file.OpenWrite())
                {
                    filestream.SetLength(0);//清空文件
                    filestream.Write(jsStream, 0, jsStream.Length);
                }
                fileSize = (file.Length / 1024.0);
            }
            catch (Exception e)
            {
                excetion = e.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 生成bat文件，用於執行壓縮命令
        /// </summary>
        /// <param name="context"></param>
        /// <param name="excetion">異常信息</param>
        /// <returns></returns>
        public bool CreateBat(ref string excetion, CompressEnum compressEnum = CompressEnum.NORMAL)
        {
            try
            {
                FileInfo file = new FileInfo(fullExcuteBat);
                StringBuilder orderCmd = new StringBuilder("java -jar compiler.jar ");
                if (compressEnum == CompressEnum.WHITESPACE_ONLY)
                {
                    orderCmd.Append(" --compilation_level WHITESPACE_ONLY ");
                }
                orderCmd.Append(" --js ");
                orderCmd.Append(this._tempFile);
                orderCmd.Append(" --js_output_file ");
                orderCmd.Append(this._compressFile);
                byte[] orderStream = Encoding.UTF8.GetBytes(orderCmd.ToString());
                using (FileStream filestream = file.OpenWrite())
                {
                    filestream.Write(orderStream, 0, orderStream.Length);
                }
            }
            catch (Exception e)
            {
                excetion = e.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 獲取壓縮後的JS代碼
        /// </summary>
        /// <param name="context"></param>
        /// <param name="excetion">異常信息</param>
        /// <returns></returns>
        public string ReadCompressJs(ref string excetion, ref double fileSize)
        {
            excetion = string.Empty;
            try
            {
                FileInfo file = new FileInfo(fullCompressFile);
                fileSize = (file.Length / 1024.0);
                using (StreamReader streamRead = new StreamReader(fullCompressFile))
                {
                    return streamRead.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                excetion = e.Message;
            }
            return string.Empty;
        }

        #region IDisposable 成员

        public void Dispose()
        {
            if (File.Exists(fullTempFile))
                File.Delete(fullTempFile);
            if (File.Exists(fullCompressFile))
                File.Delete(fullCompressFile);
            if (File.Exists(fullExcuteBat))
                File.Delete(fullExcuteBat);
        }

        #endregion
    }
}