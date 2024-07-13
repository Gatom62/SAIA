using System.Windows.Forms;
using AgroServicios.Controlador;
using AgroServicios.Controlador.CuentasContralador;

namespace AgroServicios.Vista.Cuentas
{
    public partial class CreateUser : Form
    {
        public CreateUser()
        {
            InitializeComponent();
            ControladorCreateUser control = new ControladorCreateUser(this);
        }

    }
}
