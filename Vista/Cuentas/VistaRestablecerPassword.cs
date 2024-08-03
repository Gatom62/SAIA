using AgroServicios.Controlador;
using AgroServicios.Controlador.CuentasContralador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Vista.Cuentas
{
    public partial class VistaRestablecerPassword : Form
    {
        public VistaRestablecerPassword(string usuario)
        {
            InitializeComponent();
            ControladorRestUser control = new ControladorRestUser(this, usuario);
        }

        private void VistaRestablecerPassword_Load(object sender, EventArgs e)
        {
            if (ControladorTema.IsDarkMode == true)
            {
                bunifuGradientPanel2.GradientBottomLeft = Color.FromArgb(118, 88, 152);
                bunifuGradientPanel2.GradientTopRight = Color.FromArgb(34, 36, 49);
                bunifuGradientPanel2.GradientBottomRight = Color.FromArgb(118, 88, 152);
                bunifuGradientPanel2.GradientTopLeft = Color.FromArgb(34, 36, 49);
            }
        }
    }
}
