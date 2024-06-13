using DataTransferObjects;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CUAltaMovimientoStock : ICUAlta<MovimientoStockDTO> {
        public IRepositorioMovimientosStock Repo { get; set; }
        public IRepositorioArticulos RepoArticulos { get; set; }
        public IRepositorioUsuarios RepooUsuarios { get; set; }
        public IRepositorioTiposMovimientos RepoTiposMovimientos { get; set; }
        public CUAltaMovimientoStock(IRepositorioMovimientosStock repo, IRepositorioArticulos repoArticulos, IRepositorioTiposMovimientos repoTiposMovimientos) {
            Repo = repo;
            RepoArticulos = repoArticulos;
            RepoTiposMovimientos = repoTiposMovimientos;
        }

        public void Alta(MovimientoStockDTO obj) {
            MovimientoStock nuevoMovimiento = new MovimientoStock();

            Articulo articulo = RepoArticulos.FindById(obj.ArticuloId);
            TipoMovimiento tm = RepoTiposMovimientos.FindById(obj.TipoMovimientoId);

            nuevoMovimiento.Articulo = articulo;
            nuevoMovimiento.TipoMovimiento = tm;

            // chequear que cantidaad < parametro
                // else tirar DatosInvalidosEx

            Repo.Create(nuevoMovimiento);
            obj.Id = nuevoMovimiento.Id;

        }

        // el usuario puede elegir otros o deberia guardarse el logueado?
    }
}
