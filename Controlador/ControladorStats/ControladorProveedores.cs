﻿using AgroServicios.Modelo.DAO;
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
            ObjProv.txtBuscarP.KeyPress += new KeyPressEventHandler(Search);
        }
        private void OpenVistaAgregarProveedores(object sender, EventArgs e)
        {
            VistaAgregarProveedor vistaAgregarProveedor = new VistaAgregarProveedor();
            vistaAgregarProveedor.ShowDialog();
            RefrescarData();
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
            TraducirEncabezados(ObjProv.GriewProveedores);
        }
        private void DeleteProv (object sender, EventArgs e)
        {
            if (ObjProv.GriewProveedores.CurrentRow == null)
            {
                MessageBox.Show("No se ha seleccionado ningún proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del método si no hay ninguna fila seleccionada
            }

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
            if (ObjProv.GriewProveedores.CurrentRow == null)
            {
                MessageBox.Show("No se ha seleccionado ningún proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del método si no hay ninguna fila seleccionada
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
