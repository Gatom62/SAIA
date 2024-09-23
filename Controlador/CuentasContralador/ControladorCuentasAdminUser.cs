using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Cuentas;
using AgroServicios.Vista.Notificación;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Controlador.CuentasContralador
{
    class ControladorCuentasAdminUser
    {
        VistaCuentasAdminUser ObjAdminUser;

        public ControladorCuentasAdminUser(VistaCuentasAdminUser Vista) 
        {
            ObjAdminUser = Vista;
            ObjAdminUser.Load += new EventHandler(LoadData);
            ObjAdminUser.ptbback.Click += new EventHandler(VolverForm);
            ObjAdminUser.cmsinfo.Click += new EventHandler(Infoempleado);
            ObjAdminUser.cmsRestablecer.Click += new EventHandler(RestEmpleado);
            ObjAdminUser.txtBuscarP.KeyPress += new KeyPressEventHandler(Search);
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
        private void LoadData(object sender, EventArgs e)
        {
            RefrescarData();
        }
        public void VolverForm(object sender, EventArgs e) 
        {
            ObjAdminUser.Close();
        }
        private void RefrescarData()
        {
            //Objeto de la clase DAOAdminUsuarios
            DAOAdminUsers objAdmin = new DAOAdminUsers();
            //Declarando nuevo DataSet para que obtenga los datos del metodo ObtenerPersonas
            DataSet ds = objAdmin.ObtenerPersonas();
            ////Llenar DataGridView
            ObjAdminUser.GriewEmpleados.DataSource = ds.Tables["VistaEmpleadosConRol"];
            // Traducir encabezados de las columnas

            ObjAdminUser.GriewEmpleados.Columns["Image"].Visible = false;
            ObjAdminUser.GriewEmpleados.Columns["ID del empleado"].Visible = false;
            ObjAdminUser.cmsEliminar.Visible = false;
            ObjAdminUser.cmsPreguntas.Visible = false;
            ObjAdminUser.cmsUpdate.Visible = false;
        }

        private void Infoempleado(object sender, EventArgs e)
        {
            if (ObjAdminUser.GriewEmpleados.CurrentRow == null)
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", "No se a seleccionado a ningun empleado", Properties.Resources.MensajeWarning);
                return; // Salir del método si no hay ninguna fila seleccionada
            }

            int pos = ObjAdminUser.GriewEmpleados.CurrentRow.Index;
            int id;
            string Name, phone, email, dni, address, user;
            DateTime birthday;
            byte[] img;

            user = ObjAdminUser.GriewEmpleados[7, pos].Value.ToString();
            id = int.Parse(ObjAdminUser.GriewEmpleados[0, pos].Value.ToString());
            Name = ObjAdminUser.GriewEmpleados[1, pos].Value.ToString();
            birthday = DateTime.Parse(ObjAdminUser.GriewEmpleados[2, pos].Value.ToString());
            phone = ObjAdminUser.GriewEmpleados[3, pos].Value.ToString();
            email = ObjAdminUser.GriewEmpleados[4, pos].Value.ToString();
            dni = ObjAdminUser.GriewEmpleados[5, pos].Value.ToString();
            address = ObjAdminUser.GriewEmpleados[6, pos].Value.ToString();
            img = (byte[])ObjAdminUser.GriewEmpleados[9, pos].Value;

            VistaUpdateEmpleados vistaInfo = new VistaUpdateEmpleados(2, id, Name, phone, email, dni, address, birthday, img, user);
            vistaInfo.ShowDialog();
            RefrescarData();
        }

        private void RestEmpleado(object sender, EventArgs e)
        {
            if (ObjAdminUser.GriewEmpleados.CurrentRow == null)
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", "No se a seleccionado a ningun empleado", Properties.Resources.MensajeWarning);
                return; // Salir del método si no hay ninguna fila seleccionada
            }

            int pos = ObjAdminUser.GriewEmpleados.CurrentRow.Index;
            string usuario, role;

            usuario = ObjAdminUser.GriewEmpleados[7, pos].Value.ToString();
            role = ObjAdminUser.GriewEmpleados[8, pos].Value.ToString();

            VistaRestablecerPassword vistaRestablecer = new VistaRestablecerPassword(usuario, role);
            vistaRestablecer.ShowDialog();
            RefrescarData();
        }

        private void Search(object sender, KeyPressEventArgs e)
        {
            // Verifica que la tecla presionada sea Enter antes de buscar
            if (e.KeyChar == (char)Keys.Enter)
            {
                BuscarEmpleado();
                e.Handled = true;
            }
        }

        private void BuscarEmpleado()
        {
            DAOAdminUsers objAdmin = new DAOAdminUsers();
            //Declarando nuevo DataSet para que obtenga los datos del metodo ObtenerPersonas
            DataSet ds = objAdmin.BuscarPersonas(ObjAdminUser.txtBuscarP.Text.Trim());
            //Llenar DataGridView
            ObjAdminUser.GriewEmpleados.DataSource = ds.Tables["VistaEmpleadosConRol"];
        }
    }
}
