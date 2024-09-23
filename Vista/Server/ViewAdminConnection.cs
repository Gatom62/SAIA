using AgroServicios.Controlador;
using AgroServicios.Controlador.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Vista.Server
{
    public partial class ViewAdminConnection : Form
    {
        private Size originalSize;
        public ViewAdminConnection(int origen)
        {
            InitializeComponent();
            ControllerAdminConnection objConnection = new ControllerAdminConnection(this, origen);
        }

        private void ViewAdminConnection_Load(object sender, EventArgs e)
        {
            if (ControladorTema.IsDarkMode == true)
            {
                this.BackColor = Color.Black;
                bunifuGradientPanel1.GradientBottomLeft = Color.FromArgb(118, 88, 152);
                bunifuGradientPanel1.GradientTopRight = Color.FromArgb(118, 88, 152);
                bunifuGradientPanel1.GradientBottomRight = Color.FromArgb(34, 36, 49);
                bunifuGradientPanel1.GradientTopLeft = Color.FromArgb(34, 36, 49);
                btnGuardar.BackColor = Color.DarkViolet;
                btnGuardar.ForeColor = Color.White;
                pnTitulo.BackgroundColor = Color.DimGray;
                pnMenu.BackgroundColor = Color.Gray;
            }

            if (ControladorIdioma.idioma == 1)
            {
                lbTitutlo.Text = Ingles.ConexcionBase;
                lbBaseDatos.Text = Ingles.BaseDatos;
                lbServidorUrl.Text = Ingles.ServidorURL;
                lbSQLAuthentication.Text = Ingles.SqlAuthentication;
                lbPasswordAuthenticarion.Text = Ingles.ContraseñaAuthentication;
                rdHabilitarWindows.Text = Ingles.HabilitarWindows;
                rdDeshabilitarWindows.Text = Ingles.HabilitarSql;
            }
        }
    }
    
}

