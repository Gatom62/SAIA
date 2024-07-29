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

namespace AgroServicios.Vista.Cuentas
{
    public partial class VistaUpdateEmpleados : Form
    {
        public VistaUpdateEmpleados(int accion, int id, string Name, string phone, string email, string dni, string address, DateTime birthday)
        {
            InitializeComponent();
            ControladorUpdateEmpleados control = new ControladorUpdateEmpleados(this, accion, id, Name, phone, email, dni, address, birthday);  
        }

        private void VistaUpdateEmpleados_Load(object sender, EventArgs e)
        {
            if(ControladorIdioma.idioma == 1)
            {
                bunifuLabel1.Text = Ingles.tituloactualizar;
                txtUpdateNombre.PlaceholderText = Ingles.Nombre;
                txtUpdatePhone.PlaceholderText = Ingles.Celular;
                txtUpdateCorreo.PlaceholderText = Ingles.Correo;
                txtUpdateDireccion.PlaceholderText = Ingles.Direccion;
                btnUpdateEmpleado.Text = Ingles.btnactempleado;
            }
        }
    }
}
