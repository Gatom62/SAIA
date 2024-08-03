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

        private void VistaMenuPrincipal_Load(object sender, EventArgs e)
        {
            if (ControladorTema.IsDarkMode == true)
            {
                bunifuGradientPanel1.BackColor = Color.FromArgb(34, 36, 49);
                bunifuGradientPanel1.GradientTopLeft = Color.FromArgb(34, 36, 49);
                bunifuGradientPanel1.GradientBottomLeft = Color.FromArgb(34, 36, 49);
                bunifuGradientPanel1.GradientBottomRight = Color.FromArgb(34, 36, 49);
                bunifuGradientPanel1.GradientTopRight = Color.FromArgb(34, 36, 49);
                lblhora.ForeColor = Color.White;
                lblfecha.ForeColor = Color.FromArgb(68, 197, 197);
                PanelContenedor.BackColor = Color.FromArgb(18,18,18);
                btnprin2.IdleFillColor = Color.FromArgb(82, 208, 83);
                btnprin1.IdleFillColor = Color.FromArgb(82, 208, 83);
                btn1.IdleFillColor = Color.FromArgb(118, 88, 152);
                btn2.IdleFillColor = Color.FromArgb(118, 88, 152);
                btn3.IdleFillColor = Color.FromArgb(118, 88, 152);
                btn4.IdleFillColor = Color.FromArgb(118, 88, 152);
                btn5.IdleFillColor = Color.FromArgb(118, 88, 152);
                btn6.IdleFillColor = Color.FromArgb(118, 88, 152);
                btn7.IdleFillColor = Color.FromArgb(118, 88, 152);
                btn8.IdleFillColor = Color.FromArgb(118, 88, 152);
                tableLayoutPanel1.BackColor = Color.FromArgb(230, 119, 11);
                btnInicio.BackColor = Color.FromArgb(230, 119, 11);
                btnShop.BackColor = Color.FromArgb(230, 119, 11);
                btnStats.BackColor = Color.FromArgb(230, 119, 11);
                btnAccounts.BackColor = Color.FromArgb(230, 119, 11);
                btnBusqueda.BackColor = Color.FromArgb(230, 119, 11);
            }
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            VistaAjustes vistaAjustes = new VistaAjustes();
            vistaAjustes.ShowDialog();
            this.Close();
        }
    }
}
