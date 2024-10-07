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

namespace AgroServicios.Vista.Reportes.ReporteVentas
{
    public partial class VistaReporteVenta : Form
    {
        public VistaReporteVenta()
        {
            InitializeComponent();
        }

        private void VistaReporteVenta_Load(object sender, EventArgs e)
        {
            if (ControladorTema.IsDarkMode == true)
            {
                Panel12.BackgroundColor = Color.FromArgb(118, 88, 152);
            }
            // TODO: esta línea de código carga datos en la tabla 'dataSetVentas.Ventas' Puede moverla o quitarla según sea necesario.
            this.ventasTableAdapter.Fill(this.dataSetVentas.Ventas);

            this.reportViewer1.RefreshReport();

            if (ControladorIdioma.idioma == 1) 
            {
                label1.Text = Ingles.FichaVentas;
            }
        }
    }
}
