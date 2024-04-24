using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Obligatorio.Controllers {
    public class ArticulosController : Controller {
        public ICUAlta<Articulo> CUAlta { get; set; }
        public ICUListado<Articulo> CUListado { get; set; }

        public ArticulosController(ICUAlta<Articulo> cuAlta, ICUListado<Articulo> cuListado) {
            CUAlta = cuAlta;
            CUListado = cuListado;

        }
        public IActionResult Index() {
            return View();
        }
    }
}
