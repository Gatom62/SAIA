using System;
using System.Drawing;
using System.Windows.Forms;
using AgroServicios.Controlador;
using AgroServicios.Controlador.ControladorStats;

namespace AgroServicios.Vista.Estadisticas
{
    public partial class VistaStats : Form
    {
        public VistaStats()
        {
            InitializeComponent();
            ControladorStats control = new ControladorStats(this);
        }

        private void VistaStats_Load(object sender, EventArgs e)
        {
            if(ControladorIdioma.idioma == 1)
            {
                btnHistorial.Text = Ingles.HistorialVentas;
                btnProveedores.Text = Ingles.Proveedores;
                btnClientes.Text = Ingles.RegistroVentas;
                btnSuministros.Text = Ingles.Suministros;
            }
            if(ControladorTema.IsDarkMode == true)
            {
                Panel1.BackColor = Color.FromArgb(18, 18, 18);
                btnHistorial.IdleFillColor = Color.FromArgb(118, 88, 152);
                btnProveedores.IdleFillColor = Color.FromArgb(118, 88, 152);
                btnClientes.IdleFillColor = Color.FromArgb(118, 88, 152);
                btnSuministros.IdleFillColor = Color.FromArgb(118, 88, 152);
                btnHistorial.ForeColor = Color.White;
                btnProveedores.ForeColor = Color.White;
                btnClientes.ForeColor = Color.White;
                btnSuministros.ForeColor = Color.White;
            }
        }
    }
}
