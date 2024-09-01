using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AgroServicios.Controlador.Clientes
{
    class ControladorUbdateCliente
    {
        VistaUbdateCliente ObjUbdateCliente;
        private int accion;
        bool berificacion;

        public ControladorUbdateCliente(VistaUbdateCliente Vista, int accion,int id, string Name, string telefono, string correo, string direccion, string dui)
        {
            ObjUbdateCliente = Vista;
            this.accion = accion;
            //Objupdate.Load += new EventHandler(InitialCharge);
            verificarAccion();
            ChargeValues(id, Name, telefono, correo, direccion, dui);

            ObjUbdateCliente.btnUbdateCliente.Click += new EventHandler(ActualizarRegistro);
        }

        public void verificarAccion()
        {
            if (accion == 2)
            {
                ObjUbdateCliente.btnUbdateCliente.Enabled = false;
                ObjUbdateCliente.txtUbdateNombreCliente.Enabled = false;
                ObjUbdateCliente.txtUbdateCorreoCliente.Enabled = false;
                ObjUbdateCliente.txtUbdateTelefonoCliente.Enabled = false;
                ObjUbdateCliente.txtUbdateDireccionCliente.Enabled = false;
                ObjUbdateCliente.maskedUbdateDui.Enabled = false;
            }
        }

        public void ChargeValues(int id, string Name, string telefono, string correo, string direccion, string dui)
        {
            ObjUbdateCliente.txtid.Text = id.ToString();
            ObjUbdateCliente.txtUbdateNombreCliente.Text = Name;
            ObjUbdateCliente.txtUbdateTelefonoCliente.Text = telefono;
            ObjUbdateCliente.txtUbdateCorreoCliente.Text = correo;
            ObjUbdateCliente.txtUbdateDireccionCliente.Text = direccion;
            ObjUbdateCliente.maskedUbdateDui.Text = dui;
        }

        private void ActualizarRegistro(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ObjUbdateCliente.txtUbdateNombreCliente.Text) ||
                string.IsNullOrWhiteSpace(ObjUbdateCliente.txtUbdateTelefonoCliente.Text) ||
                string.IsNullOrWhiteSpace(ObjUbdateCliente.txtUbdateCorreoCliente.Text) ||
                string.IsNullOrWhiteSpace(ObjUbdateCliente.txtUbdateDireccionCliente.Text) ||
                string.IsNullOrWhiteSpace(ObjUbdateCliente.maskedUbdateDui.Text))
            {
                MessageBox.Show("Se han dejado espacios sin llenar",
                                "Error de actualización",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            DAOClientes DaoUpdate = new DAOClientes();
            DaoUpdate.IdCliente = int.Parse(ObjUbdateCliente.txtid.Text.Trim());
            DaoUpdate.Nombre1 = ObjUbdateCliente.txtUbdateNombreCliente.Text.Trim();
            DaoUpdate.Telefono1 = ObjUbdateCliente.txtUbdateTelefonoCliente.Text.Trim();
            DaoUpdate.Correo1 = ObjUbdateCliente.txtUbdateCorreoCliente.Text.Trim();
            DaoUpdate.Dirreccion1 = ObjUbdateCliente.txtUbdateDireccionCliente.Text.Trim();
            DaoUpdate.DUI1 = ObjUbdateCliente.maskedUbdateDui.Text;
            int valorRetornado = DaoUpdate.ActualizarCliente();

            if (valorRetornado == 1)
            {
                MessageBox.Show("Los datos han sido actualizados exitosamente",
                                "Proceso completado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                ObjUbdateCliente.Close();
            }
            else
            {
                MessageBox.Show("Los datos no pudieron ser actualizados",
                                "Proceso interrumpido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
