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
    }
}
