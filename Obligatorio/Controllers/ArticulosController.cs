using Microsoft.AspNetCore.Mvc;

namespace Obligatorio.Controllers {
    public class ArticulosController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
