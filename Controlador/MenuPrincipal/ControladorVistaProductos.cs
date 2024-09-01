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
            objpro.txtBuscarP.KeyPress += BuscarProducto_KeyPress; // Evento para el TextBox de búsqueda
        }
        private void CargarTargets(object sender, EventArgs e)
        {
            RellenarProductos();
        }
        private void RellenarProductos(string filtro = "")
        {
            DAOTargproductos obj = new DAOTargproductos();
            obj.RellenarTargetas(objpro.flowLayoutPanel1, filtro);
        }
        private void BuscarProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificamos si la tecla presionada es Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Para evitar el sonido de "ding" por defecto al presionar Enter en un TextBox
                string filtro = objpro.txtBuscarP.Text.Trim(); // Obtener el texto del TextBox de búsqueda
                RellenarProductos(filtro); // Recargar los productos filtrados
            }
        }
    }
}
