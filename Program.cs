using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgroServicios.Vista.Login;
using AgroServicios.Modelo;
using System.Data.SqlClient;
using AgroServicios.Vista.MenuPrincipal;
using AgroServicios.Vista.Cuentas;

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
            Application.Run(new VistaLogin());

        }
    }
}
