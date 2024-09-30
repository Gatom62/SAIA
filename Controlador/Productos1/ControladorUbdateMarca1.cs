using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Cuentas;
using AgroServicios.Vista.Login;
using AgroServicios.Vista.Notificación;
using AgroServicios.Vista.Productos1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Controlador.Productos1
{
    class ControladorUbdateMarca1
    {
        VistaUbdateMarca Objupdate;
        private int accion;
        private string role;
        //Vamos aver si se puede
        public ControladorUbdateMarca1(VistaUbdateMarca Vista, int accion, int id, string Name)
        {
            Objupdate = Vista;
            this.accion = accion;
            //Objupdate.Load += new EventHandler(InitialCharge);
            ChargeValues(id, Name);

            Objupdate.btnUbdateMarca.Click += new EventHandler(ActualizarMarca);
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

        private void ActualizarMarca(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Objupdate.txtUbdateMarca.Text))
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", "Hay campos vacios", Properties.Resources.MensajeWarning);
                return;
            }

            // Validar que el nombre del producto no exceda 15 caracteres
            if (!ValidarNombre(Objupdate.txtUbdateMarca.Text))
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error", "Hay mas de 15 caragteres en el nombre", Properties.Resources.MensajeWarning);
                return;
            }

            DAOProductos1 DaoUpdate = new DAOProductos1();

            DaoUpdate.IdMarca = int.Parse(Objupdate.txtid.Text.Trim());
            DaoUpdate.NombreMarca1 = Objupdate.txtUbdateMarca.Text.Trim();

            int valorRetornado = DaoUpdate.ActualizarMarca();

            if (valorRetornado == 1)
            {
                MandarValoresAlerta(Color.LightGreen, Color.SeaGreen, "Proceso realizado", "La marca se actualizo correctamente", Properties.Resources.comprobado);
                VistaLogin backForm = new VistaLogin();

                Objupdate.Close();
            }
            else
            {
                MessageBoxP(Color.Red, Color.DarkRed, "Error", "Verifique que los datos no esten duplicados", Properties.Resources.ErrorIcono);
            }

            // Método para validar que el nombre de la marca no exceda los 15 caracteres
            bool ValidarNombre(string nombre)
            {
                return nombre.Length <= 15;
            }
        }

        public void ChargeValues(int id, string Name)
        {
            Objupdate.txtid.Text = id.ToString();
            Objupdate.txtUbdateMarca.Text = Name;
        }
    }
}
