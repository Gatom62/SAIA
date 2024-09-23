using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Cuentas;
using AgroServicios.Vista.Productos1;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using AgroServicios.Vista.Notificación;
using AgroServicios.Vista.Login;

namespace AgroServicios.Controlador.Productos1
{
    class ControladorUbdateProducto1
    {
        VistaUbdateProducto Objupdate;
        private int accion;
        private string marca;

        public ControladorUbdateProducto1(VistaUbdateProducto Vista, int accion, int id, int idMarca, string Name, string price, string stock, string description, string marc, string code, byte[] imagen)
        {
            Objupdate = Vista;
            this.accion = accion;
            //Objupdate.Load += new EventHandler(InitialCharge);
            verificarAccion();
            ChargeValues(id, idMarca, Name, price, stock, description, marc, code, imagen);

            Objupdate.Load += new EventHandler(InitialCharge);
            Objupdate.btnUbdateProducto.Click += new EventHandler(ActualizarRegistro);
            Objupdate.btnUbdateImagen.Click += AgregarImagen;
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
                Objupdate.ptbImagenProducto.Image = Image.FromFile(rutaImagen);

                // Asigna la ruta de la imagen al Tag del PictureBox, marcando que se ha cargado una nueva imagen.
                // Esto es útil para identificar que se ha actualizado la imagen en el formulario.
                Objupdate.ptbImagenProducto.Tag = rutaImagen;
            }
        }

        public void InitialCharge(object sender, EventArgs e)
        {
            DAOProductos1 objmarcas = new DAOProductos1();
            //Declarando nuevo DataSet para que obtenga los datos del metodo LlenarCombo
            DataSet ds = objmarcas.LlenarCombo();
            //Llenar combobox tbRole
            Objupdate.DropUbdateMarca.DataSource = ds.Tables["Marcas"];
            Objupdate.DropUbdateMarca.ValueMember = "idMarca";
            Objupdate.DropUbdateMarca.DisplayMember = "NombreMarca";
            //La condición sirve para que al actualizar un registro, el valor del registro aparezca seleccionado.
            if (accion == 2)
            {
                Objupdate.DropUbdateMarca.Text = marca;
            }
        }

