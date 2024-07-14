using System;
using System.Windows.Forms;
using AgroServicios.Vista.Login;
using AgroServicios.Vista.Cuentas;
using AgroServicios.Modelo.DAO;

namespace AgroServicios
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            //Verificación de Primer Uso
            DAOLogin Verificacion = new DAOLogin();
            //Llama al metodo "PrimerUso" para verificar que haya usuarios
            if(Verificacion.PrimerUso() == true)
            {

                Application.Run(new VistaLogin());
            }
            else
            {
                Application.Run(new CreateUser(accion: 1));
            }

        }
    }
}
