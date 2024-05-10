using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio {
    public class PedidoExpress : Pedido, IValidar {
        private int _recargo;
        private int _plazoEstipulado;
        public int Recargo {
            get { return _recargo; }
            set { _recargo = value; }
        } // si plazo = 1 ? 15% : 10%
        public int PlazoEstipulado { get { return _plazoEstipulado = FechaEntrega.DayNumber - Fecha.DayNumber; } set { _plazoEstipulado = value; } } // <= 5

        public override void EsValido() {
            if (PlazoEstipulado > 5) {
                throw new DatosInvalidosException("El plazo de entrega para un pedido express no puede ser mayor a 5 días");
            }
        }

        public override void CalcularRecargo() {
            _recargo = PlazoEstipulado == 1 ? 15 : 10;
        }
    }
}
