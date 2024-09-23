using AgroServicios.Controlador;
using AgroServicios.Controlador.Productos1;
using iTextSharp.text.pdf.codec.wmf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;

namespace AgroServicios.Vista.Productos1
{
    public partial class VistaCreateMarca : Form
    {
        private Size originalSize;
        public VistaCreateMarca(int accion)
        {
            InitializeComponent();
            ControladorCreateMarca1 ObjCreateMarca = new ControladorCreateMarca1(this, accion);
        }
        private void VistaCreateMarca_Load(object sender, EventArgs e)
        {
            if (ControladorTema.IsDarkMode == true)
            {
                this.BackColor = Color.FromArgb(34, 36, 49);
                GriewViewMarcas.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Dark;
                GriewViewMarcas.BackgroundColor = Color.FromArgb(50, 56, 62);

                btnIngresarMarca.IdleFillColor = Color.DarkBlue;
                btnIngresarMarca.onHoverState.FillColor = Color.DarkViolet;
                btnIngresarMarca.onHoverState.BorderColor = Color.DarkViolet;
                btnIngresarMarca.OnPressedState.FillColor = Color.DodgerBlue;
                btnIngresarMarca.OnPressedState.BorderColor = Color.DodgerBlue;
                btnIngresarMarca.DisabledFillColor = Color.DarkViolet;

                btnIngresarMarca.DisabledFillColor = Color.FromArgb(118, 88, 152);
                btnIngresarMarca.ForeColor = Color.White;

                pnEstructura.BackgroundColor = Color.WhiteSmoke;

                txtNombreMarca.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtNombreMarca.BorderColorActive = Color.FromArgb(211, 41, 15);
            }

            if (ControladorIdioma.idioma == 1)
            {
                lbCrearNuevaMarca.Text = Ingles.CreateMarca;
                txtNombreMarca.Text = Ingles.NombreMarca;
                btnIngresarMarca.Text = Ingles.Agregar;
                cmsElimarProducto.Text = Ingles.Eliminar;
                cmsEditarMarca.Text = Ingles.EditarDatos;
            }
        }
    }
}
