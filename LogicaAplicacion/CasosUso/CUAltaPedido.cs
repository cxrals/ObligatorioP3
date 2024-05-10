using DataTransferObjects;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.Excepciones;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CUAltaPedido : ICUAlta<PedidoDTO> {
        public IRepositorioPedidos Repo { get; set; }
        public IRepositorioClientes RepoClientes { get; set; }
        public IRepositorioArticulos RepoArticulos { get; set; }
        public IRepositorioLineas RepoLineas { get; set; }
        public CUAltaPedido(IRepositorioPedidos repo, IRepositorioClientes repoClientes, IRepositorioArticulos repoArticulos, IRepositorioLineas repoLineas) {
            Repo = repo;
            RepoClientes = repoClientes;
            RepoArticulos = repoArticulos;
            RepoLineas = repoLineas;
        }
        public void Alta(PedidoDTO obj) {
            Pedido nuevoPedido = MapperPedidos.CrearEntidad(obj);
            Cliente cliente = RepoClientes.FindById(obj.IdCliente);
            Articulo articulo = RepoArticulos.FindById(obj.IdArticulo);
            if (cliente != null) {
                nuevoPedido.Cliente = cliente;                
            } else {
                throw new RegistroNoExisteException("El cliente seleccionado para el pedido no existe");
            }

            //TODO reemplazar por map ?
            if (articulo != null) {
                // crear la Linea
                Linea nuevaLinea = new Linea();
                nuevaLinea.Articulo = articulo;
                nuevaLinea.PreciodUnitario = articulo.Precio;
                nuevaLinea.UnidadesSolicitadas = obj.Cantidad;
                RepoLineas.Create(nuevaLinea);

                // agregarla al pedido
                nuevoPedido.Lineas = new List<Linea> { nuevaLinea };
            } else {
                throw new RegistroNoExisteException("El artículo seleccionado para el pedido no existe");
            }

            Repo.Create(nuevoPedido);
        }

        public bool ChequearStock(Articulo articulo, int cantidadSolicitada) {
            throw new NotImplementedException();
        }

        public int CalcularTotal(List<Linea> lineas) {
            throw new NotImplementedException();
        }
    }
}
