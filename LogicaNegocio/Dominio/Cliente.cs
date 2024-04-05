﻿using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio {
    public class Cliente : IValidar {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public int Rut { get; set; } // 12 digitos
        public string Direccion { get; set; } // calle, numero, ciudad
        public int DistanciaHastaDeposito { get; set; }
        public void EsValido() {
            // TODO
        }
    }
}