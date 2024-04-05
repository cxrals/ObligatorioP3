using Microsoft.AspNetCore.Mvc;

namespace Obligatorio.Controllers {
    public class ClientesController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
