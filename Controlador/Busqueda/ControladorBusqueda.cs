using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgroServicios.Vista.Busqueda;
using AgroServicios.Vista.MenuPrincipal;
using AgroServicios.Vista.Estadisticas;

namespace AgroServicios.Controlador.Busqueda
{
    public class ControladorBusqueda
    {
        VistaBusqueda ObjBusqueda;

        /// <summary>
        /// Constructor de la clase ControllerLogin que inicia los eventos de la vista
        /// </summary>
        /// <param name="Busqueda"></param>
        /// 

       public ControladorBusqueda(VistaBusqueda Busqueda)
        {
            ObjBusqueda = Busqueda;
            ObjBusqueda.btnInicio.Click += new EventHandler(OpenInicio);
            ObjBusqueda.btnStats.Click += new EventHandler(OpenStats);

        }

        private void OpenInicio(object sender, EventArgs e)
        {
            VistaMenuPrincipal vistaMenuPrincipal = new VistaMenuPrincipal();
            vistaMenuPrincipal.Show();
            ObjBusqueda.Hide();
        }

        private void OpenStats(object sender, EventArgs e)
        {
            VistaStats vistaStats = new VistaStats();
            vistaStats.Show();
            ObjBusqueda.Hide();
        }
    }
}
