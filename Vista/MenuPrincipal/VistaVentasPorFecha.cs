using AgroServicios.Controlador;
using AgroServicios.Controlador.MenuPrincipal;
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
    public partial class VistaVentasPorFecha : Form
    {
        public VistaVentasPorFecha()
        {
            InitializeComponent();
            ControladorFiltroVentas control = new ControladorFiltroVentas(this);
        }

        private void VistaVentasPorFecha_Load(object sender, EventArgs e)
        {
            if(ControladorTema.IsDarkMode == true)
            {
                tableLayoutPanel1.BackColor = Color.FromArgb(118, 88, 152);
                dtpfinal.ForeColor = Color.White;
                dtpinicio.ForeColor = Color.White;

                btnBuscar.IdleFillColor = Color.FromArgb(230, 119, 11);
                btnBuscar.onHoverState.FillColor = Color.FromArgb(211, 41, 15);
                btnBuscar.onHoverState.BorderColor = Color.FromArgb(211, 41, 15);
                btnBuscar.OnPressedState.FillColor = Color.Red;
                btnBuscar.OnPressedState.BorderColor = Color.Red;
                btnBuscar.DisabledFillColor = Color.DarkOrange;
            }
            if(ControladorIdioma.idioma == 1)
            {
                label1.Text = "Start date";
                label2.Text = "End date";
                label1.Text = "Filter product";
                btnBuscar.Text = "Search";
            }
        }

    }
}
