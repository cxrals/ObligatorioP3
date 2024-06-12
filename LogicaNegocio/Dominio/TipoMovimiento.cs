using LogicaNegocio.InterfacesDominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio {
    [Index(nameof(Nombre), IsUnique = true)]
    public class TipoMovimiento : IValidar {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public void EsValido() {
            throw new NotImplementedException();
        }
    }
}
