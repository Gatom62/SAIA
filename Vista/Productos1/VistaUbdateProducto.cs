using AgroServicios.Controlador;
using AgroServicios.Controlador.CuentasContralador;
using AgroServicios.Controlador.Productos1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AgroServicios.Vista.Productos1
{
    public partial class VistaUbdateProducto : Form
    {
        public VistaUbdateProducto(int accion, int id, int idMarc, string Name, string price, string stock, string description, string marc, string code, byte[] imagen)
        {
            InitializeComponent();
            ControladorUbdateProducto1 control = new ControladorUbdateProducto1(this, accion, id, idMarc, Name, price, stock, description, marc, code, imagen);
        }
        private void VistaUbdateProducto_Load(object sender, EventArgs e)
        {
            if (ControladorTema.IsDarkMode == true)
            {
                this.BackColor = Color.FromArgb(34, 36, 49);
                btnUbdateImagen.IdleFillColor = Color.FromArgb(230, 119, 11);
                btnUbdateImagen.onHoverState.FillColor = Color.FromArgb(211, 41, 15);
                btnUbdateImagen.onHoverState.BorderColor = Color.FromArgb(211, 41, 15);
                btnUbdateImagen.OnPressedState.FillColor = Color.Red;
                btnUbdateImagen.OnPressedState.BorderColor = Color.Red;
                btnUbdateImagen.DisabledFillColor = Color.DarkOrange;

                btnUbdateProducto.IdleFillColor = Color.FromArgb(230, 119, 11);
                btnUbdateProducto.onHoverState.FillColor = Color.FromArgb(211, 41, 15);
                btnUbdateProducto.onHoverState.BorderColor = Color.FromArgb(211, 41, 15);
                btnUbdateProducto.OnPressedState.FillColor = Color.Red;
                btnUbdateImagen.OnPressedState.BorderColor = Color.Red;
                btnUbdateImagen.DisabledFillColor = Color.DarkOrange;

                pnEstructura.BackgroundColor = Color.WhiteSmoke;

                txtUbdateProducto.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtUbdateProducto.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtUbdateCodigo.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtUbdateCodigo.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtUbdateCantidad.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtUbdateCantidad.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtUbdatePrecio.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtUbdatePrecio.BorderColorActive = Color.FromArgb(211, 41, 15);
                txtUbdateDescripcion.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtUbdateDescripcion.BorderColorActive = Color.FromArgb(211, 41, 15);
            }

            if (ControladorIdioma.idioma == 1)
            {
                bunifuLabel1.Text = Ingles.btnañadir;
                txtUbdateProducto.PlaceholderText = Ingles.NombreProducto;
                txtUbdateCodigo.PlaceholderText = Ingles.Codigo;
                txtUbdateCantidad.PlaceholderText = Ingles.CantidadProducto;
                btnUbdateImagen.Text = Ingles.AgregarImagen;
                btnUbdateProducto.Text = Ingles.Agregar;
                bunifuLabel3.Text = Ingles.Marca;
                bunifuLabel2.Text = Ingles.Descripcion;
            }

        }

        private void bunifuGradientPanel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
