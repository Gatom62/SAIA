using AgroServicios.Controlador;
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
            if(ControladorTema.IsDarkMode == true)
            {
                this.BackColor = Color.FromArgb(50, 56, 62);
                bunifuPanel1.BackgroundColor = Color.FromArgb(230, 119, 11);
                bunifuPanel2.BackgroundColor = Color.FromArgb(147, 231, 64);
                lblcodigo.ForeColor = Color.Black;
                lbldescripcion.ForeColor = Color.Black;
                lblname.ForeColor = Color.White;
                lblprecio.ForeColor = Color.Black;
            }
        }
    }
}
