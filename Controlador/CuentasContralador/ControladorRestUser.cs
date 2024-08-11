using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Cuentas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
            daorest.IdCategoria = (int)objrest.DropRole.SelectedValue;

            int valorRetornado = daorest.restablecerEmpleado();
            if (valorRetornado == 2)
            {
                MessageBox.Show("La contraseña se ha actualizado correctamente",
                                "Proceso completado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                objrest.Close();
            }
            else if (valorRetornado == 1)
            {
                MessageBox.Show("Los datos no pudieron ser actualizados completamente",
                                "Proceso interrumpido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
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
