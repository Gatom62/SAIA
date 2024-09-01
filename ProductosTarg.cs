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
        private Size originalSize;
        public ProductosTarg()
        {
            InitializeComponent();
            //Metodos para hacer que la imagen cresca cuando el mause pase por heya
            //Para el btnInicio
            // Cargar la imagen desde los recursos
            ptbimg.Image = ImgProducto;
            originalSize = ptbimg.Size;
            // Eventos para cuando el mouse entra y sale del PictureBox
            ptbimg.MouseEnter += ptbimg_MouseEnter;
            ptbimg.MouseLeave += ptbimg_MouseLeave;
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

                // Usa el controlador para agregar el producto al carrito
                VistaCarrito.Instance.ControladorCarrito.AgregarProductoAlCarrito(producto, cantidad, precioUnitario, precioTotal);

                // Mensaje o notificación de que el producto se ha añadido
                MessageBox.Show("Producto añadido al carrito.");
                numericUpDown1.Value = 0;
            }
            else
            {
                MessageBox.Show("La cantidad de productos debe ser mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ptbimg_MouseEnter(object sender, EventArgs e)
        {
            // Aumentar el tamaño del PictureBox cuando el cursor está sobre la imagen
            ptbimg.Size = new Size(originalSize.Width + 10, originalSize.Height + 10);
            ptbimg.Location = new Point(ptbimg.Location.X - 10, ptbimg.Location.Y - 10); // Ajustar la posición
        }

        private void ptbimg_MouseLeave(object sender, EventArgs e)
        {
            // Restaurar el tamaño original del PictureBox cuando el cursor sale de la imagen
            ptbimg.Size = originalSize;
            ptbimg.Location = new Point(ptbimg.Location.X + 10, ptbimg.Location.Y + 10); // Restaurar la posición
        }
    }
}
