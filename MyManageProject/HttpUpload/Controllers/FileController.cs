using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HttpUpload.Controllers
{
    public class FileController : Controller
    {
        [HttpPost]
        public string Upload(HttpPostedFileBase FileData, string folder)
        {
            return "{\"success\":true,\"file\":\"/Resources/Apps/temp/a6612bae-5aef-44ac-9f89-370058e6e537.m4a\",\"thumbnail\":\"\"}";
        }

        [NonAction]
        private void SaveFile()
        {

        }
    }
}
