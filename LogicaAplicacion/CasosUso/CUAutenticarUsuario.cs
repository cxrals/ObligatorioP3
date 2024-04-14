using LogicaNegocio.Dominio;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CUAutenticarUsuario : ICUAutenticarUsuario {
        public IRepositorioUsuarios Repo { get; set; }

        public CUAutenticarUsuario(IRepositorioUsuarios repo) {
            Repo = repo;
        }

        public bool Autenticar(string email, string contraseña, out Usuario u) {
            u = Repo.BuscarPorEmail(email);
            if (u != null) {
                return u.Contraseña == contraseña;
            }
            return false;
        }
    }
}
