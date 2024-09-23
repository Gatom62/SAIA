using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Cuentas;
using AgroServicios.Vista.Login;
using AgroServicios.Vista.Notificación;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;

namespace AgroServicios.Controlador.CuentasContralador
{
    class ControladorRestUser
    {
        VistaRestablecerPassword objrest;
        private string role;

        public ControladorRestUser(VistaRestablecerPassword Vista, string usuario, string role)
        {
            objrest = Vista;
            this.role = role;
            objrest.Load += new EventHandler(InitialCharge);
            ChargeValues(usuario);
            

            objrest.btnRestablecer.Click += new EventHandler(RestablecerContraseña);
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
        public void InitialCharge(object sender, EventArgs e)
        {
            //Objeto de la clase DAOAdminUsuarios
            DAOAdminUsers objAdmin = new DAOAdminUsers();
            //Declarando nuevo DataSet para que obtenga los datos del metodo LlenarCombo
            DataSet ds = objAdmin.LlenarCombo();
            //Llenar combobox tbRole
            objrest.DropRole.DataSource = ds.Tables["Categorias"];
            objrest.DropRole.ValueMember = "idCategoria";
            objrest.DropRole.DisplayMember = "Nombre";

            objrest.DropRole.Text = role;
            
        }
        private void RestablecerContraseña(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(objrest.txtRestPass.Text))
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error de validación", "Debe de ingresar una contraseña", Properties.Resources.MensajeWarning);
                return;
            }

            // Validar que la contraseña del empleado no exceda 100 caracteres
            if (!ValidarContraseña(objrest.txtRestPass.Text))
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", "La contraseña debe tener al menos 8 caracteres", Properties.Resources.MensajeWarning);
                return;
            }

            DAOAdminUsers daorest = new DAOAdminUsers();
            Encryp encryp = new Encryp();

            daorest.Usuario1 = objrest.txtRest.Text.Trim();
            daorest.Contraseña1 = encryp.Encriptar(objrest.txtRestPass.Text.Trim());
            daorest.IdCategoria = (int)objrest.DropRole.SelectedValue;

            int valorRetornado = daorest.restablecerEmpleado();
            if (valorRetornado == 2)
            {
                MandarValoresAlerta(Color.LightGreen, Color.Black, "Proceso completado", "La contraseña se ha actualizado correctamente", Properties.Resources.comprobado);
                VistaLogin backForm = new VistaLogin();
                objrest.Close();
            }
            else if (valorRetornado == 1)
            {
                MandarValoresAlerta(Color.Red, Color.DarkRed, "Los datos no pudieron ser actualizados completamente",
                                "Error", Properties.Resources.ErrorIcono);
                VistaLogin backForm = new VistaLogin();
            }
            else
            {
                MandarValoresAlerta(Color.Red, Color.DarkRed, "La contraseña no se ha podido actualizar.",
                                "Error", Properties.Resources.ErrorIcono);
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
        public void ChargeValues(string usuario)
        {
            objrest.txtRest.Text = usuario;
        }
    }
}
