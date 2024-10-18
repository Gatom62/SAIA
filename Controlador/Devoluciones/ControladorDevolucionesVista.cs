using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Estadisticas.Devoluciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Controlador.Devoluciones
{
    class ControladorDevolucionesVista
    {
        VistaDetallesDevoluciones ObjVistaDevoluciones;
        public ControladorDevolucionesVista(VistaDetallesDevoluciones Vista)
        {
            ObjVistaDevoluciones = Vista;
            ObjVistaDevoluciones.Load += new EventHandler(LoadData);
            ObjVistaDevoluciones.btnHacerDevolucion.Click += new EventHandler(CrearDevolucion);
            ObjVistaDevoluciones.txtBuscarP.KeyPress += new KeyPressEventHandler(Search);

            //ObjVistaDevoluciones.cmsInformacion.Click += new EventHandler(InformaciónDevolución);
        }
        private void Search(object sender, KeyPressEventArgs e)
        {
            // Verifica que la tecla presionada sea Enter antes de buscar
            if (e.KeyChar == (char)Keys.Enter)
            {
                BuscarDevolucion();
                e.Handled = true;
            }
        }
        private void BuscarDevolucion()
        {
            DAODevoluciones objdev = new DAODevoluciones();
            //Declarando nuevo DataSet para que obtenga los datos del metodo ObtenerPersonas
            DataSet ds = objdev.BuscarDevoluciones(ObjVistaDevoluciones.txtBuscarP.Text.Trim());
            //Llenar DataGridView
            ObjVistaDevoluciones.dgvDevoluciones.DataSource = ds.Tables["viewDevoluciones"];
        }

        public void LoadData(object sender, EventArgs e)
        {
            RefrescarData();
        }
        public void RefrescarData()
        {
            //Objeto de la clase DAOAdminUsuarios
            DAODevoluciones dAOProductos1 = new DAODevoluciones();
            //Declarando nuevo DataSet para que obtenga los datos del metodo ObtenerProductos
            DataSet ds = dAOProductos1.ObtenerDevoluciones();
            //Llenar DataGridView
            ObjVistaDevoluciones.dgvDevoluciones.DataSource = ds.Tables["viewDevoluciones"];
            // Traducir encabezados de las columnas
            TraducirEncabezados(ObjVistaDevoluciones.dgvDevoluciones);
        }
        private void TraducirEncabezados(DataGridView dgv)
        {
            if (ControladorIdioma.idioma == 1)
            {
                dgv.Columns[0].HeaderText = "Return ID";
                dgv.Columns[1].HeaderText = "Sale ID";
                dgv.Columns[2].HeaderText = "Returned product";
                dgv.Columns[3].HeaderText = "Client Name";
                dgv.Columns[4].HeaderText = "Date of return";
                dgv.Columns[5].HeaderText = "Quantity of the returned product";
                dgv.Columns[6].HeaderText = "Refund amount";
                dgv.Columns[7].HeaderText = "Reason for return";
            }
            else
            {
                dgv.Columns[0].HeaderText = "ID de la devolución";
                dgv.Columns[1].HeaderText = "ID de la venta";
                dgv.Columns[2].HeaderText = "Producto devolvido";
                dgv.Columns[3].HeaderText = "Nombre del cliente";
                dgv.Columns[4].HeaderText = "Fecha de la devolución";
                dgv.Columns[5].HeaderText = "Cantidad del producto devolvido";
                dgv.Columns[6].HeaderText = "Monto de la devolución";
                dgv.Columns[7].HeaderText = "Motivo";
            }
        }
        public void CrearDevolucion(object sender, EventArgs e)
        {
            VistaDevoluciones NuevaDevolucion = new VistaDevoluciones();
            NuevaDevolucion.ShowDialog();
            RefrescarData();
        }
    }
}
