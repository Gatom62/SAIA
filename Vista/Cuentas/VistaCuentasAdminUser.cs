using AgroServicios.Controlador;
using AgroServicios.Controlador.CuentasContralador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Vista.Cuentas
{
    public partial class VistaCuentasAdminUser : Form
    {
        private Size originalSize;
        public VistaCuentasAdminUser()
        {
            InitializeComponent();
            ControladorCuentasAdminUser controladorCuentas = new ControladorCuentasAdminUser(this);

            //Metodos para hacer que la imagen cresca cuando el mause pase por heya
            //Para el p
            // Cargar la imagen desde los recursos
            ptbback.Image = Properties.Resources.turn_left_11044726;
            originalSize = ptbback.Size;
            // Eventos para cuando el mouse entra y sale del PictureBox
            ptbback.MouseEnter += ptbback_MouseEnter;
            ptbback.MouseLeave += ptbback_MouseLeave;
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

        private void VistaCuentasAdminUser_Load(object sender, EventArgs e)
        {
            if (ControladorIdioma.idioma == 1)
            {
                cmsEliminar.Text = Ingles.CMSELIMINAR;
                cmsinfo.Text = Ingles.CMSINFO;
                cmsRestablecer.Text = Ingles.CMSREST;
                cmsUpdate.Text = Ingles.CMSUPDT;
            }

            if (ControladorTema.IsDarkMode == true)
            {
                tableLayoutPanel1.BackColor = Color.FromArgb(118, 88, 152);
                GriewEmpleados.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Dark;
                GriewEmpleados.BackgroundColor = Color.FromArgb(50, 56, 62);
            }
        }
    }
}
