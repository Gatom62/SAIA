using AgroServicios.Controlador;
using AgroServicios.Controlador.ControladorStats;
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

namespace AgroServicios.Vista.Estadisticas
{
    public partial class VistaAgregarProveedor : Form
    {
        public VistaAgregarProveedor()
        {
            InitializeComponent();
            ControladorCrearProveedor control = new ControladorCrearProveedor(this);
        }
        private void VistaAgregarProveedor_Load(object sender, EventArgs e)
        {
            if (ControladorIdioma.idioma == 1)
            {
                AnaP.Text = Ingles.txtAñaP;
                txtNewFirstName.PlaceholderText = Ingles.txtFN;
                txtNewPhone.PlaceholderText = Ingles.txtTe;
                txtNewCorreo.PlaceholderText = Ingles.txtCR;
                btnAgregarProv.Text = Ingles.btnAP;      
            }
            if (ControladorTema.IsDarkMode == true)
            {
                this.BackColor = Color.FromArgb(34, 36, 49);
                btnAgregarProv.IdleFillColor = Color.DarkBlue;
                btnAgregarProv.onHoverState.FillColor = Color.DarkViolet;
                btnAgregarProv.onHoverState.BorderColor = Color.DarkViolet;
                btnAgregarProv.OnPressedState.FillColor = Color.DodgerBlue;
                btnAgregarProv.OnPressedState.BorderColor = Color.DodgerBlue;
                btnAgregarProv.DisabledFillColor = Color.DarkViolet;

                btnAgregarProv.DisabledFillColor = Color.FromArgb(118, 88, 152);
                btnAgregarProv.ForeColor = Color.White;

                pnEstructura.BackgroundColor = Color.WhiteSmoke;

                txtNewFirstName.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtNewFirstName.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtNewCorreo.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtNewCorreo.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtNewPhone.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtNewPhone.BorderColorActive = Color.FromArgb(211, 41, 15);
            }

            if (ControladorIdioma.idioma == 1) 
            {
                AnaP.Text = Ingles.AgreagrProveedor;
                txtNewFirstName.PlaceholderText = Ingles.Nombre;
                txtNewPhone.PlaceholderText = Ingles.Telefono;
                txtNewCorreo.PlaceholderText = Ingles.Correo;
                btnAgregarProv.Text = Ingles.Agregar;
            }
        }
    }
}
