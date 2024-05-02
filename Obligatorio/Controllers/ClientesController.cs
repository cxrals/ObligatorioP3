using Microsoft.AspNetCore.Mvc;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;

namespace Obligatorio.Controllers {
    public class ClientesController : Controller {
        public ICUListado<Cliente> CUListado { get; set; }
        public ICUBuscarPorRazonSocial CUBuscarPorRazonSocial { get; set; }

        public ClientesController(ICUListado<Cliente> cuListado, ICUBuscarPorRazonSocial cuBuscarPorRazonSocial)
        {
            CUListado = cuListado;
            CUBuscarPorRazonSocial = cuBuscarPorRazonSocial;
        }

        public IActionResult Index() {
            return View(CUListado.ObtenerListado());
        }

        public ActionResult BuscarPorRazonSocial() {
            return View(CUListado.ObtenerListado());
        }

        [HttpPost]
        public ActionResult BuscarPorRazonSocial(string razonSocial) {
            List<Cliente> clientes = CUBuscarPorRazonSocial.BuscarPorRazonSocial(razonSocial);
            if (clientes.Count == 0) ViewBag.ErrorMsg = "No existen registros";
            return View(clientes);
        }
    }
}
