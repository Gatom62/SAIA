using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Estadisticas;
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
