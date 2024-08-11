using AgroServicios.Controlador.CuentasContralador;
using AgroServicios.Controlador.Productos1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AgroServicios.Vista.Productos1
{
    public partial class VistaUbdateMarca : Form
    {
        public VistaUbdateMarca(int accion, int id, string Name)
        {
            InitializeComponent();
            ControladorUbdateMarca1 control = new ControladorUbdateMarca1(this, accion, id, Name);
        }
        private void lbCrearNuevaMarca_Click(object sender, EventArgs e)
        {
        }

        private void VistaUbdateMarca_Load(object sender, EventArgs e)
        {

        }
    }
}
