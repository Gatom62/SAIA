using AgroServicios.Controlador;
using AgroServicios.Controlador.Helper;
using AgroServicios.Controlador.Login;
using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Vista.Login
{
    public partial class VistaPreguntas : Form
    {
        private Size originalSize;
        public VistaPreguntas(string user, int action)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CommonClasses.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            ControladorPreguntasRec control = new ControladorPreguntasRec(this, user, action);

            //Metodos para hacer que la imagen cresca cuando el mause pase por heya
            //Para el p
            // Cargar la imagen desde los recursos
            btnClose.Image = Properties.Resources.turn_left_11044726;
            originalSize = btnClose.Size;
            // Eventos para cuando el mouse entra y sale del PictureBox
            btnClose.MouseEnter += btnClose_MouseEnter;
            btnClose.MouseLeave += btnClose_MouseLeave;
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            // Aumentar el tamaño del PictureBox cuando el cursor está sobre la imagen
            btnClose.Size = new Size(originalSize.Width + 5, originalSize.Height + 5);
            btnClose.Location = new Point(btnClose.Location.X - 5, btnClose.Location.Y - 5); // Ajustar la posición
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            // Restaurar el tamaño original del PictureBox cuando el cursor sale de la imagen
            btnClose.Size = originalSize;
            btnClose.Location = new Point(btnClose.Location.X + 5, btnClose.Location.Y + 5); // Restaurar la posición
        }

        private void VistaPreguntas_Load(object sender, EventArgs e)
        {
            if(ControladorTema.IsDarkMode == true)
            {
                this.BackColor = Color.FromArgb(34,36,49);
                txtUsuario.FillColor = Color.WhiteSmoke;
                txtRes1.BackColor = Color.WhiteSmoke;
                txtRes2.BackColor = Color.WhiteSmoke;
                droprole1.BackgroundColor = Color.WhiteSmoke;
                droprole2.BackgroundColor = Color.WhiteSmoke;

                btnGuardar.IdleFillColor = Color.DarkBlue;
                btnGuardar.onHoverState.FillColor = Color.DarkViolet;
                btnGuardar.onHoverState.BorderColor = Color.DarkViolet;
                btnGuardar.OnPressedState.FillColor = Color.DodgerBlue;
                btnGuardar.OnPressedState.BorderColor = Color.DodgerBlue;
                btnGuardar.DisabledFillColor = Color.DarkViolet;

                btnGuardar.DisabledFillColor = Color.FromArgb(118, 88, 152);
                btnGuardar.ForeColor = Color.White;

                btnActualizarP.IdleFillColor = Color.FromArgb(230, 119, 11);
                btnActualizarP.onHoverState.FillColor = Color.FromArgb(211, 41, 15);
                btnActualizarP.onHoverState.BorderColor = Color.FromArgb(211, 41, 15);
                btnActualizarP.OnPressedState.FillColor = Color.Red;
                btnActualizarP.OnPressedState.BorderColor = Color.Red;
                btnActualizarP.DisabledFillColor = Color.DarkOrange;

                //Esto es para cambiar el color de los gradientes del panel cuando se active el modo oscuro
                bunifuGradientPanel1.GradientBottomLeft = Color.FromArgb(118, 88, 152);
                bunifuGradientPanel1.GradientTopRight = Color.FromArgb(34, 36, 49);
                bunifuGradientPanel1.GradientBottomRight = Color.FromArgb(118, 88, 152);
                bunifuGradientPanel1.GradientTopLeft = Color.FromArgb(34, 36, 49);

                lbUsuario.ForeColor = Color.FromArgb(230, 119, 11);
            }

            if (ControladorIdioma.idioma == 1)
            {
                lbUsuario.Text = Ingles.Usuario;
                btnGuardar.Text = Ingles.Agregar;
                btnActualizarP.Text = Ingles.Actualizar;
                txtRes1.PlaceholderText = "Answer 1";
                txtRes2.PlaceholderText = "Answer 2";
            }
        }
    }
}
