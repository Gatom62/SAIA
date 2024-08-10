using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Cuentas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Controlador.CuentasContralador
{
    class ControladorCreateUser
    {
        CreateUser ObjUsers;
        private int accion;
        private string role;
        bool verificacion;

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
            ObjUsers.cmsimgsubir.Click += AgregarImagen;
        }
        void AgregarImagen(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png| Todos los archivos(*.*)| *.* ";
            ofd.Title = "Seleccionar imagen";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string rutaImagen = ofd.FileName;
                ObjUsers.ptbImgUser.Image = Image.FromFile(rutaImagen);
            }
        }

        public void InitialCharge(object sender, EventArgs e)
        {
            DAOLogin dAOLogin = new DAOLogin();
            if (dAOLogin.PrimerUso() == false)
            {
                ObjUsers.DropRole.Enabled = false;
                ObjUsers.LabelPrin.Text = "Creación de primer usuario";
                ObjUsers.bunifuGradientPanel2.GradientBottomLeft = Color.FromArgb(34, 36, 49);
                ObjUsers.bunifuGradientPanel2.GradientTopRight = Color.FromArgb(34,36,49);
                ObjUsers.bunifuGradientPanel2.GradientBottomRight = Color.FromArgb(88, 118, 152);
                ObjUsers.bunifuGradientPanel2.GradientTopLeft = Color.FromArgb(88, 118, 152);
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
            
            if (dAOLogin.PrimerUso() == true) { 
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

            // Validar el formato del número de teléfono
            if (!ValidarTelefono(ObjUsers.txtNewPhone.Text))
            {
                MessageBox.Show("El formato del número de teléfono es incorrecto. Debe ser +XXX XXXX-XXXX o XXXX-XXXX.",
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

            byte[] imageBytes = null;
            if (ObjUsers.ptbImgUser.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    ObjUsers.ptbImgUser.Image.Save(ms, ImageFormat.Jpeg);
                    imageBytes = ms.ToArray();
                }
            }

            DAOAdminUsers DaoInsert = new DAOAdminUsers();
            Encryp ObjEncriptar = new Encryp();

            // Asignar los valores a las propiedades
            DaoInsert.Img = imageBytes;
            DaoInsert.Nombre1 = ObjUsers.txtNewFirstName.Text.Trim();
            DaoInsert.FechaDeNacimiento1 = fechaNacimiento;
            DaoInsert.Telefono1 = ObjUsers.txtNewPhone.Text.Trim();
            DaoInsert.Correo1 = ObjUsers.txtNewCorreo.Text.Trim();
            DaoInsert.DUI1 = ObjUsers.maskedDui.Text;
            DaoInsert.Direccion1 = ObjUsers.txtNewDireccion.Text.Trim();
            DaoInsert.Usuario1 = ObjUsers.txtNewUser.Text.Trim();
            DaoInsert.Contraseña1 = ObjEncriptar.Encriptar(ObjUsers.txtNewPassword.Text);
            DaoInsert.IdCategoria = int.Parse(ObjUsers.DropRole.SelectedValue.ToString());

            verificacion = ValidarCorreo();
            if (verificacion == true)
            {
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

        bool ValidarTelefono(string phoneNumber)
        {
            // Expresión regular para validar números de teléfono en los formatos: +XXX XXXX-XXXX o XXXX-XXXX
            string pattern = @"^(\+\d{1,3}\s\d{4}-\d{4}|\d{4}-\d{4})$";
            return Regex.IsMatch(phoneNumber, pattern);
        }

        bool ValidarCorreo()
        {
            string email = ObjUsers.txtNewCorreo.Text.Trim();
            if (!(email.Contains("@")))
            {
                MessageBox.Show("Formato de correo invalido, verifica que contiene @.", "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
