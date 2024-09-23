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

namespace AgroServicios.Vista.Estadisticas.Devoluciones
{
    public partial class VistaDevoluciones : Form
    {
        public VistaDevoluciones()
        {
            InitializeComponent();
            ControladorDevoluciones control = new ControladorDevoluciones(this);
        }

        private void VistaDevoluciones_Load(object sender, EventArgs e)
        {
            if(ControladorTema.IsDarkMode == true)
            {
                bunifuGradientPanel2.GradientBottomLeft = Color.FromArgb(34, 36, 49);
                bunifuGradientPanel2.GradientBottomRight = Color.FromArgb(34, 36, 49);
                bunifuGradientPanel2.GradientTopLeft = Color.FromArgb(34, 36, 49);
                bunifuGradientPanel2.GradientTopRight = Color.FromArgb(34, 36, 49);
            }
        }
    }
}
