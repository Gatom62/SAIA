using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Estadisticas;
using System;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AgroServicios.Controlador.ControladorStats
{
        class ControladorActualizarProveedor
        {
            VistaActualizarProveedor Objupdate;
            private int accion;
            bool verificacion;
            private string Marca;
        

            public ControladorActualizarProveedor(VistaActualizarProveedor Vista, int accion, int id, string Name, string phone, string email, string Dui, string marca)
            {
                this.Marca = marca;
                Objupdate = Vista;
                this.accion = accion;
                ChargeValues(id, Name, Dui, phone, email);
                Objupdate.Load += CargaInicial;
                Objupdate.btnUpdateProveedor.Click += new EventHandler(ActualizarRegistro);
            }

        public void CargaInicial(object sender, EventArgs e)
        {
            DAOProductos1 objmarcas = new DAOProductos1();
            //Declarando nuevo DataSet para que obtenga los datos del metodo LlenarCombo
            DataSet ds = objmarcas.LlenarCombo();
            //Llenar combobox tbRole
            Objupdate.cmbMarca.DataSource = ds.Tables["Marcas"];
            Objupdate.cmbMarca.ValueMember = "idMarca";
            Objupdate.cmbMarca.DisplayMember = "NombreMarca";

            Objupdate.cmbMarca.Text = Marca;
        }
        private void ActualizarRegistro(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Objupdate.txtUpdateNombre.Text) ||
                string.IsNullOrWhiteSpace(Objupdate.txtUpdateID.Text) ||
                string.IsNullOrWhiteSpace(Objupdate.txtUpdatePhone.Text) ||
                string.IsNullOrWhiteSpace(Objupdate.txtUpdateCorreo.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.",
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (!ValidarTelefono(Objupdate.txtUpdatePhone.Text))
            {
                MessageBox.Show("El formato del número de teléfono es incorrecto. Debe ser +XXX XXXX-XXXX o XXXX-XXXX.",
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            DAOProveedores DaoUpdate = new DAOProveedores();

            DaoUpdate.IdProveedor = int.Parse(Objupdate.txtid.Text.Trim());
            DaoUpdate.Nombre1 = Objupdate.txtUpdateNombre.Text.Trim();
            DaoUpdate.DUI1 = Objupdate.txtUpdateID.Text;
            DaoUpdate.Teléfono1 = Objupdate.txtUpdatePhone.Text.Trim();
            DaoUpdate.Correo1 = Objupdate.txtUpdateCorreo.Text.Trim();
            DaoUpdate.Marca1 = int.Parse(Objupdate.cmbMarca.SelectedValue.ToString());

            int valorRetornado = DaoUpdate.ActualizarProveedor();
            verificacion = ValidarCorreo();

            if (verificacion == true) 
            {
                int ValorRetornado = DaoUpdate.ActualizarProveedor();

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
        bool ValidarTelefono(string PhoneNumber)
        {
            string pattern = @"^(\+\d{1,3}\s\d{4}-\d{4}|\d{4}-\d{4})$";
            return Regex.IsMatch(PhoneNumber, pattern);
        }

        bool ValidarCorreo()
        {
            string email = Objupdate.txtUpdateCorreo.Text.Trim();

            if (!(email.Contains("@"))) 
            {
                MessageBox.Show("Formato de correo invalido, verifica que contiene @.", "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (!(email.Contains(".com")))
            {
                MessageBox.Show("Formato de correo invalido, verifica que contiene com.", "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }


        public void ChargeValues(int id, string Name, string Dui, string phone, string email)
            {
                Objupdate.txtid.Text = id.ToString();
                Objupdate.txtUpdateNombre.Text = Name;
                Objupdate.txtUpdateID.Text = Dui;
                Objupdate.txtUpdatePhone.Text = phone;
                Objupdate.txtUpdateCorreo.Text = email;
            }

        }
}
