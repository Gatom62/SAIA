using AgroServicios.Controlador.Login;
using AgroServicios.Modelo.DAO;
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
    public partial class VistaForEmail : Form
    {
        public VistaForEmail()
        {
            InitializeComponent();
            ControladorForEmail control = new ControladorForEmail(this);
        }

    }
}
