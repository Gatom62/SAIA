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

namespace AgroServicios.Vista.Notificación
{
    public partial class AlertExito : Form
    {
        public AlertExito()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CommonClasses.CreateRoundRectRgn(0, 0, Width, Height, 20, 35));
        }
        public Color BackColorAlert 
        { 
            get { return this.BackColor; } 
            set { this.BackColor = value; } 
        }
        public Color ColorAlertBox
        {
            get { return LinAlertBox.BackColor; }
            set { LinAlertBox.BackColor = value; }
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

        private void PositionAlertBox()
        {
            int xPos = 0; int yPos = 0;
            xPos = Screen.GetWorkingArea(this).Width;
            yPos = Screen.GetWorkingArea(this).Height;
            this.Location = new Point(xPos - this.Width, yPos - this.Height);
        }

        private void TimerAnimation_Tick(object sender, EventArgs e)
        {
            LinAlertBox.Width += 5; // Incrementa el ancho en 2 unidades
            if (LinAlertBox.Width >= 600)
            {
                TimerAnimation.Stop(); // Detiene el Timer
                this.Close(); // Cierra el formulario
            }
        }

        private void AlertExito_Load(object sender, EventArgs e)
        {
            PositionAlertBox();
            TimerAnimation.Interval = 4; // Establece el intervalo en milisegundos
            TimerAnimation.Start();
        }
    }
}

