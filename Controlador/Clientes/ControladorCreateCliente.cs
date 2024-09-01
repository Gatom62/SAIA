using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Controlador.Clientes
{
    class ControladorCreateCliente
    {
        VistaCreateCliente ObjCreateCliente;
        private int accion;
        private int marca;
        bool verificacion;
        /// <summary>
        /// Constructor para inserción de datos
        /// </summary>
        /// <param name="Vista"></param>
        /// <param name="accion"> INSERCIÓN </param>

        public ControladorCreateCliente(VistaCreateCliente Vista, int accion)
        {
            ObjCreateCliente = Vista;
            this.accion = accion;
            ObjCreateCliente.btnAgregarCliente.Click += new EventHandler(NuevoRegistro);
        }

        public void NuevoRegistro(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ObjCreateCliente.txtNombreCliente.Text) ||
               string.IsNullOrWhiteSpace(ObjCreateCliente.txtTelefonoCliente.Text) ||
               string.IsNullOrWhiteSpace(ObjCreateCliente.txtCorreoCliente.Text) ||
               string.IsNullOrWhiteSpace(ObjCreateCliente.txtDireccionCliente.Text) ||
               string.IsNullOrWhiteSpace(ObjCreateCliente.maskedDui.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.",
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (!ValidarLetra(ObjCreateCliente.txtNombreCliente.Text)) 
            {
                MessageBox.Show("No se pude ingresar numeros en el nombre del cliente", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Validar que el nombre del cliente no exceda 65 caracteres
            if (!ValidarNombre(ObjCreateCliente.txtNombreCliente.Text))
            {
                MessageBox.Show("El nombre del cliente no debe exceder los 65 caracteres.",
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            // Validar que la direccion del cliente no exeda los 250 caracteres
            if (!ValidarDireccion(ObjCreateCliente.txtDireccionCliente.Text))
            {
                MessageBox.Show("El nombre del cliente no debe exceder los 250 caracteres.",
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            // Validar el formato del número de teléfono
            if (!ValidarTelefono(ObjCreateCliente.txtTelefonoCliente.Text))
            {
                MessageBox.Show("El formato del número de teléfono es incorrecto. Debe ser +XXX XXXX-XXXX o XXXX-XXXX.",
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            // Validar que el telefono del cliente no exceda 25 caracteres
            if (!ValidarTelefonoCantidad(ObjCreateCliente.txtTelefonoCliente.Text))
            {
                MessageBox.Show("El nombre del cliente no debe exceder los 25 caracteres.",
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            // Validar que el coreo del cliente no exceda los 250 caracteres
            if (!ValidarCorreoCantidad(ObjCreateCliente.txtTelefonoCliente.Text))
            {
                MessageBox.Show("El nombre del cliente no debe exceder los 250 caracteres.",
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            // Validar que el DUI contenga solo números
            if (!ValidarDUI(ObjCreateCliente.maskedDui.Text))
            {
                MessageBox.Show("El DUI solo debe contener números.",
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            DAOClientes DaoInsert = new DAOClientes();
            // Asignar los valores a las propiedades de DaoInsert
            DaoInsert.Nombre1 = ObjCreateCliente.txtNombreCliente.Text.Trim();
            DaoInsert.Telefono1 = ObjCreateCliente.txtTelefonoCliente.Text.Trim();
            DaoInsert.Correo1 = ObjCreateCliente.txtCorreoCliente.Text.Trim();
            DaoInsert.Dirreccion1 = ObjCreateCliente.txtDireccionCliente.Text.Trim();
            DaoInsert.DUI1 = ObjCreateCliente.maskedDui.Text;
            verificacion = ValidarCorreo();
            if (verificacion == true)
            {
                int valorRetornado = DaoInsert.RetgistraCliente();
                if (valorRetornado > 0)
                {
                    MessageBox.Show("Los datos han sido registrados exitosamente",
                                    "Proceso completado",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    ObjCreateCliente.Close();
                }
                else
                {
                    MessageBox.Show("Los datos no pudieron ser registrados",
                                    "Proceso interrumpido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
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
                string email = ObjCreateCliente.txtCorreoCliente.Text.Trim();
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

            // Método para validar que el nombre del cliente no exceda los 65 caracteres
            bool ValidarNombre(string nombre)
            {
                return nombre.Length <= 65;
            }

            // Método para validar la direccion del cliente la cual no exceda los 250 caracteres
            bool ValidarDireccion(string nombre)
            {
                return nombre.Length <= 250;
            }

            // Método para validar que el telefono del cliente no exceda los 20 caracteres
            bool ValidarTelefonoCantidad(string nombre)
            {
                return nombre.Length <= 25;
            }

            // Método para validar que el correo del cliente no exceda los 250 caracteres
            bool ValidarCorreoCantidad(string nombre)
            {
                return nombre.Length <= 250;
            }

            bool ValidarDUI(string dui)
            {
                // Aquí asumimos que el DUI debe contener solo dígitos (sin guiones o espacios)
                // Se puede ajustar según el formato requerido, por ejemplo, permitir un guion
                string pattern = @"^\d+-?\d*$"; // Solo dígitos
                return Regex.IsMatch(dui, pattern);
            }
        }
    }
}
