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
    public partial class VistaRestablecerPassword : Form
    {
        public VistaRestablecerPassword(string usuario)
        {
            InitializeComponent();
            ControladorRestUser control = new ControladorRestUser(this, usuario);
        }
    }
}
