using System;
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
            ObjVentasSemanales.btnSiguiente.Click += new EventHandler(AbrirEstadisticasEmpleados);
            ObjVentasSemanales.btnSiguiente.Click += new EventHandler(AbrirEstadisticasDiarias);
        }
        private void AbrirEstadisticasEmpleados(object sender, EventArgs e)
        {
            ObjVentasSemanales.Close();
            VistaEstadisticasVentas vistaEstadisticasVentas = new VistaEstadisticasVentas();
            vistaEstadisticasVentas.ShowDialog();
        }
        private void AbrirEstadisticasDiarias(object sender, EventArgs e)
        {
            ObjVentasSemanales.Close();
            VistaEstadisticasVentasDiarias vistaEstadisticasVentas = new VistaEstadisticasVentasDiarias();
            vistaEstadisticasVentas.ShowDialog();
        }
    }
}
