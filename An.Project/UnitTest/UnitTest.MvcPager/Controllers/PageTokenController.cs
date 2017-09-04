using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitTest.MvcPager.Models.Token;

namespace UnitTest.MvcPager.Controllers
{
    public class PageTokenController : Controller
    {
        //防止重复提交
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// from提交
        /// </summary>
        /// <param name="formCollection"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateReHttpPostToken]
        public ActionResult Index(FormCollection formCollection)
        {
            return View();
        }
        /// <summary>
        /// post提交
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateReHttpPostToken]
        public ActionResult PostToken(string id,string pwd)
        {
            return Json("提交成功");
        }
    }
}