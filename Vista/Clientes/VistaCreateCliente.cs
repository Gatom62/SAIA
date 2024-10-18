using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgroServicios.Controlador;
using AgroServicios.Controlador.Clientes;

namespace AgroServicios.Vista.Clientes
{
    public partial class VistaCreateCliente : Form
    {
        public VistaCreateCliente(int accion)
        {
            InitializeComponent();
            ControladorCreateCliente create = new ControladorCreateCliente(this, accion);
        }

        private void VistaCreateCliente_Load(object sender, EventArgs e)
        {
            if (ControladorTema.IsDarkMode == true)
            {
                this.BackColor = Color.FromArgb(34, 36, 49);
                btnAgregarCliente.IdleFillColor = Color.DarkBlue;
                btnAgregarCliente.onHoverState.FillColor = Color.DarkViolet;
                btnAgregarCliente.onHoverState.BorderColor = Color.DarkViolet;
                btnAgregarCliente.OnPressedState.FillColor = Color.DodgerBlue;
                btnAgregarCliente.OnPressedState.BorderColor = Color.DodgerBlue;
                btnAgregarCliente.DisabledFillColor = Color.DarkViolet;

                btnAgregarCliente.DisabledFillColor = Color.FromArgb(118, 88, 152);
                btnAgregarCliente.ForeColor = Color.White;

                pnEstructura.BackgroundColor = Color.WhiteSmoke;

                txtNombreCliente.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtNombreCliente.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtTelefonoCliente.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtTelefonoCliente.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtCorreoCliente.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtCorreoCliente.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtDireccionCliente.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtDireccionCliente.BorderColorActive = Color.FromArgb(211, 41, 15);
            }

            if (ControladorIdioma.idioma == 1) 
            {
                lbAgregarCliente.Text = Ingles.AgregarCliente;
                lbDui.Text = Ingles.txtDUI;
                txtNombreCliente.PlaceholderText = Ingles.NombreCliente;
                txtTelefonoCliente.PlaceholderText = Ingles.Telefono;
                txtCorreoCliente.PlaceholderText = Ingles.Correo;
                txtDireccionCliente.PlaceholderText = Ingles.Direccion;
                btnAgregarCliente.Text = Ingles.Agregar;
            }
        }
    }
}
