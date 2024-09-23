using AgroServicios.Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Modelo
{
    public class dbContext
    {
        public static SqlConnection getConnection()
        {

            try
            {
                //string server = "AYALA\\SQLEXPRESS";
                //string database = "Base_de_datos_Agro";
                //SqlConnection conexion = new SqlConnection($"Server = {server}; DataBase = {database}; Integrated Security = true");

                //SqlConnection conexion = new SqlConnection($"Server = {DTOdbContext.Server}; DataBase = {DTOdbContext.Database}; User Id = {DTOdbContext.User}; Password = {DTOdbContext.Password}");
                // Verificar si es autenticación integrada o SQL
                string connectionString;

                if (!string.IsNullOrWhiteSpace(DTOdbContext.User) && !string.IsNullOrWhiteSpace(DTOdbContext.Password))
                {
                    // Autenticación SQL
                    connectionString = $"Server={DTOdbContext.Server};Database={DTOdbContext.Database};User Id={DTOdbContext.User};Password={DTOdbContext.Password};";
                }
                else
                {
                    // Autenticación integrada (Windows)
                    connectionString = $"Server={DTOdbContext.Server};Database={DTOdbContext.Database};Integrated Security=True;";
                }

                SqlConnection conexion = new SqlConnection(connectionString);
                conexion.Open();
                return conexion;
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al conectar a la base de datos: {ex.Message}\n" +
                                "Por favor, verifique las credenciales o el acceso al sistema.",
                                "Error crítico",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return null;
            }
        }

        public static SqlConnection testConnection(string server, string database, string user = "", string password = "")
        {
            try
            {
                SqlConnection conexion;

                // Si el usuario y la contraseña están vacíos, usar autenticación de Windows (Seguridad Integrada)
                if (string.IsNullOrEmpty(user) && string.IsNullOrEmpty(password))
                {
                    conexion = new SqlConnection($"Server = {server}; DataBase = {database}; Integrated Security = true");
                }
                else
                {
                    // Si se proporcionan usuario y contraseña, usar autenticación de SQL Server
                    conexion = new SqlConnection($"Server = {server}; DataBase = {database}; User Id = {user}; Password = {password}");
                }

                // Abrir la conexión
                conexion.Open();
                return conexion;
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"{ex.Message} Código de error: EC-001 \nNo fue posible conectarse a la base de datos, verifique las credenciales, consulte el manual de usuario.", "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
