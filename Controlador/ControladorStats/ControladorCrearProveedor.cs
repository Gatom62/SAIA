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
using System.Text.RegularExpressions;

namespace AgroServicios.Controlador.ControladorStats
{
     class ControladorCrearProveedor
    {
        VistaAgregarProveedor ObjProveedor;
        bool verificacion;
        public ControladorCrearProveedor(VistaAgregarProveedor vista) 
        {
            ObjProveedor = vista;
            ObjProveedor.btnAgregarProv.Click += new EventHandler(AgregarProveedor);
        }
        public void AgregarProveedor (object sender, EventArgs e) 
        {
            if (string.IsNullOrWhiteSpace(ObjProveedor.txtNewFirstName.Text) ||
                string.IsNullOrWhiteSpace(ObjProveedor.txtNewID.Text) ||
                string.IsNullOrWhiteSpace(ObjProveedor.txtNewPhone.Text) ||
                string.IsNullOrWhiteSpace(ObjProveedor.txtNewCorreo.Text) ||
                string.IsNullOrWhiteSpace(ObjProveedor.txtNewCompany.Text)) 
                
            {
                MessageBox.Show("Todos los campos son obligatorios.",
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            // Validar el formato del número de teléfono
            if (!ValidarTelefono(ObjProveedor.txtNewPhone.Text))
            {
                MessageBox.Show("El formato del número de teléfono es incorrecto. Debe ser +XXX XXXX-XXXX o XXXX-XXXX.",
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            bool ValidarCorreo()
            {
                string email = ObjProveedor.txtNewCorreo.Text.Trim();

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

            DAOProveedores DAOinsert = new DAOProveedores();
            DAOinsert.Nombre1 = ObjProveedor.txtNewFirstName.Text.Trim();
            DAOinsert.DUI1 = ObjProveedor.txtNewID.Text.Trim();
            DAOinsert.Teléfono1 = ObjProveedor.txtNewPhone.Text.Trim();
            DAOinsert.Correo1 = ObjProveedor.txtNewCorreo.Text.Trim();
            DAOinsert.Empresa1 = ObjProveedor.txtNewCompany.Text.Trim();

            verificacion = ValidarCorreo();
            if (verificacion == true)
            {
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
        bool ValidarTelefono(string phoneNumber)
        {
            // Expresión regular para validar números de teléfono en los formatos: +XXX XXXX-XXXX o XXXX-XXXX
            string pattern = @"^(\+\d{1,3}\s\d{4}-\d{4}|\d{4}-\d{4})$";
            return Regex.IsMatch(phoneNumber, pattern);
        }

        bool ValidarCorreo()
        {
            string email = ObjProveedor.txtNewCorreo.Text.Trim();
            if (!(email.Contains("@")))
            {
                MessageBox.Show("Formato de correo invalido, verifica que contiene @.", "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
