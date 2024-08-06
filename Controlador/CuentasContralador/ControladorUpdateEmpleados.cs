using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Cuentas;
using System;
using System.Data;
using System.Windows.Forms;

namespace AgroServicios.Controlador.CuentasContralador
{
    class ControladorUpdateEmpleados
    {
        VistaUpdateEmpleados Objupdate;
        private int accion;
        private string role;
        bool verificacion;

        public ControladorUpdateEmpleados(VistaUpdateEmpleados Vista, int accion, int id, string Name, string phone, string email, string dni, string address, DateTime birthday)
        {
            Objupdate = Vista;
            this.accion = accion;
            //Objupdate.Load += new EventHandler(InitialCharge);
            verificarAccion();
            ChargeValues(id, Name, phone, email, dni, address, birthday);

            Objupdate.btnUpdateEmpleado.Click += new EventHandler(ActualizarRegistro);
        }

        //public void InitialCharge(object sender, EventArgs e)
        //{
        //    DAOAdminUsers objAdmin = new DAOAdminUsers();
        //    DataSet ds = objAdmin.LlenarCombo();

        //    Objupdate.DropRoleUpdate.DataSource = ds.Tables["Categorias"];
        //    Objupdate.DropRoleUpdate.ValueMember = "idCategoria";
        //    Objupdate.DropRoleUpdate.DisplayMember = "Nombre";

        //    if (accion == 2)
        //    {
        //        Objupdate.DropRoleUpdate.Text = role;
        //    }
        //}
        public void verificarAccion()
        {
            if (accion == 2)
            {
                Objupdate.bunifuLabel1.Text = Spanish.LabelFicha;

                Objupdate.btnUpdateEmpleado.Visible = false;
                if(ControladorIdioma.idioma == 1)
                {
                    Objupdate.bunifuLabel1.Text = Ingles.LabelFicha;
                }
           
                Objupdate.txtUpdateNombre.Enabled = false;
                Objupdate.txtUpdateCorreo.Enabled = false;
                Objupdate.txtUpdateDireccion.Enabled = false;
                Objupdate.txtUpdatePhone.Enabled = false;
                Objupdate.maskedDuiUpdate.Enabled = false;
                Objupdate.PickerBirthUpdate.Enabled = false;
            }
            if(accion == 1)
            {
                if(ControladorIdioma.idioma == 1)
                {
                    Objupdate.bunifuLabel1.Text = Ingles.tituloactualizar;
                }
            }
        }
        private void ActualizarRegistro(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Objupdate.txtUpdateNombre.Text) ||
                string.IsNullOrWhiteSpace(Objupdate.txtUpdatePhone.Text) ||
                string.IsNullOrWhiteSpace(Objupdate.txtUpdateCorreo.Text) ||
                string.IsNullOrWhiteSpace(Objupdate.maskedDuiUpdate.Text) ||
                string.IsNullOrWhiteSpace(Objupdate.txtUpdateDireccion.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.",
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            DateTime fechaNacimiento = Objupdate.PickerBirthUpdate.Value.Date;
            DateTime fechaActual = DateTime.Today;
            int edad = fechaActual.Year - fechaNacimiento.Year;
            if (fechaNacimiento > fechaActual.AddYears(-edad)) edad--;

            if (edad < 18)
            {
                MessageBox.Show("La fecha de nacimiento debe ser mayor de 18 años.",
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            DAOAdminUsers DaoUpdate = new DAOAdminUsers();

            DaoUpdate.IdEmpleado = int.Parse(Objupdate.txtid.Text.Trim());
            DaoUpdate.Nombre1 = Objupdate.txtUpdateNombre.Text.Trim();
            DaoUpdate.FechaDeNacimiento1 = Objupdate.PickerBirthUpdate.Value;
            DaoUpdate.Telefono1 = Objupdate.txtUpdatePhone.Text.Trim();
            DaoUpdate.Correo1 = Objupdate.txtUpdateCorreo.Text.Trim();
            DaoUpdate.DUI1 = Objupdate.maskedDuiUpdate.Text;
            DaoUpdate.Direccion1 = Objupdate.txtUpdateDireccion.Text.Trim();

            verificacion = ValidarCorreo();
            if (verificacion == true)
            {
                int valorRetornado = DaoUpdate.ActualizarEmpleado();

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
        }

        public void ChargeValues(int id, string Name, string phone, string email, string dni, string address, DateTime birthday)
        {
            Objupdate.txtid.Text = id.ToString();
            Objupdate.txtUpdateNombre.Text = Name;
            Objupdate.txtUpdatePhone.Text = phone;
            Objupdate.txtUpdateCorreo.Text = email;
            Objupdate.maskedDuiUpdate.Text = dni;
            Objupdate.txtUpdateDireccion.Text = address;
            Objupdate.PickerBirthUpdate.Value = birthday;
        }

        bool ValidarCorreo()
        {
            string email = Objupdate.txtUpdateCorreo.Text.Trim();
            if (!(email.Contains("@")))
            {
                MessageBox.Show("Formato de correo invalido, verifica que contiene @.", "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
