using AgroServicios.Controlador;
using AgroServicios.Vista.MenuPrincipal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios
{
    public partial class ProductosTarg : UserControl
    {
        private int id = 0;
        public ProductosTarg()
        {
            InitializeComponent();
        }
        public int Id {  get { return id; } set {  id = value; } }
        public string Descripcion { 
            get {  return lbldesc.Text; } 
            set {  lbldesc.Text = value; } 
        }
        public Image ImgProducto {
            get { return ptbimg.Image; } 
            set { ptbimg.Image = value; } 
        }
        public string nameProduct
        {
            get { return lblname.Text; }
            set { lblname.Text = value; }
        }
        public string Precio
        {
            get { return lblPrecio.Text; }
            set { lblPrecio.Text = value; }
        }
        public string Code
        {
            get { return lblcodigo.Text; }
            set { lblcodigo.Text = value; }
        }

        private void ProductosTarg_Load(object sender, EventArgs e)
        {
            if (ControladorTema.IsDarkMode == true)
            {
                bunifuPanel1.BackgroundColor = Color.FromArgb(118, 88, 152);
                lblcodigo.ForeColor = Color.White;
                lblname.ForeColor = Color.White;
                lblPrecio.ForeColor = Color.White;
            }
        }

        private void ptbimg_Click_1(object sender, EventArgs e)
        {
            using (VistaZoomProduct mm = new VistaZoomProduct())
            {
                Form form = new Form();
                form.StartPosition = FormStartPosition.Manual;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Opacity = .70d;
                form.BackColor = Color.Black;
                form.WindowState = FormWindowState.Maximized;
                form.TopMost = true;
                form.Location = this.Location;
                form.ShowInTaskbar = false;
                form.Show();

                mm.Owner = form;
       
                // Asigna los valores antes de mostrar el formulario
                mm.ptbimg.Image = this.ImgProducto;
                mm.lblname.Text = this.nameProduct;
                mm.lbldescripcion.Text = this.Descripcion;
                mm.lblcodigo.Text = this.Code;
                mm.lblprecio.Text = this.Precio;

                mm.ShowDialog();
                form.Dispose();
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0)
            {


                // Datos del producto a añadir
                string producto = lblname.Text;
                int cantidad = int.Parse(numericUpDown1.Value.ToString());
                decimal precioUnitario = decimal.Parse(lblPrecio.Text, System.Globalization.NumberStyles.Currency);
                decimal precioTotal = cantidad * precioUnitario;

                // Agrega el producto al DataGridView de VistaCarrito sin mostrar el formulario
                VistaCarrito.Instance.AgregarProductoAlCarrito(producto, cantidad, precioUnitario, precioTotal);

                // Mensaje o notificación de que el producto se ha añadido
                MessageBox.Show("Producto añadido al carrito.");
                numericUpDown1.Value = numericUpDown1.Value = 0;
            }
            else
            {
                MessageBox.Show("La cantidad de productos debe ser mayor a cero.", "Error",MessageBoxButtons.OK ,MessageBoxIcon.Warning);
            }
        }
    }
}
