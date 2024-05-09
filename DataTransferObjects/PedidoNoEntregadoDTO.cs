using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects {
    public class PedidoNoEntregadoDTO {
        // DTO usado para:
        // Listado de pedidos que se pueden anular (Estado == "Pendiente")
        // Listado de pedidos anulados (Estado == "Anulado")
        public DateOnly FechaEntrega { get; set; }
        public string RazonSocialCliente { get; set; }
        public int Total {  get; set; }
    }
}
