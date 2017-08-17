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
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Article()
        {
            return View();
        }
        public ActionResult Detail()
        {
            return View();
        }
        public ActionResult Resource()
        {
            return View();
        }
       public ActionResult TimeLine()
        {
            return View();
        }
    }
}