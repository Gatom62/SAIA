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
        public VistaRestablecerPassword(string usuario, string role)
        {
            InitializeComponent();
            ControladorRestUser control = new ControladorRestUser(this, usuario, role);
        }
        private void VistaRestablecerPassword_Load(object sender, EventArgs e)
        {
            if (ControladorTema.IsDarkMode == true)
            {
                this.BackColor = Color.FromArgb(34, 36, 49);
                btnRestablecer.IdleFillColor = Color.FromArgb(230, 119, 11);
                btnRestablecer.onHoverState.FillColor = Color.FromArgb(211, 41, 15);
                btnRestablecer.onHoverState.BorderColor = Color.FromArgb(211, 41, 15);
                btnRestablecer.OnPressedState.FillColor = Color.Red;
                btnRestablecer.OnPressedState.BorderColor = Color.Red;
                btnRestablecer.DisabledFillColor = Color.DarkOrange;

                bunifuPanel1.BackColor = Color.WhiteSmoke;

                txtRest.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtRest.BorderColorActive = Color.FromArgb(211, 41, 15);

                txtRestPass.PlaceholderForeColor = Color.Silver;
                txtRestPass.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtRestPass.BorderColorActive = Color.FromArgb(211, 41, 15);
            }

            if(ControladorIdioma.idioma == 1)
            {
                LabelPrin.Text = Ingles.ActualizarContra;
                txtRestPass.PlaceholderText = Ingles.contraseña;
                btnRestablecer.Text = Ingles.ActualizarContra;
            }
        }
    }
}
