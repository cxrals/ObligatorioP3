﻿using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CUModificarUsuario : ICUModificar<Usuario> {
        public IRepositorioUsuarios Repo { get; set; }

        public CUModificarUsuario(IRepositorioUsuarios repo) {
            Repo = repo;
        }
        public void Modificar(Usuario obj) {
            Repo.Update(obj);
        }
    }
}
