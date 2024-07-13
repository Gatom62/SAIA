using AgroServicios.Modelo.DAO;
using System;
using System.Windows.Forms;
using AgroServicios.Modelo.DTO;
using AgroServicios.Vista;
using AgroServicios.Vista.Cuentas;

namespace AgroServicios.Controlador
{
    internal class ControladorCreateUser
    {
        // Objeto de la vista CreateUser
        CreateUser ObjCreateUser;

        /// <summary>
        /// Constructor de la clase ControladorCreateUser que inicia los eventos de la vista
        /// </summary>
        /// <param name="Vista"></param>
        public ControladorCreateUser(CreateUser Vista)
        {
            ObjCreateUser = Vista;
            ObjCreateUser.btnCrearUsuario.Click += new EventHandler(CrearUsuario);
        }

        /// <summary>
        /// Evento para crear un nuevo usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CrearUsuario(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ObjCreateUser.txtNewUser.Text) ||
                string.IsNullOrWhiteSpace(ObjCreateUser.txtNewPassword.Text) ||
                string.IsNullOrWhiteSpace(ObjCreateUser.txtNewCorreo.Text) ||
                string.IsNullOrWhiteSpace(ObjCreateUser.txtNewPhone.Text) ||
                string.IsNullOrWhiteSpace(ObjCreateUser.txtNewFirstName.Text) ||
                string.IsNullOrWhiteSpace(ObjCreateUser.txtNewLastName.Text) ||
                string.IsNullOrWhiteSpace(ObjCreateUser.maskedDui.Text))
            {
                MessageBox.Show("Debe rellenar todos los campos.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Creando objeto de la Clase DTOAdminUsers
            DTOAdminUsers nuevoUsuario = new DTOAdminUsers
            {
                Usuario1 = ObjCreateUser.txtNewUser.Text,
                Password1 = ObjCreateUser.txtNewPassword.Text,
                Correo1 = ObjCreateUser.txtNewCorreo.Text,
                Phone1 = ObjCreateUser.txtNewPhone.Text,
                Nombre1 = ObjCreateUser.txtNewFirstName.Text,
                Apellido1 = ObjCreateUser.txtNewLastName.Text,
                FechaNacimiento = ObjCreateUser.PickerBirth.Value,
                Dui = ObjCreateUser.maskedDui.Text
            };

            // Creando objeto de la Clase DAOUsuario
            DAOAdminUsers DAOData = new DAOAdminUsers();

            // Invocando al método CrearUsuario contenido en el DAO
            bool success = DAOData.CrearUsuario(nuevoUsuario);

            if (success)
            {
                MessageBox.Show("Usuario creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ObjCreateUser.Close(); // Cerrar el formulario después de crear el usuario
            }
            else
            {
                MessageBox.Show("Hubo un error al crear el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
