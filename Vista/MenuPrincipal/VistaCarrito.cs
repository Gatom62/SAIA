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
    public partial class VistaCarrito : Form
    {
        // Campo estático privado para mantener una sola instancia de VistaCarrito
        private static VistaCarrito _instance;

        // Propiedad estática para acceder a la instancia de VistaCarrito
        public static VistaCarrito Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VistaCarrito();
                }
                return _instance;
            }
        }

        // Constructor privado para evitar la creación de nuevas instancias fuera de esta clase
        private VistaCarrito()
        {
            InitializeComponent();
            ControladorCarrito controladorCarrito = new ControladorCarrito(this);
        }

        public void AgregarProductoAlCarrito(string producto, int cantidad, decimal precioUnitario, decimal precioTotal)
        {
            // Agrega una fila al DataGridView con los detalles del producto
            dgvCarrito.Rows.Add(producto, cantidad, precioUnitario.ToString("C"), precioTotal.ToString("C"));

            // Actualiza el total
            ActualizarTotal();
        }

        private void ActualizarTotal()
        {
            decimal total = 0m;

            // Suma el precio total de todos los productos en el carrito
            foreach (DataGridViewRow row in dgvCarrito.Rows)
            {
                // Verifica que la celda no sea nula y que tenga un valor válido
                if (row.Cells["PrecioTotal"].Value != null &&
                    !string.IsNullOrWhiteSpace(row.Cells["PrecioTotal"].Value.ToString()))
                {
                    // Intenta convertir el valor de la celda a decimal
                    total += decimal.Parse(row.Cells["PrecioTotal"].Value.ToString(), System.Globalization.NumberStyles.Currency);
                }
            }

            // Muestra el total en el dgvTotal
            dgvTotal.Rows[0].Cells[0].Value = total.ToString("C");
        }
    }
}



