using Microsoft.AspNetCore.Mvc;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Mvc;

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
    }
}
