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
using AgroServicios.Controlador.Busqueda;

namespace AgroServicios.Vista.Busqueda
{
    public partial class VistaBusqueda : Form
    {
        public VistaBusqueda()
        {
            InitializeComponent();
            ControladorBusqueda controladorBusqueda = new ControladorBusqueda(this);
        }

        private void VistaBusqueda_Load(object sender, EventArgs e)
        {
            if(ControladorIdioma.idioma == 1)
            {
                label1.Text = Ingles.labelbuscar;
                txtBuscar.PlaceholderText = Ingles.Busqueda;
            }
        }
    }
}
