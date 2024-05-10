using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio {
    public class PedidoComun : Pedido, IValidar {
        public int _recargo;
        private int _plazoEstipulado;
        public int Recargo {
            get { return _recargo; }
            set { _recargo = value; }
        } // si Cliente.DistanciaHastaDeposito > 100 ? 5% : 0
        public int PlazoEstipulado { get { return _plazoEstipulado = FechaEntrega.DayNumber - Fecha.DayNumber; } set { _plazoEstipulado = value; } } // > 7 dias

        public override void EsValido() {
            if (PlazoEstipulado < 7) {
                throw new DatosInvalidosException("El plazo de entrega para un pedido común no puede ser menor a 7 días");
            }
        }

        public override void CalcularRecargo() {
            _recargo = Cliente != null && Cliente.DistanciaHastaDeposito > 100 ? 5 : 0;
        }
    }
}
