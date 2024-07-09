using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgroServicios.Vista.Estadisticas;
using AgroServicios.Vista.MenuPrincipal;
using AgroServicios.Vista.Busqueda;

namespace AgroServicios.Controlador.ControladorStats
{
    internal class ControladorStats
    {
        VistaStats ObjStats;

        /// <summary>
        /// Constructor de la clase ControllerLogin que inicia los eventos de la vista
        /// </summary>
        /// <param name="Estadisticas"></param>
        
        public ControladorStats(VistaStats Estadisticas)
        {
            ObjStats = Estadisticas;
        }

        private void OpenInicio(object sender, EventArgs e)
        {
            VistaMenuPrincipal vistaMenuPrincipal = new VistaMenuPrincipal();
            vistaMenuPrincipal.Show();
            ObjStats.Hide();
        }

        private void OpenBusqueda(object sender, EventArgs e)
        {
            VistaBusqueda vistaBusqueda = new VistaBusqueda();
            vistaBusqueda.Show();
            ObjStats.Hide();
        }
    }
}
