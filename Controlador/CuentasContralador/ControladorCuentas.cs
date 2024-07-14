using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Cuentas;

namespace AgroServicios.Controlador.CuentasContralador
{
    class ControladorCuentas
    {
        VistaCuentas ObjEmpleados;

        public ControladorCuentas(VistaCuentas Vista)
        {
            ObjEmpleados = Vista;
            ObjEmpleados.Load += new EventHandler(LoadData);
            ObjEmpleados.btnAgregar.Click += new EventHandler(OpenFormCreateUser);
            ObjEmpleados.cmsEliminar.Click += new EventHandler(EliminarEmpleado);
        }

        private void LoadData(object sender, EventArgs e)
        {
            RefrescarData();
        }

        private void RefrescarData()
        {
            //Objeto de la clase DAOAdminUsuarios
            DAOAdminUsers objAdmin = new DAOAdminUsers();
            //Declarando nuevo DataSet para que obtenga los datos del metodo ObtenerPersonas
            DataSet ds = objAdmin.ObtenerPersonas();
            ////Llenar DataGridView
            ObjEmpleados.GriewEmpleados.DataSource = ds.Tables["Empleados"];
        }

        private void OpenFormCreateUser(object sender, EventArgs e)
        {
            CreateUser createUser = new CreateUser(1);
            createUser.ShowDialog();
            RefrescarData();
        }

        private void EliminarEmpleado(object sender, EventArgs e)
        {
            int pos = ObjEmpleados.GriewEmpleados.CurrentRow.Index;

            if (MessageBox.Show($"¿Seguro que deseas eliminar a: \n {ObjEmpleados.GriewEmpleados[1, pos].Value.ToString()}{ObjEmpleados.GriewEmpleados[2, pos].Value.ToString()}.\nLa eliminación sera permanente.","Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DAOAdminUsers daodelete = new DAOAdminUsers();
                daodelete.IdEmpleado = int.Parse(ObjEmpleados.GriewEmpleados[0, pos].Value.ToString());
                int valorretornado = daodelete.DeteleEmpleado();
                if (valorretornado == 1)
                {
                    MessageBox.Show("Empleado eliminado", "Se ha eliminado correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefrescarData();
                }
                else
                {
                    MessageBox.Show("Eliminación fallida", "No seb ha podido eliminar el empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
