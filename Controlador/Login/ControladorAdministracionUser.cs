using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Cuentas;
using AgroServicios.Vista.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Controlador.Login
{
    class ControladorAdministracionUser
    {
        VistaMetodoRecuperacionAdminUser ObjAdminUser;
        public ControladorAdministracionUser(VistaMetodoRecuperacionAdminUser VistaAdminUser) 
        {
            ObjAdminUser = VistaAdminUser;
            VistaAdminUser.ptbback.Click += VolverForm;
            VistaAdminUser.btnVerificar.Click += new EventHandler(VerificarDatos);
        }

        private void VolverForm(object sender, EventArgs e)
        {
            // Cierra la vista actual
            ObjAdminUser.Close();
        }

        private void VerificarDatos(object sender, EventArgs e) 
        {
            if (string.IsNullOrEmpty(ObjAdminUser.txtUser.Text.ToString())||
                string.IsNullOrEmpty(ObjAdminUser.txtContraseña.Text.ToString())) 
            {
                MessageBox.Show("Se encontraron espacios en blanco, por favor ingresar los datos correctos en cada espacio", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar si el campo txtUser contiene solo letras
            if (!IsOnlyLetters(ObjAdminUser.txtUser.Text))
            {
                MessageBox.Show("El nombre de usuario solo debe contener letras", "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DAOLogin verificar = new DAOLogin();
            Encryp ObjEncriptar = new Encryp();
            verificar.Username = ObjAdminUser.txtUser.Text;
            verificar.Password = ObjEncriptar.Encriptar(ObjAdminUser.txtContraseña.Text);
            int respuesta = verificar.VerificarAdmin();
            if (respuesta == 1)
            {
                MessageBox.Show("Datos correctos, bien echo pipe", "Siii", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarCuentas();

            }
            else if (respuesta == -1) 
            {
                MessageBox.Show("Datos son incorrectos, Volve a intentar", "Nooo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                MessageBox.Show("Erorr de conexcion, Erorr de conexcion", "Nooo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Método auxiliar para verificar si el texto contiene solo letras
        private bool IsOnlyLetters(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsLetter(c))
                {
                    return false; // Si encuentra un carácter que no es una letra, retorna falso
                }
            }
            return true; // Si solo contiene letras, retorna verdadero
        }

        private void MostrarCuentas() 
        {
            VistaCuentasAdminUser vistaCuentas = new VistaCuentasAdminUser();
            vistaCuentas.ShowDialog();
        }
    }
}
