using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Clientes;
using AgroServicios.Vista.Login;
using AgroServicios.Vista.Notificación;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
            ObjClientes.ptbback.Click += new EventHandler(VolverForm);
            ObjClientes.txtBuscarClientes.KeyPress += new KeyPressEventHandler(BuscarCliente_KeyPress);
            ObjClientes.btnCrearCliente.Click += new EventHandler(NuevoCliente);
            ObjClientes.cmsEliminarCliente.Click += new EventHandler(EliminarCliente);
            ObjClientes.cmsEditarCliente.Click += new EventHandler(UbdateCliente);
            ObjClientes.cmsInformacionCliente.Click += new EventHandler(InformacionCLiente);
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
        public void LoadData(object sender, EventArgs e)
        {
            RefrescarData();
        }
        private void VolverForm(object sender, EventArgs e)
        {
            // Cierra la vista actual
            ObjClientes.Close();
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
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBox.Show("No client has been selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Salir del método si no hay ninguna fila seleccionada
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ningún cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Salir del método si no hay ninguna fila seleccionada
                }
            }

            int pos = ObjClientes.GriewViewClientes.CurrentRow.Index;

            if (ControladorIdioma.idioma == 1)
            {
                if (MessageBox.Show($"Surely you want to eliminate a: \n {ObjClientes.GriewViewClientes[1, pos].Value.ToString()}\nthe elimination will be permanent.", "Confirm action", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DAOClientes daodelete = new DAOClientes();
                    daodelete.IdCliente = int.Parse(ObjClientes.GriewViewClientes[0, pos].Value.ToString());
                    int valorretornado = daodelete.DeleteCLiente();

                    if (valorretornado == 1)
                    {
                        MandarValoresAlerta(Color.LightGreen, Color.SeaGreen, "Process performed", "The client was successfully deleted", Properties.Resources.comprobado);
                        VistaLogin backForm = new VistaLogin();
                        RefrescarData();
                    }
                    else
                    {
                        MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "Verifique si el cliente esta asociado a otros registros", Properties.Resources.ErrorIcono);
                        VistaLogin backForm = new VistaLogin();
                    }
                }
            }
            else
            {
                if (MessageBox.Show($"¿Seguro que deseas eliminar a: \n {ObjClientes.GriewViewClientes[1, pos].Value.ToString()}\nLa eliminación será permanente.", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DAOClientes daodelete = new DAOClientes();
                    daodelete.IdCliente = int.Parse(ObjClientes.GriewViewClientes[0, pos].Value.ToString());
                    int valorretornado = daodelete.DeleteCLiente();

                    if (valorretornado == 1)
                    {
                        MandarValoresAlerta(Color.LightGreen, Color.SeaGreen, "Proceso realizado", "El cliente se elimino correctamente", Properties.Resources.comprobado);
                        VistaLogin backForm = new VistaLogin();
                        RefrescarData();
                    }
                    else
                    {
                        MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "Verifique si el cliente esta asociado a otros registros", Properties.Resources.ErrorIcono);
                        VistaLogin backForm = new VistaLogin();
                    }
                }
            }
        }
        private void UbdateCliente(object sender, EventArgs e)
        {
            if (ObjClientes.GriewViewClientes.CurrentRow == null)
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBox.Show("No client has been selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Salir del método si no hay ninguna fila seleccionada
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ningún cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Salir del método si no hay ninguna fila seleccionada
                }
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
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBox.Show("No client has been selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Salir del método si no hay ninguna fila seleccionada
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ningún cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Salir del método si no hay ninguna fila seleccionada
                }
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
