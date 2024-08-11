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
                MessageBox.Show("Todos los campos son obligatorios.",
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
