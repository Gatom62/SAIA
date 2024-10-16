using AgroServicios.Controlador.Helper;
using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Cuentas;
using AgroServicios.Vista.Login;
using System;
using System.Data;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using AgroServicios.Vista.Notificación;
using System.Drawing;

namespace AgroServicios.Controlador.CuentasContralador
{
    class ControladorCuentas
    {
        VistaCuentas ObjEmpleados;
        public ControladorCuentas(VistaCuentas Vista)
        {
            ObjEmpleados = Vista;
            ObjEmpleados.Load += new EventHandler(LoadData);
            //Verificacion();
            ObjEmpleados.btnAgregar.Click += new EventHandler(OpenFormCreateUser);
            ObjEmpleados.cmsEliminar.Click += new EventHandler(EliminarEmpleado);
            ObjEmpleados.cmsUpdate.Click += new EventHandler(UpdateEmpleado);
            ObjEmpleados.cmsRestablecer.Click += new EventHandler(RestEmpleado);
            ObjEmpleados.cmsinfo.Click += new EventHandler(Infoempleado);

            ObjEmpleados.txtBuscarP.KeyPress += new KeyPressEventHandler(Search);
        }
        private void Search(object sender, KeyPressEventArgs e)
        {
            // Verifica que la tecla presionada sea Enter antes de buscar
            if (e.KeyChar == (char)Keys.Enter)
            {
                BuscarEmpleado();
                e.Handled = true;
            }
        }
        private void BuscarEmpleado()
        {
            DAOAdminUsers objAdmin = new DAOAdminUsers();
            //Declarando nuevo DataSet para que obtenga los datos del metodo ObtenerPersonas
            DataSet ds = objAdmin.BuscarPersonas(ObjEmpleados.txtBuscarP.Text.Trim());
            //Llenar DataGridView
            ObjEmpleados.GriewEmpleados.DataSource = ds.Tables["VistaEmpleadosConRol"];
        }
        private void PreguntasEmp(object sender, EventArgs e)
        {
            if (ObjEmpleados.GriewEmpleados.CurrentRow == null)
            {
                MessageBox.Show("No se ha seleccionado ningún empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del método si no hay ninguna fila seleccionada
            }

            int pos = ObjEmpleados.GriewEmpleados.CurrentRow.Index;
            string user;

            user = ObjEmpleados.GriewEmpleados[7, pos].Value.ToString();

            DAOPreguntasRec rec = new DAOPreguntasRec();

            // Obtener los RespuestaID del usuario
            DataTable dtRespuestas = rec.ObtenerRespuestaIDs(user);

            // Verificar que se obtuvieron exactamente dos RespuestaID
            if (dtRespuestas.Rows.Count < 2)
            {
                MessageBox.Show("El usuario no tiene niguna pregunta de seguridad asignada.",
                                   "Error",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
            else
            {
                VistaPreguntas vpre = new VistaPreguntas(user, 2);
                vpre.ShowDialog();
            }
        }
        private void Infoempleado(object sender, EventArgs e)
        {
            if (ObjEmpleados.GriewEmpleados.CurrentRow == null)
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBox.Show("Error", "No employee has been selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Salir del método si no hay ninguna fila seleccionada
                }
                else
                {
                    MessageBox.Show("Error", "No se ha seleccionado ningún empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Salir del método si no hay ninguna fila seleccionada
                }
            }

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
            if (ObjEmpleados.GriewEmpleados.CurrentRow == null)
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBox.Show("Error", "No employee has been selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Salir del método si no hay ninguna fila seleccionada
                }
                else
                {
                    MessageBox.Show("Error", "No se ha seleccionado ningún empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Salir del método si no hay ninguna fila seleccionada
                }
            }

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
            if (ObjEmpleados.GriewEmpleados.CurrentRow == null)
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBox.Show("No employee has been selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Salir del método si no hay ninguna fila seleccionada
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ningún empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Salir del método si no hay ninguna fila seleccionada
                }
            }

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
            if (ObjEmpleados.GriewEmpleados.CurrentRow == null)
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBox.Show("No employee has been selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Salir del método si no hay ninguna fila seleccionada
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ningún empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Salir del método si no hay ninguna fila seleccionada
                }
            }

            int pos = ObjEmpleados.GriewEmpleados.CurrentRow.Index;

            if (ControladorIdioma.idioma == 1)
            {
                // Confirmación de la eliminación del empleado
                if (MessageBox.Show($"Surely you want to eliminate a: {ObjEmpleados.GriewEmpleados[1, pos].Value.ToString()}? the elimination will be permanent.",
                                    "Confirm action", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Crear la instancia del DAO para eliminar el empleado
                    DAOAdminUsers daodelete = new DAOAdminUsers();
                    daodelete.IdEmpleado = int.Parse(ObjEmpleados.GriewEmpleados[0, pos].Value.ToString());
                    daodelete.Usuario1 = ObjEmpleados.GriewEmpleados[7, pos].Value.ToString();

                    // Llamada al método de eliminación
                    int valorretornado = daodelete.DeleteEmpleado();

                    // Evaluación de los diferentes resultados
                    if (valorretornado > 0)
                    {
                        MessageBox.Show("Employee successfully removed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefrescarData(); // Refrescar los datos después de la eliminación exitosa
                    }
                    else if (valorretornado == -2)
                    {
                        MessageBox.Show("The associated employee or user could not be deleted.", "Failed elimination", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        RefrescarData();
                    }
                    else if (valorretornado == -1)
                    {
                        MessageBox.Show("An unexpected error occurred during deletion, this may be because this employee has associated data in other records.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("The employee could not be deleted.", "Failed elimination", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        RefrescarData();
                    }
                }

            }
            else
            {
                // Confirmación de la eliminación del empleado
                if (MessageBox.Show($"¿Seguro que deseas eliminar a: {ObjEmpleados.GriewEmpleados[1, pos].Value.ToString()}? La eliminación será permanente.",
                                    "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Crear la instancia del DAO para eliminar el empleado
                    DAOAdminUsers daodelete = new DAOAdminUsers();
                    daodelete.IdEmpleado = int.Parse(ObjEmpleados.GriewEmpleados[0, pos].Value.ToString());
                    daodelete.Usuario1 = ObjEmpleados.GriewEmpleados[7, pos].Value.ToString();

                    // Llamada al método de eliminación
                    int valorretornado = daodelete.DeleteEmpleado();

                    // Evaluación de los diferentes resultados
                    if (valorretornado > 0)
                    {
                        MessageBox.Show("Empleado eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefrescarData(); // Refrescar los datos después de la eliminación exitosa
                    }
                    else if (valorretornado == -2)
                    {
                        MessageBox.Show("No se ha podido eliminar el empleado o el usuario asociado.", "Eliminación fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        RefrescarData();
                    }
                    else if (valorretornado == -1)
                    {
                        MessageBox.Show("Ocurrió un error inesperado durante la eliminación, esto puede deberse a que este empleado tiene asociado datos en otros registros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("El empleado no se ha podido eliminar.", "Eliminación fallida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        RefrescarData();
                    }
                }
            }
        }
    }
}
