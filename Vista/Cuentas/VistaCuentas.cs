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
using AgroServicios.Controlador.CuentasContralador;

namespace AgroServicios.Vista.Cuentas
{
    public partial class VistaCuentas : Form
    {
        private Size originalSize;
        public VistaCuentas()
        {
            InitializeComponent();
            ControladorCuentas control = new ControladorCuentas(this);
        }
        private void VistaCuentas_Load(object sender, EventArgs e)
        {
            if(ControladorIdioma.idioma == 1)
            {
                label1.Text = "Accounts";
                txtBuscarP.PlaceholderText = "Look for";
                btnAgregar.Text = Ingles.btnañadir;
                cmsEliminar.Text = Ingles.CMSELIMINAR;
                cmsinfo.Text = Ingles.CMSINFO;
                cmsRestablecer.Text = Ingles.CMSREST;
                cmsUpdate.Text = Ingles.CMSUPDT;
            }

            if(ControladorTema.IsDarkMode == true)
            {
                tableLayoutPanel1.BackColor = Color.FromArgb(118, 88, 152);
                GriewEmpleados.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Dark;
                GriewEmpleados.BackgroundColor = Color.FromArgb(50, 56, 62);

                btnAgregar.IdleFillColor = Color.DarkBlue;
                btnAgregar.onHoverState.FillColor = Color.DarkViolet;
                btnAgregar.onHoverState.BorderColor = Color.DarkViolet;
                btnAgregar.OnPressedState.FillColor = Color.DodgerBlue;
                btnAgregar.OnPressedState.BorderColor = Color.DodgerBlue;
                btnAgregar.DisabledFillColor = Color.DarkViolet;

                btnAgregar.DisabledFillColor = Color.FromArgb(118, 88, 152);
                btnAgregar.ForeColor = Color.White;
            }
        }
    }
}
