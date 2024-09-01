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
        public VistaProveedores()
        {
            InitializeComponent();
            ControladorProveedores controladorProveedores = new ControladorProveedores(this);
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void contextGriewProveedores_Opening(object sender, CancelEventArgs e)
        {

        }

        private void VistaProveedores_Load(object sender, EventArgs e)
        {
            if (ControladorIdioma.idioma == 1)
            {
                btnAgregarProv.Text = Ingles.btnAñadirP;
                cmsActualizar.Text = Ingles.CMSUPP;
                cmsEliminar.Text = Ingles.CMSELIP;
            } 
            if (ControladorTema.IsDarkMode) 
            {
                {
                    GriewProveedores.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Dark;
                    GriewProveedores.BackgroundColor = Color.FromArgb(50, 56, 62);
                    tableLayoutPanel1.BackColor = Color.FromArgb(118, 88, 152);
                }
            }
        }
    }
}
