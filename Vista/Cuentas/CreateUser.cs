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
                bunifuToolTip1.SetToolTip(ptbImgUser, "Picture profile (optional)");
                bunifuToolTip1.SetToolTip(PickerBirth, "Birthdate");
                bunifuToolTip1.SetToolTip(maskDui, "Employee DUI");
                bunifuToolTip1.SetToolTip(DropRole, "Employee Role");
            }
            if (ControladorTema.IsDarkMode == true)
            {
                this.BackColor = Color.FromArgb(34, 36, 49);
                btnCrearUsuario.IdleFillColor = Color.DarkBlue;
                btnCrearUsuario.onHoverState.FillColor = Color.DarkViolet;
                btnCrearUsuario.onHoverState.BorderColor = Color.DarkViolet;
                btnCrearUsuario.OnPressedState.FillColor = Color.DodgerBlue;
                btnCrearUsuario.OnPressedState.BorderColor = Color.DodgerBlue;
                btnCrearUsuario.DisabledFillColor = Color.DarkViolet;

                btnCrearUsuario.DisabledFillColor = Color.FromArgb(118, 88, 152);
                btnCrearUsuario.ForeColor = Color.White;

                pnEstructura.BackgroundColor = Color.WhiteSmoke;

                txtNewUser.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtNewUser.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtNewFirstName.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtNewFirstName.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtNewPassword.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtNewPassword.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtNewPhone.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtNewPhone.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtNewCorreo.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtNewCorreo.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtNewDireccion.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtNewDireccion.BorderColorActive = Color.FromArgb(211, 41, 15);
            }
        }
    }
}
