using AgroServicios.Controlador;
using AgroServicios.Controlador.Helper;
using AgroServicios.Controlador.Login;
using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Login;
using AgroServicios.Vista.Notificación;
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
            ControladorZoom controladorZoom = new ControladorZoom(this);
        }

        private void VistaZoomProduct_Load(object sender, EventArgs e)
        {
            if (ControladorTema.IsDarkMode == true)
            {
                this.BackColor = Color.FromArgb(50, 56, 62);
                lblcodigo.ForeColor = Color.White;
                lblname.ForeColor = Color.White;
                lblprecio.ForeColor = Color.White;
                btnadd.IdleFillColor = Color.DarkViolet;
                btnadd.ForeColor = Color.White;
                lbCaragteristica.ForeColor = Color.White;
                bunifuLabel1.ForeColor = Color.White;
                lbPrecioProducto.ForeColor = Color.White;
                lbCantidad.ForeColor = Color.White;
                PanelDescrip.BorderColor = Color.White;
            }

            if (ControladorIdioma.idioma == 1)
            {
                bunifuLabel1.Text = "Product Description:";
                lbPrecioProducto.Text = Ingles.PrecioProducto;
                lbCaragteristica.Text = "Code:";
                lbCantidad.Text = Ingles.Cantidad;
                btnadd.Text = Ingles.AnadirCarrito;
            }
        }
        private void btnadd_Click_1(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0)
            {
                // Datos del producto a añadir
                string producto = lblname.Text;
                int cantidad = (int)numericUpDown1.Value;
                decimal precioUnitario = decimal.Parse(lblprecio.Text, System.Globalization.NumberStyles.Currency);
                decimal precioTotal = cantidad * precioUnitario;

                // Usa el controlador para agregar el producto al carrito
                VistaCarrito.Instance.ControladorCarrito.AgregarProductoAlCarrito(producto, cantidad, precioUnitario, precioTotal);

                // Mensaje o notificación de que el producto se ha añadido
                numericUpDown1.Value = 0;
            }
            else
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBox.Show("The quantity of products must be greater than zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else 
                {
                    MessageBox.Show("La cantidad de productos debe ser mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

    }
}
