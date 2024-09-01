using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Cuentas;
using AgroServicios.Vista.Login;
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
            // Crea una instancia del cuadro de diálogo para seleccionar archivos.
            OpenFileDialog ofd = new OpenFileDialog();

            // Define el filtro para el cuadro de diálogo, limitando la selección a archivos de imagen
            // con extensiones .jpg, .jpeg, y .png. También incluye una opción para mostrar todos los archivos.
            ofd.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png| Todos los archivos(*.*)| *.* ";

            // Establece el título del cuadro de diálogo.
            ofd.Title = "Seleccionar imagen";

            // Muestra el cuadro de diálogo y verifica si el usuario selecciona un archivo y presiona "OK".
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Obtiene la ruta completa del archivo de imagen seleccionado.
                string rutaImagen = ofd.FileName;

                // Asigna la imagen seleccionada al PictureBox (ptbImgUser) del objeto ObjUsers.
                // Carga la imagen desde la ruta del archivo.
                ObjUsers.ptbImgUser.Image = Image.FromFile(rutaImagen);
            }
        }


        public void InitialCharge(object sender, EventArgs e)
        {
            DAOLogin dAOLogin = new DAOLogin();
            if (dAOLogin.PrimerUso() == 0)
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
            
            if (dAOLogin.PrimerUso() == 1) { 
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

            if (!ValidarLetra(ObjUsers.txtNewFirstName.Text))
            {
                MessageBox.Show("No se pude ingresar numeros en el nombre del empleado", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Validar que el nombre del empleado no exceda 65 caracteres
            if (!ValidarNombre(ObjUsers.txtNewFirstName.Text))
            {
                MessageBox.Show("El nombre del empleado no debe exceder los 65 caracteres.",
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            // Validar que la direccion del empleado no exeda los 150 caracteres
            if (!ValidarDireccion(ObjUsers.txtNewDireccion.Text))
            {
                MessageBox.Show("El nombre del empleadp no debe exceder los 150 caracteres.",
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

            // Validar que el telefono del empleado no exceda 25 caracteres
            if (!ValidarTelefonoCantidad(ObjUsers.txtNewPhone.Text))
            {
                MessageBox.Show("El nombre del empleado no debe exceder los 25 caracteres.",
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            // Validar que el coreo del empleado no exceda los 75 caracteres
            if (!ValidarCorreoCantidad(ObjUsers.txtNewCorreo.Text))
            {
                MessageBox.Show("El nombre del empleado no debe exceder los 75 caracteres.",
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            // Validar que el DUI contenga solo números
            if (!ValidarDUI(ObjUsers.maskedDui.Text))
            {
                MessageBox.Show("El DUI solo debe contener números.",
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

            // Declara una variable byte[] llamada imageBytes y la inicializa como null.
            // Esta variable almacenará los bytes de la imagen si hay una imagen en el PictureBox.
            byte[] imageBytes = null;

            // Verifica si la propiedad Image del PictureBox (ptbImgUser) de ObjUsers no es null,
            // es decir, si hay una imagen cargada en el PictureBox.
            if (ObjUsers.ptbImgUser.Image != null)
            {
                // Crea un objeto MemoryStream para trabajar con datos en memoria.
                // El uso de 'using' asegura que el MemoryStream se libere correctamente después de su uso.
                using (MemoryStream ms = new MemoryStream())
                {
                    // Guarda la imagen que está en el PictureBox en el MemoryStream en formato JPEG.
                    ObjUsers.ptbImgUser.Image.Save(ms, ImageFormat.Jpeg);

                    // Convierte los datos de la imagen en el MemoryStream a un array de bytes
                    // y los asigna a la variable imageBytes.
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
                    string newUser = DaoInsert.Usuario1;

                    MessageBox.Show("Los datos han sido registrados exitosamente",
                                    "Proceso completado",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    ObjUsers.Close();

                    VistaPreguntas pre = new VistaPreguntas(newUser, 1);
                    pre.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Los datos no pudieron ser registrados",
                                    "Proceso interrumpido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }

            // Método que valida si un carácter es una letra
            bool ValidarLetra(string texto)
            {
                foreach (char c in texto)
                {
                    if (!char.IsLetter(c) && !char.IsWhiteSpace(c)) // Permite espacios
                    {
                        return false; // Si encuentra un carácter no válido, retorna false
                    }
                }
                return true; // Si todos los caracteres son válidos, retorna true
            }

            // Método para validar que el nombre del empleado no exceda los 65 caracteres
            bool ValidarNombre(string nombre)
            {
                return nombre.Length <= 65;
            }

            // Método para validar la direccion del empleado la cual no exceda los 150 caracteres
            bool ValidarDireccion(string nombre)
            {
                return nombre.Length <= 150;
            }

            // Método para validar que el telefono del cliente no exceda los 20 caracteres
            bool ValidarTelefonoCantidad(string nombre)
            {
                return nombre.Length <= 25;
            }

            // Método para validar que el correo del empleado no exceda los 75 caracteres
            bool ValidarCorreoCantidad(string nombre)
            {
                return nombre.Length <= 75;
            }

            bool ValidarDUI(string dui)
            {
                // Aquí asumimos que el DUI debe contener solo dígitos (sin guiones o espacios)
                // Se puede ajustar según el formato requerido, por ejemplo, permitir un guion
                string pattern = @"^\d+-?\d*$"; // Solo dígitos
                return Regex.IsMatch(dui, pattern);
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
