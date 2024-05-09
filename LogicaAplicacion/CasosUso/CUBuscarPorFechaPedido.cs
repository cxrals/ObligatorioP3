using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaAplicacion.CasosUso {
    public class CUBuscarPorFechaPedido : ICUBuscarPorFechaPedido {
        public IRepositorioPedidos Repo { get; set; }
        public CUBuscarPorFechaPedido(IRepositorioPedidos repo) {
            Repo = repo;
        }
        public List<Pedido> BuscarPorFechaPedido(DateOnly fecha) {
            return Repo.BuscarPorFechaDeEmision(fecha);
        }
    }
}
