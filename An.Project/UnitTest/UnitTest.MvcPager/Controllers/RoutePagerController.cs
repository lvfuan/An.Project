using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UnitTest.MvcPager.Controllers
{
    public class RoutePagerController : Controller
    {
        // GET: RoutePager
        public ActionResult Index(int pageIndex,int pageSize)
        {
            var path = Request.Url.GetLeftPart(UriPartial.Path);
            return View();
        }
    }
}