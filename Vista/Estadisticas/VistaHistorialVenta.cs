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

namespace AgroServicios.Vista.Estadisticas
{
    public partial class VistaHistorialVenta : Form
    {
        private Size originalSize;
        public VistaHistorialVenta()
        {
            InitializeComponent();
            ControladorHistorialVenta control = new ControladorHistorialVenta(this);

            //Metodos para hacer que la imagen cresca cuando el mause pase por heya
            //Para el p
            // Cargar la imagen desde los recursos
            ptbback.Image = Properties.Resources.turn_left_11044726;
            originalSize = ptbback.Size;
            // Eventos para cuando el mouse entra y sale del PictureBox
            ptbback.MouseEnter += ptbback_MouseEnter;
            ptbback.MouseLeave += ptbback_MouseLeave;
        }

        private void VistaHistorialVenta_Load(object sender, EventArgs e)
        {
            if(ControladorTema.IsDarkMode == true)
            {
                tableLayoutPanel1.BackColor = Color.FromArgb(118, 88, 152);
                dgvVentas.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Dark;
                dgvVentas.BackgroundColor = Color.FromArgb(50, 56, 62);

                btnDevoluciones.IdleFillColor = Color.FromArgb(230, 119, 11);
                btnDevoluciones.onHoverState.FillColor = Color.FromArgb(211, 41, 15);
                btnDevoluciones.onHoverState.BorderColor = Color.FromArgb(211, 41, 15);
                btnDevoluciones.OnPressedState.FillColor = Color.Red;
                btnDevoluciones.OnPressedState.BorderColor = Color.Red;
                btnDevoluciones.DisabledFillColor = Color.DarkOrange;

                btnReporte.IdleFillColor = Color.FromArgb(230, 119, 11);
                btnReporte.onHoverState.FillColor = Color.FromArgb(211, 41, 15);
                btnReporte.onHoverState.BorderColor = Color.FromArgb(211, 41, 15);
                btnReporte.OnPressedState.FillColor = Color.Red;
                btnReporte.OnPressedState.BorderColor = Color.Red;
                btnReporte.DisabledFillColor = Color.DarkOrange;

                btnEstadisticas.IdleFillColor = Color.FromArgb(230, 119, 11);
                btnEstadisticas.onHoverState.FillColor = Color.FromArgb(211, 41, 15);
                btnEstadisticas.onHoverState.BorderColor = Color.FromArgb(211, 41, 15);
                btnEstadisticas.OnPressedState.FillColor = Color.Red;
                btnEstadisticas.OnPressedState.BorderColor = Color.Red;
                btnEstadisticas.DisabledFillColor = Color.DarkOrange;

                txtBuscarP.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtBuscarP.BorderColorActive = Color.FromArgb(211, 41, 15);

                tableLayoutPanel3.BackColor = Color.FromArgb(211, 41, 15);
            }

            if (ControladorIdioma.idioma == 1)
            {
                label1.Text = "Sales history";
                btnDevoluciones.Text = "Returns";
                btnReporte.Text = "Sales sheet";
                txtBuscarP.PlaceholderText = "Look for";
                btnEstadisticas.Text = "Statistics";
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
