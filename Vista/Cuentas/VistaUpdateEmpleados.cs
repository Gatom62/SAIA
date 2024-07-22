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

namespace AgroServicios.Vista.Cuentas
{
    public partial class VistaUpdateEmpleados : Form
    {
        public VistaUpdateEmpleados(int accion, int id, string Name, string phone, string email, string dni, string address, DateTime birthday)
        {
            InitializeComponent();
            ControladorUpdateEmpleados control = new ControladorUpdateEmpleados(this, accion, id, Name, phone, email, dni, address, birthday);  
        }

    }
}
