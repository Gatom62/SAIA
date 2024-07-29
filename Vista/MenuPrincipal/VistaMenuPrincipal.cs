using System;

using System.Globalization;
using System.Windows.Forms;
using AgroServicios.Controlador.Login;
using AgroServicios.Controlador.MenuPrincipal;
using AgroServicios.Controlador;

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
            lblhora.Text = DateTime.Now.ToString("hh:mm:ss");

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

    }
}
