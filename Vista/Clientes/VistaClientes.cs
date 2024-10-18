using AgroServicios.Controlador;
using AgroServicios.Controlador.Clientes;
using System.Drawing;
using System.Windows.Forms;

namespace AgroServicios.Vista.Clientes
{
    public partial class VistaClientes : Form
    {
        private Size originalSize;
        public VistaClientes()
        {
            InitializeComponent();
            ControladorVistaClientes control = new ControladorVistaClientes(this);

            //Metodos para hacer que la imagen cresca cuando el mause pase por heya
            //Para el p
            // Cargar la imagen desde los recursos
            ptbback.Image = Properties.Resources.turn_left_11044726;
            originalSize = ptbback.Size;
            // Eventos para cuando el mouse entra y sale del PictureBox
            ptbback.MouseEnter += ptbback_MouseEnter;
            ptbback.MouseLeave += ptbback_MouseLeave;
        }
        private void ptbback_MouseEnter(object sender, System.EventArgs e)
        {
            // Aumentar el tamaño del PictureBox cuando el cursor está sobre la imagen
            ptbback.Size = new Size(originalSize.Width + 20, originalSize.Height + 20);
            ptbback.Location = new Point(ptbback.Location.X - 10, ptbback.Location.Y - 20); // Ajustar la posición
        }

        private void ptbback_MouseLeave(object sender, System.EventArgs e)
        {
            // Restaurar el tamaño original del PictureBox cuando el cursor sale de la imagen
            ptbback.Size = originalSize;
            ptbback.Location = new Point(ptbback.Location.X + 10, ptbback.Location.Y + 10); // Restaurar la posición
        }

        private void VistaClientes_Load(object sender, System.EventArgs e)
        {
            if (ControladorTema.IsDarkMode == true)
            {
                GriewViewClientes.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Dark;
                GriewViewClientes.BackgroundColor = Color.FromArgb(50, 56, 62);
                table.BackColor = Color.FromArgb(118, 88, 152);

                btnCrearCliente.IdleFillColor = Color.DarkBlue;
                btnCrearCliente.onHoverState.FillColor = Color.DarkViolet;
                btnCrearCliente.onHoverState.BorderColor = Color.DarkViolet;
                btnCrearCliente.OnPressedState.FillColor = Color.DodgerBlue;
                btnCrearCliente.OnPressedState.BorderColor = Color.DodgerBlue;
                btnCrearCliente.DisabledFillColor = Color.DarkViolet;

                btnCrearCliente.DisabledFillColor = Color.FromArgb(118, 88, 152);
                btnCrearCliente.ForeColor = Color.White;
            }

            if (ControladorIdioma.idioma == 1) 
            {
                lbProducto.Text = Ingles.Cliente;
                btnCrearCliente.Text = Ingles.AgregarCliente;
                cmsEditarCliente.Text = "Update client.";
                cmsEliminarCliente.Text = "Delete client.";
                cmsInformacionCliente.Text = "Customer information.";
                txtBuscarClientes.PlaceholderText = Ingles.Busqueda;
            }
        }
    }
}
