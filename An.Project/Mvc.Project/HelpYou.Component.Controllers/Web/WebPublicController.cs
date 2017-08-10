using System.Web.Mvc;

namespace HelpYou.Component.Controllers.Web
{
    public class WebPublicController : Controller
    {
        public WebPublicController() { }
        public ActionResult Index()
        {
            return View();
        }
    }
}