using System.Reflection;
using System.Windows.Forms;
using AgroServicios.Controlador.Login;
using AgroServicios.Controlador;
using System.Drawing;
using System.Runtime.InteropServices;
using System;
using Bunifu.UI.WinForms;

namespace AgroServicios.Vista.Login
{
    public partial class VistaLogin : Form
    {
        private Size originalSize;

        // Importar las funciones de la API de Windows para aplicar bordes redondeados
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,      // X-coordinate of upper-left corner
            int nTopRect,       // Y-coordinate of upper-left corner
            int nRightRect,     // X-coordinate of lower-right corner
            int nBottomRect,    // Y-coordinate of lower-right corner
            int nWidthEllipse,  // Width of ellipse
            int nHeightEllipse  // Height of ellipse
        );
        public VistaLogin()
        {
            InitializeComponent();
            ControladorLogin control = new ControladorLogin(this);
            PasswordVisible.Visible = false;

            // Aplicar el borde redondeado al formulario
            this.FormBorderStyle = FormBorderStyle.None; // Deshabilitar el borde normal del formulario
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 30, 30));
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
                cmsConecarBase.Text = Ingles.ConexcionBase;
                txtPassword.PlaceholderText = Ingles.contraseña;
                txtUsername.PlaceholderText = Ingles.user;
                lblRecuperar.Text = Ingles.recuperar;
                menu.Text = Ingles.Menu;
                menuTest.Text = Ingles.Conexion;
                cmsManualUsuario.Text = "Open user manual";
                cmsManualTecnico.Text = "Open technical manual";
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
                menuTest.Text = Spanish.conexion;
                lblRecuperar.Text = Spanish.recuperar;
                cmsManualUsuario.Text = "Abrir manual de usuario";
                cmsManualTecnico.Text = "Abrir manual técnico";
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
                Firstpanel.BackgroundColor = Color.WhiteSmoke;
                LblUsername.BackColor = Color.WhiteSmoke;
                LblPassword.BackColor = Color.WhiteSmoke;
                lblinicio.BackColor = Color.WhiteSmoke;
                lblRecuperar.BackColor = Color.WhiteSmoke;
                menuStrip1.BackColor = Color.WhiteSmoke;
                //Esto es para cambiar el color de los gradientes del panel cuando se active el modo oscuro
                bunifuGradientPanel1.GradientBottomLeft = Color.Black;
                bunifuGradientPanel1.GradientTopRight = Color.Black;
                bunifuGradientPanel1.GradientBottomRight = Color.DarkViolet;
                bunifuGradientPanel1.GradientTopLeft = Color.DarkViolet;
            }
            else
            {
                this.BackColor = Color.LightSkyBlue;
                LblPassword.ForeColor = Color.FromArgb(68, 197, 197);
                LblUsername.ForeColor = Color.FromArgb(68, 197, 197);
                lblinicio.ForeColor = Color.FromArgb(228, 174, 34);
                BtnStart.IdleFillColor = Color.LawnGreen;
                txtPassword.BorderColorHover = Color.FromArgb(105, 181, 255);
                txtUsername.BorderColorHover = Color.FromArgb(105, 181, 255);
                txtPassword.BorderColorActive = Color.FromArgb(105, 181, 255);
                txtUsername.BorderColorActive = Color.FromArgb(105, 181, 255);
                BtnStart.onHoverState.FillColor = Color.FromArgb(105, 181, 255);
                BtnStart.onHoverState.BorderColor = Color.FromArgb(105, 181, 255);
                BtnStart.OnPressedState.FillColor = Color.FromArgb(40, 96, 144);
                BtnStart.OnPressedState.BorderColor = Color.FromArgb(40, 96, 144);
                Firstpanel.BackgroundColor = Color.White;
                LblUsername.BackColor = Color.White;
                LblPassword.BackColor = Color.White;
                lblinicio.BackColor = Color.White;
                lblRecuperar.BackColor = Color.White;
                menuStrip1.BackColor = Color.White;
                //Esto es para cuando se desactive el modo oscuro, se devuelvan sus colores originales
                bunifuGradientPanel1.GradientBottomLeft = Color.DeepSkyBlue;
                bunifuGradientPanel1.GradientTopRight = Color.White;
                bunifuGradientPanel1.GradientBottomRight = Color.DeepSkyBlue;
                bunifuGradientPanel1.GradientTopLeft = Color.White;
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
