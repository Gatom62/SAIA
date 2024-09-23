using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Login;
using AgroServicios.Vista.MenuPrincipal;
using AgroServicios.Vista.Notificación;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Controlador.CuentasContralador
{
    internal class ControladorResUserViaPreguntas
    {
        VistaRestContraPreguntas objrest;

        public ControladorResUserViaPreguntas(VistaRestContraPreguntas Vista, string user)
        {
            objrest = Vista;
            ChargeValues(user);
            objrest.ptbback.Click += CerrarForm;
            objrest.btnRestablecer.Click += RestablecerContraseña;
        }
        void CerrarForm(object sender, EventArgs e)
        {
            objrest.Close();
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
        private void RestablecerContraseña(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(objrest.txtRestPass.Text))
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", "Todos los campos son obligatorios", Properties.Resources.MensajeWarning);
                return;
            }

            // Validar que la contraseña del empleado no exceda 100 caracteres
            if (!ValidarContraseña(objrest.txtRestPass.Text))
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", "La contraseña debe tener al menos 8 caracteres", Properties.Resources.MensajeWarning);
                return;
            }

            //Realizamos el proceso de actualización
            DAOAdminUsers daorest = new DAOAdminUsers();
            Encryp encryp = new Encryp();
            daorest.Usuario1 = objrest.txtRest.Text.Trim();
            daorest.Contraseña1 = encryp.Encriptar(objrest.txtRestPass.Text.Trim());
            //Pedimos una contestación por parte de la base de datos, si nos manda un 1 es que si se logro realizar correctamente la insercción
            int valorRetornado = daorest.restablecerEmpleadov2();
            if (valorRetornado == 1)
            {
                //Mensaje de afirmacion si se pudo realizar la inserccion
                MandarValoresAlerta(Color.LightGreen, Color.Black, "Proceso realizado", "La contraseña se ha actualizado correctamente", Properties.Resources.comprobado);
                VistaLogin backForm = new VistaLogin();
                objrest.Close();
            }
            else
            {
                //Mensaje de error si se no se pudo realizar la inserccion
                MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "La contraseña no se ha podido actualizar.", Properties.Resources.ErrorIcono);
                VistaLogin backForm = new VistaLogin();
            }

            bool ValidarContraseña(string contraseña)
            {
                // Requiere más de 8 caracteres (letras, dígitos o caracteres especiales)
                string pattern = @"^.{9,}$";  // Acepta cualquier carácter y al menos 9 de ellos

                if (!Regex.IsMatch(contraseña, pattern))
                {
                    return false;
                }
                return true;
            }

        }
        private void ChargeValues(string user)
        {
            objrest.txtRest.Text = user;
        }
    }
}
