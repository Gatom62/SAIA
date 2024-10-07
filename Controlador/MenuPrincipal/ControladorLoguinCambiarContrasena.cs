using AgroServicios.Vista.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgroServicios.Vista.MenuPrincipal;
using AgroServicios.Vista.Notificación;
using System.Drawing;
using AgroServicios.Modelo.DAO;
using System.Runtime.Remoting;
using AgroServicios.Controlador.Helper;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System.Security.Cryptography.X509Certificates;

namespace AgroServicios.Controlador.MenuPrincipal
{
    class ControladorLoguinCambiarContrasena
    {
        VistaLoguinCambiarContrasena ObjLoguinContra;

        public ControladorLoguinCambiarContrasena (VistaLoguinCambiarContrasena objLoguinContra, string user)
        {
            ObjLoguinContra = objLoguinContra;
            CharlesValue(user);
            ObjLoguinContra.btnValidar.Click += new EventHandler(ValidarContraLoguin);
            ObjLoguinContra.ptbback.Click += new EventHandler(CerrarForm);
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
        private void ValidarContraLoguin(object sender, EventArgs e) 
        {
            if (string.IsNullOrWhiteSpace(ObjLoguinContra.txtContraseña.Text)) 
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Error", "No password has been entered", Properties.Resources.MensajeWarning);
                }
                else 
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Error", "No se a ingresado ninguna contraseña", Properties.Resources.MensajeWarning);
                }

                return;
            }


            string user = StaticSession.Username;

            // Creando objeto de la Clase DAOLogin
            DAOAdminUsers DAOData = new DAOAdminUsers();
            // Utilizando el objeto DAO para invocar a los métodos getter y setter del DTO
            Encryp ObjEncriptar = new Encryp();
            DAOData.Usuario1 = user;
            DAOData.Contraseña1 = ObjEncriptar.Encriptar(ObjLoguinContra.txtContraseña.Text);
            // Invocando al método Login contenido en el DAO
            //Pedimos una contestación por parte de la base de datos, si nos manda un 1 es que si se logro realizar correctamente la insercción
            int valorRetornado = DAOData.VerificarDatos();
            if (valorRetornado == 1)
            {
                VistaRestContraPreguntas frm = new VistaRestContraPreguntas(user);
                frm.ShowDialog();
                ObjLoguinContra.Close();
            }
            else
            {
                //Mensaje de error si se no se pudo realizar la inserccion
                if (ControladorIdioma.idioma == 1)
                {
                    MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "The password could not be updated.", Properties.Resources.ErrorIcono);
                    VistaLogin backForm = new VistaLogin();
                }
                else 
                {
                    MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "La contraseña no se ha podido actualizar.", Properties.Resources.ErrorIcono);
                    VistaLogin backForm = new VistaLogin();
                }
            }
        }
        private void CharlesValue(string user) 
        {
            ObjLoguinContra.txtUsuario.Text = user;
        }

        private void CerrarForm(object sender, EventArgs e)
        {
            ObjLoguinContra.Close();
        }
    }
}
