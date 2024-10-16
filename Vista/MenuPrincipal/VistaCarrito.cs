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
using WMPLib;
using System.Media;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using System.IO;

namespace AgroServicios.Vista.MenuPrincipal
{
    public partial class VistaCarrito : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();

        // Campo estático privado que almacena la única instancia de la clase VistaCarrito
        // Este campo es privado para evitar que otras clases creen una nueva instancia
        private static VistaCarrito _instance;

        // Propiedad estática pública para acceder a la instancia de VistaCarrito
        // Esta propiedad controla el acceso a la única instancia (Singleton) de la clase
        public static VistaCarrito Instance
        {
            get
            {
                // Si la instancia aún no ha sido creada, se crea aquí
                if (_instance == null)
                {
                    _instance = new VistaCarrito();
                }

                // Se devuelve la instancia única de la clase
                return _instance;
            }
        }

        // Propiedad para acceder al controlador asociado con VistaCarrito
        // Esta propiedad es de solo lectura fuera de esta clase
        public ControladorCarrito ControladorCarrito { get; private set; }

        // Constructor privado para evitar la creación de instancias fuera de esta clase
        // Esto asegura que solo se pueda crear una instancia a través de la propiedad estática Instance
        private VistaCarrito()
        {
            InitializeComponent();

            // Inicializa el controlador del carrito pasando la referencia de esta instancia
            ControladorCarrito = new ControladorCarrito(this);
        }

        // Método estático público para restablecer (limpiar) la instancia actual de VistaCarrito
        // Este método es necesario para manejar la limpieza del formulario y liberar recursos
        public static void ResetInstance()
        {
            if (_instance != null)
            {
                // Llama a Dispose para liberar todos los recursos utilizados por la instancia
                _instance.Dispose();

                // Establece la instancia en null para permitir que el recolector de basura (GC) la limpie
                _instance = null;
            }
        }

        private void VistaCarrito_Load(object sender, EventArgs e)
        {
            if (ControladorTema.IsDarkMode == true)
            {
                tableLayoutPanel2.BackColor = Color.FromArgb(118, 88, 152);
                dgvCarrito.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Dark;
                dgvTotal.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Dark;
                dgvTotal.BackgroundColor = Color.FromArgb(52, 54, 62);
                tableLayoutPanel1.BackColor = Color.FromArgb(52, 54, 62);
                dgvCarrito.BackgroundColor = Color.FromArgb(52, 54, 62);

                btnComprar.IdleFillColor = Color.DarkBlue;
                btnComprar.onHoverState.FillColor = Color.DarkViolet;
                btnComprar.onHoverState.BorderColor = Color.DarkViolet;
                btnComprar.OnPressedState.FillColor = Color.DodgerBlue;
                btnComprar.OnPressedState.BorderColor = Color.DarkBlue;
                btnComprar.DisabledFillColor = Color.DarkViolet;

                btnComprar.DisabledFillColor = Color.FromArgb(118, 88, 152);
                btnComprar.ForeColor = Color.White;
            }
            else
            {
                tableLayoutPanel2.BackColor = Color.LightSkyBlue;
                dgvCarrito.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
                dgvTotal.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
                dgvTotal.BackgroundColor = Color.White;
                tableLayoutPanel1.BackColor = Color.White;
                dgvCarrito.BackgroundColor = Color.White;
                btnComprar.IdleFillColor = Color.FromArgb(147, 231, 64);
            }

            if (ControladorIdioma.idioma == 1)
            {
                label1.Text = Ingles.Carri;
                btnComprar.Text = Ingles.Comp;
                btneliminar.Text = Ingles.Del;
                txtBuscarClientes.PlaceholderText = Ingles.bc;

                dgvCarrito.Columns[0].HeaderText = "Product";
                dgvCarrito.Columns[1].HeaderText = "Quantity";
                dgvCarrito.Columns[2].HeaderText = "Unit price";
                dgvCarrito.Columns[3].HeaderText = "Total price";
            }
            else
            {
                dgvCarrito.Columns[0].HeaderText = "Producto";
                dgvCarrito.Columns[1].HeaderText = "Cantidad";
                dgvCarrito.Columns[2].HeaderText = "Precio unitario";
                dgvCarrito.Columns[3].HeaderText = "Precio total";
            }
        }
        private void btnComprar_Click(object sender, EventArgs e)
        {
            // Crear un archivo temporal a partir del recurso embebido
            string tempFilePath = Path.GetTempFileName() + ".mp3";
            File.WriteAllBytes(tempFilePath, Properties.Resources.Audio_Moneda);

            // Establecer la ruta del archivo temporal y reproducirlo
            player.URL = tempFilePath;
            player.controls.play();

            // Opcional: eliminar el archivo temporal cuando se cierre el formulario
            this.FormClosing += (s, args) => { if (File.Exists(tempFilePath)) File.Delete(tempFilePath); };
        }
    }
}




