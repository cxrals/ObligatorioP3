using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects {
    public class Calle {
        public string Valor { get; init; }
        private Calle() {

        }

        public Calle(string valor) {
            Valor = valor;
            Validar();
        }

        private void Validar() {
            if (string.IsNullOrEmpty(Valor))
                throw new Exception("El nombre de la calle es obligatorio");
        }
    }
}
