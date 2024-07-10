using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
