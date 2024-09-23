using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Estadisticas;
using AgroServicios.Vista.Login;
using AgroServicios.Vista.Notificación;
using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AgroServicios.Controlador.ControladorStats
{
    class ControladorActualizarProveedor
    {
        VistaActualizarProveedor Objupdate;
        private int accion;
        bool verificacion;
        private string Marca;


        public ControladorActualizarProveedor(VistaActualizarProveedor Vista, int accion, int id, string Name, string phone, string email, string Dui, string marca)
        {
            this.Marca = marca;
            Objupdate = Vista;
            this.accion = accion;
            verificarAcion();
            ChargeValues(id, Name, Dui, phone, email);
            Objupdate.Load += CargaInicial;
            Objupdate.btnUpdateProveedor.Click += new EventHandler(ActualizarRegistro);
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
            Objupdate.cmbMarca.DataSource = ds.Tables["Marcas"];
            Objupdate.cmbMarca.ValueMember = "idMarca";
            Objupdate.cmbMarca.DisplayMember = "NombreMarca";

            Objupdate.cmbMarca.Text = Marca;
        }
        private void ActualizarRegistro(object sender, EventArgs e)
        {
            // Validar que los campos obligatorios no estén vacíos
            if (string.IsNullOrWhiteSpace(Objupdate.txtUpdateNombre.Text) ||
                string.IsNullOrWhiteSpace(Objupdate.txtUpdatePhone.Text) ||
                string.IsNullOrWhiteSpace(Objupdate.maskUbdateDui.Text) ||
                Objupdate.cmbMarca.SelectedValue == null)
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", "El nombre, el teléfono y el dui son obligatorios", Properties.Resources.MensajeWarning);
                return;
            }

            string nombreCliente = Objupdate.txtUpdateNombre.Text.Trim();
            // Validar que el nombre solo contenga letras y no exceda 65 caracteres
            if (!ValidarLetra(nombreCliente) || !ValidarNombre(nombreCliente))
            {
                MessageBoxP(Color.Yellow, Color.DarkRed, "Error", "El nombre nombre tiene numeros o tiene más de 65 letras", Properties.Resources.MensajeWarning);
                return;
            }

            // Validar el formato del número de teléfono
            if (!ValidarTelefono(Objupdate.txtUpdatePhone.Text))
            {
                MessageBoxP(Color.Yellow, Color.DarkRed, "Error", "El telefono debe de ser de El Salvador", Properties.Resources.MensajeWarning);
                return;
            }

            // Validar el formato del DUI 
            if (!ValidarDUI(Objupdate.maskUbdateDui.Text))
            {
                MessageBox.Show("El DUI del proveedor debe contener exactamente 9 dígitos",
                                    "Error de validación",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                return;
            }

            DAOProveedores DaoUpdate = new DAOProveedores();
            DaoUpdate.IdProveedor = int.Parse(Objupdate.txtid.Text.Trim());
            DaoUpdate.Nombre1 = Objupdate.txtUpdateNombre.Text.Trim();
            DaoUpdate.DUI1 = Objupdate.maskUbdateDui.Text.Trim();
            DaoUpdate.Teléfono1 = Objupdate.txtUpdatePhone.Text.Trim();
            DaoUpdate.Correo1 = string.IsNullOrWhiteSpace(Objupdate.txtUpdateCorreo.Text) ? "xxxxxxxx" : Objupdate.txtUpdateCorreo.Text;
            DaoUpdate.Marca1 = int.Parse(Objupdate.cmbMarca.SelectedValue.ToString());

            // Validar el formato del correo solo si se ingresó uno
            if (!string.IsNullOrWhiteSpace(Objupdate.txtUpdateCorreo.Text))
            {
                // Validar el formato y cantidad del correo solo si se ingresó uno
                string correoCliente = Objupdate.txtUpdateCorreo.Text.Trim();
                if (!ValidarCorreo(correoCliente) || !ValidarCorreoCantidad(correoCliente))
                {
                    MessageBoxP(Color.Yellow, Color.DarkRed, "Error", "Falta el @ o el dominio del correo o hay mas de 75 caragteres en el corréo", Properties.Resources.MensajeWarning);
                    return;
                }
            }
            int verificacion = DaoUpdate.ActualizarProveedor();
            if (verificacion == 1)
            {
                MandarValoresAlerta(Color.LightGreen, Color.Black, "Proceso realizado", "El proveedor fue actualizado", Properties.Resources.comprobado);
                VistaLogin backForm = new VistaLogin();
                Objupdate.Close();
            }
            else
            {
                MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "Verifique que el proveedor no se este duplicando", Properties.Resources.ErrorIcono);
                VistaLogin backForm = new VistaLogin();
            }

            // Método para validar que el nombre del proveedor no exceda los 65 caracteres
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

            bool ValidarCorreo(string email)
            {
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$|^[xX]{8}$"; // Formato básico de correo
                return Regex.IsMatch(email, pattern);
            }

            // Método para validar que el correo del proveedor no exceda los 50 caracteres
            bool ValidarCorreoCantidad(string nombre)
            {
                return nombre.Length <= 50;
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
        public void verificarAcion() 
        {
            if (accion == 2)
            {
                Objupdate.txtUpdateNombre.Visible = false;
                Objupdate.txtUpdateCorreo.Visible = false;
                Objupdate.txtUpdatePhone.Visible = false;
                Objupdate.maskUbdateDui.Visible = false;
                Objupdate.btnUpdateProveedor.Visible = false;
            }
        }
        public void ChargeValues(int id, string Name, string Dui, string phone, string email)
        {
            Objupdate.txtid.Text = id.ToString();
            Objupdate.txtUpdateNombre.Text = Name;
            Objupdate.maskUbdateDui.Text = Dui;
            Objupdate.txtUpdatePhone.Text = phone;
            Objupdate.txtUpdateCorreo.Text = email;
        }
    }
}

