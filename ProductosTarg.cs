using AgroServicios.Controlador;
using AgroServicios.Vista.MenuPrincipal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios
{
    public partial class ProductosTarg : UserControl
    {
        private int id = 0;
        private Size originalSize;

        // Importar las funciones de la API de Windows para aplicar bordes redondeados
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,      // X-coordinate of upper-left corner
            int nTopRect,       // Y-coordinate of upper-left corner
            int nRightRect,     // X-coordinate of lower-right corner
            int nBottomRect,    // Y-coordinate of lower-right corner
            int nWidthEllipse,  // Width of ellipse
            int nHeightEllipse  // Height of ellipse
        );
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
                bunifuPanel1.BackgroundColor = Color.White;
                lblcodigo.ForeColor = Color.White;
                lblname.ForeColor = Color.FromArgb(230, 119, 11);
                lblPrecio.ForeColor = Color.White;
                bunifuShadowPanel1.ShadowColor = Color.DimGray;
            }

            if (ControladorIdioma.idioma == 1) 
            {
                btnSeleccionar.Text = Ingles.Seleccionar;
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
        private void ptbimg_MouseEnter(object sender, EventArgs e)
        {
            // Aumentar el tamaño del PictureBox cuando el cursor está sobre la imagen
            ptbimg.Size = new Size(originalSize.Width + 5, originalSize.Height + 5);
            ptbimg.Location = new Point(ptbimg.Location.X - 5, ptbimg.Location.Y - 5); // Ajustar la posición
        }
        private void ptbimg_MouseLeave(object sender, EventArgs e)
        {
            // Restaurar el tamaño original del PictureBox cuando el cursor sale de la imagen
            ptbimg.Size = originalSize;
            ptbimg.Location = new Point(ptbimg.Location.X + 5, ptbimg.Location.Y + 5); // Restaurar la posición
        }
        private void bunifuButton21_Click(object sender, EventArgs e)
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
