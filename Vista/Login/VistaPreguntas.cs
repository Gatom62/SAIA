using AgroServicios.Controlador.Helper;
using AgroServicios.Controlador.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Vista.Login
{
    public partial class VistaPreguntas : Form
    {
        public VistaPreguntas(string user, int action)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CommonClasses.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            ControladorPreguntasRec control = new ControladorPreguntasRec(this, user, action);
        }
    }
}
