﻿using DataTransferObjects;
using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso {
    public interface ICUBuscarPorFechaPedido {
        List<PedidoNoEntregadoDTO> BuscarPorFechaPedido(DateOnly fecha);
    }
}
