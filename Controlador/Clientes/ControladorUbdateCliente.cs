using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Clientes;
using AgroServicios.Vista.Login;
using AgroServicios.Vista.Notificación;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AgroServicios.Controlador.Clientes
{
    class ControladorUbdateCliente
    {
        VistaUbdateCliente ObjUbdateCliente;
        private int accion;
        bool verificacion;

        public ControladorUbdateCliente(VistaUbdateCliente Vista, int accion,int id, string Name, string telefono, string correo, string direccion, string dui)
        {
            ObjUbdateCliente = Vista;
            this.accion = accion;
            //Objupdate.Load += new EventHandler(InitialCharge);
            verificarAccion();
            ChargeValues(id, Name, telefono, correo, direccion, dui);

            ObjUbdateCliente.btnUbdateCliente.Click += new EventHandler(ActualizarRegistro);
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
        public void verificarAccion()
        {
            if (accion == 2)
            {
                ObjUbdateCliente.btnUbdateCliente.Enabled = false;
                ObjUbdateCliente.txtUbdateNombreCliente.Enabled = false;
                ObjUbdateCliente.txtUbdateCorreoCliente.Enabled = false;
                ObjUbdateCliente.txtUbdateTelefonoCliente.Enabled = false;
                ObjUbdateCliente.txtUbdateDireccionCliente.Enabled = false;
                ObjUbdateCliente.masDUIUbdate.Enabled = false;
            }
        }
        public void ChargeValues(int id, string Name, string telefono, string correo, string direccion, string dui)
        {
            ObjUbdateCliente.txtid.Text = id.ToString();
            ObjUbdateCliente.txtUbdateNombreCliente.Text = Name;
            ObjUbdateCliente.txtUbdateTelefonoCliente.Text = telefono;
            ObjUbdateCliente.txtUbdateCorreoCliente.Text = correo;
            ObjUbdateCliente.txtUbdateDireccionCliente.Text = direccion;
            ObjUbdateCliente.masDUIUbdate.Text = dui;
        }

        private void ActualizarRegistro(object sender, EventArgs e)
        {
            // Validar que los campos obligatorios no estén vacíos
            if (string.IsNullOrWhiteSpace(ObjUbdateCliente.txtUbdateNombreCliente.Text) ||
                string.IsNullOrWhiteSpace(ObjUbdateCliente.txtUbdateTelefonoCliente.Text) ||
                string.IsNullOrWhiteSpace(ObjUbdateCliente.txtUbdateCorreoCliente.Text) ||
                string.IsNullOrWhiteSpace(ObjUbdateCliente.txtUbdateDireccionCliente.Text) ||
                string.IsNullOrWhiteSpace(ObjUbdateCliente.masDUIUbdate.Text))
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Error", "There are empty fields", Properties.Resources.MensajeWarning);
                    return;
                }
                else
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Error", "Hay campos vacios", Properties.Resources.MensajeWarning);
                    return;
                }
            }

            string nombreCliente = ObjUbdateCliente.txtUbdateNombreCliente.Text.Trim();
            // Validar que el nombre solo contenga letras y no exceda 65 caracteres
            if (!ValidarLetra(nombreCliente) || !ValidarNombre(nombreCliente))
            {
                if (ControladorIdioma.idioma == 1)
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

            if (!ValidarTelefono(ObjUbdateCliente.txtUbdateTelefonoCliente.Text.Trim()))
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

            // Validar el formato y cantidad del correo solo si se ingresó uno
            string correoCliente = ObjUbdateCliente.txtUbdateCorreoCliente.Text.Trim();
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

            if (!ValidarDireccion(ObjUbdateCliente.txtUbdateDireccionCliente.Text.Trim()))
            {
                if (ControladorIdioma.idioma == 1)
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

            // Validar el formato del DUI 
            if (!ValidarDUI(ObjUbdateCliente.masDUIUbdate.Text))
            {
                if (ControladorIdioma.idioma == 1)
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

            DAOClientes dAOClientes = new DAOClientes();
            // Asignar los valores a las propiedades del objeto DaoUpdate
            dAOClientes.IdCliente = int.Parse(ObjUbdateCliente.txtid.Text.Trim());
            dAOClientes.Nombre1 = ObjUbdateCliente.txtUbdateNombreCliente.Text.Trim();
            dAOClientes.Telefono1 = ObjUbdateCliente.txtUbdateTelefonoCliente.Text.Trim();
            dAOClientes.Correo1 = ObjUbdateCliente.txtUbdateCorreoCliente.Text.Trim();
            dAOClientes.Dirreccion1 = ObjUbdateCliente.txtUbdateDireccionCliente.Text.Trim();
            dAOClientes.DUI1 = ObjUbdateCliente.masDUIUbdate.Text.Trim();
            // Realizar la actualización del cliente
            int valoRetornado = dAOClientes.ActualizarCliente();
            if (valoRetornado > 0)
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MandarValoresAlerta(Color.LightGreen, Color.Black, "Process performed", "The client was upgraded", Properties.Resources.comprobado);
                    VistaLogin backForm = new VistaLogin();
                    ObjUbdateCliente.Close();
                }
                else
                {
                    MandarValoresAlerta(Color.LightGreen, Color.Black, "Proceso realizado", "El cliente fue actualizado", Properties.Resources.comprobado);
                    VistaLogin backForm = new VistaLogin();
                    ObjUbdateCliente.Close();
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

            bool ValidarCorreo(string email)
            {
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$|^[xX]{8}$"; // Formato básico de correo
                return Regex.IsMatch(email, pattern);
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

            bool ValidarTelefono(string phoneNumber)
            {
                string pattern = @"^[267]\d{7}$|^[xX]{8}$"; // Permite 8 dígitos empezando con 2, 6, o 7, o 8 'x'
                return Regex.IsMatch(phoneNumber, pattern);
            }

            // Método para validar que el nombre del cliente no exceda los 50 caracteres
            bool ValidarNombre(string nombre)
            {
                return nombre.Length <= 50;
            }

            // Método para validar la direccion del cliente la cual no exceda los 250 caracteres
            bool ValidarDireccion(string direccion)
            {
                return direccion.Length <= 250;
            }

            // Método para validar que el nombre del proceedor no exceda los 25 caracteres
            bool ValidarCorreoCantidad(string nombre)
            {
                return nombre.Length <= 75;
            }
        }
    }
}
