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
        public ContentResult Upload(HttpPostedFileBase FileData, string folder)
        {
            return Content("complete");
        }

        [NonAction]
        private void SaveFile()
        {

        }
    }
}
