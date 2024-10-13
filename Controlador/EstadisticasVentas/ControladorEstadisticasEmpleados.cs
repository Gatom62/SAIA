using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgroServicios.Vista.Estadisticas;
using AgroServicios.Vista.Estadisticas.EstadisticasVentas;

namespace AgroServicios.Controlador.EstadisticasVentas
{
    class ControladorEstadisticasEmpleados
    {
        VistaEstadisticasVentas ObjEstadisticasVentas;

        public ControladorEstadisticasEmpleados (VistaEstadisticasVentas vista)
        {
            ObjEstadisticasVentas = vista;
            ObjEstadisticasVentas.btnSiguiente.Click += new EventHandler(AbrirEstadisticasDiarias);
            ObjEstadisticasVentas.btnAtras.Click += new EventHandler(AbrirEstadisticasSemanales);
        }
        private void AbrirEstadisticasDiarias(object sender, EventArgs e) 
        {
            ObjEstadisticasVentas.Close();
            VistaEstadisticasVentasDiarias vistaEstadisticasVentas = new VistaEstadisticasVentasDiarias();
            vistaEstadisticasVentas.ShowDialog();
        }

        private void AbrirEstadisticasSemanales(object sender, EventArgs e) 
        {
            ObjEstadisticasVentas.Close();
            VistaEstadisticasVentasSemanales vistaEstadisticasVentasSemanales = new VistaEstadisticasVentasSemanales();
            vistaEstadisticasVentasSemanales.ShowDialog();
        }
    }
}
