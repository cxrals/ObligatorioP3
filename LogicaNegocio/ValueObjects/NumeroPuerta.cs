using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects {
    public class NumeroPuerta {
        public string Valor { get; init; }
        private NumeroPuerta() {

        }

        public NumeroPuerta(string valor) {
            Valor = valor;
            Validar();
        }

        private void Validar() {
            if (string.IsNullOrEmpty(Valor))
                throw new Exception("El numero de puerta es obligatorio");
            if (!int.TryParse(Valor, out _))
                throw new Exception("El numero de puerta es obligatorio");
        }
    }
}
