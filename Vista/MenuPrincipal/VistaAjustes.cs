using AgroServicios.Controlador;
using AgroServicios.Controlador.Helper;
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
    public partial class VistaAjustes : Form
    {
        public VistaAjustes()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CommonClasses.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void DarkMode_CheckedChanged(object sender, EventArgs e)
        {
            if (DarkMode.Checked)
            {
                ControladorTema.IsDarkMode = true;
            }
            else
            {
                ControladorTema.IsDarkMode = false;
            }
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            VistaMenuPrincipal vistaMenuPrincipal = new VistaMenuPrincipal();
            vistaMenuPrincipal.Show();
            this.Close();
        }

        private void VistaAjustes_Load(object sender, EventArgs e)
        {
            if (ControladorTema.IsDarkMode == false)
            {
                DarkMode.Checked = false;
            }
            else
            {
                DarkMode.Checked = true;
            }

            if (ControladorIdioma.idioma == 0)
            {
                switchidioma.Checked = false;
            }
            else
            {
                switchidioma.Checked = true;
            }

            label7.Text = StaticSession.Username;

            if (ControladorTema.IsDarkMode == true)
            {
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                label4.ForeColor = Color.White;
                label5.ForeColor = Color.White;
                label6.ForeColor = Color.White;
                label7.ForeColor = Color.White;
                tableLayoutPanel1.BackColor = Color.FromArgb(230, 119, 11);
                this.BackColor = Color.FromArgb(34, 36, 49);

            }
        }

        private void switchidioma_CheckedChanged(object sender, EventArgs e)
        {
            if (switchidioma.Checked)
            {
                ControladorIdioma.idioma = 1;
            }
            else
            {
                ControladorIdioma.idioma = 0;
            }
        }
    }
}
