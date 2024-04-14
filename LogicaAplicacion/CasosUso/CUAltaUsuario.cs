using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CUAltaUsuario : ICUAlta<Usuario>{

        public IRepositorioUsuarios Repo { get; set; }
        public CUAltaUsuario(IRepositorioUsuarios repo) {
            Repo = repo;
        }
        public void Alta(Usuario obj) {
            Repo.Create(obj);
        }
    }
}
