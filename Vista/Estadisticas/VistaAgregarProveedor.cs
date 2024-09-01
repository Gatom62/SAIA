using AgroServicios.Controlador;
using AgroServicios.Controlador.ControladorStats;
using Bunifu.UI.WinForms;
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
    public partial class VistaAgregarProveedor : Form
    {
        public VistaAgregarProveedor()
        {
            InitializeComponent();
            ControladorCrearProveedor control = new ControladorCrearProveedor(this);
        }

        private void VistaAgregarProveedor_Load(object sender, EventArgs e)
        {
            if (ControladorIdioma.idioma == 1)
            {
                AñaP.Text = Ingles.txtAñaP;
                txtNewFirstName.PlaceholderText = Ingles.txtFN;
                txtNewPhone.PlaceholderText = Ingles.txtTe;
                txtNewCorreo.PlaceholderText = Ingles.txtCR;
                btnAgregarProv.Text = Ingles.btnAP;      
            }
            if (ControladorTema.IsDarkMode == true)
            {
                bunifuGradientPanel2.GradientBottomLeft = Color.FromArgb(118, 88, 152);
                bunifuGradientPanel2.GradientTopRight = Color.FromArgb(118, 88, 152);
                bunifuGradientPanel2.GradientBottomRight = Color.FromArgb(34, 36, 49);
                bunifuGradientPanel2.GradientTopLeft = Color.FromArgb(34, 36, 49);
                bunifuPanel1.BackgroundColor = Color.FromArgb(34, 36, 49);
            }
        }
    }
}
