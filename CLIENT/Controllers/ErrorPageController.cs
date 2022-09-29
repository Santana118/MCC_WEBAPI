using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLIENT.Controllers
{
    public class ErrorPageController : Controller
    {
#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        public IActionResult Unauthorized()
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
        {
            return View();
        }
    }
}
