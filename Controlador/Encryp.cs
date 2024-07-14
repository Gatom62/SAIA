using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AgroServicios.Controlador
{
    internal class Encryp
    {
        public string Encriptar(string EncriptarContraseña)
        {
            SHA256 sHA256 = SHA256.Create();
            byte[] bytes = sHA256.ComputeHash(Encoding.UTF8.GetBytes(EncriptarContraseña));

            StringBuilder contructor = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                contructor.Append(bytes[i].ToString("x2"));
            }

            return contructor.ToString();
        }
    }
}
