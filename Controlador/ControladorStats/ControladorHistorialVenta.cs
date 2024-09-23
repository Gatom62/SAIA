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

            objventa.dgvVentas.DataSource = ds.Tables["VistaClienteEmpleado"];
        }
    }
}
