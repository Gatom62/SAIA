using AgroServicios.Controlador;
using AgroServicios.Controlador.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Vista.MenuPrincipal
{
    public partial class VistaZoomProduct : Form
    {
        public VistaZoomProduct()
        {
            InitializeComponent();
        }

        private void VistaZoomProduct_Load(object sender, EventArgs e)
        {
            if (ControladorTema.IsDarkMode == true)
            {
                this.BackColor = Color.FromArgb(50, 56, 62);
                bunifuPanel2.BackgroundColor = Color.FromArgb(147, 231, 64);
                lblcodigo.ForeColor = Color.Black;
                lbldescripcion.ForeColor = Color.Black;
                lblname.ForeColor = Color.White;
                lblprecio.ForeColor = Color.Black;
                btnadd.IdleFillColor = Color.DarkViolet;
                btnadd.ForeColor = Color.White;
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0)
            {
                // Datos del producto a añadir
                string producto = lblname.Text;
                int cantidad = int.Parse(numericUpDown1.Value.ToString());
                decimal precioUnitario = decimal.Parse(lblprecio.Text, System.Globalization.NumberStyles.Currency);
                decimal precioTotal = cantidad * precioUnitario;

                // Usa el controlador para agregar el producto al carrito
                VistaCarrito.Instance.ControladorCarrito.AgregarProductoAlCarrito(producto, cantidad, precioUnitario, precioTotal);


                // Mensaje o notificación de que el producto se ha añadido
                MessageBox.Show("Producto añadido al carrito", "Se agrego el producto correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                numericUpDown1.Value = 0;
            }
            else
            {
                MessageBox.Show("La cantidad de productos debe ser mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
