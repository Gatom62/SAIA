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
            ObjProveedor.Load += CargaInicial;
        }

        public void CargaInicial(object sender, EventArgs e)
        {
            DAOProductos1 objmarcas = new DAOProductos1();
            //Declarando nuevo DataSet para que obtenga los datos del metodo LlenarCombo
            DataSet ds = objmarcas.LlenarCombo();
            //Llenar combobox tbRole
            ObjProveedor.cmbMarca.DataSource = ds.Tables["Marcas"];
            ObjProveedor.cmbMarca.ValueMember = "idMarca";
            ObjProveedor.cmbMarca.DisplayMember = "NombreMarca";
        }

        public void AgregarProveedor (object sender, EventArgs e) 
        {
            if (string.IsNullOrWhiteSpace(ObjProveedor.txtNewFirstName.Text) ||
                string.IsNullOrWhiteSpace(ObjProveedor.maskedDui.Text) ||
                string.IsNullOrWhiteSpace(ObjProveedor.txtNewPhone.Text) ||
                string.IsNullOrWhiteSpace(ObjProveedor.txtNewCorreo.Text))
                
            {
                MessageBox.Show("Todos los campos son obligatorios.",
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (!ValidarLetra(ObjProveedor.txtNewFirstName.Text))
            {
                MessageBox.Show("No se pude ingresar numeros en el nombre del proveedor", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Validar que el nombre del proveedor no exceda 65 caracteres
            if (!ValidarNombre(ObjProveedor.txtNewFirstName.Text))
            {
                MessageBox.Show("El nombre del proveedor no debe exceder los 65 caracteres.",
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

            // Validar que el telefono del proveedor no exceda 25 caracteres
            if (!ValidarTelefonoCantidad(ObjProveedor.txtNewPhone.Text))
            {
                MessageBox.Show("El telefono del proveedor no debe exceder los 25 caracteres.",
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            // Validar que el DUI contenga solo números
            if (!ValidarDUI(ObjProveedor.maskedDui.Text))
            {
                MessageBox.Show("El DUI solo debe contener números.",
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            // Validar que el correo del provedor no exceda 75 caracteres
            if (!ValidarCorreoCantidad(ObjProveedor.txtNewCorreo.Text))
            {
                MessageBox.Show("El correo del proveedor no debe exceder los 75 caracteres.",
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            DAOProveedores DAOinsert = new DAOProveedores();
            DAOinsert.Nombre1 = ObjProveedor.txtNewFirstName.Text.Trim();
            DAOinsert.DUI1 = ObjProveedor.maskedDui.Text.Trim();
            DAOinsert.Teléfono1 = ObjProveedor.txtNewPhone.Text.Trim();
            DAOinsert.Correo1 = ObjProveedor.txtNewCorreo.Text.Trim();
            DAOinsert.Marca1 = int.Parse(ObjProveedor.cmbMarca.SelectedValue.ToString());

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

        // Método que valida si un carácter es una letra
        bool ValidarLetra(string texto)
        {
            foreach (char c in texto)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c)) // Permite espacios
                {
                    return false; // Si encuentra un carácter no válido, retorna false
                }
            }
            return true; // Si todos los caracteres son válidos, retorna true
        }

        // Método para validar que el nombre del proveedor no exceda los 65 caracteres
        bool ValidarNombre(string nombre)
        {
            return nombre.Length <= 65;
        }
        bool ValidarDUI(string dui)
        {
            // Aquí asumimos que el DUI debe contener solo dígitos (sin guiones o espacios)
            // Se puede ajustar según el formato requerido, por ejemplo, permitir un guion
            string pattern = @"^\d+-?\d*$"; // Solo dígitos
            return Regex.IsMatch(dui, pattern);
        }

        // Método para validar que el nombre del proceedor no exceda los 25 caracteres
        bool ValidarTelefonoCantidad(string nombre)
        {
            return nombre.Length <= 25;
        }

        // Método para validar que el correo del proveedor no exceda los 75 caracteres
        bool ValidarCorreoCantidad(string nombre)
        {
            return nombre.Length <= 75;
        }
    }
}
