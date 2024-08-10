using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.MenuPrincipal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Controlador.MenuPrincipal
{
    internal class ControladorVistaProductos
    {
        VistaProductos objpro;

        public ControladorVistaProductos(VistaProductos vista)
        {
            objpro = vista;
            objpro.Load += CargarTargets;
        }
        private void CargarTargets(object sender, EventArgs e)
        {
            RellenarProductos();
        }
        private void RellenarProductos()
        {
            DAOTargproductos obj = new DAOTargproductos();
            obj.RellenarTargetas(objpro.flowLayoutPanel1);
        }
    }
}
