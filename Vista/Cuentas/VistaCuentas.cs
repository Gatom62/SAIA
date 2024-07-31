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
        public VistaCuentas()
        {
            InitializeComponent();
            ControladorCuentas control = new ControladorCuentas(this);
        }

        private void VistaCuentas_Load(object sender, EventArgs e)
        {
            if(ControladorIdioma.idioma == 1)
            {
                btnAgregar.Text = Ingles.btnañadir;
            }

            if(ControladorTema.IsDarkMode == true)
            {
                GriewEmpleados.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Dark;
                GriewEmpleados.BackgroundColor = Color.FromArgb(50, 56, 62);
            }
        }
    }
}
