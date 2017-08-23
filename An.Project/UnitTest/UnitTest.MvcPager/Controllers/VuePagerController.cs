using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitTest.MvcPager.Models;

namespace UnitTest.MvcPager.Controllers
{
    public class VuePagerController : Controller
    {
        // GET: VuePager
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            var list = new InitPagerDate().GetPagerDate;
            ViewBag.TotalRecord = list.Count();//总记录
            ViewBag.PageCount = Math.Ceiling(list.Count * 0.1 / 10) * 10; //总页数
            var page = list.OrderBy(x => x.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            Dictionary<string, List<PagerDemo>> dic = new Dictionary<string, List<PagerDemo>>();
            dic.Add("Items", page);
            var json = JsonConvert.SerializeObject(dic);
            ViewBag.json = json;
            if (Request.IsAjaxRequest())
            {
                return Json(json);
            }
            return View();
        }
    }
}