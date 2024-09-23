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
        private Size originalSize;
        public VistaProductos()
        {
            InitializeComponent();
            ControladorVistaProductos1 ObjProductosVista = new ControladorVistaProductos1(this);

            //Metodos para hacer que la imagen cresca cuando el mause pase por heya
            //Para el p
            // Cargar la imagen desde los recursos
            ptbback.Image = Properties.Resources.turn_left_11044726;
            originalSize = ptbback.Size;
            // Eventos para cuando el mouse entra y sale del PictureBox
            ptbback.MouseEnter += ptbback_MouseEnter;
            ptbback.MouseLeave += ptbback_MouseLeave;
        }

        private void VistaProductos_Load(object sender, EventArgs e)
        {
            if (ControladorTema.IsDarkMode == true)
            {
                this.BackColor = Color.Black;
                lbProducto.BackColor = Color.Transparent;
                lbProducto.ForeColor = Color.White;
                GriewViewProductos.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Dark;
                GriewViewProductos.BackgroundColor = Color.FromArgb(50, 56, 62);

                btnAgregarProducto.IdleFillColor = Color.DarkBlue;
                btnAgregarProducto.onHoverState.FillColor = Color.DarkViolet;
                btnAgregarProducto.onHoverState.BorderColor = Color.DarkViolet;
                btnAgregarProducto.OnPressedState.FillColor = Color.DodgerBlue;
                btnAgregarProducto.OnPressedState.BorderColor = Color.DodgerBlue;
                btnAgregarProducto.DisabledFillColor = Color.DarkViolet;

                btnAgregarProducto.DisabledFillColor = Color.FromArgb(118, 88, 152);
                btnAgregarProducto.ForeColor = Color.White;

                btnAgregarMarca.IdleFillColor = Color.FromArgb(230, 119, 11);
                btnAgregarMarca.onHoverState.FillColor = Color.FromArgb(211, 41, 15);
                btnAgregarMarca.onHoverState.BorderColor = Color.FromArgb(211, 41, 15);
                btnAgregarMarca.OnPressedState.FillColor = Color.Red;
                btnAgregarMarca.OnPressedState.BorderColor = Color.Red;
                btnAgregarMarca.DisabledFillColor = Color.DarkOrange;

                tableLayoutPanel1.BackColor = Color.FromArgb(118, 88, 152);
            }

            if (ControladorIdioma.idioma == 1)
            {
                lbProducto.Text = Ingles.LabelTitulo;
                btnAgregarMarca.Text = Ingles.AgregarMarca;
                btnAgregarProducto.Text = Ingles.AgregarProducto;
                cmsEditarProducto.Text = Ingles.EditarProducto;
                cmsElimarProducto.Text = Ingles.Eliminar;
                cmsInformacion.Text = Ingles.Informacion;
            }
        }

        private void ptbback_MouseEnter(object sender, EventArgs e)
        {
            // Aumentar el tamaño del PictureBox cuando el cursor está sobre la imagen
            ptbback.Size = new Size(originalSize.Width + 20, originalSize.Height + 20);
            ptbback.Location = new Point(ptbback.Location.X - 10, ptbback.Location.Y - 20); // Ajustar la posición
        }

        private void ptbback_MouseLeave(object sender, EventArgs e)
        {
            // Restaurar el tamaño original del PictureBox cuando el cursor sale de la imagen
            ptbback.Size = originalSize;
            ptbback.Location = new Point(ptbback.Location.X + 10, ptbback.Location.Y + 10); // Restaurar la posición
        }
    }
}
