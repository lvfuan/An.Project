using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HelpYou.Component.Controllers.Web
{
    public class UserManagerController:Controller
    {
        public UserManagerController() { }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Main()
        {
            return View();
        }
    }
}
