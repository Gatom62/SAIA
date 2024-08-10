using AgroServicios.Controlador;
using AgroServicios.Controlador.MenuPrincipal;
using AgroServicios.Modelo.DAO;
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
    public partial class VistaProductos : Form
    {
        public VistaProductos()
        {
            InitializeComponent();
            ControladorVistaProductos control = new ControladorVistaProductos(this);
        }

        private void VistaProductos_Load(object sender, EventArgs e)
        {
            if(ControladorTema.IsDarkMode == true)
            {
                this.BackColor = Color.FromArgb(18, 18, 18);
            }
        }
    }
}
