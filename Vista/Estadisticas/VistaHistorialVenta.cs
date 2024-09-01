using AgroServicios.Controlador;
using AgroServicios.Controlador.ControladorStats;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Vista.Estadisticas
{
    public partial class VistaHistorialVenta : Form
    {
        public VistaHistorialVenta()
        {
            InitializeComponent();
            ControladorHistorialVenta control = new ControladorHistorialVenta(this);
        }

        private void VistaHistorialVenta_Load(object sender, EventArgs e)
        {
            if(ControladorTema.IsDarkMode == true)
            {
                tableLayoutPanel1.BackColor = Color.FromArgb(118, 88, 152);
                dgvVentas.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Dark;
            }
        }
    }
}
