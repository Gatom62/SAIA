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
                // Validar que la fecha de inicio no sea mayor que la fecha final
                if (objfecha.dtpinicio.Value.Date > objfecha.dtpfinal.Value.Date)
                {
                    MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha final.", "Error de fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
                    TraducirEncabezados(objfecha.GriewFiltroV);
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
        private void TraducirEncabezados(DataGridView dgv)
        {
            if (ControladorIdioma.idioma == 1)
            {
                dgv.Columns[0].HeaderText = "Sale ID";
                dgv.Columns[1].HeaderText = "Customer name";
                dgv.Columns[2].HeaderText = "Employee name";
                dgv.Columns[3].HeaderText = "Sale date";
                dgv.Columns[4].HeaderText = "Total amount";
            }
        }
    }
}
