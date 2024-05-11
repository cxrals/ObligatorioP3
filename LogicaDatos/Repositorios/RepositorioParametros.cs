using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios {
    public class RepositorioParametros : IRepositorioParametros {
        public ObligatorioContext Contexto { get; set; }
        public RepositorioParametros(ObligatorioContext ctx) {
            Contexto = ctx;
        }
        public void Create(Parametro obj) {
            Contexto.Parametros.Add(obj);
            Contexto.SaveChanges();
        }

        public void Delete(int id) {
            throw new NotImplementedException();
        }

        public Parametro FindById(int id) {
            throw new NotImplementedException();
        }

        public List<Parametro> GetAll() {
            return Contexto.Parametros.ToList();
        }

        public void Update(Parametro obj) {
            throw new NotImplementedException();
        }
    }
}
