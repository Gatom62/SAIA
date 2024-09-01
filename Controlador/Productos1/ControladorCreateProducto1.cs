using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Cuentas;
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
        /// <param name="Vista"></param>
        /// <param name="accion"> INSERCIÓN </param>

        public ControladorCreateProducto1(VistaCreateProducto Vista, int accion)
        {
            ObjCreateProducto1 = Vista;
            this.accion = accion;
            ObjCreateProducto1.Load += new EventHandler(InitialCharge);
            ObjCreateProducto1.btnCrearProducto.Click += new EventHandler(NuevoRegistro);
            ObjCreateProducto1.btnImagenProducto.Click += AgregarImagen;
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
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(ObjCreateProducto1.txtNombreProducto.Text) ||
                string.IsNullOrWhiteSpace(ObjCreateProducto1.txtCodigo.Text) ||
                string.IsNullOrWhiteSpace(ObjCreateProducto1.txtCantidad.Text) ||
                string.IsNullOrWhiteSpace(ObjCreateProducto1.txtPrecio.Text) ||
                string.IsNullOrWhiteSpace(ObjCreateProducto1.txtDescripcion.Text) ||
                ObjCreateProducto1.DropMarca.SelectedValue == null ||
                ObjCreateProducto1.ptbImagenProducto.Image == null)
            {
                MessageBox.Show("Todos los campos son obligatorios, incluyendo la imagen del producto.",
                   "Error de validación",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                return;
            }

            // Validar que el nombre del producto no exceda 80 caracteres
            if (!ValidarNombre(ObjCreateProducto1.txtNombreProducto.Text))
            {
                MessageBox.Show("El nombre del producto no debe exceder los 80 caracteres.",
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (!ValidarDescripcion(ObjCreateProducto1.txtDescripcion.Text))
            {
                MessageBox.Show("El nombre del producto no debe exceder los 150 caracteres.",
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            // Validar que la cantidad del producto contenga solo números
            if (!ValidarNumero(ObjCreateProducto1.txtCodigo.Text)||
                !ValidarNumero(ObjCreateProducto1.txtCantidad.Text))
            {
                MessageBox.Show("La cantidad del producto solo debe contener números enteros, como 1, 2, 3..",
                                "Error de al ingresar la cantidad",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            // Validar que el precio del producto contenga solo decimales
            if (!ValidarDecimales(ObjCreateProducto1.txtPrecio.Text))
            {
                MessageBox.Show("El precio del producto solo debe contener números decimales o no debe de exeder la cantidad de 10000000.00",
                                "Error de al ingresar el precio",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            // Declara una variable byte[] llamada imageBytes y la inicializa como null.
            // Esta variable almacenará los bytes de la imagen si hay una imagen en el PictureBox.
            byte[] imageBytes = null;

            // Verifica si la propiedad Image del PictureBox (ptbImgUser) de ObjUsers no es null,
            // es decir, si hay una imagen cargada en el PictureBox.
            if (ObjCreateProducto1.ptbImagenProducto.Image != null)
            {
                // Crea un objeto MemoryStream para trabajar con datos en memoria.
                // El uso de 'using' asegura que el MemoryStream se libere correctamente después de su uso.
                using (MemoryStream ms = new MemoryStream())
                {
                    // Guarda la imagen que está en el PictureBox en el MemoryStream en formato JPEG.
                    ObjCreateProducto1.ptbImagenProducto.Image.Save(ms, ImageFormat.Jpeg);

                    // Convierte los datos de la imagen en el MemoryStream a un array de bytes
                    // y los asigna a la variable imageBytes.
                    imageBytes = ms.ToArray();
                }
            }

            DAOProductos1 DaoInsert = new DAOProductos1();
            // Asignar los valores a las propiedades de DaoInsert
            DaoInsert.Img = imageBytes;
            DaoInsert.Nombre1 = ObjCreateProducto1.txtNombreProducto.Text.Trim();
            DaoInsert.Codigo1 = ObjCreateProducto1.txtCodigo.Text.Trim();
            DaoInsert.Stock1 = ObjCreateProducto1.txtCantidad.Text.Trim();
            DaoInsert.Precio1 = ObjCreateProducto1.txtPrecio.Text.Trim();
            DaoInsert.Descripcion1 = ObjCreateProducto1.txtDescripcion.Text.Trim();  
            DaoInsert.IdMarca = int.Parse(ObjCreateProducto1.DropMarca.SelectedValue.ToString());
            int valorRetornado = DaoInsert.RegistrarProducto();
            if (valorRetornado == 1)
            {
                MessageBox.Show("Los datos han sido registrados exitosamente",
                                "Proceso completado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                ObjCreateProducto1.Close();
            }
            else
            {
                MessageBox.Show("Los datos no pudieron ser registrados",
                                "Proceso interrumpido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
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

            bool ValidarDecimales(string Decimal) 
            {
                // Validar formato decimal: hasta 8 dígitos enteros y 2 decimales
                string pattern = @"^\d{1,8}(\.\d{1,2})?$";
                if (!Regex.IsMatch(Decimal, pattern))
                {
                    return false; // Si no cumple con el formato, retornar false
                }

                // Validar que no exceda DECIMAL(10,2) - valor numérico
                if (decimal.TryParse(Decimal, out decimal valorDecimal))
                {
                    return valorDecimal <= 99999999.99m; // Asegurar que no exceda 99999999.99
                }

                return false; // Si no se puede parsear a decimal, retornar false
            }
        }
    }
}
