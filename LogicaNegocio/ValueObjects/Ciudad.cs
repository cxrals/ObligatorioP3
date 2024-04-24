using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects {
    public class Ciudad {
        public string Valor { get; init; }
        private Ciudad() {
            
        }

        public Ciudad(string valor) {
            Valor = valor;
            Validar();
        }

        private void Validar() {
            if (string.IsNullOrEmpty(Valor))
                throw new Exception("El nombre de la ciudad es obligatorio");
        }
    }
}
