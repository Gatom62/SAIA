using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Estadisticas;
using AgroServicios.Vista.Estadisticas.Devoluciones;
using AgroServicios.Vista.Reportes.ReporteVentas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Controlador.ControladorStats
{
    internal class ControladorHistorialVenta
    {
        VistaHistorialVenta objventa;

        public ControladorHistorialVenta(VistaHistorialVenta Vista)
        {
            objventa = Vista;
            objventa.Load += LlenarGrid;
            objventa.ptbback.Click += new EventHandler(VolverForm);
            objventa.btnReporte.Click += new EventHandler(OpenReporte);
            objventa.btnDevoluciones.Click += OpenDevoluciones;
        }
        private void OpenDevoluciones(object sender, EventArgs e)
        {
            VistaDetallesDevoluciones vistaDetalleDevoluciones = new VistaDetallesDevoluciones();
            vistaDetalleDevoluciones.ShowDialog();
        }
        private void OpenReporte(object sender, EventArgs e)
        {
            VistaReporteVenta vistaReporteVenta = new VistaReporteVenta();
            vistaReporteVenta.ShowDialog();
        }
        private void VolverForm(object sender, EventArgs e)
        {
            // Cierra la vista actual
            objventa.Close();
        }
        private void LlenarGrid(object sender, EventArgs e)
        {
            CargarGrid();
        }
        void CargarGrid()
        {
            DAOHistorialVenta daogrid = new DAOHistorialVenta();
            DataSet ds = daogrid.LlenarDataGriew();
            //Seleccionamos la tabla que mostraremos en el dvgVentas
            objventa.dgvVentas.DataSource = ds.Tables["VistaClienteEmpleado"];
            // Traducir encabezados de las columnas
            TraducirEncabezados(objventa.dgvVentas);
        }
        private void TraducirEncabezados(DataGridView dgv)
        {
            if (ControladorIdioma.idioma == 1)
            {
                dgv.Columns["ID de la venta"].HeaderText = "Sale ID";
                dgv.Columns["Nombre del cliente"].HeaderText = "Client Name";
                dgv.Columns["Nombre del empleado"].HeaderText = "Employee Name";
                dgv.Columns["Fecha de la venta"].HeaderText = "Date of sale";
                dgv.Columns["Monto total"].HeaderText = "Total amount";
            }
            else
            {
                dgv.Columns["ID de la venta"].HeaderText = "ID de la venta";
                dgv.Columns["Nombre del cliente"].HeaderText = "Nombre del cliente";
                dgv.Columns["Nombre del empleado"].HeaderText = "Nombre del empleado";
                dgv.Columns["Fecha de la venta"].HeaderText = "Fecha de la venta";
                dgv.Columns["Monto total"].HeaderText = "Monto total";
            }
        }
    }
}
