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
    public partial class VistaUbdateMarca : Form
    {
        public VistaUbdateMarca(int accion, int id, string Name)
        {
            InitializeComponent();
            ControladorUbdateMarca1 control = new ControladorUbdateMarca1(this, accion, id, Name);
        }
        private void lbCrearNuevaMarca_Click(object sender, EventArgs e)
        {
        }

        private void VistaUbdateMarca_Load(object sender, EventArgs e)
        {
            if (ControladorTema.IsDarkMode == true)
            {
                this.BackColor = Color.Black;
                bunifuGradientPanel1.GradientBottomLeft = Color.FromArgb(118, 88, 152);
                bunifuGradientPanel1.GradientTopRight = Color.FromArgb(118, 88, 152);
                bunifuGradientPanel1.GradientBottomRight = Color.FromArgb(34, 36, 49);
                bunifuGradientPanel1.GradientTopLeft = Color.FromArgb(34, 36, 49);
                btnUbdateMarca.IdleFillColor = Color.FromArgb(118, 88, 152);
                btnUbdateMarca.ForeColor = Color.White;
            }

            if (ControladorIdioma.idioma == 1)
            {
                lbCrearNuevaMarca.Text = Ingles.EditarMarca;
                txtUbdateMarca.PlaceholderText = Ingles.NombreMarca;
                btnUbdateMarca.Text = Ingles.Actualizar;
            }

        }
    }
}
