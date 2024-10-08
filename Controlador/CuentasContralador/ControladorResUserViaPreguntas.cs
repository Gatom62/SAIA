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
            if (string.IsNullOrWhiteSpace(objrest.txtNuevaContra.Text))
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Error", "All fields are required", Properties.Resources.MensajeWarning);
                    return;
                }
                else
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Error", "Todos los campos son obligatorios", Properties.Resources.MensajeWarning);
                    return;
                }
            }

            // Validar que las contraseñas coincidan
            if (objrest.txtNuevaContra.Text != objrest.txtContraDenuevo.Text)
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Error", "The same password has not been entered twice.", Properties.Resources.MensajeWarning);
                    return;
                }
                else
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Error", "No se ha ingresado la misma contraseña dos veces", Properties.Resources.MensajeWarning);
                    return;
                }
            }

            // Validar que la contraseña tenga al menos 8 caracteres
            if (!ValidarContraseña(objrest.txtNuevaContra.Text))
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Error", "The password must be at least 8 characters long", Properties.Resources.MensajeWarning);
                    return;
                }
                else
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Error", "La contraseña debe tener al menos 8 caracteres", Properties.Resources.MensajeWarning);
                    return;
                }
            }

            // Realizar el proceso de actualización de la contraseña
            DAOAdminUsers daorest = new DAOAdminUsers();
            Encryp encryp = new Encryp();
            daorest.Usuario1 = objrest.txtRest.Text.Trim();
            daorest.Contraseña1 = encryp.Encriptar(objrest.txtNuevaContra.Text.Trim());

            // Pedimos respuesta de la base de datos
            int valorRetornado = daorest.restablecerEmpleadov2();
            if (valorRetornado == 1)
            {
                if (ControladorIdioma.idioma == 1)
                {
                    // Mensaje de éxito si se actualiza correctamente
                    MandarValoresAlerta(Color.LightGreen, Color.Black, "Process performed", "Password has been successfully updated", Properties.Resources.comprobado);
                    VistaLogin backForm = new VistaLogin();
                    objrest.Close();
                }
                else
                {
                    // Mensaje de éxito si se actualiza correctamente
                    MandarValoresAlerta(Color.LightGreen, Color.Black, "Proceso realizado", "La contraseña se ha actualizado correctamente", Properties.Resources.comprobado);
                    VistaLogin backForm = new VistaLogin();
                    objrest.Close();
                }
            }
            else
            {
                if (ControladorIdioma.idioma == 1)
                {
                    // Mensaje de error si no se pudo actualizar
                    MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "The password could not be updated.", Properties.Resources.ErrorIcono);
                    VistaLogin backForm = new VistaLogin();
                }
                else
                {
                    // Mensaje de error si no se pudo actualizar
                    MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "La contraseña no se ha podido actualizar.", Properties.Resources.ErrorIcono);
                    VistaLogin backForm = new VistaLogin();
                }
            }

            // Método para validar que la contraseña tenga al menos 8 caracteres
            bool ValidarContraseña(string contraseña)
            {
                // Requiere más de 8 caracteres (letras, dígitos o caracteres especiales)
                string pattern = @"^.{8,}$";  // Acepta cualquier carácter y al menos 8 de ellos

                return Regex.IsMatch(contraseña, pattern);
            }
        }
        private void ChargeValues(string user)
        {
            objrest.txtRest.Text = user;
        }
    }
}
