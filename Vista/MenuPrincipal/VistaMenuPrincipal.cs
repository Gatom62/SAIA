using System;

using System.Globalization;
using System.Windows.Forms;
using AgroServicios.Controlador.Login;
using AgroServicios.Controlador.MenuPrincipal;
using AgroServicios.Controlador;
using System.Drawing;
using Newtonsoft.Json.Linq;

namespace AgroServicios.Vista.MenuPrincipal
{
    public partial class VistaMenuPrincipal : Form
    {
        public Control[] OriginalControls { get; private set; }

        public VistaMenuPrincipal()
        {
            InitializeComponent();
            ControladorMenuPrincipal control = new ControladorMenuPrincipal(this);
            // Guarda el estado original de los controles en PanelView
            OriginalControls = new Control[PanelContenedor.Controls.Count];
            PanelContenedor.Controls.CopyTo(OriginalControls, 0);
        }

        private void horafecha_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("hh:mm:ss tt"); // "tt" agrega AM/PM

            if (ControladorIdioma.idioma == 1) // Inglés
            {
                CultureInfo cultureInfo = new CultureInfo("en-US");
                lblfecha.Text = DateTime.Now.ToString("D", cultureInfo);
            }
            else // Español
            {
                lblfecha.Text = DateTime.Now.ToLongDateString();
            }
        }


        private void VistaMenuPrincipal_Load(object sender, EventArgs e)
        {
            if (ControladorTema.IsDarkMode == true)
            {
                panel1.BackColor = Color.FromArgb(34, 36, 49);
                lblhora.ForeColor = Color.White;
                lblfecha.ForeColor = Color.FromArgb(68, 197, 197);
                PanelContenedor.BackColor = Color.FromArgb(18,18,18);
                btnprin2.IdleFillColor = Color.FromArgb(82, 208, 83);
               
                tableLayoutPanel1.BackColor = Color.FromArgb(230, 119, 11);
                btnInicio.BackColor = Color.FromArgb(230, 119, 11);
                btnShop.BackColor = Color.FromArgb(230, 119, 11);
                btnStats.BackColor = Color.FromArgb(230, 119, 11);
                btnAccounts.BackColor = Color.FromArgb(230, 119, 11);
                btnBusqueda.BackColor = Color.FromArgb(230, 119, 11);

                bunifuPanel2.BackgroundColor = Color.FromArgb(34, 36, 49);
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.FromArgb(68, 197, 197);
            }
        }
        private void btnConfi_Click_1(object sender, EventArgs e)
        {
            VistaAjustes vistaAjustes = new VistaAjustes();
            vistaAjustes.ShowDialog();
            this.Close();
        }
    }
}
