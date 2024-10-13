using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgroServicios.Vista.Estadisticas;
using AgroServicios.Vista.Estadisticas.EstadisticasVentas;

namespace AgroServicios.Controlador.EstadisticasVentas
{
    class ControladorEstadisticasVentasDirias
    {
        VistaEstadisticasVentasDiarias ObjVistaDiarias;

        public ControladorEstadisticasVentasDirias (VistaEstadisticasVentasDiarias Vista)
        {
            ObjVistaDiarias = Vista;
            ObjVistaDiarias.btnSiguiente.Click += new EventHandler(AbrirEstadisticasSemanales);
            ObjVistaDiarias.btnAtras.Click += new EventHandler(AbrirEstadisticasEmpleados);
        }
        private void AbrirEstadisticasEmpleados(object sender, EventArgs e)
        {
            ObjVistaDiarias.Close();
            VistaEstadisticasVentas vistaEstadisticasVentas = new VistaEstadisticasVentas();
            vistaEstadisticasVentas.ShowDialog();
        }
        private void AbrirEstadisticasSemanales(object sender, EventArgs e)
        {
            ObjVistaDiarias.Close();
            VistaEstadisticasVentasSemanales vistaEstadisticasVentasSemanales = new VistaEstadisticasVentasSemanales();
            vistaEstadisticasVentasSemanales.ShowDialog();
        }
    }
}
