using System.Web.Mvc;

namespace HelpYou.Component.Controllers.Manage
{
    public class HomeController : Controller
    {
        public HomeController() { }
        public ActionResult Index(string login,string pwd,string yzm)
        {
            if (Request.IsAjaxRequest())
            {
               
            }
            return View();
        }

        public ActionResult Main()
        {
            return View();
        }
    }
}