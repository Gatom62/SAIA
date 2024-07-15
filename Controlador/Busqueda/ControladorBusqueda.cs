using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgroServicios.Vista.Busqueda;
using AgroServicios.Vista.MenuPrincipal;
using AgroServicios.Vista.Estadisticas;
using System.Data;
using System.Windows.Forms;
using AgroServicios.Modelo.DAO;

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
            ObjBusqueda.txtBuscar.TextChanged += new EventHandler(BuscarProducto);
        }

        private void BuscarProducto(object sender, EventArgs e)
        {
            string criterio = ObjBusqueda.txtBuscar.Text.Trim();
            DAOAdminUsers daoBuscar = new DAOAdminUsers();
            DataTable dataTable = daoBuscar.BuscarProducto(criterio);
            ObjBusqueda.GriewViewBuscar.DataSource = dataTable;
        }
    }
}
