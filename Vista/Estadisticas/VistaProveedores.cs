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
    public partial class VistaProveedores : Form
    {
        private Size originalSize;
        public VistaProveedores()
        {
            InitializeComponent();
            ControladorProveedores controladorProveedores = new ControladorProveedores(this);

            //Metodos para hacer que la imagen cresca cuando el mause pase por heya
            //Para el p
            // Cargar la imagen desde los recursos
            ptbback.Image = Properties.Resources.turn_left_11044726;
            originalSize = ptbback.Size;
            // Eventos para cuando el mouse entra y sale del PictureBox
            ptbback.MouseEnter += ptbback_MouseEnter;
            ptbback.MouseLeave += ptbback_MouseLeave;
        }
        private void VistaProveedores_Load(object sender, EventArgs e)
        {
            if (ControladorIdioma.idioma == 1)
            {
                btnAgregarProv.Text = Ingles.btnAñadirP;
                cmsActualizar.Text = Ingles.CMSUPP;
                cmsEliminar.Text = Ingles.CMSELIP;
                label1.Text = "Suppliers";
                txtBuscarP.PlaceholderText = "Search";
            } 
            if (ControladorTema.IsDarkMode) 
            {
                {
                    GriewProveedores.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Dark;
                    GriewProveedores.BackgroundColor = Color.FromArgb(50, 56, 62);
                    tableLayoutPanel1.BackColor = Color.FromArgb(118, 88, 152);

                    btnAgregarProv.IdleFillColor = Color.DarkBlue;
                    btnAgregarProv.onHoverState.FillColor = Color.DarkViolet;
                    btnAgregarProv.onHoverState.BorderColor = Color.DarkViolet;
                    btnAgregarProv.OnPressedState.FillColor = Color.DodgerBlue;
                    btnAgregarProv.OnPressedState.BorderColor = Color.DodgerBlue;
                    btnAgregarProv.DisabledFillColor = Color.DarkViolet;

                    btnAgregarProv.DisabledFillColor = Color.FromArgb(118, 88, 152);
                    btnAgregarProv.ForeColor = Color.White;
                }
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
