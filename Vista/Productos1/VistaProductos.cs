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
                bunifuLabel1.BackColor = Color.Transparent;
                bunifuLabel1.ForeColor = Color.White;
                GriewViewProductos.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Dark;
                GriewViewProductos.BackgroundColor = Color.FromArgb(50, 56, 62);
                btnAgregarProducto.IdleFillColor = Color.DarkViolet;
                btnAgregarProducto.ForeColor = Color.White;
                tableLayoutPanel1.BackColor = Color.FromArgb(118, 88, 152);
            }

            if (ControladorIdioma.idioma == 1)
            {
                bunifuLabel1.Text = Ingles.LabelTitulo;
                btnAgregarMarca.Text = Ingles.AgregarMarca;
                btnAgregarProducto.Text = Ingles.AgregarProducto;
                cmsEditarProducto.Text = Ingles.EditarProducto;
                cmsElimarProducto.Text = Ingles.Eliminar;
                cmsInformacion.Text = Ingles.Informacion;
            }
        }
    }
}
