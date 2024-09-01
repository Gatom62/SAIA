using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.MenuPrincipal;

namespace AgroServicios.Controlador.MenuPrincipal
{
    internal class ControladorFiltroVentas
    {
        VistaVentasPorFecha objfecha;

        public ControladorFiltroVentas(VistaVentasPorFecha vista)
        {
            objfecha = vista;
            objfecha.btnBuscar.Click += FiltrarVentas;
        }

        private void FiltrarVentas(object sender, EventArgs e)
        {
            try
            {
                // Crear una instancia del DAO y establecer las fechas
                DAOFiltroVentas dao = new DAOFiltroVentas
                {
                    Fechadeinicio = objfecha.dtpinicio.Value.Date,
                    Fechafinal = objfecha.dtpfinal.Value.Date.AddDays(1).AddTicks(-1) // Asegura incluir todo el final del día
                };

                // Obtener el DataSet desde el DAO
                DataSet ds = dao.FiltrarVenta();

                // Limpiar el DataSource antes de asignar uno nuevo
                objfecha.GriewFiltroV.DataSource = null;

                // Asignar el DataSet al DataGridView si tiene datos
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    objfecha.GriewFiltroV.DataSource = ds.Tables[0];
                }
                else
                {
                    // Si no hay datos, muestra un mensaje al usuario
                    MessageBox.Show("No se encontraron ventas para el rango de fechas seleccionado.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show("Ocurrió un error al filtrar las ventas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
