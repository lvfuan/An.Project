using Helper.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HelpYou.Component.Controllers.Web
{
     public class WebPartViewController:Controller
    {
        public WebPartViewController() { }
        public ActionResult SignIn()
        {
            return View();
        }
        public ActionResult GetValidateCode()
        {
            string code = ValidateCode.CreateValidateCode(5);
            SessionHelper.Add("yzm", code);
            byte[] bytes = ValidateCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }
    }
}
