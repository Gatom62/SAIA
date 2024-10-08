using AgroServicios.Modelo.DTO;
using AgroServicios.Vista.Login;
using AgroServicios.Vista.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AgroServicios.Controlador.Helper
{
    public class CommonClasses
    {
        /// <summary>
        /// Método para crear bordes redondos en el formulario
        /// </summary>
        /// <param name="nLeftRect"></param>
        /// <param name="nTopRect"></param>
        /// <param name="nRightRect"></param>
        /// <param name="nBottomRect"></param>
        /// <param name="nWidthEllipse"></param>
        /// <param name="nHeightEllipse"></param>
        /// <returns></returns>
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        public bool TieneAlMenos8Caracteres(string contrasena)
        {
            return contrasena.Length >= 8;
        }
        public bool ContieneAlMenosUnNumero(string contrasena)
        {
            return contrasena.Any(char.IsDigit);
        }
        public bool ContieneAlMenosUnaMayuscula(string contrasena)
        {
            return contrasena.Any(char.IsUpper);
        }
        public bool ContieneAlMenosUnaMinuscula(string contrasena)
        {
            return contrasena.Any(char.IsLower);
        }
        public bool ContieneAlMenosUnSimbolo(string contrasena)
        {
            string simbolos = "@$#_";
            return contrasena.Any(simbolo => simbolos.Contains(simbolo));
        }
        public bool EsValida(string contrasena)
        {
            return TieneAlMenos8Caracteres(contrasena) &&
                   ContieneAlMenosUnNumero(contrasena) &&
                   ContieneAlMenosUnaMayuscula(contrasena) &&
                   ContieneAlMenosUnaMinuscula(contrasena) &&
                   ContieneAlMenosUnSimbolo(contrasena);
        }

        public void LeerArchivoXMLConexion()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory().ToString(), "config_server.xml");
            if (File.Exists(path))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);

                XmlNode root = doc.DocumentElement;
                XmlNode serverNode = root.SelectSingleNode("Server/text()");
                XmlNode databaseNode = root.SelectSingleNode("Database/text()");
                XmlNode sqlAuthNode = root.SelectSingleNode("SqlAuth/text()");
                XmlNode sqlPassNode = root.SelectSingleNode("SqlPass/text()");

                string serverCode = serverNode?.Value ?? string.Empty;
                string databaseCode = databaseNode?.Value ?? string.Empty;
                string userCode = sqlAuthNode?.Value ?? string.Empty; // Validación para que no dé error si es nulo
                string passwordCode = sqlPassNode?.Value ?? string.Empty; // Validación para que no dé error si es nulo

                DTOdbContext.Server = DescifrarCadena(serverCode);
                DTOdbContext.Database = DescifrarCadena(databaseCode);
                DTOdbContext.User = !string.IsNullOrEmpty(userCode) ? DescifrarCadena(userCode) : string.Empty; // Si no hay usuario, lo dejamos vacío
                DTOdbContext.Password = !string.IsNullOrEmpty(passwordCode) ? DescifrarCadena(passwordCode) : string.Empty; // Si no hay contraseña, lo dejamos vacío

                //MessageBox.Show($"{DTOdbContext.Server}, {DTOdbContext.Database}, {DTOdbContext.User}, {DTOdbContext.Password}");
            }
            else
            {
                // Si no existe el archivo, abrir el formulario de configuración
                ViewAdminConnection openForm = new ViewAdminConnection(1);
                openForm.ShowDialog();
            }
        }

        public string DescifrarCadena(string cadenaCode)
        {
            try
            {
                byte[] decodedBytes = Convert.FromBase64String(cadenaCode);
                // Convertir los bytes a una cadena
                string decodedString = Encoding.UTF8.GetString(decodedBytes);
                return decodedString.ToString();
            }
            catch (Exception ex)
            {
                if (ControladorIdioma.idioma == 1)
                {
                    return $"Error decrypting: {ex.Message}";
                }
                else 
                {
                    return $"Error al descifrar: {ex.Message}";
                }
            }
        }
    }
}

