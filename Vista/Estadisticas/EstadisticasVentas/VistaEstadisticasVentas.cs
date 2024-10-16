using AgroServicios.Controlador;
using AgroServicios.Controlador.EstadisticasVentas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Vista.Estadisticas.EstadisticasVentas
{
    public partial class VistaEstadisticasVentas : Form
    {
        private Size originalSize;
        public VistaEstadisticasVentas()
        {
            InitializeComponent();
            ControladorEstadisticasEmpleados controladorEstadisticasEmpleados = new ControladorEstadisticasEmpleados(this);
        }
        
        private void VistaEstadisticasVentas_Load(object sender, EventArgs e)
        {
            if (ControladorTema.IsDarkMode == true) 
            {
                this.BackColor = Color.FromArgb(34, 36, 49);
                pnEstructura.BackgroundColor = Color.WhiteSmoke;
            }

            if (ControladorIdioma.idioma == 1) 
            {
                lbVentasEchasPorEmpleados.Text = Ingles.VentasEchasPorEmpleados;
            }
        }
    }
}
