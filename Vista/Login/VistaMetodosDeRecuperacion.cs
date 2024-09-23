using AgroServicios.Controlador;
using AgroServicios.Controlador.Login;
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
    public partial class VistaMetodosDeRecuperacion : Form
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
        public VistaMetodosDeRecuperacion()
        {
            InitializeComponent();
            ControlerBasicMetodosRecuperar control = new ControlerBasicMetodosRecuperar(this);
            // Aplicar el borde redondeado al formulario
            this.FormBorderStyle = FormBorderStyle.None; // Deshabilitar el borde normal del formulario
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 30, 30));

            //Metodos para hacer que la imagen cresca cuando el mause pase por heya
            // Cargar la imagen desde los recursos
            ptbback.Image = Properties.Resources.turn_left_11044726;
            originalSize = ptbback.Size;
            // Eventos para cuando el mouse entra y sale del PictureBox
            ptbback.MouseEnter += ptbback_MouseEnter;
            ptbback.MouseLeave += ptbback_MouseLeave;

        }

        private void VistaMetodosDeRecuperacion_Load(object sender, EventArgs e)
        {
            if(ControladorTema.IsDarkMode == true)
            {
                this.BackColor = Color.FromArgb(34, 36, 49);
                btnEmail.IdleFillColor = Color.FromArgb(230, 119, 11);
                btnEmail.onHoverState.FillColor = Color.FromArgb(211, 41, 15);
                btnEmail.onHoverState.BorderColor = Color.FromArgb(211, 41, 15);
                btnEmail.OnPressedState.FillColor = Color.Red;
                btnEmail.OnPressedState.BorderColor = Color.Red;

                btnPreguntas.IdleFillColor = Color.FromArgb(230, 119, 11);
                btnPreguntas.onHoverState.FillColor = Color.FromArgb(211, 41, 15);
                btnPreguntas.onHoverState.BorderColor = Color.FromArgb(211, 41, 15);
                btnPreguntas.OnPressedState.FillColor = Color.Red;
                btnPreguntas.OnPressedState.BorderColor = Color.Red;

                btnRecuperacionAdmin.IdleFillColor = Color.FromArgb(230, 119, 11);
                btnRecuperacionAdmin.IdleFillColor = Color.FromArgb(230, 119, 11);
                btnRecuperacionAdmin.onHoverState.FillColor = Color.FromArgb(211, 41, 15);
                btnRecuperacionAdmin.onHoverState.BorderColor = Color.FromArgb(211, 41, 15);
                btnRecuperacionAdmin.OnPressedState.FillColor = Color.Red;
                btnRecuperacionAdmin.OnPressedState.BorderColor = Color.Red;

                bunifuGradientPanel2.GradientBottomLeft = Color.FromArgb(118, 88, 152);
                bunifuGradientPanel2.GradientTopRight = Color.FromArgb(34, 36, 49);
                bunifuGradientPanel2.GradientBottomRight = Color.FromArgb(118, 88, 152);
                bunifuGradientPanel2.GradientTopLeft = Color.FromArgb(34, 36, 49);
            }
            if(ControladorIdioma.idioma == 1)
            {
                btnEmail.Text = "Recovery through Gmail.";
                btnPreguntas.Text = "Recovery by questions.";
                btnRecuperacionAdmin.Text = "Administrator recovery";
            }
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
    }
}
