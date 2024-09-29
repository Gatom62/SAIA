using AgroServicios.Controlador;
using AgroServicios.Controlador.Helper;
using AgroServicios.Controlador.MenuPrincipal;
using AgroServicios.Vista.Login;
using AgroServicios.Vista.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Vista.MenuPrincipal
{
    public partial class VistaAjustes : Form
    {
        public VistaAjustes()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CommonClasses.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        private void VistaAjustes_Load(object sender, EventArgs e)
        {
            Acceso();
            if (ControladorTema.IsDarkMode == false)
            {
                DarkMode.Checked = false;
            }
            else
            {
                DarkMode.Checked = true;
            }

            if (ControladorIdioma.idioma == 0)
            {
                switchidioma.Checked = false;
            }
            else
            {
                switchidioma.Checked = true;
            }

            if (ControladorTema.IsDarkMode == true)
            {
                this.BackColor = Color.FromArgb(34, 36, 49);
                tableLayoutPanel1.BackColor = Color.FromArgb(230, 119, 11);

                btnConfigurarServidor.IdleFillColor = Color.FromArgb(230, 119, 11);
                btnConfigurarServidor.onHoverState.FillColor = Color.FromArgb(211, 41, 15);
                btnConfigurarServidor.onHoverState.BorderColor = Color.FromArgb(211, 41, 15);
                btnConfigurarServidor.OnPressedState.FillColor = Color.Red;
                btnConfigurarServidor.OnPressedState.BorderColor = Color.Red;
                btnConfigurarServidor.DisabledFillColor = Color.DarkOrange;

                btnGuardarConfi.IdleFillColor = Color.FromArgb(230, 119, 11);
                btnGuardarConfi.onHoverState.FillColor = Color.FromArgb(211, 41, 15);
                btnGuardarConfi.onHoverState.BorderColor = Color.FromArgb(211, 41, 15);
                btnGuardarConfi.OnPressedState.FillColor = Color.Red;
                btnGuardarConfi.OnPressedState.BorderColor = Color.Red;
                btnGuardarConfi.DisabledFillColor = Color.DarkOrange;

                pn1.BackgroundColor = Color.DimGray;
                pn2.BackgroundColor = Color.DimGray;
                pn3.BackgroundColor = Color.DimGray;
            }
            if (ControladorIdioma.idioma == 1)
            {
                label2.Text = "System configuration";
                label1.Text = "Normal theme";
                label4.Text = "English";
                label5.Text = "Spanish";
                btnConfigurarServidor.Text = "Edit server";
                btnGuardarConfi.Text = "Save configuration";
                btnCambiarPass.Text = "Change password";
                btnCambiarPreguntas.Text = "Update my answers";
            }
        }
        private void switchidioma_CheckedChanged_1(object sender, EventArgs e)
        {
            if (switchidioma.Checked)
            {
                ControladorIdioma.idioma = 1;
            }
            else
            {
                ControladorIdioma.idioma = 0;
            }
        }

        private void DarkMode_CheckedChanged_1(object sender, EventArgs e)
        {
            if (DarkMode.Checked)
            {
                ControladorTema.IsDarkMode = true;
            }
            else
            {
                ControladorTema.IsDarkMode = false;
            }
        }
        public void Acceso()
        {
            switch (StaticSession.Categorianame1)
            {
                case "Manager":
                    break;
                case "Empleado":
                    btnConfigurarServidor.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void btnGuardarConfi_Click_1(object sender, EventArgs e)
        {
            VistaMenuPrincipal vistaMenuPrincipal = new VistaMenuPrincipal();
            vistaMenuPrincipal.Show();
            this.Close();
        }

        private void btnConfigurarServidor_Click_1(object sender, EventArgs e)
        {
            VerificarContraServer objc = new VerificarContraServer();
            objc.ShowDialog();
        }

        private void btnCambiarPass_Click(object sender, EventArgs e)
        {
            string user = StaticSession.Username;
            VistaLoguinCambiarContrasena vistaLoguinCambiarContrasena = new VistaLoguinCambiarContrasena(user);
            vistaLoguinCambiarContrasena.ShowDialog();
        }

        private void btnCambiarPreguntas_Click(object sender, EventArgs e)
        {
            string user = StaticSession.Username;
            VistaPreguntas vpre = new VistaPreguntas(user, 2);
            vpre.ShowDialog();
        }
    }
}
