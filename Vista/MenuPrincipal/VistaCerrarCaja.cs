using AgroServicios.Controlador;
using AgroServicios.Controlador.MenuPrincipal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Vista.MenuPrincipal
{
    public partial class VistaCerrarCaja : Form
    {
        public VistaCerrarCaja()
        {
            InitializeComponent();
            ControladorCerrarCaja control = new ControladorCerrarCaja(this);
        }

        private void VistaCerrarCaja_Load(object sender, EventArgs e)
        {
            if (ControladorTema.IsDarkMode == true)
            {
                tableLayoutPanel2.BackColor = Color.FromArgb(118, 88, 152);
                label1.ForeColor = Color.White;
                

                btnCerrarCaja.IdleFillColor = Color.FromArgb(230, 119, 11);
                btnCerrarCaja.onHoverState.FillColor = Color.FromArgb(211, 41, 15);
                btnCerrarCaja.onHoverState.BorderColor = Color.FromArgb(211, 41, 15);
                btnCerrarCaja.OnPressedState.FillColor = Color.Red;
                btnCerrarCaja.OnPressedState.BorderColor = Color.Red;
                btnCerrarCaja.DisabledFillColor = Color.DarkOrange;
                dgvCierre.BackgroundColor = Color.FromArgb(52, 54, 62);
                dgvCierre.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Dark;

            }
            if (ControladorIdioma.idioma == 1)
            {
                label1.Text = "Cash closing";
                btnCerrarCaja.Text = "Close cash register";
                
            }
        }
    }
}
