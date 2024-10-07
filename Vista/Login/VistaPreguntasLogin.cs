using AgroServicios.Controlador;
using AgroServicios.Controlador.Login;
using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Vista.Login
{
    public partial class VistaPreguntasLogin : Form
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
        public VistaPreguntasLogin()
        {
            InitializeComponent();
            ControladorPreguntasLogin controlador = new ControladorPreguntasLogin(this);
            // Aplicar el borde redondeado al formulario
            this.FormBorderStyle = FormBorderStyle.None; // Deshabilitar el borde normal del formulario
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 30, 30));

            //Metodos para hacer que la imagen cresca cuando el mause pase por heya
            //Para el p
            // Cargar la imagen desde los recursos
            ptbback.Image = Properties.Resources.turn_left_11044726;
            originalSize = ptbback.Size;
            // Eventos para cuando el mouse entra y sale del PictureBox
            ptbback.MouseEnter += ptbback_MouseEnter;
            ptbback.MouseLeave += ptbback_MouseLeave;
        }
        private void ptbback_MouseEnter(object sender, EventArgs e)
        {
            // Aumentar el tamaño del PictureBox cuando el cursor está sobre la imagen
            ptbback.Size = new Size(originalSize.Width + 5, originalSize.Height + 5);
            ptbback.Location = new Point(ptbback.Location.X - 5, ptbback.Location.Y - 5); // Ajustar la posición
        }
        private void ptbback_MouseLeave(object sender, EventArgs e)
        {
            // Restaurar el tamaño original del PictureBox cuando el cursor sale de la imagen
            ptbback.Size = originalSize;
            ptbback.Location = new Point(ptbback.Location.X + 5, ptbback.Location.Y + 5); // Restaurar la posición
        }
        private void VistaPreguntasLogin_Load(object sender, EventArgs e)
        {
            if (ControladorTema.IsDarkMode == true)
            {
                this.BackColor = Color.FromArgb(34, 36, 49);
                btnGuardar.IdleFillColor = Color.FromArgb(230, 119, 11);
                btnGuardar.onHoverState.FillColor = Color.FromArgb(211, 41, 15);
                btnGuardar.onHoverState.BorderColor = Color.FromArgb(211, 41, 15);
                btnGuardar.OnPressedState.FillColor = Color.Red;
                btnGuardar.OnPressedState.BorderColor = Color.Red;
                btnGuardar.DisabledFillColor = Color.DarkOrange;

                txtUsuario.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtUsuario.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtRes1.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtRes1.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtRes2.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtRes2.BorderColorActive = Color.FromArgb(211, 41, 15);
                bunifuPanel1.BackgroundColor = Color.DarkViolet;

                //Esto es para cambiar el color de los gradientes del panel cuando se active el modo oscuro
                bunifuGradientPanel1.GradientBottomLeft = Color.FromArgb(118, 88, 152);
                bunifuGradientPanel1.GradientTopRight = Color.FromArgb(34, 36, 49);
                bunifuGradientPanel1.GradientBottomRight = Color.FromArgb(118, 88, 152);
                bunifuGradientPanel1.GradientTopLeft = Color.FromArgb(34, 36, 49);

                lbIngreseUsuario.ForeColor = Color.FromArgb(230, 119, 11);
            }

            if (ControladorIdioma.idioma == 1)
            {
                lbIngreseUsuario.Text = Ingles.IngreseSuUsuario;
                btnGuardar.Text = Ingles.Verificar;
                txtRes1.PlaceholderText = Ingles.RespuestaUno;
                txtRes2.PlaceholderText = Ingles.RespuestaDos;
                txtUsuario.PlaceholderText = "Enter the user";
            }
        }
    }
}
