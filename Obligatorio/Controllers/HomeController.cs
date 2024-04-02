using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Obligatorio.Controllers {
    public class HomeController : Controller {

        public IActionResult Index() {
            return View();
        }
    }
}
