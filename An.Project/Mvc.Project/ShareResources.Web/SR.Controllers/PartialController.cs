using SR.Interfaces;
using SR.Models.SRContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SR.Controllers
{
    public class PartialController:BaseController
    {
     
        public PartialController(ISRContainer container) { _CONTAINER = container; }
        public ActionResult Layout()
        {
            return View();
        }
    }
}
