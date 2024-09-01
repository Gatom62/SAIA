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
                Command.CommandText = "SELECT idEmpleado, Usuario, idCategoria, Nombre ,picprofile FROM VistaUsuariosCategoriasV2 WHERE Usuario COLLATE SQL_Latin1_General_CP1_CS_AS = @username AND Contraseña COLLATE SQL_Latin1_General_CP1_CS_AS = @password";

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
                            StaticSession.Id = rd.GetInt32(0);
                            StaticSession.Username = rd.GetString(1); // Usuario
                            StaticSession.IdCategoria = rd.GetInt32(2); // idCategoria
                            StaticSession.Categorianame1 = rd.GetString(3); // Nombre de la categoría
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

        public int PrimerUso()
        {
            try
            {
                Command.Connection = getConnection();
                Command.CommandText = "SELECT * FROM Usuarios";
                object users = Command.ExecuteScalar();
                if (users != null)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo establecer conexón con la base de datos", "Error");
                return -1;
            }

        }

        public int VerificarAdmin()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @username AND Contraseña = @password";
                // Crear un comando SQL con la consulta y la conexión
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                // Limpia cualquier parámetro existente en el objeto Command
                Command.Parameters.Clear();
                // Asignar valores a los parámetros del query
                cmd.Parameters.AddWithValue("username", Username);
                cmd.Parameters.AddWithValue("password", Password);

                // Ejecutar el comando y obtener el resultado
                int respuesta = (int)cmd.ExecuteScalar();

                if (respuesta > 0)
                {
                    // El usuario fue autenticado correctamente
                    return 1;
                }
                else 
                {
                    return -1;
                }
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                Command.Connection.Close();
            }
        }
    }
}
