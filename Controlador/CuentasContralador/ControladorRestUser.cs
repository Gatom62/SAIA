using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Cuentas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Controlador.CuentasContralador
{
    class ControladorRestUser
    {
        VistaRestablecerPassword objrest;

        public ControladorRestUser(VistaRestablecerPassword Vista, string usuario)
        {
            objrest = Vista;
            ChargeValues(usuario);

            objrest.btnRestablecer.Click += new EventHandler(RestablecerContraseña);
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

            int valorRetornado = daorest.restablecerEmpleado();
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
        public void ChargeValues(string usuario)
        {
            objrest.txtRest.Text = usuario;
        }
    }
}