        private void ActualizarRegistro(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Objupdate.txtUbdateProducto.Text) ||
               string.IsNullOrWhiteSpace(Objupdate.DropUbdateMarca.Text) ||
               string.IsNullOrWhiteSpace(Objupdate.txtUbdatePrecio.Text) ||
               string.IsNullOrWhiteSpace(Objupdate.txtUbdateCantidad.Text) ||
               string.IsNullOrWhiteSpace(Objupdate.txtUbdateDescripcion.Text) ||
               string.IsNullOrWhiteSpace(Objupdate.txtUbdateCodigo.Text))
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", "Todos los campos son obligatorios", Properties.Resources.MensajeWarning);
                return;
            }

            // Validar que el nombre del producto no exceda 30 caracteres
            if (!ValidarNombre(Objupdate.txtUbdateProducto.Text))
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", "El nombre tiene mas de 80 caragteres", Properties.Resources.MensajeWarning);
                return;
            }

            // Validar que la cantidad del producto contenga solo números enteros
            if (!ValidarNumero(Objupdate.txtUbdateCodigo.Text) ||
                !ValidarNumero(Objupdate.txtUbdateCantidad.Text))
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", "Numeros decimales o letras en el codigo o en la cantidad", Properties.Resources.MensajeWarning);
                return;
            }

            //Validamos que el codigo no exeda la cantidad de 12 numeros.
            if (!CantidadCodigo(Objupdate.txtUbdateCodigo.Text))
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", "Hay mas de 12 numeros en el codigo", Properties.Resources.MensajeWarning);
                return;
            }

            //Validamos que el codigo no exeda la cantidad de 12 numeros.
            if (!CantidadStock(Objupdate.txtUbdateCantidad.Text))
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", "Se quiere ingresar más de 500 productos del mismo tipo", Properties.Resources.MensajeWarning);
                return;
            }


            // Validar que el precio del producto contenga solo decimales
            if (!ValidarDecimales(Objupdate.txtUbdatePrecio.Text))
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", "El precio tiene numeros enteros o supero los 1000.00", Properties.Resources.MensajeWarning);
                return;
            }

            if (!ValidarDescripcion(Objupdate.txtUbdateDescripcion.Text))
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", "Hay mas de 150 caragteres en la descripción", Properties.Resources.MensajeWarning);
                return;
            }

            // Declara una variable byte[] llamada imageBytes y la inicializa como null.
            // Esta variable almacenará los bytes de la imagen si se ha cargado una nueva imagen.
            byte[] imageBytes = null;

            // Verifica si el Tag del PictureBox (ptbactimg) en Objupdate no es null.
            // El Tag se usa para marcar si se ha cargado una nueva imagen.
            if (Objupdate.ptbImagenProducto.Tag != null)
            {
                // Solo convierte la imagen a un array de bytes si se ha detectado que la imagen ha cambiado.
                // Obtiene la imagen actual del PictureBox.
                Image imagen = Objupdate.ptbImagenProducto.Image;

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

            DAOProductos1 DaoUpdate = new DAOProductos1();
            DaoUpdate.Img = imageBytes;
            DaoUpdate.IdProducto = int.Parse(Objupdate.txtid.Text.Trim());
            DaoUpdate.IdMarca = int.Parse(Objupdate.DropUbdateMarca.SelectedValue.ToString());
            DaoUpdate.Nombre1 = Objupdate.txtUbdateProducto.Text.Trim();
            DaoUpdate.Codigo1 = Objupdate.txtUbdateCodigo.Text.Trim();
            DaoUpdate.Stock1 = Objupdate.txtUbdateCantidad.Text.Trim();
            DaoUpdate.Precio1 = Objupdate.txtUbdatePrecio.Text.Trim();
            DaoUpdate.Descripcion1 = Objupdate.txtUbdateDescripcion.Text.Trim();

            int valorRetornado = DaoUpdate.ActualizarProducto();

            if (valorRetornado == 1)
            {
                MandarValoresAlerta(Color.LightGreen, Color.Black, "Proceso realizado", "El producto fue registrado", Properties.Resources.comprobado);
                VistaLogin backForm = new VistaLogin();
                Objupdate.Close();
            }
            else
            {
                MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "Verifique que el producto no se este duplicando o asociando a otro registro", Properties.Resources.ErrorIcono);
                VistaLogin backForm = new VistaLogin();
            }

            // Método para validar que el nombre del producto no exceda los 80 caracteres
            bool ValidarNombre(string nombre)
            {
                return nombre.Length <= 80;
            }

            // Método para validar la descripcion del producto y que este no exceda los 150 caracteres
            bool ValidarDescripcion(string descripcion)
            {
                return descripcion.Length <= 150;
            }

            bool ValidarNumero(string numero)
            {
                // Aquí asumimos que el DUI debe contener solo dígitos (sin guiones o espacios)
                // Se puede ajustar según el formato requerido, por ejemplo, permitir un guion
                string pattern = @"^\d+$"; // Solo dígitos
                return Regex.IsMatch(numero, pattern);
            }

            bool CantidadCodigo(string codigo)
            {
                // Intentar convertir el código a un número entero largo (long) 
                if (long.TryParse(codigo, out long cantidadCodigo))
                {
                    // Validar que la cantidad no exceda 12 dígitos
                    return cantidadCodigo <= 9999999999; // 12 dígitos
                }
                return false;
            }

            bool CantidadStock(string cantidad)
            {
                // Intentar convertir la cantidad a un número entero
                if (int.TryParse(cantidad, out int cantidadNumero))
                {
                    // Validar que la cantidad no exceda 500
                    return cantidadNumero <= 500;
                }

                // Si no se puede convertir a entero, retornar false
                return false;
            }

            bool ValidarDecimales(string Decimal)
            {
                // Validar formato decimal: hasta 8 dígitos enteros y 2 decimales
                string pattern = @"^\d{1,4}(\.\d{1,2})?$";
                if (!Regex.IsMatch(Decimal, pattern))
                {
                    return false; // Si no cumple con el formato, retornar false
                }

                // Validar que no exceda DECIMAL(4,2) - valor numérico
                if (decimal.TryParse(Decimal, out decimal valorDecimal))
                {
                    return valorDecimal <= 9999.99m; // Asegurar que no exceda 9999.99
                }

                return false; // Si no se puede parsear a decimal, retornar false
            }
        }

        public void verificarAccion()
        {
            if (accion == 2)
            {
                Objupdate.btnUbdateImagen.Enabled = false;
                Objupdate.btnUbdateProducto.Enabled = false;
                Objupdate.txtUbdateProducto.Enabled = false;
                Objupdate.txtUbdateCodigo.Enabled = false;
                Objupdate.txtUbdateCantidad.Enabled = false;
                Objupdate.txtUbdatePrecio.Enabled = false;
                Objupdate.txtUbdateDescripcion.Enabled = false;
            }
        }

        public void ChargeValues(int id, int idMarca, string Name, string price, string stock, string description, string marc, string code, byte[] imagen)
        {
            Objupdate.txtid.Text = id.ToString();
            Objupdate.txtIdMarca.Text = idMarca.ToString();
            Objupdate.txtUbdateProducto.Text = Name;
            Objupdate.txtUbdateCantidad.Text = price;
            Objupdate.txtUbdatePrecio.Text = stock;
            Objupdate.txtUbdateDescripcion.Text = description;
            Objupdate.txtUbdateCodigo.Text = code;
            Objupdate.DropUbdateMarca.Text = marc;
            using (MemoryStream ms = new MemoryStream(imagen))
            {
                Objupdate.ptbImagenProducto.Image = Image.FromStream(ms);
            }
        }
    }
}
