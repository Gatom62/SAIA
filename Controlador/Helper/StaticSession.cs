using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroServicios.Controlador.Helper
{
    internal class StaticSession
    {
        private static int id;
        private static string username = string.Empty;
        private static int idCategoria = 0;
        private static string Categorianame = string.Empty;
        private static byte[] picture = null;

        public static string Username { get => username; set => username = value; }
        public static int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public static string Categorianame1 { get => Categorianame; set => Categorianame = value; }
        public static byte[] Picture { get => picture; set => picture = value; }
        public static int Id { get => id; set => id = value; }
    }
}
