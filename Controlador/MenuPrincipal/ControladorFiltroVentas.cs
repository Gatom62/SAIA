using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.MenuPrincipal;
using AgroServicios.Vista.Notificación;

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
        void MessageBoxP(Color backcolor, Color color, string title, string text, Image icon)
        {
            AlertExito frm = new AlertExito();

            frm.BackColorAlert = backcolor;

            frm.ColorAlertBox = color;

            frm.TittlAlertBox = title;

            frm.TextAlertBox = text;

            frm.IconeAlertBox = icon;

            frm.ShowDialog();
        }
        private void FiltrarVentas(object sender, EventArgs e)
        {
            try
            {
                // Validar que la fecha de inicio no sea mayor que la fecha final
                if (objfecha.dtpinicio.Value.Date > objfecha.dtpfinal.Value.Date)
                {
                    if (ControladorIdioma.idioma == 1)
                    {
                        MessageBoxP(Color.Yellow, Color.Orange, "Error", "The start date cannot be greater than the end date.", Properties.Resources.MensajeWarning);
                    }
                    else
                    {
                        MessageBoxP(Color.Yellow, Color.Orange, "Error", "La fecha de inicio no puede ser mayor que la fecha final.", Properties.Resources.MensajeWarning);
                    }
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
                }
                else
                {
                    // Si no hay datos, muestra un mensaje al usuario
                    if (ControladorIdioma.idioma == 1)
                    {
                        MessageBoxP(Color.Yellow, Color.Orange, "No results", "No sales were found for the selected date range.", Properties.Resources.MensajeWarning);
                    }
                    else
                    {
                        MessageBoxP(Color.Yellow, Color.Orange, "Sin resultados", "No se encontraron ventas para el rango de fechas seleccionado.", Properties.Resources.MensajeWarning);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Error", "An error occurred while filtering sales: " + ex.Message, Properties.Resources.MensajeWarning);
                }
                else 
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Error", "Ocurrió un error al filtrar las ventas: " + ex.Message, Properties.Resources.MensajeWarning);
                }
            }
        }
    }
}
