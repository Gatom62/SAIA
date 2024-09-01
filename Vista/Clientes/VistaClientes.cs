using AgroServicios.Controlador.Clientes;
using System.Windows.Forms;

namespace AgroServicios.Vista.Clientes
{
    public partial class VistaClientes : Form
    {
        public VistaClientes()
        {
            InitializeComponent();
            ControladorVistaClientes control = new ControladorVistaClientes(this);
        }
    }
}
