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
    public partial class VistaMostrarEstadisticas : Form
    {
        public VistaMostrarEstadisticas()
        {
            InitializeComponent();
            ControladorMostrarEstadisticas controladorMostrarEstadisticas = new ControladorMostrarEstadisticas(this);
        }
        private void VistaMostrarEstadisticas_Load(object sender, EventArgs e)
        {
            if (ControladorTema.IsDarkMode == true) 
            {
                this.BackColor = Color.FromArgb(34, 36, 49);
                //Para que cambie de color el boton de mostrar estadisticas de usuarios
                btnEstadisticasUsuarios.IdleFillColor = Color.FromArgb(230, 119, 11);
                btnEstadisticasUsuarios.onHoverState.FillColor = Color.FromArgb(211, 41, 15);
                btnEstadisticasUsuarios.onHoverState.BorderColor = Color.FromArgb(211, 41, 15);
                btnEstadisticasUsuarios.OnPressedState.FillColor = Color.Red;
                btnEstadisticasUsuarios.OnPressedState.BorderColor = Color.Red;
                btnEstadisticasUsuarios.DisabledFillColor = Color.DarkOrange;

                //Para que cambie de color el boton de mostrar estadisticas de ventas diarias
                btnEstadisticasVentasDiarias.IdleFillColor = Color.FromArgb(230, 119, 11);
                btnEstadisticasVentasDiarias.onHoverState.FillColor = Color.FromArgb(211, 41, 15);
                btnEstadisticasVentasDiarias.onHoverState.BorderColor = Color.FromArgb(211, 41, 15);
                btnEstadisticasVentasDiarias.OnPressedState.FillColor = Color.Red;
                btnEstadisticasVentasDiarias.OnPressedState.BorderColor = Color.Red;
                btnEstadisticasVentasDiarias.DisabledFillColor = Color.DarkOrange;

                //Para que cambie de color el boton de mostrar estadisticas de ventas semanales
                btnEstadisticasVentasSemanales.IdleFillColor = Color.FromArgb(230, 119, 11);
                btnEstadisticasVentasSemanales.onHoverState.FillColor = Color.FromArgb(211, 41, 15);
                btnEstadisticasVentasSemanales.onHoverState.BorderColor = Color.FromArgb(211, 41, 15);
                btnEstadisticasVentasSemanales.OnPressedState.FillColor = Color.Red;
                btnEstadisticasVentasSemanales.OnPressedState.BorderColor = Color.Red;
                btnEstadisticasVentasSemanales.DisabledFillColor = Color.DarkOrange;

                //Esto es para cambiar el color de los gradientes del panel cuando se active el modo oscuro
                bunifuGradientPanel1.GradientBottomLeft = Color.Black;
                bunifuGradientPanel1.GradientTopRight = Color.Black;
                bunifuGradientPanel1.GradientBottomRight = Color.DarkViolet;
                bunifuGradientPanel1.GradientTopLeft = Color.DarkViolet;
            }

            if (ControladorIdioma.idioma == 1) 
            {
                lbEstadisticas.Text = Ingles.Estadisticas;
                btnEstadisticasUsuarios.Text = Ingles.EstadisticasDeUsuarios;
                btnEstadisticasVentasDiarias.Text = Ingles.EstadisticasVentasDiarias;
                shadorw.Text = Ingles.EstadisticasVentasSemanales;
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
