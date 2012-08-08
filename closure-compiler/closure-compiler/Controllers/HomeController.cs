using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using closure_compiler.Helper;

namespace closure_compiler.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public string Compress(int compressWay, string jsContent = "")
        {
            double unCompressFileSize = 0.0, compressedFileSize = 0.0;
            if (string.IsNullOrEmpty(jsContent.Trim()))
                return "{\"status\":-2,\"msg\":\"沒有內容需要壓縮\"}";
            string jsJarPath = ConfigurationManager.AppSettings["jarpath"];
            string orderError = string.Empty, excetion = string.Empty;
            bool haveError;
            jsContent = HttpUtility.UrlDecode(jsContent);
            //if (!string.IsNullOrEmpty(jsJarPath))
            //{
            //    if (!jsJarPath.EndsWith(".jar"))
            //        return "{\"status\":-3,\"msg\":\"壓縮類庫文件錯誤\"}";
            //}
            using (CompilerJarHelper compilerHelper = new CompilerJarHelper(this.HttpContext))
            {
                if (compilerHelper.WriteFile(jsContent, ref excetion, ref unCompressFileSize))//寫入JS代碼
                {
                    if (compilerHelper.CreateBat(ref excetion, (Enum.CompressEnum)compressWay))//生成壓縮命令的bat文件
                    {
                        if (compilerHelper.ExcuteBat(out haveError, ref orderError, ref excetion))//執行bat文件，生成壓縮後的JS代碼
                        {
                            if (haveError)
                            {
                                return "{\"status\":-7,\"msg\":\"壓縮出錯\",\"excetion\":\"" + Uri.EscapeDataString(orderError) + "\"}";
                            }
                            else
                            {
                                string CompressJsCode = compilerHelper.ReadCompressJs(ref excetion, ref compressedFileSize);//讀取壓縮後的JS代碼
                                return "{\"status\":1,\"unCompressFileSize\":\"" + unCompressFileSize + "\",\"compressedFileSize\":\"" + compressedFileSize + "\",\"msg\":\"" + HttpUtility.UrlEncode(CompressJsCode).Replace("+", "%20") + "\",\"excetion\":\"" + Uri.EscapeDataString(excetion) + "\",\"error\":\"" + Uri.EscapeDataString(orderError) + "\"}";
                            }
                        }
                        else
                            return "{\"status\":-4,\"msg\":\"壓縮出錯\",\"excetion\":\"" + Uri.EscapeDataString(excetion) + "\"}";
                    }
                    else
                        return "{\"status\":-5,\"msg\":\"寫入壓縮命令出錯\",\"excetion\":\"" + Uri.EscapeDataString(excetion) + "\"}";
                }
                else
                    return "{\"status\":-6,\"msg\":\"代碼寫入temp.txt出錯\",\"excetion\":\"" + Uri.EscapeDataString(excetion) + "\"}}";
            }
            //return "{\"status\":-1,\"msg\":\"壓縮失敗\"}";
        }
    }
}
