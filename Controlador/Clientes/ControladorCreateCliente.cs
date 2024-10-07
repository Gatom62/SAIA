using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Clientes;
using AgroServicios.Vista.Login;
using AgroServicios.Vista.Notificación;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AgroServicios.Controlador.Clientes
{
    class ControladorCreateCliente
    {
        VistaCreateCliente ObjCreateCliente;
        private int accion;
        private int marca;
        bool verificacion;
        /// <summary>
        /// Constructor para inserción de datos
        /// </summary>
        /// <param name="Vista"></param>
        /// <param name="accion"> INSERCIÓN </param>

        public ControladorCreateCliente(VistaCreateCliente Vista, int accion)
        {
            ObjCreateCliente = Vista;
            this.accion = accion;
            ObjCreateCliente.btnAgregarCliente.Click += new EventHandler(NuevoRegistro);
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
        public void NuevoRegistro(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(ObjCreateCliente.txtNombreCliente.Text) ||
                 string.IsNullOrWhiteSpace(ObjCreateCliente.maskDui.Text))
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Error", "Name and dui are required", Properties.Resources.MensajeWarning);
                    return;
                }
                else
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Error", "El nombre y el dui son obligatorios", Properties.Resources.MensajeWarning);
                    return;
                }
            }

            string nombreCliente = ObjCreateCliente.txtNombreCliente.Text.Trim();
            // Validar que el nombre solo contenga letras y no exceda 65 caracteres
            if (!ValidarLetra(nombreCliente) || !ValidarNombre(nombreCliente))
            {
               if(ControladorIdioma.idioma == 1)
               {
                    MessageBoxP(Color.Yellow, Color.DarkRed, "Error", "Name has numbers or has more than 50 letters", Properties.Resources.MensajeWarning);
                    return;
               }
                else
                {
                    MessageBoxP(Color.Yellow, Color.DarkRed, "Error", "El nombre nombre tiene numeros o tiene más de 50 letras", Properties.Resources.MensajeWarning);
                    return;
                }
            }

            // Validar el formato del DUI y que este no tenga menos de 8 numeros
            if (!ValidarDUI(ObjCreateCliente.maskDui.Text))
            {
               if(ControladorIdioma.idioma == 1)
               {
                    MessageBoxP(Color.Yellow, Color.DarkRed, "Error", "There are less than 8 numbers in the dui", Properties.Resources.MensajeWarning);
                    return;
               }
                else
                {
                    MessageBoxP(Color.Yellow, Color.DarkRed, "Error", "Hay menos de 8 numeros en el dui", Properties.Resources.MensajeWarning);
                    return;
                }
            }

            DAOClientes DaoInsert = new DAOClientes();
            DaoInsert.Nombre1 = ObjCreateCliente.txtNombreCliente.Text.Trim();
            DaoInsert.Telefono1 = string.IsNullOrWhiteSpace(ObjCreateCliente.txtTelefonoCliente
                .Text) ? "xxxxxxxx" : ObjCreateCliente.txtTelefonoCliente.Text;
            DaoInsert.Correo1 = string.IsNullOrWhiteSpace(ObjCreateCliente.txtCorreoCliente.Text) ? "xxxxxxxx" : ObjCreateCliente.txtCorreoCliente.Text;
            DaoInsert.Dirreccion1 = string.IsNullOrWhiteSpace(ObjCreateCliente.txtDireccionCliente.Text) ? "xxxxxxxx" : ObjCreateCliente.txtNombreCliente.Text;
            DaoInsert.DUI1 = ObjCreateCliente.maskDui.Text.Trim();
            //En este caso no realizamos el proceso de inserccion por que es posible que el usuario no haya puesto nada en el correo, telefono o la direccion del cliente, a si que los validamos antes de realizar la inserccion, si hay correo, telefono o direccion los validamos individual mente si no ponemos 8 x (X)


            // Validar el formato del teléfono solo si se ingresó uno
            if (!string.IsNullOrWhiteSpace(ObjCreateCliente.txtTelefonoCliente.Text) && !ValidarTelefono())
            {
                if(ControladorIdioma.idioma == 1)
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

            // Validar el formato del correo solo si se ingresó uno
            if (!string.IsNullOrWhiteSpace(ObjCreateCliente.txtCorreoCliente.Text))
            {

                string correo = ObjCreateCliente.txtCorreoCliente.Text.Trim();
                // Validar que el nombre solo contenga letras y no exceda 75 caracteres
                if (!ValidarCorreo(correo) || !ValidarCorreoCantidad(correo))
                {
                    if(ControladorIdioma.idioma == 1)
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

            // Validar la direccion del cliente solo si se ingresó uno
            if (!string.IsNullOrWhiteSpace(ObjCreateCliente.txtDireccionCliente.Text) && !ValidarDireccion())
            {
                if(ControladorIdioma.idioma == 1)
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Error", "There are more than 100 characters in the address", Properties.Resources.MensajeWarning);
                    return;
                }
                else
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Error", "Hay mas de 100 caracteres en la dirección", Properties.Resources.MensajeWarning);
                    return;
                }
            }

            int valorRetornado = DaoInsert.RetgistraCliente();
            if (valorRetornado > 0)
            {
                if(ControladorIdioma.idioma == 1)
                {
                    MandarValoresAlerta(Color.LightGreen, Color.Black, "Process performed", "The client was registered", Properties.Resources.comprobado);
                    VistaLogin backForm = new VistaLogin();
                    ObjCreateCliente.Close();
                }
                else
                {
                    MandarValoresAlerta(Color.LightGreen, Color.Black, "Proceso realizado", "El cliente fue registrado", Properties.Resources.comprobado);
                    VistaLogin backForm = new VistaLogin();
                    ObjCreateCliente.Close();
                }
            }
            else
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "Verify that the client is not being duplicated.", Properties.Resources.ErrorIcono);
                    VistaLogin backForm = new VistaLogin();
                }
                else
                {
                    MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "Verifique que el cliente no se este duplicando", Properties.Resources.ErrorIcono);
                    VistaLogin backForm = new VistaLogin();
                }
            }

            // Método para validar que el nombre del cliente no exceda los 50 caracteres
            bool ValidarNombre(string nombre)
            {
                return nombre.Length <= 50;
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

            bool ValidarCorreo(string email)
            {
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$|^[xX]{8}$"; // Formato básico de correo
                return Regex.IsMatch(email, pattern);
            }

            // Método para validar que el correo del proveedor no exceda los 75 caracteres.
            bool ValidarCorreoCantidad(string nombre)
            {
                return nombre.Length <= 75;
            }

            bool ValidarTelefono()
            {
                string phoneNumber = ObjCreateCliente.txtTelefonoCliente.Text.Trim();
                string pattern = @"^[267]\d{7}$|^[xX]{8}$"; // Permite 8 dígitos empezando con 2, 6, o 7, o 8 'x'
                return Regex.IsMatch(phoneNumber, pattern);
            }

            // Método para validar la direccion del cliente la cual no exceda los 100 caracteres
            bool ValidarDireccion()
            {
                string direccion = ObjCreateCliente.txtDireccionCliente.Text.Trim();
                return direccion.Length <= 100;
            }
        }
    }
}
