﻿using SR.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SR.Controllers
{
    public class JRKBController:BaseController
    {
        public JRKBController(ISRContainer container) { _CONTAINER = container; }
        public ActionResult Index()
        {
            return View();
        }
    }
}
