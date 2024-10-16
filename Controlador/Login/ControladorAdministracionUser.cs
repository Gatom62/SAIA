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
using System.Windows.Forms;

namespace AgroServicios.Controlador.Login
{
    class ControladorAdministracionUser
    {
        VistaMetodoRecuperacionAdminUser ObjAdminUser;
        public ControladorAdministracionUser(VistaMetodoRecuperacionAdminUser VistaAdminUser) 
        {
            ObjAdminUser = VistaAdminUser;
            VistaAdminUser.ptbback.Click += VolverForm;
            VistaAdminUser.btnVerificar.Click += new EventHandler(VerificarDatos);
            ObjAdminUser.PasswordVisible.Click += new EventHandler(ShowPassword);
            ObjAdminUser.PasswordHide.Click += new EventHandler(HidePassword);
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
            ObjAdminUser.Close();
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
                datosIncorrectos = "The data is incorrect, or you don't have the role you need to access";
                noConection = "Could not connect to the database";
            }
            else
            {
                mensajeVacio = "Debe rellenar todos los campos.";
                procesorealizado = "Proceso realizado";
                numerosNombre = "Hay numeros en el nombre";
                datosCorrectos = "Los datos son correctos";
                datosIncorrectos = "Los datos son incorrectos, o no tiene el rol necesario para acceder";
                noConection = "No se pudo conectar con la base de datos";
            }

            if (string.IsNullOrEmpty(ObjAdminUser.txtUser.Text.ToString())||
                string.IsNullOrEmpty(ObjAdminUser.txtContraseña.Text.ToString())) 
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", mensajeVacio, Properties.Resources.MensajeWarning);
                return;
            }

            // Verificar si el campo txtUser contiene solo letras
            if (!IsOnlyLetters(ObjAdminUser.txtUser.Text))
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", numerosNombre, Properties.Resources.MensajeWarning);
                return;
            }

            DAOLogin verificar = new DAOLogin();
            Encryp ObjEncriptar = new Encryp();
            verificar.Username = ObjAdminUser.txtUser.Text;
            verificar.Password = ObjEncriptar.Encriptar(ObjAdminUser.txtContraseña.Text);
            int respuesta = verificar.VerificarAdmin();
            if (respuesta == 1)
            {
                MandarValoresAlerta(Color.LightGreen, Color.Black, procesorealizado, datosCorrectos, Properties.Resources.comprobado);
                VistaLogin backForm = new VistaLogin();
                MostrarCuentas();
            }
            else if (respuesta == -1) 
            {
                //Mensaje de error si se no se pudo realizar la inserccion
                MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", datosIncorrectos, Properties.Resources.ErrorIcono);
                VistaLogin backForm = new VistaLogin();
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
            VistaCuentasAdminUser vistaCuentas = new VistaCuentasAdminUser();
            vistaCuentas.ShowDialog();
        }
        private void ShowPassword(object sender, EventArgs e)
        {
            ObjAdminUser.txtContraseña.UseSystemPasswordChar = false;
            ObjAdminUser.PasswordVisible.Visible = false;
            ObjAdminUser.PasswordHide.Visible = true;
            // Forzar la actualización del TextBox
            string tempText = ObjAdminUser.txtContraseña.Text;
            ObjAdminUser.txtContraseña.Text = string.Empty;
            ObjAdminUser.txtContraseña.Text = tempText;

            ObjAdminUser.ResumeLayout();  // Reanudar el redibujado
        }
        private void HidePassword(object sender, EventArgs e)
        {
            ObjAdminUser.txtContraseña.UseSystemPasswordChar = true;
            ObjAdminUser.PasswordVisible.Visible = true;
            ObjAdminUser.PasswordHide.Visible = false;
            // Forzar la actualización del TextBox
            string tempText = ObjAdminUser.txtContraseña.Text;
            ObjAdminUser.txtContraseña.Text = string.Empty;
            ObjAdminUser.txtContraseña.Text = tempText;

            ObjAdminUser.ResumeLayout();  // Reanudar el redibujado
        }
    }
}
