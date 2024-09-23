using AgroServicios.Vista.MenuPrincipal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroServicios.Controlador.Login
{
    class ControladorZoom
    {
        VistaZoomProduct ObjZoom;

        public ControladorZoom(VistaZoomProduct vista){
            ObjZoom = vista;
            ObjZoom.ptbback.Click += new EventHandler(Salir);
        }

        private void Salir(object sender, EventArgs e)
        {
            // Cierra la vista actual
            ObjZoom.Close();
        }
    }
}
