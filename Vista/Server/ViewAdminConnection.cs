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
            //Metodos para hacer que la imagen cresca cuando el mause pase por heya
            //Para el p
            // Cargar la imagen desde los recursos
            ptbback.Image = Properties.Resources.turn_left_11044726;
            originalSize = ptbback.Size;
            // Eventos para cuando el mouse entra y sale del PictureBox
            ptbback.MouseEnter += ptbback_MouseEnter;
            ptbback.MouseLeave += ptbback_MouseLeave;
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

