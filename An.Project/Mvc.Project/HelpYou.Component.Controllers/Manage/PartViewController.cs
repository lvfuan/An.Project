using System.Web.Mvc;
using Helper.Common;
namespace HelpYou.Component.Controllers.Manage
{
    public class PartViewController : Controller
    {
        public PartViewController() { }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetValidateCode()
        {          
            string code = ValidateCode.CreateValidateCode(5);
            Session["ValidateCode"] = code;
            byte[] bytes = ValidateCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }
    }
}