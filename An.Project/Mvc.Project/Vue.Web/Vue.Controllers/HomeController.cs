using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Vue.Controllers
{
    public class HomeController:Controller
    {
        public HomeController() { }
        public ActionResult Index()
        {
            return View();
        }
    }
}
