using AgroServicios.Vista.Estadisticas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgroServicios.Modelo.DAO;
using System.Windows.Forms;
using System.Data;

namespace AgroServicios.Controlador.ControladorStats
{
    internal class ControladorCrearProveedor
    {
        VistaAgregarProveedor ObjProveedor;
        public ControladorCrearProveedor(VistaAgregarProveedor vista) 
        {
            ObjProveedor = vista;
            ObjProveedor.btnAgregarProv.Click += new EventHandler(AgregarProveedor);
        }
        public void AgregarProveedor (object sender, EventArgs e) 
        {
            DAOProveedores DAOinsert = new DAOProveedores();

            DAOinsert.Nombre1 = ObjProveedor.txtNewFirstName.Text.Trim();
            DAOinsert.DUI1 = ObjProveedor.txtNewID.Text.Trim();
            DAOinsert.Teléfono1 = ObjProveedor.txtNewPhone.Text.Trim();
            DAOinsert.Correo1 = ObjProveedor.txtNewCorreo.Text.Trim();
            DAOinsert.Empresa1 = ObjProveedor.txtNewCompany.Text.Trim();
            int valorRetornado = DAOinsert.RegistrarProveedor();
                if (valorRetornado == 1)
                {
                    MessageBox.Show("Los datos han sido registrados exitosamente",
                                "Proceso completado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                    ObjProveedor.Close();

                }
                else
                {
                    MessageBox.Show("Los datos no pudieron ser registrados",
                                "Proceso interrumpido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                }
        }
    }
}
