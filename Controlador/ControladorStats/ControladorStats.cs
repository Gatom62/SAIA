using System;
using System.Linq;
using System.Windows.Forms;
using AgroServicios.Vista.Clientes;
using AgroServicios.Vista.Estadisticas;
using AgroServicios.Vista.Productos1;


namespace AgroServicios.Controlador.ControladorStats
{
    internal class ControladorStats
    {
        VistaStats ObjStats;
        Form currentForm;

        /// <summary>
        /// Constructor de la clase ControllerLogin que inicia los eventos de la vista
        /// </summary>
        /// <param name="Estadisticas"></param>

        public ControladorStats(VistaStats Estadisticas)
        {
            ObjStats = Estadisticas;
            ObjStats.btnProveedores.Click += new EventHandler(OpenProveedores);
            ObjStats.btnSuministros.Click += new EventHandler(OpenSuministros);
            ObjStats.btnHistorial.Click += OpenHistorialVentas;
            ObjStats.btnClientes.Click += OpenClientes;

        }
        private void OpenSuministros(object sender, EventArgs e)
        {
            AbrirPanel<VistaProductos>();
        }
        private void OpenProveedores(object sender, EventArgs e)
        {
            AbrirPanel<VistaProveedores>();
        }
        private void OpenHistorialVentas(object sender, EventArgs e)
        {
            AbrirPanel<VistaHistorialVenta>();
        }
        private void OpenClientes(object sender, EventArgs e)
        {
            AbrirPanel<VistaClientes>();
        }

        private void AbrirPanel<MiForm>() where MiForm : Form, new()
        {
            Form formulario;

            formulario = ObjStats.Panel1.Controls.OfType<MiForm>().FirstOrDefault();
            if (formulario == null)
            {
                //Se define un nuevo formulario para guardarse como nuevo objeto MiForm
                formulario = new MiForm();
                //Se especifica que el formulario debe mostrarse como ventana
                formulario.TopLevel = false;
                //Se eliminan los bordes del formulario
                formulario.FormBorderStyle = FormBorderStyle.None;
                //Se establece que se abrira en todo el espacio del formulario padre
                formulario.Dock = DockStyle.Fill;
                //Se le asigna una opacidad de 0.75
                formulario.Opacity = 0.75;
                //Se evalua el formulario actual para verificar si es nulo
                if (currentForm != null)
                {
                    //Se cierra el formulario actual para mostrar el nuevo formulario
                    currentForm.Close();
                    //Se eliminan del panel contenedor todos los controles del formulario que se cerrará
                    ObjStats.Panel1.Controls.Remove(currentForm);
                }
                //Se establece como nuevo formulario actual el formulario que se está abriendo
                currentForm = formulario;
                //Se agregan los controles del nuevo formulario al panel contenedor
                ObjStats.Panel1.Controls.Add(formulario);
                //Tag es una propiedad genérica disponible para la mayoría de los controles en aplicaciones .NET, incluyendo los paneles.
                ObjStats.Panel1.Tag = formulario;
                //Se muestra el formulario en el panel contenedor
                formulario.Show();
                //Se trae al frente el formulario armado
                formulario.BringToFront();
            }
            else
            {
                formulario.BringToFront();
            }
        }
    }
}
