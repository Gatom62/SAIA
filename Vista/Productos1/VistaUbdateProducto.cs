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
                bunifuGradientPanel2.GradientBottomLeft = Color.FromArgb(118, 88, 152);
                bunifuGradientPanel2.GradientTopRight = Color.FromArgb(118, 88, 152);
                bunifuGradientPanel2.GradientBottomRight = Color.FromArgb(34, 36, 49);
                bunifuGradientPanel2.GradientTopLeft = Color.FromArgb(34, 36, 49);
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
