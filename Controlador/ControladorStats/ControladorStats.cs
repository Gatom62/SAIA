using System;
using AgroServicios.Vista.Estadisticas;

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
            ObjStats.btnAbrirProveedores.Click += new EventHandler(OpenProveedores);
            ObjStats.btnAbrirSuministros.Click += new EventHandler(OpenSuministros);
        }

        private void OpenProveedores(object sender, EventArgs e)
        {
            VistaProveedores vistaProveedores = new VistaProveedores();
            vistaProveedores.ShowDialog();
        }

        private void OpenSuministros(object sender, EventArgs e)
        {
          VistaSuministros vistaSuministros = new VistaSuministros();
            vistaSuministros.ShowDialog();
        }
    }
}
