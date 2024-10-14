using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgroServicios.Vista.Estadisticas;
using AgroServicios.Vista.Estadisticas.EstadisticasVentas;

namespace AgroServicios.Controlador.EstadisticasVentas
{
    class ControladorMostrarEstadisticas
    {
        VistaMostrarEstadisticas ObjMostrarEstadisticas;
        Form currentForm;
        public ControladorMostrarEstadisticas (VistaMostrarEstadisticas Vista)
        {
            ObjMostrarEstadisticas = Vista;
            ObjMostrarEstadisticas.btnEstadisticasUsuarios.Click += new EventHandler(MostrarEstadisticasUsuarios);
            ObjMostrarEstadisticas.btnEstadisticasVentasDiarias.Click += new EventHandler(MostrarEstadisticasVentasDiarias);
            ObjMostrarEstadisticas.btnEstadisticasVentasSemanales.Click += new EventHandler(MostrarEstadisticasVentasSemanales);
        }

        private void MostrarEstadisticasUsuarios(object sender, EventArgs e) 
        {
           VistaEstadisticasVentas vistaEstadisticasVentas = new VistaEstadisticasVentas();
            vistaEstadisticasVentas.Show();
        }

        private void MostrarEstadisticasVentasDiarias(object sender, EventArgs e)
        {
            VistaEstadisticasVentasDiarias vistaEstadisticasVentasDiarias = new VistaEstadisticasVentasDiarias();
            vistaEstadisticasVentasDiarias.Show();
        }

        private void MostrarEstadisticasVentasSemanales(object sender, EventArgs e)
        {
            VistaEstadisticasVentasSemanales vistaEstadisticasVentasSemanales = new VistaEstadisticasVentasSemanales();
            vistaEstadisticasVentasSemanales.Show();
        }
    }
}
