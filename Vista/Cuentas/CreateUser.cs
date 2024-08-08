using System.Drawing;
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
                LabelPrin.Text = Ingles.tituloingresar;
                txtNewUser.PlaceholderText = Ingles.Usuario;
                txtNewFirstName.PlaceholderText = Ingles.Nombre;
                txtNewPassword.PlaceholderText = Ingles.contraseña;
                txtNewPhone.PlaceholderText = Ingles.Celular;
                txtNewCorreo.PlaceholderText = Ingles.Correo;
                txtNewDireccion.PlaceholderText = Ingles.Direccion;
                btnCrearUsuario.Text = Ingles.btningresarempleado;
            }
            if (ControladorTema.IsDarkMode == true)
            {
                bunifuGradientPanel2.GradientBottomLeft = Color.FromArgb(118, 88, 152);
                bunifuGradientPanel2.GradientTopRight = Color.FromArgb(118,88, 152);
                bunifuGradientPanel2.GradientBottomRight = Color.FromArgb(34, 36, 49);
                bunifuGradientPanel2.GradientTopLeft = Color.FromArgb(34, 36, 49);
            }
        }

        private void bunifuPanel1_Click(object sender, System.EventArgs e)
        {

        }
    }
}
