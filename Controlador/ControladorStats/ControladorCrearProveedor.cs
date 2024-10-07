using AgroServicios.Vista.Estadisticas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgroServicios.Modelo.DAO;
using System.Windows.Forms;
using System.Data;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using AgroServicios.Vista.Notificación;
using System.Drawing;
using AgroServicios.Vista.Login;

namespace AgroServicios.Controlador.ControladorStats
{
     class ControladorCrearProveedor
    {
        VistaAgregarProveedor ObjProveedor;
        bool verificacion;
        public ControladorCrearProveedor(VistaAgregarProveedor vista) 
        {
            ObjProveedor = vista;
            ObjProveedor.btnAgregarProv.Click += new EventHandler(AgregarProveedor);
            ObjProveedor.Load += CargaInicial;
        }
        void MessageBoxP(Color backcolor, Color color, string title, string text, Image icon)
        {
            AlertExito frm = new AlertExito();

            frm.BackColorAlert = backcolor;

            frm.ColorAlertBox = color;

            frm.TittlAlertBox = title;

            frm.TextAlertBox = text;

            frm.IconeAlertBox = icon;

            frm.ShowDialog();
        }
        void MandarValoresAlerta(Color backcolor, Color color, string title, string text, Image icon)
        {
            MessagePersonal message = new MessagePersonal();
            message.BackColorAlert = backcolor;
            message.ColorAlertBox = color;
            message.TittlAlertBox = title;
            message.TextAlertBox = text;
            message.IconeAlertBox = icon;
            message.ShowDialog();
        }
        public void CargaInicial(object sender, EventArgs e)
        {
            DAOProductos1 objmarcas = new DAOProductos1();
            //Declarando nuevo DataSet para que obtenga los datos del metodo LlenarCombo
            DataSet ds = objmarcas.LlenarCombo();
            //Llenar combobox tbRole
            ObjProveedor.cmbMarca.DataSource = ds.Tables["Marcas"];
            ObjProveedor.cmbMarca.ValueMember = "idMarca";
            ObjProveedor.cmbMarca.DisplayMember = "NombreMarca";
        }
        public void AgregarProveedor (object sender, EventArgs e) 
        {
            // Validar que los campos obligatorios no estén vacíos
            if (string.IsNullOrWhiteSpace(ObjProveedor.txtNewFirstName.Text) ||
                string.IsNullOrWhiteSpace(ObjProveedor.txtNewPhone.Text) ||
                string.IsNullOrEmpty(ObjProveedor.maskDui.Text) ||
                ObjProveedor.cmbMarca.SelectedValue == null)
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Error", "Name, phone and dui are required.", Properties.Resources.MensajeWarning);
                    return;
                }
                else
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Error", "El nombre, el teléfono y el dui son obligatorios", Properties.Resources.MensajeWarning);
                    return;
                }
            }

            // Validar que el nombre solo contenga letras y no exceda 65 caracteres
            string nombreCliente = ObjProveedor.txtNewFirstName.Text.Trim();
            if (!ValidarLetra(nombreCliente) || !ValidarNombre(nombreCliente))
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBoxP(Color.Yellow, Color.DarkRed, "Error", "Name has numbers or has more than 65 letters", Properties.Resources.MensajeWarning);
                    return;
                }
                else
                {
                    MessageBoxP(Color.Yellow, Color.DarkRed, "Error", "El nombre nombre tiene numeros o tiene más de 65 letras", Properties.Resources.MensajeWarning);
                    return;
                }
            }

            // Validar el formato del número de teléfono y que este tenga las caragteristicas de un numero de telefono salvadoreño
            if (!ValidarTelefono(ObjProveedor.txtNewPhone.Text))
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBoxP(Color.Yellow, Color.DarkRed, "Error", "The phone must be from El Salvador", Properties.Resources.MensajeWarning);
                    return;
                }
                else
                {
                    MessageBoxP(Color.Yellow, Color.DarkRed, "Error", "El telefono debe de ser de El Salvador", Properties.Resources.MensajeWarning);
                    return;
                }
            }

            // Validar el formato del DUI y que este no tenga menos de 8 numeros
            if (!ValidarDUI(ObjProveedor.maskDui.Text))
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBox.Show("The supplier's DUI must contain exactly 9 digits.",
                                    "Validation error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("El DUI del proveedor debe contener exactamente 9 dígitos",
                    "Error de validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return;
                }
            }

            //Realizamos el proceso de inserción
            // Asignación de valores a las propiedades del objeto DAOinsert
            DAOProveedores DAOinsert = new DAOProveedores();
            DAOinsert.Nombre1 = ObjProveedor.txtNewFirstName.Text.Trim();
            DAOinsert.DUI1 = ObjProveedor.maskDui.Text.Trim();
            DAOinsert.Teléfono1 = ObjProveedor.txtNewPhone.Text.Trim();
            DAOinsert.Correo1 = string.IsNullOrWhiteSpace(ObjProveedor.txtNewCorreo.Text) ? "xxxxxxxx" : ObjProveedor.txtNewCorreo.Text;
            DAOinsert.Marca1 = int.Parse(ObjProveedor.cmbMarca.SelectedValue.ToString());
            //En este caso no realizamos el proceso de inserccion por que es posible que el usuario no haya puesto nada en el correo del proveedor, a si que eso lo validamos antes de realizar la inserccion, si hay correo validamos si no ponemos 8 x (X)

            // Validar el formato del correo solo si se ingresó uno
            if (!string.IsNullOrWhiteSpace(ObjProveedor.txtNewCorreo.Text))
            {
                // Validar el formato y cantidad del correo solo si se ingresó uno
                string correoCliente = ObjProveedor.txtNewCorreo.Text.Trim();
                if (!ValidarCorreo(correoCliente) || !ValidarCorreoCantidad(correoCliente))
                {
                    if (ControladorIdioma.idioma == 1)
                    {
                        MessageBoxP(Color.Yellow, Color.DarkRed, "Error", "No @, no domain or more than 75 characters in the e-mail", Properties.Resources.MensajeWarning);
                        return;
                    }
                    else
                    {
                        MessageBoxP(Color.Yellow, Color.DarkRed, "Error", "No tiene el @, el dominio o hay mas de 75 caracteres en el correo", Properties.Resources.MensajeWarning);
                        return;
                    }
                }
            }
            //Pedimos una contestación por parte de la base de datos, si nos manda un 1 es que si se logro realizar correctamente la insercción
            int valorRetornado = DAOinsert.RegistrarProveedor();
            if (valorRetornado == 1)
            {
                //Mensaje de afirmacion si se pudo realizar la inserccion
                if(ControladorIdioma.idioma == 1)
                {
                    MandarValoresAlerta(Color.LightGreen, Color.Black, "Process performed", "Supplier was registered", Properties.Resources.comprobado);
                    VistaLogin backForm = new VistaLogin();
                    ObjProveedor.Close();
                }
                else
                {
                    MandarValoresAlerta(Color.LightGreen, Color.Black, "Proceso realizado", "El proveedor fue registrado", Properties.Resources.comprobado);
                    VistaLogin backForm = new VistaLogin();
                    ObjProveedor.Close();
                }
            }
            else
            {
                //Mensaje de error si se no se pudo realizar la inserccion
                if(ControladorIdioma.idioma == 1)
                {
                    MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "Verify that the supplier is not being duplicated.", Properties.Resources.ErrorIcono);
                    VistaLogin backForm = new VistaLogin();
                }
                else
                {
                    MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "Verifique que el proveedor no se este duplicando", Properties.Resources.ErrorIcono);
                    VistaLogin backForm = new VistaLogin();
                }
            }

            //Metodos para validar los datos ingresados por el usuario
            bool ValidarCorreo(string email)
            {
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$|^[xX]{8}$"; // Formato básico de correo
                return Regex.IsMatch(email, pattern);
            }

            // Método para validar que el correo del proceedor no exceda los 75 caracteres
            bool ValidarCorreoCantidad(string nombre)
            {
                return nombre.Length <= 75;
            }

            // Método para validar que el nombre del proveedor no exceda los 50 caracteres
            bool ValidarNombre(string nombre)
            {
                return nombre.Length <= 65;
            }

            // Método que valida si un carácter es una letra
            bool ValidarLetra(string texto)
            {
                foreach (char c in texto)
                {
                    if (!char.IsLetter(c) && !char.IsWhiteSpace(c)) // Permite espacios
                    {
                        return false; // Si encuentra un carácter no válido, retorna false
                    }
                }
                return true; // Si todos los caracteres son válidos, retorna true
            }

            bool ValidarTelefono(string phoneNumber)
            {
                string pattern = @"^[267]\d{7}$"; // 8 dígitos, empezando con 2, 6, o 7
                return Regex.IsMatch(phoneNumber, pattern);
            }

            // Método para validar el formato del DUI
            bool ValidarDUI(string dui)
            {
                // Expresión regular para verificar 8 dígitos seguidos de un guion y luego 1 dígito
                string pattern = @"^\d{8}-\d$";
                if (!Regex.IsMatch(dui, pattern))
                {
                    return false;
                }
                return true;
            }
        }
    }
}
