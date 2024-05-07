using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.Models;

namespace Obligatorio.Controllers {
    public class PedidosController : Controller {
        public ICUListado<Articulo> CUListadoArticulos { get; set; }
        public ICUListado<Cliente> CUListadoClientes { get; set; }

        public PedidosController(ICUListado<Articulo> cuListadoArticulos, ICUListado<Cliente> cuListadoClientes) {
            CUListadoArticulos = cuListadoArticulos;
            CUListadoClientes = cuListadoClientes;
        }

        public IActionResult Index() {
            return View();
        }

        //--------------------------------------------------------------------------
        //----------------------------- CREATE -------------------------------------
        //--------------------------------------------------------------------------
        public ActionResult Create() {
            AltaPedidoViewModel vm = new AltaPedidoViewModel() {
                Articulos = CUListadoArticulos.ObtenerListado(),
                Clientes = CUListadoClientes.ObtenerListado()
            };
            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(Pedido nuevo) {
            try {
                return RedirectToAction("Index", "Pedidos");
            } catch (Exception e) {
                //TODO: refinar exceptions
                ViewBag.ErrorMsg = e.ToString();
            }

            return View();
        }
    }
}
