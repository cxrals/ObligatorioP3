using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio {
    public class PedidoExpress : Pedido {
        public int Recargo { get; set; } // si plazo = 1 ? 15% : 10%
        public DateOnly FechaEntrega { get; set; }
        public int PlazoEstipulado { get; set; } // <= 5
    }
}
