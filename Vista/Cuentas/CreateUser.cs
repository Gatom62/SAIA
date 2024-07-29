using System.Windows.Forms;
using AgroServicios.Controlador;
using AgroServicios.Controlador.CuentasContralador;

namespace AgroServicios.Vista.Cuentas
{
    public partial class CreateUser : Form
    {
        public CreateUser(int accion)
        {
            InitializeComponent();
           ControladorCreateUser ObjUsers = new ControladorCreateUser(this, accion);

        }

        private void CreateUser_Load(object sender, System.EventArgs e)
        {
            if (ControladorIdioma.idioma == 1)
            {
                bunifuLabel2.Text = Ingles.tituloingresar;
                txtNewUser.PlaceholderText = Ingles.Usuario;
                txtNewFirstName.PlaceholderText = Ingles.Nombre;
                txtNewPassword.PlaceholderText = Ingles.contraseña;
                txtNewPhone.PlaceholderText = Ingles.Celular;
                txtNewCorreo.PlaceholderText = Ingles.Correo;
                txtNewDireccion.PlaceholderText = Ingles.Direccion;
                btnCrearUsuario.Text = Ingles.btningresarempleado;
            }
        }
    }
}
