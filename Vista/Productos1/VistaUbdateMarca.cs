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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AgroServicios.Vista.Productos1
{
    public partial class VistaUbdateMarca : Form
    {
        // Importar las funciones de la API de Windows para aplicar bordes redondeados
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,      // X-coordinate of upper-left corner
            int nTopRect,       // Y-coordinate of upper-left corner
            int nRightRect,     // X-coordinate of lower-right corner
            int nBottomRect,    // Y-coordinate of lower-right corner
            int nWidthEllipse,  // Width of ellipse
            int nHeightEllipse  // Height of ellipse
        );
        public VistaUbdateMarca(int accion, int id, string Name)
        {
            InitializeComponent();
            ControladorUbdateMarca1 control = new ControladorUbdateMarca1(this, accion, id, Name);
            // Aplicar el borde redondeado al formulario
            this.FormBorderStyle = FormBorderStyle.None; // Deshabilitar el borde normal del formulario
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 30, 30));
        }

        private void VistaUbdateMarca_Load(object sender, EventArgs e)
        {
            if (ControladorTema.IsDarkMode == true)
            {
                this.BackColor = Color.FromArgb(34, 36, 49);

                pnEstructura.BackgroundColor = Color.WhiteSmoke;

                btnUbdateMarca.IdleFillColor = Color.FromArgb(230, 119, 11);
                btnUbdateMarca.onHoverState.FillColor = Color.FromArgb(211, 41, 15);
                btnUbdateMarca.onHoverState.BorderColor = Color.FromArgb(211, 41, 15);
                btnUbdateMarca.OnPressedState.FillColor = Color.Red;
                btnUbdateMarca.OnPressedState.BorderColor = Color.Red;
                btnUbdateMarca.DisabledFillColor = Color.DarkOrange;

                txtUbdateMarca.BorderColorHover = Color.FromArgb(211, 41, 15);
                txtUbdateMarca.BorderColorActive = Color.FromArgb(211, 41, 15);
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
