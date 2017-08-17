using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UnitTest.NetCore2._0.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hello World NetCore 2.0";
        }
    }
}