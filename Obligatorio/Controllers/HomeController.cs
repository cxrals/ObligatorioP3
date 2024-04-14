using Obligatorio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Obligatorio.Controllers {
    public class HomeController : Controller {

        public IActionResult Index() {
            return View();
        }

        
    }
}
