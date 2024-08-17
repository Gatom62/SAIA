using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgroServicios.Vista.MenuPrincipal;
using AgroServicios.Vista.Estadisticas;
using AgroServicios.Vista.Busqueda;
using AgroServicios.Vista.Cuentas;
using AgroServicios.Vista.Login;
using AgroServicios.Controlador.Helper;
using System.IO;
using System.Drawing;

namespace AgroServicios.Controlador.MenuPrincipal
{
    public class ControladorMenuPrincipal
    {
        VistaMenuPrincipal ObjMenu;
        Form currentForm;
        /// <summary>
        /// Constructor de la clase ControllerLogin que inicia los eventos de la vista
        /// </summary>
        /// <param name="Menu"></param>
        /// 
        public ControladorMenuPrincipal(VistaMenuPrincipal Menu)
        {
            ObjMenu = Menu;
            ObjMenu.Load += LoadUser;
            ObjMenu.btnStats.Click += new EventHandler(OpenStats);
            ObjMenu.btnBusqueda.Click += new EventHandler(OpenBusqueda);
            ObjMenu.btnInicio.Click += new EventHandler(OpenInicio);
            ObjMenu.btnExit.Click += new EventHandler(CerrarSesion);
            ObjMenu.btnAccounts.Click += new EventHandler(OpenCuentas);
            ObjMenu.btnShop.Click += new EventHandler(OpenCarrito);
            ObjMenu.btnprin2.Click += new EventHandler(OpenShop);
        }
        private void LoadUser(object sender, EventArgs e)
        {
            ObjMenu.label2.Text = StaticSession.Username;
            using (MemoryStream ms = new MemoryStream(StaticSession.Picture))
            {
                ObjMenu.ptbimg.Image = Image.FromStream(ms);
            }

        }
        private void OpenCarrito(object sender, EventArgs e)
        {
            VistaCarrito.Instance.ShowDialog();
        }
        private void OpenShop(object sender, EventArgs e)
        {
            AbrirPanel<VistaProductos>();
        }
 
        private void OpenCuentas(object sender, EventArgs e)
        {
            AbrirPanel<VistaCuentas>();
        }

        private void OpenStats(object sender, EventArgs e)
        {
            AbrirPanel<VistaStats>();
        }

        private void CerrarSesion(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar sesión?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LimpiarVariablesSesion();
                VistaLogin backForm = new VistaLogin();
                backForm.Show();
                ObjMenu.Dispose();
            }
        }
        void LimpiarVariablesSesion()
        {
            StaticSession.Categorianame1 = string.Empty;
            StaticSession.IdCategoria = 0;
            StaticSession.Username = string.Empty;
        }

        private void AbrirPanel<MiForm>() where MiForm : Form, new()
        {
            Form formulario;

            formulario = ObjMenu.PanelContenedor.Controls.OfType<MiForm>().FirstOrDefault();

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
                    ObjMenu.PanelContenedor.Controls.Remove(currentForm);
                }
                //Se establece como nuevo formulario actual el formulario que se está abriendo
                currentForm = formulario;
                //Se agregan los controles del nuevo formulario al panel contenedor
                ObjMenu.PanelContenedor.Controls.Add(formulario);
                //Tag es una propiedad genérica disponible para la mayoría de los controles en aplicaciones .NET, incluyendo los paneles.
                ObjMenu.PanelContenedor.Tag = formulario;
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

        private void OpenBusqueda(object sender, EventArgs e)
        {
            AbrirPanel<VistaBusqueda>();
        }

        private void OpenInicio(object sender, EventArgs e)
        {
            RestablecerPanelOriginal();
        }

        private void RestablecerPanelOriginal()
        {
            ObjMenu.PanelContenedor.Controls.Clear(); // Limpia el panel

            // Clona los controles originales en PanelView
            foreach (Control control in ObjMenu.OriginalControls)
            {
                ObjMenu.PanelContenedor.Controls.Add(control);
            }
        }
    }
}