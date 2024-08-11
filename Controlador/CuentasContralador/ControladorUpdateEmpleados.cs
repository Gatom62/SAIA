using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Cuentas;
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
                Objupdate.maskedDuiUpdate.Enabled = false;
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
                string.IsNullOrWhiteSpace(Objupdate.maskedDuiUpdate.Text) ||
                string.IsNullOrWhiteSpace(Objupdate.txtUpdateDireccion.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.",
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            // Validar el formato del número de teléfono
            if (!ValidarTelefono(Objupdate.txtUpdatePhone.Text))
            {
                MessageBox.Show("El formato del número de teléfono es incorrecto. Debe ser +XXX XXXX-XXXX o XXXX-XXXX.",
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

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
            DaoUpdate.DUI1 = Objupdate.maskedDuiUpdate.Text;
            DaoUpdate.Direccion1 = Objupdate.txtUpdateDireccion.Text.Trim();

            verificacion = ValidarCorreo();
            if (verificacion == true)
            {
                int valorRetornado = DaoUpdate.ActualizarEmpleado();

                if (valorRetornado == 1)
                {
                    MessageBox.Show("Los datos han sido actualizados exitosamente",
                                    "Proceso completado",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    Objupdate.Close();
                }
                else
                {
                    MessageBox.Show("Los datos no pudieron ser actualizados",
                                    "Proceso interrumpido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        public void ChargeValues(int id, string Name, string phone, string email, string dni, string address, DateTime birthday, byte[] img, string user)
        {
            Objupdate.txtid.Text = id.ToString();
            Objupdate.txtUpdateNombre.Text = Name;
            Objupdate.txtUpdatePhone.Text = phone;
            Objupdate.txtUpdateCorreo.Text = email;
            Objupdate.maskedDuiUpdate.Text = dni;
            Objupdate.txtUpdateDireccion.Text = address;
            Objupdate.PickerBirthUpdate.Value = birthday;
            Objupdate.txtUser.Text = user;
            using (MemoryStream ms = new MemoryStream(img))
            {
                Objupdate.ptbactimg.Image = Image.FromStream(ms);
            }
        }

        bool ValidarTelefono(string phoneNumber)
        {
            //validar números de teléfono en los formatos: +XXX XXXX-XXXX o XXXX-XXXX
            string pattern = @"^(\+\d{1,3}\s\d{4}-\d{4}|\d{4}-\d{4})$";
            return Regex.IsMatch(phoneNumber, pattern);
        }
        bool ValidarCorreo()
        {
            string email = Objupdate.txtUpdateCorreo.Text.Trim();
            if (!(email.Contains("@")))
            {
                MessageBox.Show("Formato de correo invalido, verifica que contiene @.", "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
