using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio {
    public class Articulo : IValidar {
        public int Id { get; set; }
        public string? Nombre { get; set; } // no vacio y unico
        public string Descripcion { get; set; } // largo minimo de 5 caracteres
        public int CodigoProveedor { get; set; } // 13 digitos
        public int PrecioActual {  get; set; }
        public int Stock {  get; set; }

        public void EsValido() {
            // TODO
        }
    }
}
