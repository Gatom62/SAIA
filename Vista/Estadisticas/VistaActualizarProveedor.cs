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
    public partial class VistaActualizarProveedor : Form
    {

        public VistaActualizarProveedor(int accion, int id, string Name, string Dui, string phone, string email,  string marca)
        {
            InitializeComponent();
            ControladorActualizarProveedor control = new ControladorActualizarProveedor(this, accion, id, Name, Dui, phone, email, marca);
        }


        private void PickerBirthUpdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuGradientPanel1_Click(object sender, EventArgs e)
        {

        }

        private void VistaActualizarProveedor_Load(object sender, EventArgs e)
        {
            if (ControladorIdioma.idioma == 1)
            {
                txtAcP.Text = Ingles.txtUp;
                txtUpdateNombre.PlaceholderText = Ingles.txtFN;
                txtUpdateID.PlaceholderText = Ingles.txtDUI;
                txtUpdatePhone.PlaceholderText = Ingles.txtTe;
                txtUpdateCorreo.PlaceholderText = Ingles.txtCR;
            
                btnUpdateProveedor.Text = Ingles.btnUP;
            }
            if (ControladorTema.IsDarkMode == true)
            {
                bunifuGradientPanel1.GradientBottomLeft = Color.FromArgb(118, 88, 152);
                bunifuGradientPanel1.GradientTopRight = Color.FromArgb(118, 88, 152);
                bunifuGradientPanel1.GradientBottomRight = Color.FromArgb(34, 36, 49);
                bunifuGradientPanel1.GradientTopLeft = Color.FromArgb(34, 36, 49);
                bunifuPanel1.BackgroundColor = Color.FromArgb(34, 36, 49);
            }
        }
    }
}
