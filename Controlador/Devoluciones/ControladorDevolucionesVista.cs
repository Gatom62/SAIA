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
            //ObjVistaDevoluciones.cmsInformacion.Click += new EventHandler(InformaciónDevolución);
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
                dgv.Columns["ID de la devolución"].HeaderText = "Return ID";
                dgv.Columns["ID de la venta"].HeaderText = "Sale ID";
                dgv.Columns["Producto"].HeaderText = "Returned product";
                dgv.Columns["Nombre del cliente"].HeaderText = "Client Name";
                dgv.Columns["Fecha de la devolución"].HeaderText = "Date of return";
                dgv.Columns["Cantidad del producto devolvido"].HeaderText = "Quantity of the returned product";
                dgv.Columns["Monto de la devolución"].HeaderText = "Refund amount";
                dgv.Columns["Motivo"].HeaderText = "Reason for return";
            }
            else
            {
                dgv.Columns["ID de la devolución"].HeaderText = "ID de la devolución";
                dgv.Columns["Producto"].HeaderText = "Producto devolvido";
                dgv.Columns["Nombre del cliente"].HeaderText = "Nombre del cliente";
                dgv.Columns["Fecha de la devolución"].HeaderText = "Fecha de la devolución";
                dgv.Columns["Cantidad del producto devolvido"].HeaderText = "Cantidad del producto devolvido";
                dgv.Columns["Monto de la devolución"].HeaderText = "Monto de la devolución";
                dgv.Columns["Motivo"].HeaderText = "Motivo";
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
