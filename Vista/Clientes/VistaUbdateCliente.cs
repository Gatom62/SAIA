using AgroServicios.Controlador;
using AgroServicios.Controlador.Clientes;
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
using static TheArtOfDev.HtmlRenderer.Adapters.RGraphicsPath;

namespace AgroServicios.Vista.Clientes
{
    public partial class VistaUbdateCliente : Form
    {
        public VistaUbdateCliente(int accion, int id, string Name, string telefono, string correo, string direccion, string dui)
        {
            InitializeComponent();
            ControladorUbdateCliente controladorUbdateCliente = new ControladorUbdateCliente(this, accion, id, Name, telefono, correo, direccion, dui);
        }

        private void VistaUbdateCliente_Load(object sender, EventArgs e)
        {
            if (ControladorTema.IsDarkMode == true)
            {
                this.BackColor = Color.FromArgb(34, 36, 49);
                btnUbdateCliente.IdleFillColor = Color.FromArgb(230, 119, 11);
                btnUbdateCliente.onHoverState.FillColor = Color.FromArgb(211, 41, 15);
                btnUbdateCliente.onHoverState.BorderColor = Color.FromArgb(211, 41, 15);
                btnUbdateCliente.OnPressedState.FillColor = Color.Red;
                btnUbdateCliente.OnPressedState.BorderColor = Color.Red;
                btnUbdateCliente.DisabledFillColor = Color.DarkOrange;

                pnEstructura.BackgroundColor = Color.WhiteSmoke;

                txtUbdateNombreCliente.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtUbdateNombreCliente.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtUbdateTelefonoCliente.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtUbdateTelefonoCliente.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtUbdateCorreoCliente.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtUbdateCorreoCliente.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtUbdateDireccionCliente.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtUbdateDireccionCliente.BorderColorActive = Color.FromArgb(211, 41, 15);

            }
        }
    }
}
