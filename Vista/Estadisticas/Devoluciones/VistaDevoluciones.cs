using AgroServicios.Controlador;
using AgroServicios.Controlador.ControladorStats;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Vista.Estadisticas.Devoluciones
{
    public partial class VistaDevoluciones : Form
    {
        public VistaDevoluciones()
        {
            InitializeComponent();
            ControladorDevoluciones control = new ControladorDevoluciones(this);
        }
        private void VistaDevoluciones_Load(object sender, EventArgs e)
        {
            if(ControladorTema.IsDarkMode == true)
            {
                this.BackColor = Color.FromArgb(34, 36, 49);
                btnCrearDevoluciones.IdleFillColor = Color.DarkBlue;
                btnCrearDevoluciones.onHoverState.FillColor = Color.DarkViolet;
                btnCrearDevoluciones.onHoverState.BorderColor = Color.DarkViolet;
                btnCrearDevoluciones.OnPressedState.FillColor = Color.DodgerBlue;
                btnCrearDevoluciones.OnPressedState.BorderColor = Color.DodgerBlue;
                btnCrearDevoluciones.DisabledFillColor = Color.DarkViolet;

                btnCrearDevoluciones.DisabledFillColor = Color.FromArgb(118, 88, 152);
                btnCrearDevoluciones.ForeColor = Color.White;

                pnEstructura.BackgroundColor = Color.WhiteSmoke;

                txtMonto.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtMonto.BorderColorActive = Color.FromArgb(211, 41, 15);
            }

            if (ControladorIdioma.idioma == 1) 
            {
                LabelPrin.Text = Ingles.Ingresar_una_devolucion;
                lbCantidadProductoDevuelto.Text = Ingles.CantidadProductoDevuelto;
                lbFechaDevolucion.Text = Ingles.FechaDevolucion;
                lbIdVenta.Text = Ingles.IdVenta;
                lbMontoDevolucion.Text = Ingles.MontoDevolucion;
                lbMotivoDevolucion.Text = Ingles.MotivoDevolucion;
                lbNombreCliente.Text = Ingles.NombreCliente;
                lbNombreProducto.Text = Ingles.NombreProducto;
                btnCrearDevoluciones.Text = Ingles.CrearDevolucion;
            }
        }
    }
}
