using LogicaNegocio.Dominio;
using LogicaNegocio.Excepciones;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios {
    internal class RepositorioArticulos : IRepositorioArticulos {
        public ObligatorioContext Contexto { get; set; }

        public RepositorioArticulos(ObligatorioContext ctx) {
            Contexto = ctx;
        }
        public void Create(Articulo obj) {
            obj.EsValido();
            Contexto.Articulos.Add(obj);
            Contexto.SaveChanges();
        }

        public void Delete(int id) {
            Articulo aBorrar = FindById(id);
            if (aBorrar != null) {
                Contexto.Articulos.Remove(aBorrar);
                Contexto.SaveChanges();
            } else {
                throw new RegistroNoExisteException("El articulo no existe");
            }
        }

        public Articulo FindById(int id) {
            return Contexto.Articulos.Find(id);
        }

        public List<Articulo> GetAll() {
            return Contexto.Articulos.ToList();
        }

        public void Update(Articulo obj) {
            obj.EsValido();
            Contexto.Articulos.Update(obj);
            Contexto.SaveChanges();
        }
    }
}
