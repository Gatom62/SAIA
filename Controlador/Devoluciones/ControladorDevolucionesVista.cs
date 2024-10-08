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
            if (ControladorIdioma.idioma == 1)
            {
                DataSet ds = dAOProductos1.ObtenerDevoluciones();
                ////Llenar DataGridView
                ObjVistaDevoluciones.dgvDevoluciones.DataSource = ds.Tables["viewDevoluciones"];
            }
            else 
            {
                DataSet ds = dAOProductos1.ObtenerDevolucionesEnglish();
                ////Llenar DataGridView
                ObjVistaDevoluciones.dgvDevoluciones.DataSource = ds.Tables["viewDevolucionesEnglish"];
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
