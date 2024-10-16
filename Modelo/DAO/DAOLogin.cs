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
            try
            {
                Command.Connection = getConnection();
                Command.CommandText = "SELECT idEmpleado, Usuario, idCategoria, Nombre, picprofile, Contraseña FROM VistaUsuariosCategoriasV2 WHERE Usuario COLLATE SQL_Latin1_General_CP1_CS_AS = @username AND Contraseña COLLATE SQL_Latin1_General_CP1_CS_AS = @password";
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@username", Username);
                Command.Parameters.AddWithValue("@password", Password);

                using (SqlDataReader rd = Command.ExecuteReader())
                {
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            StaticSession.Id = rd.GetInt32(0);
                            StaticSession.Username = rd.GetString(1);
                            StaticSession.IdCategoria = rd.GetInt32(2);
                            StaticSession.Categorianame1 = rd.GetString(3);
                            StaticSession.Picture = rd["picprofile"] as byte[];
                            StaticSession.Password = rd.GetString(5);
                        }

                        // Verificar si el usuario tiene dos preguntas de seguridad
                        if (!UsuarioTieneDosPreguntas())
                        {
                            return -2; // Indicar que el usuario necesita configurar preguntas de seguridad
                        }

                        return 0; // Login exitoso y preguntas de seguridad configuradas
                    }
                    else
                    {
                        return 1; // Usuario o contraseña incorrectos
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1; // Error durante el proceso de login
            }
            finally
            {
                if (Command.Connection != null && Command.Connection.State == System.Data.ConnectionState.Open)
                {
                    Command.Connection.Close();
                }
            }
        }

        public bool UsuarioTieneDosPreguntas()
        {
            try
            {
                Command.Connection = getConnection();

                string query = "SELECT COUNT(*) FROM RespuestasSeguridad WHERE Usuario = @Usuario";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("Usuario", StaticSession.Username);

                int count = (int)cmd.ExecuteScalar();
                return count >= 2;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al verificar las preguntas del usuario: " + ex.Message);
                return false;
            }
            finally
            {
                getConnection().Close();
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
                // Consulta para verificar usuario, contraseña y rol del empleado
                string query = @"SELECT COUNT(*) 
                         FROM Usuarios U
                         INNER JOIN Categorias C ON U.idCategoria = C.idCategoria
                         WHERE U.Usuario = @username AND U.Contraseña = @password AND C.Nombre = 'Manager'";

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
                    // El usuario es un Manager o Admin y ha sido autenticado correctamente
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
