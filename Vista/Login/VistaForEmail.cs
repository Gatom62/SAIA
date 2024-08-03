using AgroServicios.Controlador;
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

        private void VistaForEmail_Load(object sender, EventArgs e)
        {
            if(ControladorTema.IsDarkMode == true)
            {
                btnEnviar.IdleFillColor = Color.FromArgb(188, 88, 152);
                this.BackColor = Color.FromArgb(34, 36, 49);
                btnEnviar.ForeColor = Color.White;
                lblResult.ForeColor = Color.White;
            }
        }
    }
}
