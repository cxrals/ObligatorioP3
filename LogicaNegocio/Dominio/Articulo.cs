using LogicaNegocio.InterfacesDominio;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio {
    //[Index(nameof(Nombre), IsUnique = true)]
    public class Articulo : IValidar {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; } // no vacio y unico
        [RegularExpression(@".{5,}")]
        public string Descripcion { get; set; } // largo minimo de 5 caracteres
        public int CodigoProveedor { get; set; } // 13 digitos
        public int PrecioActual {  get; set; }
        public int Stock {  get; set; }

        public void EsValido() {
            // TODO
        }
    }
}
