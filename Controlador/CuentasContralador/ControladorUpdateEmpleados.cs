using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Cuentas;
using AgroServicios.Vista.Notificación;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AgroServicios.Controlador.CuentasContralador
{
    class ControladorUpdateEmpleados
    {
        VistaUpdateEmpleados Objupdate;
        private int accion;
        bool verificacion;

        public ControladorUpdateEmpleados(VistaUpdateEmpleados Vista, int accion, int id, string Name, string phone, string email, string dni, string address, DateTime birthday, byte[] img, string user)
        {
            Objupdate = Vista;
            this.accion = accion;
            //Objupdate.Load += new EventHandler(InitialCharge);
            verificarAccion();
            ChargeValues(id, Name, phone, email, dni, address, birthday, img, user);

            Objupdate.btnUpdateEmpleado.Click += new EventHandler(ActualizarRegistro);
            Objupdate.cmsactimg.Click += AgregarImagen;
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

        private void AgregarImagen(object sender, EventArgs e)
        {
            // Crea una instancia de OpenFileDialog, que permite al usuario seleccionar un archivo.
            OpenFileDialog ofd = new OpenFileDialog();

            // Establece un filtro para el cuadro de diálogo, limitando la selección a archivos de imagen
            // con extensiones .jpg, .jpeg, y .png, además de permitir seleccionar todos los archivos.
            ofd.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png| Todos los archivos(*.*)| *.* ";

            // Establece el título del cuadro de diálogo que se mostrará al usuario.
            ofd.Title = "Seleccionar imagen";

            // Abre el cuadro de diálogo y verifica si el usuario selecciona un archivo y presiona "OK".
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Almacena la ruta completa del archivo de imagen seleccionado en una variable string.
                string rutaImagen = ofd.FileName;

                // Carga la imagen desde la ruta del archivo y la asigna al PictureBox (ptbactimg) del objeto Objupdate.
                Objupdate.ptbactimg.Image = Image.FromFile(rutaImagen);

                // Asigna la ruta de la imagen al Tag del PictureBox, marcando que se ha cargado una nueva imagen.
                // Esto es útil para identificar que se ha actualizado la imagen en el formulario.
                Objupdate.ptbactimg.Tag = rutaImagen;
            }
        }

        //public void InitialCharge(object sender, EventArgs e)
        //{
        //    DAOAdminUsers objAdmin = new DAOAdminUsers();
        //    DataSet ds = objAdmin.LlenarCombo();

        //    Objupdate.DropRoleUpdate.DataSource = ds.Tables["Categorias"];
        //    Objupdate.DropRoleUpdate.ValueMember = "idCategoria";
        //    Objupdate.DropRoleUpdate.DisplayMember = "Nombre";

        //    if (accion == 2)
        //    {
        //        Objupdate.DropRoleUpdate.Text = role;
        //    }
        //}
        public void verificarAccion()
        {
            if (accion == 2)
            {
                Objupdate.bunifuLabel1.Text = Spanish.LabelFicha;

                Objupdate.btnUpdateEmpleado.Visible = false;
                if(ControladorIdioma.idioma == 1)
                {
                    Objupdate.bunifuLabel1.Text = Ingles.LabelFicha;
                }
           
                Objupdate.txtUpdateNombre.Enabled = false;
                Objupdate.txtUpdateCorreo.Enabled = false;
                Objupdate.txtUpdateDireccion.Enabled = false;
                Objupdate.txtUpdatePhone.Enabled = false;
                Objupdate.maskDuiUbdate.Enabled = false;
                Objupdate.PickerBirthUpdate.Enabled = false;
                Objupdate.cmsactimg.Visible = false;
            }
            if(accion == 1)
            {
                if(ControladorIdioma.idioma == 1)
                {
                    Objupdate.bunifuLabel1.Text = Ingles.tituloactualizar;
                }
            }
        }
        private void ActualizarRegistro(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Objupdate.txtUpdateNombre.Text) ||
                string.IsNullOrWhiteSpace(Objupdate.txtUpdatePhone.Text) ||
                string.IsNullOrWhiteSpace(Objupdate.txtUpdateCorreo.Text) ||
                string.IsNullOrWhiteSpace(Objupdate.maskDuiUbdate.Text) ||
                string.IsNullOrWhiteSpace(Objupdate.txtUpdateDireccion.Text))
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", "Hay campos sin llenar", Properties.Resources.MensajeWarning);
                return;
            }

            string nombreCliente = Objupdate.txtUpdateNombre.Text.Trim();
            // Validar que el nombre solo contenga letras y no exceda 65 caracteres
            if (!ValidarLetra(nombreCliente) || !ValidarNombre(nombreCliente))
            {
                MessageBoxP(Color.Yellow, Color.DarkRed, "Error", "El nombre nombre tiene numeros o tiene más de 65 letras", Properties.Resources.MensajeWarning);
                return;
            }

            // Validar el formato del número de teléfono
            if (!ValidarTelefono(Objupdate.txtUpdatePhone.Text))
            {
                MessageBoxP(Color.Yellow, Color.DarkRed, "Error", "El telefono debe de ser de El Salvador", Properties.Resources.MensajeWarning);
                return;
            }

            // Validar el formato y cantidad del correo solo si se ingresó uno
            string correoCliente = Objupdate.txtUpdateCorreo.Text.Trim();
            if (!ValidarCorreo(correoCliente) || !ValidarCorreoCantidad(correoCliente))
            {
                MessageBoxP(Color.Yellow, Color.DarkRed, "Error", "Falta el @ o el dominio del correo o hay mas de 75 caragteres en el corréo", Properties.Resources.MensajeWarning);
                return;
            }

            // Validar que la direccion del empleado no exeda los 100 caracteres
            if (!ValidarDireccion(Objupdate.txtUpdateDireccion.Text))
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", "La dirección no debe exceder los 150 caracteres", Properties.Resources.Report2);
                return;
            }

            // Validar que el dui tenga exactamente 9 caragteres, incluyendo la rallita
            if (!ValidarDUI(Objupdate.maskDuiUbdate.Text))
            {
                MessageBoxP(Color.Yellow, Color.DarkRed, "Error", "El DUI debe de tener 8 caragteres", Properties.Resources.Delete);
                return;
            }

            // Validar que la fecha de nacimiento sea mayor de 18 años
            DateTime fechaNacimiento = Objupdate.PickerBirthUpdate.Value.Date;
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
            // Esta variable almacenará los bytes de la imagen si se ha cargado una nueva imagen.
            byte[] imageBytes = null;

            // Verifica si el Tag del PictureBox (ptbactimg) en Objupdate no es null.
            // El Tag se usa para marcar si se ha cargado una nueva imagen.
            if (Objupdate.ptbactimg.Tag != null)
            {
                // Solo convierte la imagen a un array de bytes si se ha detectado que la imagen ha cambiado.
                // Obtiene la imagen actual del PictureBox.
                Image imagen = Objupdate.ptbactimg.Image;

                // Crea un objeto MemoryStream para trabajar con datos en memoria.
                // 'using' asegura que el MemoryStream se libere correctamente después de su uso.
                using (MemoryStream ms = new MemoryStream())
                {
                    // Guarda la imagen en el MemoryStream en formato JPEG.
                    imagen.Save(ms, ImageFormat.Jpeg);

                    // Convierte los datos de la imagen en el MemoryStream a un array de bytes
                    // y los asigna a la variable imageBytes.
                    imageBytes = ms.ToArray();
                }
            }

            DAOAdminUsers DaoUpdate = new DAOAdminUsers();
            DaoUpdate.Usuario1 = Objupdate.txtUser.Text.Trim();
            DaoUpdate.Img = imageBytes;
            DaoUpdate.IdEmpleado = int.Parse(Objupdate.txtid.Text.Trim());
            DaoUpdate.Nombre1 = Objupdate.txtUpdateNombre.Text.Trim();
            DaoUpdate.FechaDeNacimiento1 = Objupdate.PickerBirthUpdate.Value;
            DaoUpdate.Telefono1 = Objupdate.txtUpdatePhone.Text.Trim();
            DaoUpdate.Correo1 = Objupdate.txtUpdateCorreo.Text.Trim();
            DaoUpdate.DUI1 = Objupdate.maskDuiUbdate.Text;
            DaoUpdate.Direccion1 = Objupdate.txtUpdateDireccion.Text.Trim();

            verificacion = ValidarCorreo(Objupdate.txtUpdateCorreo.Text.Trim());
            if (verificacion == true)
            {
                int valorRetornado = DaoUpdate.ActualizarEmpleado();

                if (valorRetornado == 1)
                {
                    Objupdate.Close();
                    MessageBoxP(Color.LightGreen, Color.SeaGreen, "Exito", "Se ha actualizado el empleado", Properties.Resources.actualizar);
                }
                else
                {
                    MessageBoxP(Color.Red, Color.DarkRed, "Error", "No se pudo actualizar el empleado", Properties.Resources.Delete);
                    Objupdate.Close();
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

        public void ChargeValues(int id, string Name, string phone, string email, string dni, string address, DateTime birthday, byte[] img, string user)
        {
            Objupdate.txtid.Text = id.ToString();
            Objupdate.txtUpdateNombre.Text = Name;
            Objupdate.txtUpdatePhone.Text = phone;
            Objupdate.txtUpdateCorreo.Text = email;
            Objupdate.maskDuiUbdate.Text = dni;
            Objupdate.txtUpdateDireccion.Text = address;
            Objupdate.PickerBirthUpdate.Value = birthday;
            Objupdate.txtUser.Text = user;
            using (MemoryStream ms = new MemoryStream(img))
            {
                Objupdate.ptbactimg.Image = Image.FromStream(ms);
            }
        }
    }
}
