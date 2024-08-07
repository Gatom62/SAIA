using System.Reflection;
using System.Windows.Forms;
using AgroServicios.Controlador.Login;
using AgroServicios.Controlador;
using System.Drawing;

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
            else
            {
                lblinicio.Text = Spanish.BotonInicio;
                LblUsername.Text = Spanish.user;
                LblPassword.Text = Spanish.contraseña;
                BtnStart.Text = Spanish.BotonInicio;
                txtPassword.PlaceholderText = Spanish.contraseña;
                txtUsername.PlaceholderText= Spanish.user;
                menu.Text= Spanish.Menu;
                menuIntegrantes.Text = Spanish.integrantes;
                menuTest.Text = Spanish.conexion;
                lblRecuperar.Text = Spanish.recuperar;
            }

        }

        private void DarkMode_CheckedChanged(object sender, System.EventArgs e)
        {
            if (DarkMode.Checked)
            {
                ControladorTema.IsDarkMode = true;
            }
            else
            {
                ControladorTema.IsDarkMode= false;
            }
            if (DarkMode.Checked == true)
            {
                this.BackColor = Color.FromArgb(34, 36, 49);
                LblPassword.ForeColor = Color.FromArgb(188, 88, 152);
                LblUsername.ForeColor = Color.FromArgb(188, 88, 152);
                lblinicio.ForeColor = Color.FromArgb(230, 119, 11);
                BtnStart.IdleFillColor = Color.FromArgb(82, 208, 83);
                Firstpanel.BorderColor = Color.FromArgb(211, 41, 15);
                txtPassword.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtUsername.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtPassword.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtUsername.BorderColorActive = Color.FromArgb(211, 41, 15);
                BtnStart.onHoverState.FillColor = Color.FromArgb(211, 41, 15);
                BtnStart.onHoverState.BorderColor = Color.FromArgb(211, 41, 15);
                BtnStart.OnPressedState.FillColor = Color.Red;
                BtnStart.OnPressedState.BorderColor = Color.Red;
            }
            else
            {
                this.BackColor = Color.LightSkyBlue;
                LblPassword.ForeColor = Color.FromArgb(68, 197, 197);
                LblUsername.ForeColor = Color.FromArgb(68, 197, 197);
                lblinicio.ForeColor = Color.FromArgb(228, 174, 34);
                BtnStart.IdleFillColor = Color.LawnGreen;
                Firstpanel.BorderColor = Color.Black;
                txtPassword.BorderColorHover = Color.FromArgb(105, 181, 255);
                txtUsername.BorderColorHover = Color.FromArgb(105, 181, 255);
                txtPassword.BorderColorActive = Color.FromArgb(105, 181, 255);
                txtUsername.BorderColorActive = Color.FromArgb(105, 181, 255);
                BtnStart.onHoverState.FillColor = Color.FromArgb(105, 181, 255);
                BtnStart.onHoverState.BorderColor = Color.FromArgb(105, 181, 255);
                BtnStart.OnPressedState.FillColor = Color.FromArgb(40, 96, 144);
                BtnStart.OnPressedState.BorderColor = Color.FromArgb(40, 96, 144);
            }
        }

        private void VistaLogin_Load(object sender, System.EventArgs e)
        {
            if(ControladorIdioma.idioma == 0)
            {
                switchidioma.Checked = false;
            }
            else 
            { 
                switchidioma.Checked = true;
            }

            if(ControladorTema.IsDarkMode == false)
            {
                DarkMode.Checked = false;
            }
            else
            {
                DarkMode.Checked = true;
            }
        }
    }
}
