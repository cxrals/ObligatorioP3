using LogicaNegocio.InterfacesDominio;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace LogicaNegocio.Dominio {
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario : IValidar {
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; } // unico, aplicar formateado
        [RegularExpression(@"^[A-Za-z][A-Za-z' -]*[A-Za-z]$")]
        public string Nombre { get; set; }
        [RegularExpression(@"^[A-Za-z][A-Za-z' -]*[A-Za-z]$")]
        public string Apellido { get; set; }
        [MinLength(6)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[.!;]).{6,}$")]
        public string Contraseña { get; set; } // min 6 char, mayuscula, minuscula, char especial (punto, punto y coma, coma, signo de admiración de cierre)

        public void EsValido() {
            // TODO
        }

        private Boolean ValidarContraseña(String contraseña) {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasMinimum6Chars = new Regex(@".{6,}");
            var hasSymbols = new Regex(@"[!;,.?]");

            return hasNumber.IsMatch(contraseña) && hasUpperChar.IsMatch(contraseña);
        }
    }
}
