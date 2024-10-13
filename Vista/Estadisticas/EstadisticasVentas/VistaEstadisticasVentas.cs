using AgroServicios.Controlador;
using AgroServicios.Controlador.EstadisticasVentas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Vista.Estadisticas.EstadisticasVentas
{
    public partial class VistaEstadisticasVentas : Form
    {
        private Size originalSize;
        public VistaEstadisticasVentas()
        {
            InitializeComponent();
            ControladorEstadisticasEmpleados controladorEstadisticasEmpleados = new ControladorEstadisticasEmpleados(this);

            //Metodos para hacer que la imagen cresca cuando el mause pase por heya
            //Esto es para el boton siguiente
            // Cargar la imagen desde los recursos
            btnSiguiente.Image = Properties.Resources.IconoFlecha_flipped;
            originalSize = btnSiguiente.Size;
            // Eventos para cuando el mouse entra y sale del PictureBox
            btnSiguiente.MouseEnter += btnSiguiente_MouseEnter;
            btnSiguiente.MouseLeave += btnSiguiente_MouseLeave;

            //Metodos para hacer que la imagen cresca cuando el mause pase por heya
            //Esto es para el boton atras
            // Cargar la imagen desde los recursos
            btnAtras.Image = Properties.Resources.IconoFlecha;
            originalSize = btnAtras.Size;
            // Eventos para cuando el mouse entra y sale del PictureBox
            btnAtras.MouseEnter += btnAtras_MouseEnter;
            btnAtras.MouseLeave += btnAtras_MouseLeave;
        }

        //Codigos para que la imagen de la flecha que mira hacia a la derecha se engrandesca
        private void btnSiguiente_MouseEnter(object sender, EventArgs e)
        {
            // Aumentar el tamaño del PictureBox cuando el cursor está sobre la imagen
            btnSiguiente.Size = new Size(originalSize.Width + 5, originalSize.Height + 5);
            btnSiguiente.Location = new Point(btnSiguiente.Location.X - 5, btnSiguiente.Location.Y - 5); // Ajustar la posición
        }

        private void btnSiguiente_MouseLeave(object sender, EventArgs e)
        {
            // Restaurar el tamaño original del PictureBox cuando el cursor sale de la imagen
            btnSiguiente.Size = originalSize;
            btnSiguiente.Location = new Point(btnSiguiente.Location.X + 5, btnSiguiente.Location.Y + 5); // Restaurar la posición
        }
        /*---**---*/
        /*---**---*/
        //Codigos para que la imagen de la flecha que mira hacia a la izquierda se engrandesca
        private void btnAtras_MouseEnter(object sender, EventArgs e)
        {
            // Aumentar el tamaño del PictureBox cuando el cursor está sobre la imagen
            btnAtras.Size = new Size(originalSize.Width + 5, originalSize.Height + 5);
            btnAtras.Location = new Point(btnAtras.Location.X - 5, btnAtras.Location.Y - 5); // Ajustar la posición
        }

        private void btnAtras_MouseLeave(object sender, EventArgs e)
        {
            // Restaurar el tamaño original del PictureBox cuando el cursor sale de la imagen
            btnAtras.Size = originalSize;
            btnAtras.Location = new Point(btnAtras.Location.X + 5, btnAtras.Location.Y + 5); // Restaurar la posición
        }

        private void VistaEstadisticasVentas_Load(object sender, EventArgs e)
        {
            if (ControladorTema.IsDarkMode == true) 
            {
                this.BackColor = Color.FromArgb(34, 36, 49);
                pnEstructura.BackgroundColor = Color.WhiteSmoke;
            }

            if (ControladorIdioma.idioma == 1) 
            {
                lbEstadisticas.Text = Ingles.Estadisticas;
                lbVentasEchasPorEmpleados.Text = Ingles.VentasEchasPorEmpleados;
            }
        }
    }
}
