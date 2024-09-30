using System;

using System.Globalization;
using System.Windows.Forms;
using AgroServicios.Controlador.Login;
using AgroServicios.Controlador.MenuPrincipal;
using AgroServicios.Controlador;
using System.Drawing;
using Newtonsoft.Json.Linq;
using System.Numerics;
using System.Drawing.Imaging;

namespace AgroServicios.Vista.MenuPrincipal
{
    public partial class VistaMenuPrincipal : Form
    {
        public Control[] OriginalControls { get; private set; }
        private Size originalSize;

        public VistaMenuPrincipal()
        {
            InitializeComponent();
            ControladorMenuPrincipal control = new ControladorMenuPrincipal(this);
            // Guarda el estado original de los controles en PanelView
            OriginalControls = new Control[PanelContenedor.Controls.Count];
            PanelContenedor.Controls.CopyTo(OriginalControls, 0);

            //Metodos para hacer que la imagen cresca cuando el mause pase por heya
            //Para el btnInicio
            // Cargar la imagen desde los recursos
            btnInicio.Image = Properties.Resources.Casa_Logo2;
            originalSize = btnInicio.Size;
            // Eventos para cuando el mouse entra y sale del PictureBox
            btnInicio.MouseEnter += btnInicio_MouseEnter;
            btnInicio.MouseLeave += btnInicio_MouseLeave;

            //Para el boton del carrito
            // Cargar la imagen desde los recursos
            btnShop.Image = Properties.Resources.bolsita;
            originalSize = btnInicio.Size;
            // Eventos para cuando el mouse entra y sale del PictureBox
            btnShop.MouseEnter += btnShop_MouseEnter;
            btnShop.MouseLeave += btnShop_MouseLeave;

            //Para el boton de stats
            // Cargar la imagen desde los recursos
            btnStats.Image = Properties.Resources.image_49;
            originalSize = btnStats.Size;
            // Eventos para cuando el mouse entra y sale del PictureBox
            btnStats.MouseEnter += btnStats_MouseEnter;
            btnStats.MouseLeave += btnStats_MouseLeave;

            //Para el boton de cuentas
            // Cargar la imagen desde los recursos
            btnAccounts.Image = Properties.Resources.silueta_de_multiples_usuarios;
            originalSize = btnAccounts.Size;
            // Eventos para cuando el mouse entra y sale del PictureBox
            btnAccounts.MouseEnter += btnAccounts_MouseEnter;
            btnAccounts.MouseLeave += btnAccounts_MouseLeave;
        }

        private void horafecha_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("hh:mm:ss tt"); // "tt" agrega AM/PM

            if (ControladorIdioma.idioma == 1) // Inglés
            {
                CultureInfo cultureInfo = new CultureInfo("en-US");
                lblfecha.Text = DateTime.Now.ToString("D", cultureInfo);
            }
            else // Español
            {
                lblfecha.Text = DateTime.Now.ToLongDateString();
            }
        }


