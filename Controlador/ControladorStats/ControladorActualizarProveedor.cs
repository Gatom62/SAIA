using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Estadisticas;
using System;
using System.Data;
using System.Windows.Forms;

namespace AgroServicios.Controlador.ControladorStats
{
        class ControladorActualizarProveedor
        {
            VistaActualizarProveedor Objupdate;
            private int accion;
            private string role;

            public ControladorActualizarProveedor(VistaActualizarProveedor Vista, int accion, int id, string Name, string phone, string email, string Dui, string Company)
            {
                Objupdate = Vista;
                this.accion = accion;
                //Objupdate.Load += new EventHandler(InitialCharge);
                ChargeValues(id, Name, Dui, phone, email, Company);

                Objupdate.btnUpdateProveedor.Click += new EventHandler(ActualizarRegistro);
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

            private void ActualizarRegistro(object sender, EventArgs e)
            {
                /*if (string.IsNullOrWhiteSpace(Objupdate.txtUpdateNombre.Text) ||
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
                */


                DAOProveedores DaoUpdate = new DAOProveedores();

                DaoUpdate.IdProveedor = int.Parse(Objupdate.txtid.Text.Trim());
                DaoUpdate.Nombre1 = Objupdate.txtUpdateNombre.Text.Trim();
                DaoUpdate.DUI1 = Objupdate.txtUpdateID.Text;
                DaoUpdate.Teléfono1 = Objupdate.txtUpdatePhone.Text.Trim();
                DaoUpdate.Correo1 = Objupdate.txtUpdateCorreo.Text.Trim();
                DaoUpdate.Empresa1 = Objupdate.txtUpdateCompany.Text.Trim();

                int valorRetornado = DaoUpdate.ActualizarProveedor();

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

            public void ChargeValues(int id, string Name, string Dui, string phone, string email, string Company)
            {
                Objupdate.txtid.Text = id.ToString();
                Objupdate.txtUpdateNombre.Text = Name;
                Objupdate.txtUpdateID.Text = Dui;
                Objupdate.txtUpdatePhone.Text = phone;
                Objupdate.txtUpdateCorreo.Text = email;
                Objupdate.txtUpdateCompany.Text = Company;
            }

        }
    }
