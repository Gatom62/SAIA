using AgroServicios.Controlador.ControladorStats;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Vista.Estadisticas
{
    public partial class VistaProveedores : Form
    {
        public VistaProveedores()
        {
            InitializeComponent();
            ControladorProveedores controladorProveedores = new ControladorProveedores(this);
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void contextGriewProveedores_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
