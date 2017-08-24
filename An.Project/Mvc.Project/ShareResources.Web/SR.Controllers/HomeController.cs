using SR.Models.SRContext;
using System.Web.Mvc;
using System.Linq;
using SR.Interfaces;
using System;

namespace SR.Controllers
{
    public class HomeController:BaseController
    {
        public HomeController(ISRContainer container) { _CONTAINER = container; }
        public ActionResult Index()
        {
            var  s= _CONTAINER.Menu.QueryList(0);
            return View();
        }
    }
}
