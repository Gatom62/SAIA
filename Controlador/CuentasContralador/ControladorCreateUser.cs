using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Cuentas;
using AgroServicios.Vista.Login;
using AgroServicios.Vista.Notificación;
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
        void MessageBoxP(Color backcolor, Color color, string title, string text, Image icon)

        {

            AlertExito frm = new AlertExito();

            frm.BackColorAlert = backcolor;

            frm.ColorAlertBox = color;

            frm.TittlAlertBox = title;

            frm.TextAlertBox = text;

            frm.IconeAlertBox = icon;

            frm.ShowDialog();

        }

        void MandarValoresAlerta(Color backcolor, Color color, string title, string text, Image icon)
        {
            MessagePersonal message = new MessagePersonal();
            message.BackColorAlert = backcolor;
            message.ColorAlertBox = color;
            message.TittlAlertBox = title;
            message.TextAlertBox = text;
            message.IconeAlertBox = icon;
            message.ShowDialog();
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
                string.IsNullOrWhiteSpace(ObjUsers.maskDui.Text) ||
                string.IsNullOrWhiteSpace(ObjUsers.txtNewDireccion.Text) ||
                string.IsNullOrWhiteSpace(ObjUsers.txtNewUser.Text) ||
                string.IsNullOrWhiteSpace(ObjUsers.txtNewPassword.Text) ||
                ObjUsers.DropRole.SelectedValue == null)
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", "Hay campos sin llenar", Properties.Resources.MensajeWarning);
                return;
            }
            //Validamos que en el nombre del usuario que el manager ingrese o empleado no exeda los 50 caeagteres de longitud
            if (!ValidarUsuario(ObjUsers.txtNewUser.Text))
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", "Hay mas de 50 caragteres en el usuario", Properties.Resources.MensajeWarning);
                return;
            }

            string nombreCliente = ObjUsers.txtNewFirstName.Text.Trim();
            // Validar que el nombre solo contenga letras y no exceda 65 caracteres
            if (!ValidarLetra(nombreCliente) || !ValidarNombre(nombreCliente))
            {
                MessageBoxP(Color.Yellow, Color.DarkRed, "Error", "El nombre nombre tiene numeros o tiene más de 65 letras", Properties.Resources.MensajeWarning);
                return;
            }

            // Validar que la contraseña del empleado no exceda 100 caracteres
            if (!ValidarContraseña(ObjUsers.txtNewPassword.Text))
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", "La contraseña debe tener al menos 8 caracteres", Properties.Resources.MensajeWarning);
                return;
            }

            // Validar el formato del número de teléfono y que este tenga las caragteristicas de un numero de telefono salvadoreño
            if (!ValidarTelefono(ObjUsers.txtNewPhone.Text))
            {
                MessageBoxP(Color.Yellow, Color.DarkRed, "Error", "El telefono debe de ser de El Salvador", Properties.Resources.MensajeWarning);
                return;
            }

            // Validar el formato y cantidad del correo solo si se ingresó uno
            string correoCliente = ObjUsers.txtNewCorreo.Text.Trim();
            if (!ValidarCorreo(correoCliente) || !ValidarCorreoCantidad(correoCliente))
            {
                MessageBoxP(Color.Yellow, Color.DarkRed, "Error", "Falta el @ o el dominio del correo o hay mas de 75 caragteres en el corréo", Properties.Resources.MensajeWarning);
                return;
            }

            // Validar que la direccion del empleado no exeda los 150 caracteres
            if (!ValidarDireccion(ObjUsers.txtNewDireccion.Text))
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", "Hay mas de 150 caragteres en la dirección", Properties.Resources.MensajeWarning);
                return;
            }

            // Validar el formato del DUI y que este no tenga menos de 8 numeros
            if (!ValidarDUI(ObjUsers.maskDui.Text))
            {
                MessageBoxP(Color.Yellow, Color.DarkRed, "Error", "Hay menos de 8 numeros en el dui", Properties.Resources.MensajeWarning);
                return;
            }

            // Validar que la fecha de nacimiento sea mayor de 18 años
            DateTime fechaNacimiento = ObjUsers.PickerBirth.Value.Date;
            DateTime fechaActual = DateTime.Today;
            int edad = fechaActual.Year - fechaNacimiento.Year;
            if (fechaNacimiento > fechaActual.AddYears(-edad)) edad--;

            if (edad < 18)
            {
                MessageBoxP(Color.Yellow, Color.DarkRed, "Error", "El usuario debe de ser mayor de 18 años", Properties.Resources.MensajeWarning);
                return;
            }

            //Declaramos que el usuario puede tener una imagen nula, es decir, puede si o no ponerse una imagen de perfil

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

            //Realizamos el proceso de inserción
            DAOAdminUsers DaoInsert = new DAOAdminUsers();
            Encryp ObjEncriptar = new Encryp();
            // Asignar los valores a las propiedades
            DaoInsert.Img = imageBytes;
            DaoInsert.Nombre1 = ObjUsers.txtNewFirstName.Text.Trim();
            DaoInsert.FechaDeNacimiento1 = fechaNacimiento;
            DaoInsert.Telefono1 = ObjUsers.txtNewPhone.Text.Trim();
            DaoInsert.Correo1 = ObjUsers.txtNewCorreo.Text.Trim();
            DaoInsert.DUI1 = ObjUsers.maskDui.Text;
            DaoInsert.Direccion1 = ObjUsers.txtNewDireccion.Text.Trim();
            DaoInsert.Usuario1 = ObjUsers.txtNewUser.Text.Trim();
            DaoInsert.Contraseña1 = ObjEncriptar.Encriptar(ObjUsers.txtNewPassword.Text);
            DaoInsert.IdCategoria = int.Parse(ObjUsers.DropRole.SelectedValue.ToString());
            //Pedimos una contestación por parte de la base de datos, si nos manda un 1 es que si se logro realizar correctamente la insercción
            verificacion = ValidarCorreo(ObjUsers.txtNewCorreo.Text.Trim());
            if (verificacion == true)
            {
                int valorRetornado = DaoInsert.RegistrarUsuario();
                if (valorRetornado == 1)
                {
                    //Mensaje de afirmacion si se pudo realizar la inserccion
                    string newUser = DaoInsert.Usuario1;
                    MandarValoresAlerta(Color.LightGreen, Color.Black, "Proceso realizado", "El usuario fue registrado", Properties.Resources.comprobado);
                    VistaLogin backForm = new VistaLogin();
                    ObjUsers.Close();

                    VistaPreguntas pre = new VistaPreguntas(newUser, 1);
                    pre.ShowDialog();
                }
                else
                {
                    //Mensaje de error si se no se pudo realizar la inserccion
                    MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "Verifique que el usuario no se este duplicando", Properties.Resources.ErrorIcono);
                    VistaLogin backForm = new VistaLogin();
                }
            }

            // Método para validar que el usuario no excede los 50 caracteres
            bool ValidarUsuario(string usuario)
            {
                return usuario.Length <= 50;
            }

            bool ValidarContraseña(string contraseña)
            {
                // Requiere más de 8 caracteres (letras, dígitos o caracteres especiales)
                string pattern = @"^.{9,}$";  // Acepta cualquier carácter y al menos 9 de ellos

                if (!Regex.IsMatch(contraseña, pattern))
                {
                    return false;
                }
                return true;
            }

            // Método para validar que el nombre contiene solo letras y espacios
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

            // Método para validar que el nombre no excede los 65 caracteres
            bool ValidarNombre(string nombre)
            {
                return nombre.Length <= 65;
            }

            // Método para validar que la dirección no excede los 150 caracteres
            bool ValidarDireccion(string direccion)
            {
                return direccion.Length <= 150;
            }

            // Método para validar el formato del número de teléfono (El Salvador)
            bool ValidarTelefono(string telefono)
            {
                string pattern = @"^[267]\d{7}$"; // 8 dígitos, empezando con 2, 6, o 7
                return Regex.IsMatch(telefono, pattern);
            }

            // Método para validar el formato del correo electrónico
            bool ValidarCorreo(string email)
            {
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; // Formato básico de correo
                return Regex.IsMatch(email, pattern);
            }

            // Método para validar que el correo del empleado no exceda los 75 caracteres
            bool ValidarCorreoCantidad(string nombre)
            {
                return nombre.Length <= 75;
            }

            // Método para validar el formato del DUI
            bool ValidarDUI(string dui)
            {
                // Expresión regular para verificar 8 dígitos seguidos de un guion y luego 1 dígito
                string pattern = @"^\d{8}-\d$";
                if (!Regex.IsMatch(dui, pattern))
                {
                    return false;
                }
                return true;
            }
        }
    }
}
