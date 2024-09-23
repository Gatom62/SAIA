using AgroServicios.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Vista.Reportes.ReporteProductos
{
    public partial class VistaReporteProductos : Form
    {
        public VistaReporteProductos()
        {
            InitializeComponent();
        }

        private void VistaReporteProductos_Load(object sender, EventArgs e)
        {
            if(ControladorTema.IsDarkMode == true)
            {
                flowLayoutPanel1.BackColor = Color.FromArgb(118,88,152);
            }
            // TODO: esta línea de código carga datos en la tabla 'dataSetProductos.Productos' Puede moverla o quitarla según sea necesario.
            this.productosTableAdapter.LlenarProducto(this.dataSetProductos.Productos);
            // TODO: esta línea de código carga datos en la tabla 'dataSetProductos.Productos' Puede moverla o quitarla según sea necesario.
            this.productosTableAdapter.LlenarProducto(this.dataSetProductos.Productos);

            this.reportViewer1.RefreshReport();
        }
    }
}
