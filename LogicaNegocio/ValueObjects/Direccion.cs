using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects {
    [Owned]
    public class Direccion {
        public Calle Calle { get; set; }
        public NumeroPuerta NumeroPuerta { get; set; }
        public Ciudad Ciudad { get; set; }

        private Direccion() {
            
        }

        public Direccion(Calle calle, NumeroPuerta nroPuerta, Ciudad ciudad) {
            Calle = calle;
            NumeroPuerta = nroPuerta;
            Ciudad = ciudad;
        }
    }
}
