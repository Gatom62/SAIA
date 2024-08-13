using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Cuentas;
using AgroServicios.Vista.Estadisticas;
using System;
using System.Collections.Generic;
using System.Data;
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
            ObjProv.btnAgregarProv.Click += new EventHandler(OpenVistaAgregarProveedores);
            ObjProv.Load += new EventHandler(LoadData);
            //
            ObjProv.cmsEliminar.Click += new EventHandler(DeleteProv);
            ObjProv.cmsActualizar.Click += new EventHandler(ActualizarProv);
        }
        private void OpenVistaAgregarProveedores(object sender, EventArgs e)
        {
            VistaAgregarProveedor vistaAgregarProveedor = new VistaAgregarProveedor();
            vistaAgregarProveedor.ShowDialog();
            RefrescarData();
        }

        private void LoadData(object sender, EventArgs e)
        {
            RefrescarData();
        }

        private void RefrescarData()
        {
            DAOProveedores objAdmin = new DAOProveedores();
            DataSet ds = objAdmin.ObtenerPersonas();
            ObjProv.GriewProveedores.DataSource = ds.Tables["Proveedores"];
            TraducirEncabezados(ObjProv.GriewProveedores);
            ObjProv.GriewProveedores.Columns["idProveedor"].Visible = false;
        }
        private void DeleteProv (object sender, EventArgs e)
        {
            int pos = ObjProv.GriewProveedores.CurrentRow.Index;
            if (MessageBox.Show($"¿Seguro que deseas eliminar a: \n {ObjProv.GriewProveedores[1, pos].Value.ToString()}\nLa eliminación sera permanente.", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DAOProveedores daoDel = new DAOProveedores();
                daoDel.IdProveedor = int.Parse(ObjProv.GriewProveedores[0, pos].Value.ToString());
                int valorRetornado = daoDel.EliminarProv();
                if (valorRetornado == 1) 
                {
                    MessageBox.Show("Proveedor eliminado", "Se ha eliminado correctamente",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefrescarData();
                }
                else
                {
                    MessageBox.Show("Eliminación fallida", "No se ha podido eliminar el proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ActualizarProv(object sender, EventArgs e)
        {
            int pos = ObjProv.GriewProveedores.CurrentRow.Index;
            int id;
            string Name, Dui, phone, email, company;

            id = int.Parse(ObjProv.GriewProveedores[0, pos].Value.ToString());
            Name = ObjProv.GriewProveedores[1, pos].Value.ToString();
            Dui = ObjProv.GriewProveedores[2, pos].Value.ToString();
            phone = ObjProv.GriewProveedores[3, pos].Value.ToString();
            email = ObjProv.GriewProveedores[4, pos].Value.ToString();
            company = ObjProv.GriewProveedores[5, pos].Value.ToString();


            VistaActualizarProveedor vistaUpdate = new VistaActualizarProveedor(1, id, Name, phone, email, Dui, company);
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
                dgv.Columns["Empresa"].HeaderText = "Company";
            }
            else
            {
                dgv.Columns["idProveedor"].HeaderText = "idProveedor";
                dgv.Columns["Nombre"].HeaderText = "Nombre";
                dgv.Columns["DUI"].HeaderText = "DUI";
                dgv.Columns["Teléfono"].HeaderText = "Teléfono";
                dgv.Columns["Correo"].HeaderText = "Correo";
                dgv.Columns["Empresa"].HeaderText = "Empresa";
            }
        }
    }
}
