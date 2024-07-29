using System;
using AgroServicios.Controlador;
using System.Windows.Forms;

namespace AgroServicios.Vista.Login
{
    public partial class Bienvenida : Form
    {
        public Bienvenida()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1) this.Opacity += 0.05;
            BarradeProgeso.Value += 1;
            BarradeProgeso.Text = BarradeProgeso.Value.ToString();
            if (BarradeProgeso.Value == 100)
            {
                timer1.Stop();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if (this.Opacity == 0)
            {
                timer2.Stop();
                this.Close();
            }
        }

        private void Bienvenida_Load(object sender, EventArgs e)
        {
            if (ControladorIdioma.idioma == 1)
            {
                lblbienvenido.Text = Ingles.bienvenida;
            }

            this.Opacity = 0.0;
            //Inicializamos estas propiedades de la barra de progreso, mediante codigo.(Opcional)
            BarradeProgeso.Value = 0;
            BarradeProgeso.Minimum = 0;
            BarradeProgeso.Maximum = 100;
            //Iniciamos el temporizador 1.
            timer1.Start();
        }

    }
}
