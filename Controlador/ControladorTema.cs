using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroServicios.Controlador
{
    internal class ControladorTema
    {
        private static bool isDarkMode;

        public static bool IsDarkMode { get => isDarkMode; set => isDarkMode = value; }
    }
}
