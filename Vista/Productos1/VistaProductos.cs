using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgroServicios.Controlador;
using AgroServicios.Controlador.Productos1;
using AgroServicios.Vista.Productos1;

namespace AgroServicios.Vista.Productos1 
{
    public partial class VistaProductos : Form
    {
        public VistaProductos()
        {
            InitializeComponent();
            ControladorVistaProductos1 ObjProductosVista = new ControladorVistaProductos1(this);
        }

        private void VistaProductos_Load(object sender, EventArgs e)
        {
            if (ControladorTema.IsDarkMode == true) 
            {
              this.BackColor = Color.Black;
            }
        }

        private void GriewViewProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ControladorTema.IsDarkMode == true)
            {
                GriewViewProductos.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Dark;
                GriewViewProductos.BackgroundColor = Color.FromArgb(50, 56, 62);
            }
        }
    }
}
