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
    public class CUListadoMovimientosStock : ICUListado<MovimientoStockDTO> {
        public IRepositorioMovimientosStock Repo { get; set; }
        public CUListadoMovimientosStock(IRepositorioMovimientosStock repo) {
            Repo = repo;
        }
        public List<MovimientoStockDTO> ObtenerListado() {
            List<MovimientoStockDTO> dtos = new List<MovimientoStockDTO>();
            List<MovimientoStock> tmEncontrados = Repo.GetAll();

            if (tmEncontrados.Count > 0) {
                dtos = tmEncontrados.Select(ms => new MovimientoStockDTO() {
                    Id = ms.Id,
                    Fecha = ms.Fecha,
                    Cantidad = ms.Cantidad,
                })
                .ToList();
            }
            return dtos;
        }
    }
}
