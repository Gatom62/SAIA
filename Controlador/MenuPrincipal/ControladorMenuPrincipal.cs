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
using AgroServicios.Vista.Reportes.ReporteProductos;
using AgroServicios.Modelo.DAO;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;

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
            ObjMenu.btnInicio.Click += new EventHandler(OpenInicio);
            ObjMenu.btnExit.Click += new EventHandler(CerrarSesion);
            ObjMenu.btnAccounts.Click += new EventHandler(OpenCuentas);
            ObjMenu.btnShop.Click += new EventHandler(OpenCarrito);
            ObjMenu.btnprin2.Click += new EventHandler(OpenShop);
            ObjMenu.btnVentas.Click += new EventHandler(OpenVentas);
            ObjMenu.btnFichaProductos.Click += new EventHandler(OpenFichaProductos);
        }
        private void OpenFichaProductos(object sender, EventArgs e)
        {
            VistaReporteProductos reporteProductos = new VistaReporteProductos();
            reporteProductos.ShowDialog();
        }
        private void OpenVentas(object sender, EventArgs e)
        {
            VistaVentasPorFecha vistaVentasPorFecha = new VistaVentasPorFecha();
            vistaVentasPorFecha.ShowDialog();
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
            // Usar el método ResetInstance para limpiar la instancia de VistaCarrito
            VistaCarrito.ResetInstance();
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

        //public void CierreCaja(object sender, EventArgs e)
        //{
        //    //Realizamos el proceso de inserccion y de optencion de respuesta departe de la base de datos
        //    DAOProductos1 DaoInsert = new DAOProductos1();
        //    // Asignar los valores a las propiedades de DaoInsert
        //    DaoInsert.Img = imageBytes;
        //    DaoInsert.Nombre1 = ObjCreateProducto1.txtNombreProducto.Text.Trim();
        //    DaoInsert.Codigo1 = ObjCreateProducto1.txtCodigo.Text.Trim();
        //    DaoInsert.Stock1 = ObjCreateProducto1.txtCantidad.Text.Trim();
        //    DaoInsert.Precio1 = ObjCreateProducto1.txtPrecio.Text.Trim();
        //    DaoInsert.Descripcion1 = ObjCreateProducto1.txtDescripcion.Text.Trim();
        //    DaoInsert.IdMarca = int.Parse(ObjCreateProducto1.DropMarca.SelectedValue.ToString());
        //    //Pedimos una contestación por parte de la base de datos, si nos manda un uno es que si se logro realizar correctamente la insercción
        //    int valorRetornado = DaoInsert.RegistrarProducto();
        //    if (valorRetornado == 1)
        //    {
        //        //Mensaje de afirmacion si se pudo realizar la inserccion
        //        MandarValoresAlerta(Color.LightGreen, Color.Black, "Proceso realizado", "El producto fue registrado", Properties.Resources.comprobado);
        //        VistaLogin backForm = new VistaLogin();
        //        ObjCreateProducto1.Close();
        //    }
        //    else
        //    {
        //        //Mensaje de error si se no se pudo realizar la inserccion
        //        MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "Verifique que el producto no se este duplicando", Properties.Resources.ErrorIcono);
        //        VistaLogin backForm = new VistaLogin();
        //    }

        //    // Método para validar que el nombre del producto no exceda los 80 caracteres
        //    bool ValidarNombre(string nombre)
        //    {
        //        return nombre.Length <= 80;
        //    }

        //    // Método para validar la descripcion del producto y que este no exceda los 150 caracteres
        //    bool ValidarDescripcion(string descripcion)
        //    {
        //        return descripcion.Length <= 150;
        //    }

        //    bool ValidarNumero(string numero)
        //    {
        //        // Aquí validamos que la cantidad del prodcuto solo debe contener solo dígitos numeros 
        //        string pattern = @"^\d+$"; // Solo dígitos
        //        return Regex.IsMatch(numero, pattern);
        //    }

        //    bool CantidadCodigo(string codigo)
        //    {
        //        // Intentar convertir el código a un número entero largo (long) 
        //        if (long.TryParse(codigo, out long cantidadCodigo))
        //        {
        //            // Validar que la cantidad no exceda 12 dígitos
        //            return cantidadCodigo <= 9999999999; // 12 dígitos
        //        }
        //        return false;
        //    }

        //    bool CantidadStock(string numero)
        //    {
        //        // Intentar convertir la cantidad a un número entero
        //        if (int.TryParse(numero, out int cantidadNumero))
        //        {
        //            // Validar que la cantidad no exceda 500
        //            return cantidadNumero <= 500;
        //        }

        //        // Si no se puede convertir a entero, retornar false
        //        return false;
        //    }

        //    bool ValidarDecimales(string Decimal)
        //    {
        //        // Validar formato decimal: hasta 8 dígitos enteros y 2 decimales
        //        string pattern = @"^\d{1,4}(\.\d{1,2})?$";
        //        if (!Regex.IsMatch(Decimal, pattern))
        //        {
        //            return false; // Si no cumple con el formato, retornar false
        //        }

        //        // Validar que no exceda DECIMAL(10,2) - valor numérico
        //        if (decimal.TryParse(Decimal, out decimal valorDecimal))
        //        {
        //            return valorDecimal <= 9999.99m; // Asegurar que no exceda 9999.99
        //        }

        //        return false; // Si no se puede parsear a decimal, retornar false
        //    }
        //}
    }
}