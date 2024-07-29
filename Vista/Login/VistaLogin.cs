using System.Reflection;
using System.Windows.Forms;
using AgroServicios.Controlador.Login;
using AgroServicios.Controlador;

namespace AgroServicios.Vista.Login
{
    public partial class VistaLogin : Form
    {
        public VistaLogin()
        {
            InitializeComponent();
            ControladorLogin control = new ControladorLogin(this);
            PasswordHide.Visible = false;

        }

        private void inglesToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (switchidioma.Checked)
            {
                ControladorIdioma.idioma = 1;
            }
            else
            {
                ControladorIdioma.idioma = 0;
            }
            if(ControladorIdioma.idioma == 1)
            {
                lblinicio.Text = Ingles.LabeldeInicio;
            }
        }

        private void switchidioma_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e)
        {
            if (switchidioma.Checked)
            {
                ControladorIdioma.idioma = 1;
            }
            else
            {
                ControladorIdioma.idioma = 0;
            }
            if (ControladorIdioma.idioma == 1)
            {
                lblinicio.Text = Ingles.LabeldeInicio;
                LblUsername.Text = Ingles.user;
                LblPassword.Text = Ingles.contraseña;
                BtnStart.Text = Ingles.BotonInicio;
                txtPassword.PlaceholderText = Ingles.contraseña;
                txtUsername.PlaceholderText = Ingles.user;
                lblRecuperar.Text = Ingles.recuperar;
                menu.Text = Ingles.Menu;
                menuIntegrantes.Text = Ingles.Integrantes;
                menuTest.Text = Ingles.Conexion;

            }

        }
    }
}
