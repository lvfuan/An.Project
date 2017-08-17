using System.Web.Mvc;

namespace HelpYou.Component.Controllers.Web
{
    public class MasterViewController:Controller
    {
        public MasterViewController() { }
        public ActionResult Master()
        {
            return View();
        }
    }
}
