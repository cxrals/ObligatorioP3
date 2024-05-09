using DataTransferObjects;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCasosUso;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase {
        public ICUOrdenarPedidosAnuladosDesc CUOrdenarPedidosAnuladosDesc { get; set; }

        public PedidosController(ICUOrdenarPedidosAnuladosDesc cuOrdenarPedidosAnuladosDesc) {
            CUOrdenarPedidosAnuladosDesc = cuOrdenarPedidosAnuladosDesc;
        }

        // GET: api/<PedidosController>
        [HttpGet]
        public IActionResult Get() {
            List<PedidoNoEntregadoDTO> pedidoDTOs = CUOrdenarPedidosAnuladosDesc.OrdenarPorFechaDesc();
            return Ok(pedidoDTOs);
        }

        // GET api/<PedidosController>/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }

        // POST api/<PedidosController>
        [HttpPost]
        public void Post([FromBody] string value) {
        }

        // PUT api/<PedidosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<PedidosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
