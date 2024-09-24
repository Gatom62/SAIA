using System;
using AgroServicios.Controlador;
using System.Windows.Forms;
using AgroServicios.Controlador.Helper;
using System.Drawing;
using System.Media;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using System.IO;
using WMPLib;

//using WMPLib;

namespace AgroServicios.Vista.Login
{
    public partial class Bienvenida : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
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
            // Crear un archivo temporal a partir del recurso embebido
            string tempFilePath = Path.GetTempFileName() + ".mp3";
            File.WriteAllBytes(tempFilePath, Properties.Resources.Vos_SAIA__vocals_);

            // Establecer la ruta del archivo temporal y reproducirlo
            player.URL = tempFilePath;
            player.controls.play();

            // Opcional: eliminar el archivo temporal cuando se cierre el formulario
            this.FormClosing += (s, args) => { if (File.Exists(tempFilePath)) File.Delete(tempFilePath); };


            if (ControladorIdioma.idioma == 1)
            {
                lblbienvenido.Text = Ingles.bienvenida;
            }

            bunifuLabel1.Text = StaticSession.Username;
            this.Opacity = 0.0;
            //Inicializamos estas propiedades de la barra de progreso, mediante codigo.(Opcional)
            BarradeProgeso.Value = 0;
            BarradeProgeso.Minimum = 0;
            BarradeProgeso.Maximum = 100;
            //Iniciamos el temporizador 1.
            timer1.Start();

            if(ControladorTema.IsDarkMode == true)
            {
                BarradeProgeso.ForeColor = Color.White;
                this.BackColor = Color.FromArgb(34, 36, 49);
                panel1.BackColor = Color.FromArgb(230, 119, 11);
                panel2.BackColor = Color.FromArgb(118, 88, 152);
                BarradeProgeso.ProgressColor = Color.FromArgb(211, 41, 15);
                BarradeProgeso.ProgressColor2 = Color.FromArgb(211, 41, 15);

            }

            //Esto es para que el form haga ruidito

        }

    }
}
