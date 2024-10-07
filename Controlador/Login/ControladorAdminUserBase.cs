using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Cuentas;
using AgroServicios.Vista.Login;
using AgroServicios.Vista.Notificación;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgroServicios.Vista.Server;

namespace AgroServicios.Controlador.Login
{
    class ControladorAdminUserBase
    {
        VistaValidacionBase ObjValidacionBase;

        public ControladorAdminUserBase(VistaValidacionBase objValidacionBase)
        {
            ObjValidacionBase = objValidacionBase;
            ObjValidacionBase.ptbback.Click += VolverForm;
            ObjValidacionBase.btnVerificar.Click += new EventHandler(VerificarDatos);
            ObjValidacionBase.PasswordVisible.Click += new EventHandler(ShowPassword);
            ObjValidacionBase.PasswordHide.Click += new EventHandler(HidePassword);
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

        private void VolverForm(object sender, EventArgs e)
        {
            // Cierra la vista actual
            ObjValidacionBase.Close();
        }

        private void VerificarDatos(object sender, EventArgs e)
        {
            string mensajeVacio, procesorealizado, numerosNombre, datosCorrectos, datosIncorrectos, noConection;

            if (ControladorIdioma.idioma == 1)
            {
                mensajeVacio = "You must fill in all the fields.";
                procesorealizado = "Process carried out";
                numerosNombre = "There are numbers in the name";
                datosCorrectos = "The data is correct";
                datosIncorrectos = "The data is incorrect";
                noConection = "Could not connect to the database";
            }
            else
            {
                mensajeVacio = "Debe rellenar todos los campos.";
                procesorealizado = "Proceso realizado";
                numerosNombre = "Hay numeros en el nombre";
                datosCorrectos = "Los datos son correctos";
                datosIncorrectos = "Los datos son incorrectos";
                noConection = "No se pudo conectar con la base de datos";
            }

            if (string.IsNullOrEmpty(ObjValidacionBase.txtUser.Text.ToString()) ||
                string.IsNullOrEmpty(ObjValidacionBase.txtContraseña.Text.ToString()))
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", mensajeVacio, Properties.Resources.MensajeWarning);
                return;
            }

            // Verificar si el campo txtUser contiene solo letras
            if (!IsOnlyLetters(ObjValidacionBase.txtUser.Text))
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", numerosNombre, Properties.Resources.MensajeWarning);
                return;
            }

            DAOLogin verificar = new DAOLogin();
            Encryp ObjEncriptar = new Encryp();
            verificar.Username = ObjValidacionBase.txtUser.Text;
            verificar.Password = ObjEncriptar.Encriptar(ObjValidacionBase.txtContraseña.Text);
            int respuesta = verificar.VerificarAdmin();
            if (respuesta == 1)
            {
                MandarValoresAlerta(Color.LightGreen, Color.Black, procesorealizado, datosCorrectos, Properties.Resources.comprobado);
                VistaLogin backForm = new VistaLogin();
                MostrarCuentas();
            }
            else if (respuesta == -1)
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", datosIncorrectos, Properties.Resources.MensajeWarning);
                return;
            }
            else
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", noConection, Properties.Resources.MensajeWarning);
                return;
            }
        }

        //Método auxiliar para verificar si el texto contiene solo letras
        private bool IsOnlyLetters(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsLetter(c))
                {
                    return false; // Si encuentra un carácter que no es una letra, retorna falso
                }
            }
            return true; // Si solo contiene letras, retorna verdadero
        }
        private void MostrarCuentas()
        {
            ViewAdminConnection adminConnection = new ViewAdminConnection(2);
            adminConnection.ShowDialog();
        }
        private void ShowPassword(object sender, EventArgs e)
        {
            ObjValidacionBase.txtContraseña.UseSystemPasswordChar = false;
            ObjValidacionBase.PasswordVisible.Visible = false;
            ObjValidacionBase.PasswordHide.Visible = true;
            // Forzar la actualización del TextBox
            string tempText = ObjValidacionBase.txtContraseña.Text;
            ObjValidacionBase.txtContraseña.Text = string.Empty;
            ObjValidacionBase.txtContraseña.Text = tempText;

            ObjValidacionBase.ResumeLayout();  // Reanudar el redibujado
        }

        private void HidePassword(object sender, EventArgs e)
        {
            ObjValidacionBase.txtContraseña.UseSystemPasswordChar = true;
            ObjValidacionBase.PasswordVisible.Visible = true;
            ObjValidacionBase.PasswordHide.Visible = false;
            // Forzar la actualización del TextBox
            string tempText = ObjValidacionBase.txtContraseña.Text;
            ObjValidacionBase.txtContraseña.Text = string.Empty;
            ObjValidacionBase.txtContraseña.Text = tempText;

            ObjValidacionBase.ResumeLayout();  // Reanudar el redibujado
        }
    }
}
