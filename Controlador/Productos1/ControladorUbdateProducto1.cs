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

        void AgregarImagen(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png| Todos los archivos(*.*)| *.* ";
            ofd.Title = "Seleccionar imagen";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string rutaImagen = ofd.FileName;
                Objupdate.ptbImagenProducto.Image = Image.FromFile(rutaImagen);
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

            Image imagen = Objupdate.ptbImagenProducto.Image;
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
            Objupdate.txtUbdatePrecio.Text = price;
            Objupdate.txtUbdateCantidad.Text = stock;
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
