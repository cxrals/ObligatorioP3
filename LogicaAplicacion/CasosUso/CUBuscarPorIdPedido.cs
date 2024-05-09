using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CUBuscarPorIdPedido : ICUBuscarPorId<Pedido> {
        public IRepositorioPedidos Repo { get; set; }

        public CUBuscarPorIdPedido(IRepositorioPedidos repo) {
            Repo = repo;
        }

        public Pedido BuscarPorId(int id) {
            return Repo.FindById(id);
        }
    }
}
