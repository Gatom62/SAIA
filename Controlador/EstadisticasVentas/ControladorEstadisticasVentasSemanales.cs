﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgroServicios.Vista.Estadisticas;
using AgroServicios.Vista.Estadisticas.EstadisticasVentas;


namespace AgroServicios.Controlador.EstadisticasVentas
{
    class ControladorEstadisticasVentasSemanales
    {
        VistaEstadisticasVentasSemanales ObjVentasSemanales;
        public ControladorEstadisticasVentasSemanales (VistaEstadisticasVentasSemanales objVentasSemanales)
        {
            ObjVentasSemanales = objVentasSemanales;
        }
    }
}
