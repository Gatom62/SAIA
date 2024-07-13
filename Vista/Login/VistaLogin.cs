using System.Windows.Forms;
using AgroServicios.Controlador.Login;

namespace AgroServicios.Vista.Login
{
    public partial class VistaLogin : Form
    {
        public VistaLogin()
        {
            InitializeComponent();
            ControladorLogin control = new ControladorLogin(this);
        }

    }
}
