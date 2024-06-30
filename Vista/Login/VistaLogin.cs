using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgroServicios.Controlador.Login;

namespace AgroServicios.Vista.Login
{
    public partial class VistaLogin : Form
    {
        public VistaLogin()
        {
            InitializeComponent();
            ControladorLogin control = new ControladorLogin(this);
        }

    }
}
