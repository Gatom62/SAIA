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

        public void AgregarImagen(object sender, EventArgs e) 
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png| Todos los archivos(*.*)| *.* ";
            ofd.Title = "Seleccionar Imagen";

            if (ofd.ShowDialog() == DialogResult.OK) 
            {
                string rutaImagen = ofd.FileName;
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
                ObjCreateProducto1.DropMarca.SelectedValue == null)
            {
                MessageBox.Show("Todos los campos son obligatorios.",
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

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
        }
    }
}
