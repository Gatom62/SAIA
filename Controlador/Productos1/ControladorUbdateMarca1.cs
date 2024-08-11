using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Cuentas;
using AgroServicios.Vista.Productos1;
using System;
using System.Collections.Generic;
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

        public ControladorUbdateMarca1(VistaUbdateMarca Vista, int accion, int id, string Name)
        {
            Objupdate = Vista;
            this.accion = accion;
            //Objupdate.Load += new EventHandler(InitialCharge);
            ChargeValues(id, Name);

            Objupdate.btnUbdateMarca.Click += new EventHandler(ActualizarMarca);
        }

        private void ActualizarMarca(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Objupdate.txtUbdateMarca.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.",
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            DAOProductos1 DaoUpdate = new DAOProductos1();

            DaoUpdate.IdMarca = int.Parse(Objupdate.txtid.Text.Trim());
            DaoUpdate.NombreMarca1 = Objupdate.txtUbdateMarca.Text.Trim();

            int valorRetornado = DaoUpdate.ActualizarMarca();

            if (valorRetornado == 1)
            {
                MessageBox.Show("Los datos han sido actualizados exitosamente",
                                "Proceso completado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                Objupdate.Close();
            }
            else
            {
                MessageBox.Show("Los datos no pudieron ser actualizados",
                                "Proceso interrumpido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        public void ChargeValues(int id, string Name)
        {
            Objupdate.txtid.Text = id.ToString();
            Objupdate.txtUbdateMarca.Text = Name;
        }
    }
}
