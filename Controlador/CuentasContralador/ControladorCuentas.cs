using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using AgroServicios.Controlador.Helper;
using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Cuentas;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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
            ObjEmpleados.cmsinfo.Click += new EventHandler(Infoempleado);
        }
        private void Infoempleado(object sender, EventArgs e)
        {
            int pos = ObjEmpleados.GriewEmpleados.CurrentRow.Index;
            int id;
            string Name, phone, email, dni, address, user;
            DateTime birthday;
            byte[] img;

            user = ObjEmpleados.GriewEmpleados[7, pos].Value.ToString();
            id = int.Parse(ObjEmpleados.GriewEmpleados[0, pos].Value.ToString());
            Name = ObjEmpleados.GriewEmpleados[1, pos].Value.ToString();
            birthday = DateTime.Parse(ObjEmpleados.GriewEmpleados[2, pos].Value.ToString());
            phone = ObjEmpleados.GriewEmpleados[3, pos].Value.ToString();
            email = ObjEmpleados.GriewEmpleados[4, pos].Value.ToString();
            dni = ObjEmpleados.GriewEmpleados[5, pos].Value.ToString();
            address = ObjEmpleados.GriewEmpleados[6, pos].Value.ToString();
            img = (byte[])ObjEmpleados.GriewEmpleados[9, pos].Value;

            VistaUpdateEmpleados vistaInfo = new VistaUpdateEmpleados(2, id, Name, phone, email, dni, address, birthday, img, user);
            vistaInfo.ShowDialog();
            RefrescarData();
        }
        private void UpdateEmpleado(object sender, EventArgs e)
        {
            int pos = ObjEmpleados.GriewEmpleados.CurrentRow.Index;
            int id;
            string Name, phone, email, dni, address, user;
            DateTime birthday;
            byte[] img;

            user = ObjEmpleados.GriewEmpleados[7, pos].Value.ToString();
            id = int.Parse(ObjEmpleados.GriewEmpleados[0, pos].Value.ToString());
            Name = ObjEmpleados.GriewEmpleados[1, pos].Value.ToString();
            birthday = DateTime.Parse(ObjEmpleados.GriewEmpleados[2, pos].Value.ToString());
            phone = ObjEmpleados.GriewEmpleados[3, pos].Value.ToString();
            email = ObjEmpleados.GriewEmpleados[4, pos].Value.ToString();
            dni = ObjEmpleados.GriewEmpleados[5, pos].Value.ToString();
            address = ObjEmpleados.GriewEmpleados[6, pos].Value.ToString();
            img = (byte[])ObjEmpleados.GriewEmpleados[9, pos].Value;


            VistaUpdateEmpleados vistaUpdate = new VistaUpdateEmpleados(1, id, Name, phone, email, dni, address, birthday, img, user);
            vistaUpdate.ShowDialog();
            RefrescarData();
        }
        private void RestEmpleado(object sender, EventArgs e)
        {
            int pos = ObjEmpleados.GriewEmpleados.CurrentRow.Index;
            string usuario, role;

            usuario = ObjEmpleados.GriewEmpleados[7, pos].Value.ToString();
            role = ObjEmpleados.GriewEmpleados[8, pos].Value.ToString();

            VistaRestablecerPassword vistaRestablecer = new VistaRestablecerPassword(usuario, role);
            vistaRestablecer.ShowDialog();
            RefrescarData();
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
            ObjEmpleados.GriewEmpleados.DataSource = ds.Tables["VistaEmpleadosConRol"];
            // Traducir encabezados de las columnas
            TraducirEncabezados(ObjEmpleados.GriewEmpleados);

            ObjEmpleados.GriewEmpleados.Columns["Image"].Visible = false;
            ObjEmpleados.GriewEmpleados.Columns["ID del empleado"].Visible = false;
        }
        private void TraducirEncabezados(DataGridView dgv)
        {
            if (ControladorIdioma.idioma == 1)
            {
                dgv.Columns["ID del empleado"].HeaderText = "Employee ID";
                dgv.Columns["Nombre"].HeaderText = "Name";
                dgv.Columns["Fecha de nacimiento"].HeaderText = "Birthdate";
                dgv.Columns["Telefono"].HeaderText = "Phone";
                dgv.Columns["Correo"].HeaderText = "Email";
                dgv.Columns["DUI"].HeaderText = "DUI";
                dgv.Columns["Dirección"].HeaderText = "Address";
                dgv.Columns["Usuario"].HeaderText = "Username";
                dgv.Columns["Rol"].HeaderText = "Role";
            }
            else
            {
                dgv.Columns["ID del empleado"].HeaderText = "ID del empleado";
                dgv.Columns["Nombre"].HeaderText = "Nombre";
                dgv.Columns["Fecha de nacimiento"].HeaderText = "Fecha de nacimiento";
                dgv.Columns["Telefono"].HeaderText = "Teléfono";
                dgv.Columns["Correo"].HeaderText = "Correo";
                dgv.Columns["DUI"].HeaderText = "DUI";
                dgv.Columns["Dirección"].HeaderText = "Dirección";
                dgv.Columns["Usuario"].HeaderText = "Usuario";
                dgv.Columns["Rol"].HeaderText = "Rol";
            }
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
