using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios {
    public class RepositorioUsuarios : IRepositorioUsuarios {
        public ObligatorioContext Contexto { get; set; }
        public RepositorioUsuarios(ObligatorioContext ctx) { 
            Contexto = ctx;
        }
        public void Create(Usuario obj) {
            obj.EsValido(); 
            Contexto.Usuarios.Add(obj);
            Contexto.SaveChanges();
        }

        public void Delete(int id) {
            //throw new NotImplementedException();
        }

        public void Update(Usuario obj) {
            obj.EsValido();
            Contexto.Usuarios.Update(obj);
            Contexto.SaveChanges();
        }

        public Usuario BuscarPorEmail(string email) {
            return Contexto.Usuarios.Where(u => u.Email.ToLower() == email.ToLower()).First();
        }

        public List<Usuario> GetAll() {
            return Contexto.Usuarios.ToList();
        }

        //public void Delete(string email) {
        //    Usuario aBorrar = BuscarPorEmail(email);
        //    if (aBorrar != null) {
        //        Contexto.Usuarios.Remove(aBorrar);
        //        Contexto.SaveChanges();
        //    } else {
        //        throw new Exception("El usuario no existe");
        //    }
        //}
    }
}
