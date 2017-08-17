using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HelpYou.Component.Controllers.Web
{
    class FileUploadController:Controller
    {
        public FileUploadController() { }
        public ActionResult UpLoadImage()
        {
            return View();
        }
    }
}
