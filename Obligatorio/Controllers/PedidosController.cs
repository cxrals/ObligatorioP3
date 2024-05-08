using DataTransferObjects;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.Models;

namespace Obligatorio.Controllers {
    public class PedidosController : Controller {
        public ICUListado<Articulo> CUListadoArticulos { get; set; }
        public ICUListado<Cliente> CUListadoClientes { get; set; }
        public ICUAlta<PedidoDTO> CUAlta { get; set; }

        public PedidosController(ICUListado<Articulo> cuListadoArticulos, ICUListado<Cliente> cuListadoClientes, ICUAlta<PedidoDTO> cuAlta) {
            CUListadoArticulos = cuListadoArticulos;
            CUListadoClientes = cuListadoClientes;
            CUAlta = cuAlta;
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
        public ActionResult Create(AltaPedidoViewModel vm) {
            try {
               // if (ModelState.IsValid) {
                    
                    // PedidoExpressDTO dto = new PedidoExpressDTO()
                    // PedidoComunDTO dto = new PedidoComunDTO()

                    PedidoDTO dto = new PedidoDTO();
                    dto.IdCliente = vm.IdCliente;
                    dto.TipoPedido = vm.TipoPedido;
                    dto.FechaEntrega = vm.FechaEntrega;
                    dto.IdArticulo = vm.IdArticulo;
                    dto.Cantidad = vm.Cantidad;

                    CUAlta.Alta(dto);

                    return RedirectToAction("Index", "Pedidos");
               // }
            } catch (Exception e) {
                //TODO: refinar exceptions
                ViewBag.ErrorMsg = e.ToString();
            }

            vm.Articulos = CUListadoArticulos.ObtenerListado();
            vm.Clientes = CUListadoClientes.ObtenerListado();
            return View(vm);
        }
    }
}
