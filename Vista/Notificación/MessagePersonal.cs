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

namespace AgroServicios.Vista.Notificación
{
    public partial class MessagePersonal : Form
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

        public MessagePersonal()
        {
            InitializeComponent();

            // Aplicar el borde redondeado al formulario
            this.FormBorderStyle = FormBorderStyle.None; // Deshabilitar el borde normal del formulario
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 30, 35));
        }
        public Image IconeAlertBox
        {
            get { return IconAlertBox.Image; }
            set { IconAlertBox.Image = value; }
        }
        public string TittlAlertBox
        {
            get { return LblTitleAlertBox.Text; }
            set { LblTitleAlertBox.Text = value; }
        }
        public string TextAlertBox
        {
            get { return LblTextAlertBox.Text; }
            set { LblTextAlertBox.Text = value; }
        }
        public Color BackColorAlert
        {
            get { return ShadowColor.PanelColor; }
            set { ShadowColor.PanelColor = value; }
        }
        public Color ColorAlertBox
        {
            get { return LinBotton.BackgroundColor; }
            set { LinBotton.BackgroundColor = value; }
        }
        private void PositionAlertBox()
        {
            // Obtén el tamaño de la pantalla actual
            int screenWidth = Screen.GetWorkingArea(this).Width;
            int screenHeight = Screen.GetWorkingArea(this).Height;

            // Calcula la posición para centrar el formulario
            int xPos = (screenWidth - this.Width) / 2;
            int yPos = (screenHeight - this.Height) / 2;

            // Establece la posición del formulario en el centro de la pantalla
            this.Location = new Point(xPos, yPos);
        }


        private void MessagePersonal_Load(object sender, EventArgs e)
        {
            PositionAlertBox();
            // Establece el intervalo del Timer (ej. 3000 ms = 3 segundos)
            TimeLapse.Interval = 2000;
            TimeLapse.Start(); // Inicia el Timer al cargar el formulario
        }

        private void TimeLapse_Tick(object sender, EventArgs e)
        {
            TimeLapse.Stop(); // Detenemos el Timer una vez transcurrido el tiempo
            this.Close();     // Cerramos el formulario
        }

        private void ShadowColor_ControlAdded(object sender, ControlEventArgs e)
        {

        }
    }
}
