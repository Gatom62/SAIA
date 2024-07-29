using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                btnRegistroVentas.Text = Ingles.RegistroVentas;
                btnSuministros.Text = Ingles.Suministros;
            }
        }
    }
}
