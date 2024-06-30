using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgroServicios.Vista.MenuPrincipal;
using AgroServicios.Vista.Estadisticas;
using AgroServicios.Vista.Busqueda;

namespace AgroServicios.Controlador.MenuPrincipal
{
    public class ControladorMenuPrincipal
    {
        VistaMenuPrincipal ObjMenu;
        /// <summary>
        /// Constructor de la clase ControllerLogin que inicia los eventos de la vista
        /// </summary>
        /// <param name="Menu"></param>
        /// 
        public ControladorMenuPrincipal(VistaMenuPrincipal Menu)
        {
            ObjMenu = Menu;
            ObjMenu.BtnExit.Click += new EventHandler(QuitApplication);
            ObjMenu.btnStats.Click += new EventHandler(OpenStats);
            ObjMenu.btnBusqueda.Click += new EventHandler(OpenBusqueda);
        }
        private void QuitApplication(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void OpenStats(object sender, EventArgs e)
        {
            VistaStats vistaEstadisticas = new VistaStats();
            vistaEstadisticas.Show();
            ObjMenu.Hide();
        }

        private void OpenBusqueda(object sender, EventArgs e)
        {
            VistaBusqueda vistaBusqueda = new VistaBusqueda();
            vistaBusqueda.Show();
            ObjMenu.Hide();
        }
    }
}
