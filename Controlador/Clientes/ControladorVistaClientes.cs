using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Clientes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Controlador.Clientes
{
    class ControladorVistaClientes
    {
        VistaClientes ObjClientes;

        public ControladorVistaClientes(VistaClientes objClientes) 
        {
            ObjClientes = objClientes;
            ObjClientes.Load += new EventHandler(LoadData);
            //Evento click de botones
            ObjClientes.txtBuscarClientes.KeyPress += new KeyPressEventHandler(BuscarCliente_KeyPress);
            ObjClientes.btnCrearCliente.Click += new EventHandler(NuevoCliente);
            ObjClientes.cmsEliminarCliente.Click += new EventHandler(EliminarCliente);
            ObjClientes.cmsEditarCliente.Click += new EventHandler(UbdateCliente);
            ObjClientes.cmsInformacionCliente.Click += new EventHandler(InformacionCLiente);
        }

        public void LoadData(object sender, EventArgs e)
        {
            RefrescarData();
        }

        public void RefrescarData()
        {
            //Objeto de la clase DAOAdminUsuarios
            DAOClientes dAOClientes = new DAOClientes();
            //Declarando nuevo DataSet para que obtenga los datos del metodo ObtenerProductos
            DataSet ds = dAOClientes.ObtenerClientes();
            ////Llenar DataGridView
            ObjClientes.GriewViewClientes.DataSource = ds.Tables["Clientes"];

            ObjClientes.GriewViewClientes.Columns["idCliente"].Visible = false;
        }

        private void NuevoCliente(object sender, EventArgs e)
        {
            VistaCreateCliente nuevoProducto = new VistaCreateCliente(1);
            nuevoProducto.ShowDialog();
            RefrescarData();
        }

        private void EliminarCliente(object sender, EventArgs e)
        {
            if (ObjClientes.GriewViewClientes.CurrentRow == null)
            {
                MessageBox.Show("No se ha seleccionado ningún cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del método si no hay ninguna fila seleccionada
            }

            int pos = ObjClientes.GriewViewClientes.CurrentRow.Index;

            if (MessageBox.Show($"¿Seguro que deseas eliminar a: \n {ObjClientes.GriewViewClientes[1, pos].Value.ToString()}\nLa eliminación será permanente.", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DAOClientes daodelete = new DAOClientes();
                daodelete.IdCliente = int.Parse(ObjClientes.GriewViewClientes[0, pos].Value.ToString());
                int valorretornado = daodelete.DeleteCLiente();

                if (valorretornado == 1)
                {
                    MessageBox.Show("Cliente eliminado", "Se ha eliminado correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefrescarData();
                }
                else
                {
                    MessageBox.Show("Eliminación fallida", "No se ha podido eliminar el cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void UbdateCliente(object sender, EventArgs e)
        {
            if (ObjClientes.GriewViewClientes.CurrentRow == null)
            {
                MessageBox.Show("No se ha seleccionado ningún cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del método si no hay ninguna fila seleccionada
            }

            int pos = ObjClientes.GriewViewClientes.CurrentRow.Index;
            int id;
            string Name, telefono, correo, direccion, dui;

            id = int.Parse(ObjClientes.GriewViewClientes[0, pos].Value.ToString());
            Name = ObjClientes.GriewViewClientes[1, pos].Value.ToString();
            telefono = ObjClientes.GriewViewClientes[2, pos].Value.ToString();
            correo = ObjClientes.GriewViewClientes[3, pos].Value.ToString();
            direccion = ObjClientes.GriewViewClientes[4, pos].Value.ToString();
            dui = ObjClientes.GriewViewClientes[5, pos].Value.ToString();

            VistaUbdateCliente vistaUpdate = new VistaUbdateCliente(1, id, Name, telefono, correo, direccion, dui);
            vistaUpdate.ShowDialog();
            RefrescarData();
        }

        private void InformacionCLiente(object sender, EventArgs e)
        {
            if (ObjClientes.GriewViewClientes.CurrentRow == null)
            {
                MessageBox.Show("No se ha seleccionado ningún cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del método si no hay ninguna fila seleccionada
            }

            int pos = ObjClientes.GriewViewClientes.CurrentRow.Index;
            int id;
            string Name, telefono, correo, direccion, dui;

            id = int.Parse(ObjClientes.GriewViewClientes[0, pos].Value.ToString());
            Name = ObjClientes.GriewViewClientes[1, pos].Value.ToString();
            telefono = ObjClientes.GriewViewClientes[2, pos].Value.ToString();
            correo = ObjClientes.GriewViewClientes[3, pos].Value.ToString();
            direccion = ObjClientes.GriewViewClientes[4, pos].Value.ToString();
            dui = ObjClientes.GriewViewClientes[5, pos].Value.ToString();

            VistaUbdateCliente vistaUpdate = new VistaUbdateCliente(2, id, Name, telefono, correo, direccion, dui);
            vistaUpdate.ShowDialog();
            RefrescarData();
        }

        private void BuscarCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string criterio = ObjClientes.txtBuscarClientes.Text.Trim();
                DAOClientes daoBuscar = new DAOClientes();
                DataSet ds = daoBuscar.BuscarClientes(criterio);
                ObjClientes.GriewViewClientes.DataSource = ds.Tables["Clientes"];
                e.Handled = true;
            }
        }
    }
}
