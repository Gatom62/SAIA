using System;
using System.Windows.Forms;
using AgroServicios.Vista.Login;
using AgroServicios.Vista.Cuentas;
using AgroServicios.Modelo.DAO;
using AgroServicios.Controlador.Helper;

namespace AgroServicios
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CommonClasses commonClasses = new CommonClasses();
            commonClasses.LeerArchivoXMLConexion();

            // Verificación de Primer Uso
            DAOLogin Verificacion = new DAOLogin();

            if (Verificacion.PrimerUso() == 1)
            {
                Application.Run(new VistaLogin());
            }
            else
            {
                // Crear un formulario CreateUser
                CreateUser createUserForm = new CreateUser(accion: 1);

                // Mostrar CreateUser como un formulario modal
                createUserForm.ShowDialog();

                // Una vez que CreateUser se cierra, abrir VistaLogin
                Application.Run(new VistaLogin());
            }
        }
    }
}
