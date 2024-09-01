using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgroServicios.Controlador.Clientes;

namespace AgroServicios.Vista.Clientes
{
    public partial class VistaCreateCliente : Form
    {
        public VistaCreateCliente(int accion)
        {
            InitializeComponent();
            ControladorCreateCliente create = new ControladorCreateCliente(this, accion);
        }
    }
}
