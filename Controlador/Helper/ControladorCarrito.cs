using AgroServicios.Vista.MenuPrincipal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Controlador.Helper
{
    internal class ControladorCarrito
    {
        VistaCarrito objcarrito;

        public ControladorCarrito (VistaCarrito Vista)
        {
            objcarrito = Vista;
            objcarrito.btneliminar.Click += Borrarcompra;

        }
        private void Borrarcompra(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Esta seguro que desea eliminar está compra?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                objcarrito.dgvCarrito.Rows.Clear();
                objcarrito.dgvTotal.Rows.Clear();
            }
            
        }
    }
}
