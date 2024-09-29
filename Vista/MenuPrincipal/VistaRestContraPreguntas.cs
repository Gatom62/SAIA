using AgroServicios.Controlador;
using AgroServicios.Controlador.CuentasContralador;
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

namespace AgroServicios.Vista.MenuPrincipal
{
    public partial class VistaRestContraPreguntas : Form
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
        public VistaRestContraPreguntas(string user)
        {
            InitializeComponent();
            ControladorResUserViaPreguntas viaPreguntas = new ControladorResUserViaPreguntas(this, user);
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

        private void VistaRestContraPreguntas_Load(object sender, EventArgs e)
        {
            if (ControladorTema.IsDarkMode == true)
            {
                this.BackColor = Color.FromArgb(34, 36, 49);
                //Esto es para cambiar el color de los gradientes del panel cuando se active el modo oscuro
                bunifuGradientPanel2.GradientBottomLeft = Color.FromArgb(118, 88, 152);
                bunifuGradientPanel2.GradientTopRight = Color.FromArgb(34, 36, 49);
                bunifuGradientPanel2.GradientBottomRight = Color.FromArgb(118, 88, 152);
                bunifuGradientPanel2.GradientTopLeft = Color.FromArgb(34, 36, 49);

                btnRestablecer.IdleFillColor = Color.DarkBlue;
                btnRestablecer.onHoverState.FillColor = Color.DarkViolet;
                btnRestablecer.onHoverState.BorderColor = Color.DarkViolet;
                btnRestablecer.OnPressedState.FillColor = Color.DodgerBlue;
                btnRestablecer.OnPressedState.BorderColor = Color.DodgerBlue;
                btnRestablecer.DisabledFillColor = Color.DarkViolet;

                btnRestablecer.DisabledFillColor = Color.FromArgb(118, 88, 152);
                btnRestablecer.ForeColor = Color.White;

                txtRest.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtRest.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtNuevaContra.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtNuevaContra.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtContraDenuevo.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtContraDenuevo.BorderColorActive = Color.FromArgb(211, 41, 15);
            }
            if (ControladorIdioma.idioma == 1)
            {
                label1.Text = Ingles.LabelRestUser;
                btnRestablecer.Text = Ingles.LabelRestContra;
                txtRest.PlaceholderText = Ingles.Usuario;
                txtNuevaContra.PlaceholderText = Ingles.IngreseNuevaContra;
                txtContraDenuevo.PlaceholderText = Ingles.VuelvaIngresarContra;
            }
        }

        private void ptbback_MouseEnter(object sender, EventArgs e)
        {
            // Aumentar el tamaño del PictureBox cuando el cursor está sobre la imagen
            ptbback.Size = new Size(originalSize.Width + 20, originalSize.Height + 20);
            ptbback.Location = new Point(ptbback.Location.X - 10, ptbback.Location.Y - 20); // Ajustar la posición
        }

        private void ptbback_MouseLeave(object sender, EventArgs e)
        {
            // Restaurar el tamaño original del PictureBox cuando el cursor sale de la imagen
            ptbback.Size = originalSize;
            ptbback.Location = new Point(ptbback.Location.X + 10, ptbback.Location.Y + 10); // Restaurar la posición
        }
    }
}
