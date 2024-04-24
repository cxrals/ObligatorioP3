using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasosUso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CUBuscarPorRazonSocial : ICUBuscarPorRazonSocial {
        public IRepositorioClientes Repo { get; set; }
        public CUBuscarPorRazonSocial(IRepositorioClientes repo) {
            Repo = repo;
        }
        public Cliente BuscarPorRazonSocial(string nombre) {
            return Repo.BuscarPorRazonSocial(nombre);
        }
    }
}
