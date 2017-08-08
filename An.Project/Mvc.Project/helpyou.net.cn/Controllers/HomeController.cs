using helpyou.net.cn.DB.Interface;
using System.Web.Mvc;

namespace helpyou.net.cn.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMenu _menuServer;
        public HomeController(IMenu menu)
        {
            this._menuServer = menu;
        }
        public ActionResult Index()
        {         
            var lst = this._menuServer.QueryAll();
            //foreach (var item1 in lst.Where(x=>x.Level==0).ToList())
            //{
            //    foreach (var item2 in lst.Where(x=>x.Level==1&&x.ParentUrl.Contains(item1.ParentUrl)).ToList())
            //    {
            //        var t = item2.Name;
            //    }
            //}
            return View(lst);
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}
