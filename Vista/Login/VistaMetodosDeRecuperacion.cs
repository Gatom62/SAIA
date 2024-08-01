using AgroServicios.Controlador;
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
    public partial class VistaMetodosDeRecuperacion : Form
    {
        public VistaMetodosDeRecuperacion()
        {
            InitializeComponent();
            ControlerBasicMetodosRecuperar control = new ControlerBasicMetodosRecuperar(this);
        }

        private void VistaMetodosDeRecuperacion_Load(object sender, EventArgs e)
        {
            if(ControladorTema.IsDarkMode == true)
            {
                this.BackColor = Color.FromArgb(34, 36, 49);
                btnEmail.IdleFillColor = Color.FromArgb(230, 119, 11);
                btnEmail.ForeColor = Color.White;
            }
        }
    }
}
