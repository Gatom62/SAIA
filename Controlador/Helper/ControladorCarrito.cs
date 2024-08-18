using AgroServicios.Vista.MenuPrincipal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Controlador.Helper
{
    public class ControladorCarrito
    {
        private VistaCarrito objCarrito;

        public ControladorCarrito(VistaCarrito vistaCarrito)
        {
            objCarrito = vistaCarrito;
            objCarrito.btneliminar.Click += Borrarcompra;
        }

        public void AgregarProductoAlCarrito(string producto, int cantidad, decimal precioUnitario, decimal precioTotal)
        {
            // Verifica si el producto ya existe en el carrito
            foreach (DataGridViewRow row in objCarrito.dgvCarrito.Rows)
            {
                if (row.Cells["Producto"].Value != null &&
                    row.Cells["Producto"].Value.ToString() == producto)
                {
                    // Producto ya existe, actualiza la cantidad y el precio total
                    int cantidadExistente = int.Parse(row.Cells["Cantidad"].Value.ToString());
                    decimal precioTotalExistente = decimal.Parse(row.Cells["PrecioTotal"].Value.ToString(), System.Globalization.NumberStyles.Currency);

                    int nuevaCantidad = cantidadExistente + cantidad;
                    decimal nuevoPrecioTotal = precioTotalExistente + precioTotal;

                    row.Cells["Cantidad"].Value = nuevaCantidad;
                    row.Cells["PrecioTotal"].Value = nuevoPrecioTotal.ToString("C");

                    // Actualiza el total general
                    ActualizarTotal();
                    return;
                }
            }

            // Si el producto no existe, agrega una nueva fila
            objCarrito.dgvCarrito.Rows.Add(producto, cantidad, precioUnitario.ToString("C"), precioTotal.ToString("C"));

            // Actualiza el total general
            ActualizarTotal();
        }

        private void ActualizarTotal()
        {
            decimal total = 0m;

            // Suma el precio total de todos los productos en el carrito
            foreach (DataGridViewRow row in objCarrito.dgvCarrito.Rows)
            {
                if (row.Cells["PrecioTotal"].Value != null &&
                    !string.IsNullOrWhiteSpace(row.Cells["PrecioTotal"].Value.ToString()))
                {
                    total += decimal.Parse(row.Cells["PrecioTotal"].Value.ToString(), System.Globalization.NumberStyles.Currency);
                }
            }

            // Muestra el total en el dgvTotal
            objCarrito.dgvTotal.Rows[0].Cells[0].Value = total.ToString("C");
        }
        private void Borrarcompra(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea eliminar está compra?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                objCarrito.dgvCarrito.Rows.Clear();
                objCarrito.dgvTotal.Rows.Clear();
            }

        }

    }
}
