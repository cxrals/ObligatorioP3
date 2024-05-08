using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio {
    public class PedidoExpress : Pedido, IValidar {
        public int Recargo { get; set; } // si plazo = 1 ? 15% : 10%
        public int PlazoEstipulado { get; set; } // <= 5

        public void EsValido() {
            if (PlazoEstipulado > 5) {
                throw new DatosInvalidosException("El plazo de entrega para un pedido express no puede ser mayor a 5 días");
            }
        }
    }
}
