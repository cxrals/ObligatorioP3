using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects {
    public class MapperPedidos {
        public static Pedido CrearEntidad(PedidoDTO pedidoDTO) {
            Pedido p;

            if (pedidoDTO.TipoPedido == "PedidoExpress") {
                p = new PedidoExpress();
            } else {
                p = new PedidoComun();
            }

            p.FechaEntrega = pedidoDTO.FechaEntrega;
            p.Estado = "Pendiente";

            return p;
        }
    }
}
