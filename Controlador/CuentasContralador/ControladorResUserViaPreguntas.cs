using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Login;
using AgroServicios.Vista.MenuPrincipal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            objrest.btnRestablecer.Click += RestablecerContraseña;
            ChargeValues(user);
        }
        private void RestablecerContraseña(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(objrest.txtRestPass.Text))
            {
                MessageBox.Show("Introduzca una contraseña valida.",
                               "Error de validación",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                return;
            }

            DAOAdminUsers daorest = new DAOAdminUsers();
            Encryp encryp = new Encryp();

            daorest.Usuario1 = objrest.txtRest.Text.Trim();
            daorest.Contraseña1 = encryp.Encriptar(objrest.txtRestPass.Text.Trim());

            int valorRetornado = daorest.restablecerEmpleadov2();
            if (valorRetornado == 1)
            {
                MessageBox.Show("La contraseña se ha actualizado correctamente",
                                "Proceso completado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                objrest.Close();
            }
            else
            {
                MessageBox.Show("La contraseña no se ha podido actualizar.",
                                "Proceso interrumpido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        private void ChargeValues(string user)
        {
            objrest.txtRest.Text = user;
        }
    }
}
