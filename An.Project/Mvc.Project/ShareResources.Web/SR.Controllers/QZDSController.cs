using SR.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SR.Controllers
{
     public class QZDSController:BaseController
    {
        public QZDSController(ISRContainer container) { _CONTAINER = container; }
        public ActionResult Index()
        {
            return View();
        }
    }
}
