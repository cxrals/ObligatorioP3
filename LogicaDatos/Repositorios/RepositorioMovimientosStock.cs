﻿using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios {
    public class RepositorioMovimientosStock : IRepositorioMovimientosStock {
        public ObligatorioContext Contexto { get; private set; }

        public RepositorioMovimientosStock(ObligatorioContext ctx) {
            Contexto = ctx;
        }
        public void Create(MovimientoStock obj) {
            obj.EsValido();
            Contexto.Entry(obj.Articulo).State = EntityState.Unchanged;
            Contexto.MovimientosStock.Add(obj);
            Contexto.SaveChanges();
        }

        public MovimientoStock FindById(int id) {
            return Contexto.MovimientosStock.Find(id);
        }

        public List<MovimientoStock> GetAll() {
            return Contexto.MovimientosStock.ToList();
        }

        // no implementar 
        public void Update(MovimientoStock obj) {
            throw new NotImplementedException();
        }
        public void Delete(int id) {
            throw new NotImplementedException();
        }
    }
}
