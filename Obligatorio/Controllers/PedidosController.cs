using Microsoft.AspNetCore.Mvc;

namespace Obligatorio.Controllers {
    public class PedidosController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
