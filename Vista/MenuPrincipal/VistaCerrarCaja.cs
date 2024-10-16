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
using WMPLib;
using System.Media;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using System.IO;

namespace AgroServicios.Vista.MenuPrincipal
{
    public partial class VistaCerrarCaja : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        public VistaCerrarCaja()
        {
            InitializeComponent();
            ControladorCerrarCaja control = new ControladorCerrarCaja(this);
        }
        private void VistaCerrarCaja_Load(object sender, EventArgs e)
        {
            if (ControladorTema.IsDarkMode == true) 
            {
                this.BackColor = Color.FromArgb(34, 36, 49);
                dgvCierre.BackColor = Color.FromArgb(118, 88, 152);

                btnCerrarCaja.IdleFillColor = Color.FromArgb(230, 119, 11);
                btnCerrarCaja.onHoverState.FillColor = Color.FromArgb(211, 41, 15);
                btnCerrarCaja.onHoverState.BorderColor = Color.FromArgb(211, 41, 15);
                btnCerrarCaja.OnPressedState.FillColor = Color.Red;
                btnCerrarCaja.OnPressedState.BorderColor = Color.Red;
                btnCerrarCaja.DisabledFillColor = Color.DarkOrange;

                tableLayoutPanel2.BackColor = Color.FromArgb(118, 88, 152);

                dgvCierre.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Dark;
                dgvCierre.BackgroundColor = Color.FromArgb(50, 56, 62);
            }

            if (ControladorIdioma.idioma == 1) 
            {
                label1.Text = Ingles.CierreCaja;
                btnCerrarCaja.Text = Ingles.btnCierreCaja;
            }
        }
        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            // Crear un archivo temporal a partir del recurso embebido
            string tempFilePath = Path.GetTempFileName() + ".mp3";
            File.WriteAllBytes(tempFilePath, Properties.Resources.Sonido_caja_registradora);

            // Establecer la ruta del archivo temporal y reproducirlo
            player.URL = tempFilePath;
            player.controls.play();

            // Opcional: eliminar el archivo temporal cuando se cierre el formulario
            this.FormClosing += (s, args) => { if (File.Exists(tempFilePath)) File.Delete(tempFilePath); };
        }
    }
}
