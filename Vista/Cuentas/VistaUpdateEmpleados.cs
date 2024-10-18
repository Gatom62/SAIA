using AgroServicios.Controlador.CuentasContralador;
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
using Bunifu.UI.WinForms;

namespace AgroServicios.Vista.Cuentas
{
    public partial class VistaUpdateEmpleados : Form
    {
        public VistaUpdateEmpleados(int accion, int id, string Name, string phone, string email, string dni, string address, DateTime birthday, byte[] img, string user)
        {
            InitializeComponent();
            ControladorUpdateEmpleados control = new ControladorUpdateEmpleados(this, accion, id, Name, phone, email, dni, address, birthday, img, user);  
        }
        private void VistaUpdateEmpleados_Load(object sender, EventArgs e)
        {
   
            if(ControladorIdioma.idioma == 1)
            {
                txtUpdateNombre.PlaceholderText = Ingles.Nombre;
                txtUpdatePhone.PlaceholderText = Ingles.Celular;
                txtUpdateCorreo.PlaceholderText = Ingles.Correo;
                txtUpdateDireccion.PlaceholderText = Ingles.Direccion;
                btnUpdateEmpleado.Text = Ingles.btnactempleado;
            }
            if (ControladorTema.IsDarkMode == true)
            {
                this.BackColor = Color.FromArgb(34, 36, 49);
                btnUpdateEmpleado.IdleFillColor = Color.FromArgb(230, 119, 11);
                btnUpdateEmpleado.onHoverState.FillColor = Color.FromArgb(211, 41, 15);
                btnUpdateEmpleado.onHoverState.BorderColor = Color.FromArgb(211, 41, 15);
                btnUpdateEmpleado.OnPressedState.FillColor = Color.Red;
                btnUpdateEmpleado.OnPressedState.BorderColor = Color.Red;
                btnUpdateEmpleado.DisabledFillColor = Color.DarkOrange;

                pnTitulo.BackColor = Color.WhiteSmoke;

                txtUser.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtUser.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtUpdateNombre.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtUpdateNombre.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtUpdatePhone.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtUpdatePhone.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtUpdateCorreo.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtUpdateCorreo.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtUpdateDireccion.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtUpdateDireccion.BorderColorActive = Color.FromArgb(211, 41, 15);
            }
        }
    }
}
