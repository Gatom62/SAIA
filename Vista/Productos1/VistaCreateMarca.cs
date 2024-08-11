using AgroServicios.Controlador.Productos1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Vista.Productos1
{
    public partial class VistaCreateMarca : Form
    {
        public VistaCreateMarca(int accion)
        {
            InitializeComponent();
            ControladorCreateMarca1 ObjCreateMarca = new ControladorCreateMarca1(this, accion);
        }

        private void bunifuGradientPanel1_Click(object sender, EventArgs e)
        {

        }

        private void VistaCreateMarca_Load(object sender, EventArgs e)
        {

        }
    }
}
