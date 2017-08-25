using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitTest.MvcPager.Models;
using Dapper;
using System.Data.SQLite;
using System.Net;

namespace UnitTest.MvcPager.Controllers
{
    public class HomeController : Controller
    {
      
        // GET: Home
        public ActionResult Index()
        {
            var list = new InitPagerDate().GetPagerDate;
            ViewBag.TotalRecord = list.Count();//总记录

         
            return View(list);
        }
    }
}