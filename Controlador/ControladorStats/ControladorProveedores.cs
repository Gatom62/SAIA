using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Cuentas;
using AgroServicios.Vista.Estadisticas;
using AgroServicios.Vista.Login;
using AgroServicios.Vista.Notificación;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Controlador.ControladorStats
{
    internal class ControladorProveedores
    {
        VistaProveedores ObjProv;

        /// <summary>
        /// Constructor de la clase ControllerLogin que inicia los eventos de la vista
        /// </summary>
        /// <param name="Proveedores"></param>
        public ControladorProveedores(VistaProveedores Proveedores)
        {
            ObjProv = Proveedores;
            ObjProv.Load += new EventHandler(LoadData);
            //Evento click de botones
            ObjProv.ptbback.Click += new EventHandler(VolverForm);
            ObjProv.btnAgregarProv.Click += new EventHandler(OpenVistaAgregarProveedores);
            ObjProv.cmsEliminar.Click += new EventHandler(DeleteProv);
            ObjProv.cmsActualizar.Click += new EventHandler(ActualizarProv);
            ObjProv.cmsInformación.Click += new EventHandler(InformarProv);
            ObjProv.txtBuscarP.KeyPress += new KeyPressEventHandler(Search);
        }

        void MessageBoxP(Color backcolor, Color color, string title, string text, Image icon)
        {
            AlertExito frm = new AlertExito();

            frm.BackColorAlert = backcolor;

            frm.ColorAlertBox = color;

            frm.TittlAlertBox = title;

            frm.TextAlertBox = text;

            frm.IconeAlertBox = icon;

            frm.ShowDialog();
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
        private void OpenVistaAgregarProveedores(object sender, EventArgs e)
        {
            VistaAgregarProveedor vistaAgregarProveedor = new VistaAgregarProveedor();
            vistaAgregarProveedor.ShowDialog();
            RefrescarData();
        }
        private void VolverForm(object sender, EventArgs e)
        {
            // Cierra la vista actual
            ObjProv.Close();
        }
        private void Search(object sender, KeyPressEventArgs e)
        {
            // Verifica que la tecla presionada sea Enter antes de buscar
            if (e.KeyChar == (char)Keys.Enter)
            {
                BuscarProv();
                e.Handled = true;
            }
        }
        void BuscarProv()
        {
            DAOProveedores daoprv = new DAOProveedores();
            //Declarando nuevo DataSet para que obtenga los datos del metodo ObtenerPersonas
            DataSet ds = daoprv.BuscarProv(ObjProv.txtBuscarP.Text.Trim());
            //Llenar DataGridView
            ObjProv.GriewProveedores.DataSource = ds.Tables["VistaProveedoresConMarcas"];
        }
        private void LoadData(object sender, EventArgs e)
        {
            RefrescarData();
        }

        private void RefrescarData()
        {
            DAOProveedores objAdmin = new DAOProveedores();
            DataSet ds = objAdmin.ObtenerPersonas();
            ObjProv.GriewProveedores.DataSource = ds.Tables["VistaProveedoresConMarcas"];
            ObjProv.GriewProveedores.Columns["idProveedor"].Visible = false;
            TraducirEncabezados(ObjProv.GriewProveedores);
        }
        private void DeleteProv (object sender, EventArgs e)
        {
            if (ObjProv.GriewProveedores.CurrentRow == null)
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBox.Show("No supplier has been selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Salir del método si no hay ninguna fila seleccionada
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado a ningún proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Salir del método si no hay ninguna fila seleccionada
                }
            }

            int pos = ObjProv.GriewProveedores.CurrentRow.Index;
            if(ControladorIdioma.idioma == 1)
            {
                if (MessageBox.Show($"Surely you want to eliminate a: \n {ObjProv.GriewProveedores[1, pos].Value.ToString()}\nthe elimination will be permanent.", "Confirm action", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DAOProveedores daoDel = new DAOProveedores();
                    daoDel.IdProveedor = int.Parse(ObjProv.GriewProveedores[0, pos].Value.ToString());
                    int valorRetornado = daoDel.EliminarProv();
                    if (valorRetornado == 1)
                    {
                        MandarValoresAlerta(Color.LightGreen, Color.SeaGreen, "Process performed", "The supplier was successfully removed", Properties.Resources.comprobado);
                        VistaLogin backForm = new VistaLogin();
                        RefrescarData();
                    }
                    else
                    {
                        MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "Check if the supplier is associated to other records.", Properties.Resources.ErrorIcono);
                        VistaLogin backForm = new VistaLogin();
                    }
                }
            }
            else
            {
                if (MessageBox.Show($"¿Seguro que deseas eliminar a: \n {ObjProv.GriewProveedores[1, pos].Value.ToString()}\nLa eliminación sera permanente.", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DAOProveedores daoDel = new DAOProveedores();
                    daoDel.IdProveedor = int.Parse(ObjProv.GriewProveedores[0, pos].Value.ToString());
                    int valorRetornado = daoDel.EliminarProv();
                    if (valorRetornado == 1)
                    {
                        MandarValoresAlerta(Color.LightGreen, Color.SeaGreen, "Proceso realizado", "El proveedor se elimino correctamente", Properties.Resources.comprobado);
                        VistaLogin backForm = new VistaLogin();
                        RefrescarData();
                    }
                    else
                    {
                        MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "Verifique si el proveedor esta asociado a otros registros", Properties.Resources.ErrorIcono);
                        VistaLogin backForm = new VistaLogin();
                    }
                }
            }
        }
        private void ActualizarProv(object sender, EventArgs e)
        {
            if (ObjProv.GriewProveedores.CurrentRow == null)
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBox.Show("No supplier has been selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Salir del método si no hay ninguna fila seleccionada
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado a ningún proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Salir del método si no hay ninguna fila seleccionada
                }
            }

            int pos = ObjProv.GriewProveedores.CurrentRow.Index;
            int id;
            string Name, Dui, phone, email, marca;

            id = int.Parse(ObjProv.GriewProveedores[0, pos].Value.ToString());
            Name = ObjProv.GriewProveedores[1, pos].Value.ToString();
            Dui = ObjProv.GriewProveedores[2, pos].Value.ToString();
            phone = ObjProv.GriewProveedores[3, pos].Value.ToString();
            email = ObjProv.GriewProveedores[4, pos].Value.ToString();
            marca = ObjProv.GriewProveedores[5, pos].Value.ToString();
            
            VistaActualizarProveedor vistaUpdate = new VistaActualizarProveedor(1, id, Name, phone, email, Dui, marca);
            vistaUpdate.ShowDialog();
            RefrescarData();
        }

        private void InformarProv(object sender, EventArgs e)
        {
            if (ObjProv.GriewProveedores.CurrentRow == null)
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBox.Show("No supplier has been selected","Error",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Salir del método si no hay ninguna fila seleccionada
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado a ningún proveedor","Error",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Salir del método si no hay ninguna fila seleccionada
                }
            }

            int pos = ObjProv.GriewProveedores.CurrentRow.Index;
            int id;
            string Name, Dui, phone, email, marca;

            id = int.Parse(ObjProv.GriewProveedores[0, pos].Value.ToString());
            Name = ObjProv.GriewProveedores[1, pos].Value.ToString();
            Dui = ObjProv.GriewProveedores[2, pos].Value.ToString();
            phone = ObjProv.GriewProveedores[3, pos].Value.ToString();
            email = ObjProv.GriewProveedores[4, pos].Value.ToString();
            marca = ObjProv.GriewProveedores[5, pos].Value.ToString();

            VistaActualizarProveedor vistaUpdate = new VistaActualizarProveedor(2, id, Name, phone, email, Dui, marca);
            vistaUpdate.ShowDialog();
            RefrescarData();
        }
        private void TraducirEncabezados(DataGridView dgv)
        {
            if (ControladorIdioma.idioma == 1)
            {
                dgv.Columns["idProveedor"].HeaderText = "Supplier ID";
                dgv.Columns["Nombre"].HeaderText = "Name";
                dgv.Columns["DUI"].HeaderText = "ID";
                dgv.Columns["Teléfono"].HeaderText = "Phone";
                dgv.Columns["Correo"].HeaderText = "Email";
                dgv.Columns["NombreMarca"].HeaderText = "Brand name";


            }
            else
            {
                dgv.Columns["idProveedor"].HeaderText = "ID del Proveedor";
                dgv.Columns["Nombre"].HeaderText = "Nombre";
                dgv.Columns["DUI"].HeaderText = "DUI";
                dgv.Columns["Teléfono"].HeaderText = "Teléfono";
                dgv.Columns["Correo"].HeaderText = "Correo";
                dgv.Columns["NombreMarca"].HeaderText = "Nombre de la marca";
            }
        }
    }
}
