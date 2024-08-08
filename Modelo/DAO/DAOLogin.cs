using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AgroServicios.Controlador.Helper;
using AgroServicios.Modelo.DTO;

namespace AgroServicios.Modelo.DAO
{
    internal class DAOLogin: DTOLogin
    {
        SqlCommand Command = new SqlCommand();
        public int Login()
        {
            // Inicia el bloque try para capturar excepciones
            try
            {
                // Asigna la conexión de la base de datos al objeto Command
                Command.Connection = getConnection();

                // Define la consulta SQL para seleccionar el usuario, idCategoria y nombre de la vista
                // Utiliza COLLATE para hacer que la comparación de Usuario y Contraseña sea sensible a mayúsculas y minúsculas
                Command.CommandText = "SELECT Usuario, idCategoria, Nombre, picprofile FROM VistaUsuariosCategorias WHERE Usuario COLLATE SQL_Latin1_General_CP1_CS_AS = @username AND Contraseña = @password COLLATE SQL_Latin1_General_CP1_CS_AS";

                // Limpia cualquier parámetro existente en el objeto Command
                Command.Parameters.Clear();

                // Agrega los parámetros de username y password al objeto Command
                Command.Parameters.AddWithValue("@username", Username);
                Command.Parameters.AddWithValue("@password", Password);

                // Ejecuta la consulta y obtiene los resultados usando un SqlDataReader
                using (SqlDataReader rd = Command.ExecuteReader())
                {
                    // Verifica si hay filas en los resultados
                    if (rd.HasRows)
                    {
                        // Lee los datos de cada fila
                        while (rd.Read())
                        {
                            // Asigna los valores leídos a las variables de sesión estáticas
                            StaticSession.Username = rd.GetString(0); // Usuario
                            StaticSession.IdCategoria = rd.GetInt32(1); // idCategoria
                            StaticSession.Categorianame1 = rd.GetString(2); // Nombre de la categoría
                            StaticSession.Picture = rd["picprofile"] as byte[]; // Imagen del usuario

                        }
                        // Devuelve 0 indicando que el usuario es correcto
                        return 0;
                    }
                    else
                    {
                        // Devuelve 1 indicando que el usuario o la contraseña son incorrectos
                        return 1;
                    }
                }
            }
            // Captura cualquier excepción que ocurra durante el proceso
            catch (Exception ex)
            {
                // Muestra un mensaje de error
                MessageBox.Show(ex.Message);
                // Devuelve -1 indicando que ocurrió un error
                return -1;
            }
            // Bloque finally que siempre se ejecuta al final, independientemente de si hubo una excepción o no
            finally
            {
                // Verifica si la conexión está abierta y la cierra
                if (Command.Connection != null && Command.Connection.State == System.Data.ConnectionState.Open)
                {
                    Command.Connection.Close();
                }
            }
        }

        public bool PrimerUso()
        {
            Command.Connection = getConnection();
            Command.CommandText = "SELECT * FROM Usuarios";
            object  users = Command.ExecuteScalar();
            if (users != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
