using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios {
    public class RepositorioClientes : IRepositorioClientes {
        public ObligatorioContext Contexto { get; set; }
        public RepositorioClientes(ObligatorioContext ctx) {
            Contexto = ctx;
        }
        public Cliente BuscarPorRazonSocial(string nombre) {
            return Contexto.Clientes.Where(c => c.RazonSocial.ToLower() == nombre.ToLower()).SingleOrDefault();
        }

        public void Create(Cliente obj) {
            //throw new NotImplementedException();
        }

        public void Delete(int id) {
            //throw new NotImplementedException();
        }

        public Cliente FindById(int id) {
            throw new NotImplementedException();
        }

        public List<Cliente> GetAll() {
            throw new NotImplementedException();
        }

        public void Update(Cliente obj) {
            //throw new NotImplementedException();
        }
    }
}
