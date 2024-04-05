using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio {
    public class Usuario : IValidar {
        public int Id { get; set; }
        public string Email { get; set; } // unico, aplicar formateado
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contraseña { get; set; } // min 6 char, mayuscula, minuscula, char especial 

        public void EsValido() {
            // TODO
        }
    }
}
