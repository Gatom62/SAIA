using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Cuentas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Controlador.CuentasContralador
{
    class ControladorCreateUser
    {
        CreateUser ObjUsers;
        private int accion;
        private string role;

        /// <summary>
        /// Constructor para inserción de datos
        /// </summary>
        /// <param name="Vista"></param>
        /// <param name="accion"> INSERCIÓN </param>

        public ControladorCreateUser(CreateUser Vista, int accion) 
        {
            ObjUsers = Vista;
            this.accion = accion;
            ObjUsers.Load += new EventHandler(InitialCharge);

            ObjUsers.btnCrearUsuario.Click += new EventHandler(NuevoRegistro);
        }

        public void InitialCharge(object sender, EventArgs e)
        {
            //Objeto de la clase DAOAdminUsuarios
            DAOAdminUsers objAdmin = new DAOAdminUsers();
            //Declarando nuevo DataSet para que obtenga los datos del metodo LlenarCombo
            DataSet ds = objAdmin.LlenarCombo();
            //Llenar combobox tbRole
            ObjUsers.DropRole.DataSource = ds.Tables["Categorias"];
            ObjUsers.DropRole.ValueMember = "idCategoria";
            ObjUsers.DropRole.DisplayMember = "Nombre";
            //La condición sirve para que al actualizar un registro, el valor del registro aparezca seleccionado.
            if (accion == 2)
            {
                ObjUsers.DropRole.Text = role;
            }
        }
        public void NuevoRegistro(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(ObjUsers.txtNewFirstName.Text) ||
                string.IsNullOrWhiteSpace(ObjUsers.txtNewPhone.Text) ||
                string.IsNullOrWhiteSpace(ObjUsers.txtNewCorreo.Text) ||
                string.IsNullOrWhiteSpace(ObjUsers.maskedDui.Text) ||
                string.IsNullOrWhiteSpace(ObjUsers.txtNewDireccion.Text) ||
                string.IsNullOrWhiteSpace(ObjUsers.txtNewUser.Text) ||
                string.IsNullOrWhiteSpace(ObjUsers.txtNewPassword.Text) ||
                ObjUsers.DropRole.SelectedValue == null)
            {
                MessageBox.Show("Todos los campos son obligatorios.",
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            // Validar que la fecha de nacimiento sea mayor de 18 años
            DateTime fechaNacimiento = ObjUsers.PickerBirth.Value.Date;
            DateTime fechaActual = DateTime.Today;
            int edad = fechaActual.Year - fechaNacimiento.Year;
            if (fechaNacimiento > fechaActual.AddYears(-edad)) edad--;

            if (edad < 18)
            {
                MessageBox.Show("La fecha de nacimiento debe ser mayor de 18 años.",
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            DAOAdminUsers DaoInsert = new DAOAdminUsers();
            Encryp ObjEncriptar = new Encryp();

            // Asignar los valores a las propiedades de DaoInsert
            DaoInsert.Nombre1 = ObjUsers.txtNewFirstName.Text.Trim();
            DaoInsert.FechaDeNacimiento1 = fechaNacimiento;
            DaoInsert.Telefono1 = ObjUsers.txtNewPhone.Text.Trim();
            DaoInsert.Correo1 = ObjUsers.txtNewCorreo.Text.Trim();
            DaoInsert.DUI1 = ObjUsers.maskedDui.Text;
            DaoInsert.Direccion1 = ObjUsers.txtNewDireccion.Text.Trim();
            DaoInsert.Usuario1 = ObjUsers.txtNewUser.Text.Trim();
            DaoInsert.Contraseña1 = ObjEncriptar.Encriptar(ObjUsers.txtNewPassword.Text);
            DaoInsert.IdCategoria = int.Parse(ObjUsers.DropRole.SelectedValue.ToString());

            int valorRetornado = DaoInsert.RegistrarUsuario();
            if (valorRetornado == 1)
            {
                MessageBox.Show("Los datos han sido registrados exitosamente",
                                "Proceso completado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                ObjUsers.Close();
            }
            else
            {
                MessageBox.Show("Los datos no pudieron ser registrados",
                                "Proceso interrumpido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

    }
}
