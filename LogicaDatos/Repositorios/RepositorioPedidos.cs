using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios {
    public class RepositorioPedidos : IRepositorioPedidos {
        public ObligatorioContext Contexto { get; set; }

        public RepositorioPedidos(ObligatorioContext ctx) {
            Contexto = ctx;
        }
        public void Create(Pedido obj) {
            obj.EsValido();
            Contexto.Entry(obj.Cliente).State = EntityState.Unchanged;
            Contexto.Pedidos.Add(obj);
            Contexto.SaveChanges();
        }

        public void Delete(int id) {
            //throw new NotImplementedException();
        }

        public Pedido FindById(int id) {
            throw new NotImplementedException();
        }

        public List<Pedido> GetAll() {
            throw new NotImplementedException();
        }

        public void Update(Pedido obj) {
            //throw new NotImplementedException();
        }
    }
}
// TODO https://learn.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/implementing-inheritance-with-the-entity-framework-in-an-asp-net-mvc-application