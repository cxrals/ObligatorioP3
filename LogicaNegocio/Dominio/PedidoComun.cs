using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio {
    public class PedidoComun : Pedido, IValidar {
        public int Recargo { get; set; } // si Cliente.DistanciaHastaDeposito > 100 ? 5% : 0
        public DateOnly FechaEntrega { get; set; }
        public int PlazoEstipulado { get; set; } // > 7 dias

        public void EsValido() {
            if (PlazoEstipulado < 7) {
                throw new DatosInvalidosException("El plazo de entrega para un pedido común no puede ser menor a 7 días");
            }
        }
    }
}
