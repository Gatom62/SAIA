using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgroServicios.Controlador.Helper;
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
            ObjEmpleados.cmsUpdate.Click += new EventHandler (UpdateEmpleado);
            ObjEmpleados.cmsRestablecer.Click += new EventHandler(RestEmpleado);
        }
        private void UpdateEmpleado(object sender, EventArgs e)
        {
            int pos = ObjEmpleados.GriewEmpleados.CurrentRow.Index;
            int id;
            string Name, phone, email, dni, address;
            DateTime birthday;

            id = int.Parse(ObjEmpleados.GriewEmpleados[0, pos].Value.ToString());
            Name = ObjEmpleados.GriewEmpleados[1, pos].Value.ToString();
            birthday = DateTime.Parse(ObjEmpleados.GriewEmpleados[2, pos].Value.ToString());
            phone = ObjEmpleados.GriewEmpleados[3, pos].Value.ToString();
            email = ObjEmpleados.GriewEmpleados[4, pos].Value.ToString();
            dni = ObjEmpleados.GriewEmpleados[5, pos].Value.ToString();
            address = ObjEmpleados.GriewEmpleados[6, pos].Value.ToString();


           VistaUpdateEmpleados vistaUpdate = new VistaUpdateEmpleados(1, id, Name, phone, email, dni, address, birthday);
            vistaUpdate.ShowDialog();
            RefrescarData();
        }
        private void RestEmpleado(object sender, EventArgs e)
        {
            int pos = ObjEmpleados.GriewEmpleados.CurrentRow.Index;
            string usuario;

            usuario = ObjEmpleados.GriewEmpleados[7, pos].Value.ToString();

            VistaRestablecerPassword vistaRestablecer = new VistaRestablecerPassword(usuario);
            vistaRestablecer.ShowDialog();
        }
        private void LoadData(object sender, EventArgs e)
        {
            RefrescarData();
            Acceso();
        }
        public void Acceso()
        {
            switch (StaticSession.Categorianame1)
            {
                case "Manager":
                    break;
                case "Empleado":
                ObjEmpleados.btnAgregar.Enabled = false;
                ObjEmpleados.cmsEliminar.Enabled = false;
                ObjEmpleados.cmsRestablecer.Enabled = false;
                ObjEmpleados.cmsUpdate.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void RefrescarData()
        {
            //Objeto de la clase DAOAdminUsuarios
            DAOAdminUsers objAdmin = new DAOAdminUsers();
            //Declarando nuevo DataSet para que obtenga los datos del metodo ObtenerPersonas
            DataSet ds = objAdmin.ObtenerPersonas();
            ////Llenar DataGridView
            ObjEmpleados.GriewEmpleados.DataSource = ds.Tables["viewEmpleados"];
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

            if (MessageBox.Show($"¿Seguro que deseas eliminar a: \n {ObjEmpleados.GriewEmpleados[1, pos].Value.ToString()}\nLa eliminación sera permanente.","Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DAOAdminUsers daodelete = new DAOAdminUsers();
                daodelete.IdEmpleado = int.Parse(ObjEmpleados.GriewEmpleados[0, pos].Value.ToString());
                daodelete.Usuario1 = ObjEmpleados.GriewEmpleados[7, pos].Value.ToString();
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
