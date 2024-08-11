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
    public partial class VistaAgregarProveedor : Form
    {
        public VistaAgregarProveedor()
        {
            InitializeComponent();
            ControladorCrearProveedor control = new ControladorCrearProveedor(this);
        }
    }
}
