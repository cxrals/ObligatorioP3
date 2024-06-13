using LogicaNegocio.Excepciones;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio {
    public class MovimientoStock : IValidar {
        private DateTime _fecha = DateTime.Now;
        public int Id { get; set; }
        public DateTime Fecha { get { return _fecha; } set { _fecha = value; } }
        public Articulo Articulo { get; set; }
        public Usuario Usuario { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }
        public int Cantidad { get; set; }

        public void EsValido() {
            if (Cantidad < 0) {
                throw new DatosInvalidosException("La cantidad no puede ser negativa.");
            }
        }
    }
}
