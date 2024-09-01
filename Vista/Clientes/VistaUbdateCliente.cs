using AgroServicios.Controlador.Clientes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TheArtOfDev.HtmlRenderer.Adapters.RGraphicsPath;

namespace AgroServicios.Vista.Clientes
{
    public partial class VistaUbdateCliente : Form
    {
        public VistaUbdateCliente(int accion, int id, string Name, string telefono, string correo, string direccion, string dui)
        {
            InitializeComponent();
            ControladorUbdateCliente controladorUbdateCliente = new ControladorUbdateCliente(this, accion, id, Name, telefono, correo, direccion, dui);
        }
    }
}