        private void VistaMenuPrincipal_Load(object sender, EventArgs e)
        {
            if (ControladorTema.IsDarkMode == true)
            {
                panel1.BackColor = Color.FromArgb(34, 36, 49);
                lblhora.ForeColor = Color.White;
                lblfecha.ForeColor = Color.FromArgb(68, 197, 197);
                PanelContenedor.BackColor = Color.FromArgb(18,18,18);
                btnprin2.IdleFillColor = Color.FromArgb(82, 208, 83);
               
                tableLayoutPanel1.BackColor = Color.FromArgb(230, 119, 11);
                btnInicio.BackColor = Color.FromArgb(230, 119, 11);
                btnShop.BackColor = Color.FromArgb(230, 119, 11);
                btnStats.BackColor = Color.FromArgb(230, 119, 11);
               
                bunifuPanel2.BackgroundColor = Color.FromArgb(34, 36, 49);
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.FromArgb(68, 197, 197);
                tableLayoutPanel2.BackColor = Color.FromArgb(34, 36, 49);
                tableLayoutPanel3.BackColor = Color.FromArgb(34, 36, 49);
                tableLayoutPanel4.BackColor = Color.FromArgb(34, 36, 49);
                tableLayoutPanel5.BackColor = Color.FromArgb(34, 36, 49);
                panel4.BackColor = Color.FromArgb(34, 36, 49);
                panel5.BackColor = Color.FromArgb(34, 36, 49);
            }
            if (ControladorIdioma.idioma == 1)
            {
                btnprin2.Text = Ingles.mbp;
                btnVentas.Text = Ingles.mbv;
                btnCierreCaja.Text = Ingles.mbc;
                btnFichaProductos.Text = Ingles.mbf;
                btnConfi.Text = Ingles.mbcf;
                btnExit.Text = Ingles.mbe;
                label1.Text = Ingles.welcome;
                label3.Text = "Processes";
            }
        }
        private void btnConfi_Click_1(object sender, EventArgs e)
        {
            VistaAjustes vistaAjustes = new VistaAjustes();
            vistaAjustes.ShowDialog();
            this.Close();
        }
        private void btnInicio_MouseEnter(object sender, EventArgs e)
        {
            // Aumentar el tamaño del PictureBox cuando el cursor está sobre la imagen
            btnInicio.Size = new Size(originalSize.Width + 20, originalSize.Height + 20);
            btnInicio.Location = new Point(btnInicio.Location.X - 10, btnInicio.Location.Y - 20); // Ajustar la posición
        }

        private void btnInicio_MouseLeave(object sender, EventArgs e)
        {
            // Restaurar el tamaño original del PictureBox cuando el cursor sale de la imagen
            btnInicio.Size = originalSize;
            btnInicio.Location = new Point(btnInicio.Location.X + 10, btnInicio.Location.Y + 10); // Restaurar la posición
        }

        private void btnShop_MouseEnter(object sender, EventArgs e)
        {
            // Aumentar el tamaño del PictureBox cuando el cursor está sobre la imagen
            btnShop.Size = new Size(originalSize.Width + 20, originalSize.Height + 20);
            btnShop.Location = new Point(btnShop.Location.X - 10, btnShop.Location.Y - 20); // Ajustar la posición
        }

        private void btnShop_MouseLeave(object sender, EventArgs e)
        {
            // Restaurar el tamaño original del PictureBox cuando el cursor sale de la imagen
            btnShop.Size = originalSize;
            btnShop.Location = new Point(btnShop.Location.X + 10, btnShop.Location.Y + 10); // Restaurar la posición
        }

        private void btnStats_MouseEnter(object sender, EventArgs e)
        {
            // Aumentar el tamaño del PictureBox cuando el cursor está sobre la imagen
            btnStats.Size = new Size(originalSize.Width + 20, originalSize.Height + 20);
            btnStats.Location = new Point(btnStats.Location.X - 10, btnStats.Location.Y - 20); // Ajustar la posición
        }

        private void btnStats_MouseLeave(object sender, EventArgs e)
        {
            // Restaurar el tamaño original del PictureBox cuando el cursor sale de la imagen
            btnStats.Size = originalSize;
            btnStats.Location = new Point(btnStats.Location.X + 10, btnStats.Location.Y + 10); // Restaurar la posición
        }

        private void btnAccounts_MouseEnter(object sender, EventArgs e)
        {
            // Aumentar el tamaño del PictureBox cuando el cursor está sobre la imagen
            btnAccounts.Size = new Size(originalSize.Width + 20, originalSize.Height + 20);
            btnAccounts.Location = new Point(btnAccounts.Location.X - 10, btnAccounts.Location.Y - 20); // Ajustar la posición
        }

        private void btnAccounts_MouseLeave(object sender, EventArgs e)
        {
            // Restaurar el tamaño original del PictureBox cuando el cursor sale de la imagen
            btnAccounts.Size = originalSize;
            btnAccounts.Location = new Point(btnAccounts.Location.X + 10, btnAccounts.Location.Y + 10); // Restaurar la posición
        }
    }
}
