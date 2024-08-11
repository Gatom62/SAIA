using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Cuentas;
using AgroServicios.Vista.Productos1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Controlador.Productos1
{
    class ControladorCreateMarca1
    {
        VistaCreateMarca ObjCreateMarca;
        private int accion;
        private string role;

        /// <summary>
        /// Constructor para inserción de datos
        /// </summary>
        /// <param name="Vista"></param>
        /// <param name="accion"> INSERCIÓN </param>
        public ControladorCreateMarca1(VistaCreateMarca Vista, int accion)
        {
            ObjCreateMarca = Vista;
            this.accion = accion;
            ObjCreateMarca.Load += new EventHandler(LoadData);
            //ObjCreateProducto1.Load += new EventHandler(InitialCharge);
            ObjCreateMarca.btnIngresarMarca.Click += new EventHandler(NuevoRegistro);
            ObjCreateMarca.cmsElimarProducto.Click += new EventHandler(EliminarMarca);
            ObjCreateMarca.cmsEditarMarca.Click += new EventHandler(UpdateMarca);
        }

        private void UpdateMarca(object sender, EventArgs e)
        {
            int pos = ObjCreateMarca.GriewViewMarcas.CurrentRow.Index;
            int id;
            string Name;

            id = int.Parse(ObjCreateMarca.GriewViewMarcas[0, pos].Value.ToString());
            Name = ObjCreateMarca.GriewViewMarcas[1, pos].Value.ToString();

            VistaUbdateMarca vistaUpdate = new VistaUbdateMarca(1, id, Name);
            vistaUpdate.ShowDialog();
            RefrescarData();
        }

        public void NuevoRegistro(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (ObjCreateMarca.txtNombreMarca.Text  == null)
            {
                MessageBox.Show("Todos los campos son obligatorios.",
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            DAOProductos1 DaoInsert = new DAOProductos1();
            // Asignar los valores a las propiedades de DaoInsert
            DaoInsert.NombreMarca1 = ObjCreateMarca.txtNombreMarca.Text.Trim();

            int valorRetornado = DaoInsert.RegistrarMarca();
            if (valorRetornado == 1)
            {
                MessageBox.Show("Los datos han sido registrados exitosamente",
                                "Proceso completado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                ObjCreateMarca.Close();
            }
            else
            {
                MessageBox.Show("Los datos no pudieron ser registrados",
                                "Proceso interrumpido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        public void LoadData(object sender, EventArgs e)
        {
            RefrescarData();
        }

        public void RefrescarData()
        {
            //Objeto de la clase DAOAdminUsuarios
            DAOProductos1 dAOProductos1 = new DAOProductos1();
            //Declarando nuevo DataSet para que obtenga los datos del metodo ObtenerMarcas
            DataSet ds = dAOProductos1.ObtenerMarcas();
            ////Llenar DataGridView
            ObjCreateMarca.GriewViewMarcas.DataSource = ds.Tables["Marcas"];
        }

        private void EliminarMarca(object sender, EventArgs e)
        {
            int pos = ObjCreateMarca.GriewViewMarcas.CurrentRow.Index;

            if (MessageBox.Show($"¿Seguro que deseas eliminar a: \n {ObjCreateMarca.GriewViewMarcas[1, pos].Value.ToString()}\nLa eliminación sera permanente.", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DAOProductos1 daodelete = new DAOProductos1();
                daodelete.IdMarca = int.Parse(ObjCreateMarca.GriewViewMarcas[0, pos].Value.ToString());
                int valorretornado = daodelete.DeleteMarca();
                if (valorretornado == 1)
                {
                    MessageBox.Show("Marca eliminada", "Se ha eliminado correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefrescarData();
                }
                else
                {
                    MessageBox.Show("Eliminación fallida", "No seb ha podido eliminar la marca", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
