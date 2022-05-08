using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_WebAPP.controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contact()
        {
            throw new InvalidOperationException("Something is wrong in code...");
            return View();
        }

        [HttpGet("About")]
        public IActionResult About()
        {
            return View();
        }
    }
}
