using AgroServicios.Controlador.Login;
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
    public partial class VistaPreguntasLogin : Form
    {
        public VistaPreguntasLogin()
        {
            InitializeComponent();
            ControladorPreguntasLogin controlador = new ControladorPreguntasLogin(this);
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
