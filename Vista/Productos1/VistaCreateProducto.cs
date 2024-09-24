using AgroServicios.Controlador;
using AgroServicios.Controlador.Productos1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Vista.Productos1
{
    public partial class VistaCreateProducto : Form
    {
        public VistaCreateProducto(int accion)
        {
            InitializeComponent();
            ControladorCreateProducto1 ObjCreateProducto1 = new ControladorCreateProducto1(this, accion);
        }

        private void VistaCreateProducto_Load(object sender, EventArgs e)
        {
            if (ControladorTema.IsDarkMode == true)
            {
                this.BackColor = Color.FromArgb(34, 36, 49);
                btnImagenProducto.IdleFillColor = Color.FromArgb(230, 119, 11);
                btnImagenProducto.onHoverState.FillColor = Color.FromArgb(211, 41, 15);
                btnImagenProducto.onHoverState.BorderColor = Color.FromArgb(211, 41, 15);
                btnImagenProducto.OnPressedState.FillColor = Color.Red;
                btnImagenProducto.OnPressedState.BorderColor = Color.Red;
                btnImagenProducto.DisabledFillColor = Color.DarkOrange;

                btnCrearProducto.IdleFillColor = Color.DarkBlue;
                btnCrearProducto.onHoverState.FillColor = Color.DarkViolet;
                btnCrearProducto.onHoverState.BorderColor = Color.DarkViolet;
                btnCrearProducto.OnPressedState.FillColor = Color.DodgerBlue;
                btnCrearProducto.OnPressedState.BorderColor = Color.DodgerBlue;
                btnCrearProducto.DisabledFillColor = Color.DarkViolet;

                btnCrearProducto.DisabledFillColor = Color.FromArgb(118, 88, 152);
                btnCrearProducto.ForeColor = Color.White;

                pnEstructura.BackgroundColor = Color.WhiteSmoke;

                txtNombreProducto.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtNombreProducto.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtCodigo.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtCodigo.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtCantidad.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtCantidad.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtPrecio.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtPrecio.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtDescripcion.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtDescripcion.BorderColorActive = Color.FromArgb(211, 41, 15);
            }

            if (ControladorIdioma.idioma == 1)
            {
                bunifuLabel1.Text = Ingles.btnañadir;
                txtNombreProducto.PlaceholderText = Ingles.NombreProducto;
                txtCodigo.PlaceholderText = Ingles.Codigo;
                txtCantidad.PlaceholderText = Ingles.CantidadProducto;
                btnImagenProducto.Text = Ingles.AgregarImagen;
                btnCrearProducto.Text = Ingles.Agregar;
                bunifuLabel3.Text = Ingles.Marca;
                bunifuLabel2.Text = Ingles.Descripcion;
            }
            // Asignar eventos a los BunifuTextBox para deshabilitar copiar, pegar y cortar
            txtNombreProducto.KeyDown += txtNombreProducto_KeyDown;
            txtNombreProducto.ContextMenuStrip = null; // Deshabilitar menú contextual
        }

        // Manejar Ctrl+C, Ctrl+V, Ctrl+X y bloquear copiar, pegar o cortar
        private void txtNombreProducto_KeyDown(object sender, KeyEventArgs e)
        {
            // Detectar si Ctrl está presionado y alguna de las teclas de cortar, copiar, pegar
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V || e.KeyCode == Keys.X))
            {
                // Evitar la acción de copiar, pegar o cortar
                e.SuppressKeyPress = true;
            }
        }
    }
}
