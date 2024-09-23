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

        private void VistaActualizarProveedor_Load(object sender, EventArgs e)
        {
            if (ControladorIdioma.idioma == 1)
            {
                cmbMarca.Text = Ingles.txtUp;
                txtUpdateNombre.PlaceholderText = Ingles.txtFN;
                //bunifuLabel2.PlaceholderText = Ingles.txtDUI;
                txtUpdatePhone.PlaceholderText = Ingles.txtTe;
                txtUpdateCorreo.PlaceholderText = Ingles.txtCR;
            
                btnUpdateProveedor.Text = Ingles.btnUP;
            }
            if (ControladorTema.IsDarkMode == true)
            {
                this.BackColor = Color.FromArgb(34, 36, 49);
                btnUpdateProveedor.IdleFillColor = Color.FromArgb(230, 119, 11);
                btnUpdateProveedor.onHoverState.FillColor = Color.FromArgb(211, 41, 15);
                btnUpdateProveedor.onHoverState.BorderColor = Color.FromArgb(211, 41, 15);
                btnUpdateProveedor.OnPressedState.FillColor = Color.Red;
                btnUpdateProveedor.OnPressedState.BorderColor = Color.Red;
                btnUpdateProveedor.DisabledFillColor = Color.DarkOrange;

                pnEstructura.BackgroundColor = Color.WhiteSmoke;

                txtUpdateNombre.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtUpdateNombre.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtUpdatePhone.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtUpdatePhone.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtUpdateCorreo.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtUpdateCorreo.BorderColorActive = Color.FromArgb(211, 41, 15);
            }
        }
    }
}
