using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Cuentas;
using AgroServicios.Vista.Login;
using AgroServicios.Vista.Notificación;
using AgroServicios.Vista.Productos1;
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

namespace AgroServicios.Controlador.Productos1
{
    class ControladorCreateProducto1
    {
        VistaCreateProducto ObjCreateProducto1;
        private int accion;
        private string marca;

        /// <summary>
        /// Constructor para inserción de datos
        /// </summary>
        /// <param name="Vista"></param
        /// <param name="accion"> INSERCIÓN </param>

        public ControladorCreateProducto1(VistaCreateProducto Vista, int accion)
        {
            ObjCreateProducto1 = Vista;
            this.accion = accion;
            ObjCreateProducto1.Load += new EventHandler(InitialCharge);
            ObjCreateProducto1.btnCrearProducto.Click += new EventHandler(NuevoRegistro);
            ObjCreateProducto1.btnImagenProducto.Click += AgregarImagen;
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
                ObjCreateProducto1.ptbImagenProducto.Image = Image.FromFile(rutaImagen);
            }
        }

        public void InitialCharge(object sender, EventArgs e)
        {
            DAOProductos1 objmarcas = new DAOProductos1();
            //Declarando nuevo DataSet para que obtenga los datos del metodo LlenarCombo
            DataSet ds = objmarcas.LlenarCombo();
            //Llenar combobox tbRole
            ObjCreateProducto1.DropMarca.DataSource = ds.Tables["Marcas"];
            ObjCreateProducto1.DropMarca.ValueMember = "idMarca";
            ObjCreateProducto1.DropMarca.DisplayMember = "NombreMarca";
            //La condición sirve para que al actualizar un registro, el valor del registro aparezca seleccionado.
            if (accion == 2)
            {
                ObjCreateProducto1.DropMarca.Text = marca;
            }
        }

        public void NuevoRegistro(object sender, EventArgs e)
        {
            // Validamos que los campos no esten vacios cuando vallamos a ingresar los datos 
            if (string.IsNullOrWhiteSpace(ObjCreateProducto1.txtNombreProducto.Text) ||
                string.IsNullOrWhiteSpace(ObjCreateProducto1.txtCodigo.Text) ||
                string.IsNullOrWhiteSpace(ObjCreateProducto1.txtCantidad.Text) ||
                string.IsNullOrWhiteSpace(ObjCreateProducto1.txtPrecio.Text) ||
                string.IsNullOrWhiteSpace(ObjCreateProducto1.txtDescripcion.Text) ||
                ObjCreateProducto1.DropMarca.SelectedValue == null ||
                ObjCreateProducto1.ptbImagenProducto.Image == null)
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", "Todos los campos son obligatorios", Properties.Resources.MensajeWarning);
                return;
            }

            // Validar que el nombre del producto no exceda 80 caracteres
            if (!ValidarNombre(ObjCreateProducto1.txtNombreProducto.Text))
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", "El nombre tiene mas de 80 caragteres", Properties.Resources.MensajeWarning);
                return;
            }

            // Validar que la cantidad del producto contenga solo números enteros
            if (!ValidarNumero(ObjCreateProducto1.txtCodigo.Text) ||
                !ValidarNumero(ObjCreateProducto1.txtCantidad.Text))
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", "Numeros decimales o letras en el codigo o en la cantidad", Properties.Resources.MensajeWarning);
                return;
            }

            //Validamos que el codigo no exeda la cantidad de 12 numeros.
            if (!CantidadCodigo(ObjCreateProducto1.txtCodigo.Text))
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", "Hay mas de 12 numeros en el codigo", Properties.Resources.MensajeWarning);
                return;
            }

            //Validamos que el codigo no exeda la cantidad de 12 numeros.
            if (!CantidadStock(ObjCreateProducto1.txtCantidad.Text))
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", "Se quiere ingresar más de 500 productos del mismo tipo", Properties.Resources.MensajeWarning);
                return;
            }

            // Validar que el precio del producto contenga solo decimales
            if (!ValidarDecimales(ObjCreateProducto1.txtPrecio.Text))
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", "El precio tiene numeros enteros o letras o supero los 1000.00", Properties.Resources.MensajeWarning);
                return;
            }
            //Validamos que la descripción del producto solo contenga un maximo de 150 caragteres
            if (!ValidarDescripcion(ObjCreateProducto1.txtDescripcion.Text))
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", "Hay mas de 150 caragteres en la descripción", Properties.Resources.MensajeWarning);
                return;
            }
            //Validamos que el producto obligatoriamente si lleve imagen para ser ingresado
            Image imagen = ObjCreateProducto1.ptbImagenProducto.Image;
            byte[] imageBytes;
            if (imagen == null)
            {
                imageBytes = null;
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                imagen.Save(ms, ImageFormat.Jpeg);
                imageBytes = ms.ToArray();
            }
            //Realizamos el proceso de inserccion y de optencion de respuesta departe de la base de datos
            DAOProductos1 DaoInsert = new DAOProductos1();
            // Asignar los valores a las propiedades de DaoInsert
            DaoInsert.Img = imageBytes;
            DaoInsert.Nombre1 = ObjCreateProducto1.txtNombreProducto.Text.Trim();
            DaoInsert.Codigo1 = ObjCreateProducto1.txtCodigo.Text.Trim();
            DaoInsert.Stock1 = ObjCreateProducto1.txtCantidad.Text.Trim();
            DaoInsert.Precio1 = ObjCreateProducto1.txtPrecio.Text.Trim();
            DaoInsert.Descripcion1 = ObjCreateProducto1.txtDescripcion.Text.Trim();
            DaoInsert.IdMarca = int.Parse(ObjCreateProducto1.DropMarca.SelectedValue.ToString());
            //Pedimos una contestación por parte de la base de datos, si nos manda un uno es que si se logro realizar correctamente la insercción
            int valorRetornado = DaoInsert.RegistrarProducto();
            if (valorRetornado == 1)
            {
                //Mensaje de afirmacion si se pudo realizar la inserccion
                MandarValoresAlerta(Color.LightGreen, Color.Black, "Proceso realizado", "El producto fue registrado", Properties.Resources.comprobado);
                VistaLogin backForm = new VistaLogin();
                ObjCreateProducto1.Close();
            }
            else
            {
                //Mensaje de error si se no se pudo realizar la inserccion
                MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "Verifique que el producto no se este duplicando", Properties.Resources.ErrorIcono);
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
                // Aquí validamos que la cantidad del prodcuto solo debe contener solo dígitos numeros 
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

            bool CantidadStock(string numero)
            {
                // Intentar convertir la cantidad a un número entero
                if (int.TryParse(numero, out int cantidadNumero))
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

                // Validar que no exceda DECIMAL(10,2) - valor numérico
                if (decimal.TryParse(Decimal, out decimal valorDecimal))
                {
                    return valorDecimal <= 9999.99m; // Asegurar que no exceda 9999.99
                }

                return false; // Si no se puede parsear a decimal, retornar false
            }
        }
    }
}
