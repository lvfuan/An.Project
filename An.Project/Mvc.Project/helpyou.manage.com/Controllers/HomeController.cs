using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace helpyou.manage.com.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
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