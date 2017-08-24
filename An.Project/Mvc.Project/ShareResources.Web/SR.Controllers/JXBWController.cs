using SR.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SR.Controllers
{
    public class JXBWController:BaseController
    {   
        public JXBWController(ISRContainer container){ _CONTAINER = container; }
        public ActionResult Index()
        {
            return View();
        }
    }
}
