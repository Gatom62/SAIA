using AgroServicios.Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Modelo.DAO
{
    class DAOAdminUsers: DTOAdminUsers
    {
        readonly SqlCommand Command = new SqlCommand();

        public DataSet ObtenerPersonas()
        {
            try
            {
                //Accedemos a la conexión que ya se tiene
                Command.Connection = getConnection();
                //Instrucción que se hará hacia la base de datos
                string query = "SELECT * FROM Empleados";
                //Comando sql en el cual se pasa la instrucción y la conexión
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                //Se ejecuta el comando y con ExecuteNonQuery se verifica su retorno
                //ExecuteNonQuery devuelve un valor entero.
                cmd.ExecuteNonQuery();
                //Se utiliza un adaptador sql para rellenar el dataset
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                //Se crea un objeto Dataset que es donde se devolverán los resultados
                DataSet ds = new DataSet();
                //Rellenamos con el Adaptador el DataSet diciendole de que tabla provienen los datos
                adp.Fill(ds, "Empleados");
                //Devolvemos el Dataset
                return ds;
            }
            catch (Exception)
            {
                //Retornamos null si existiera algún error durante la ejecución
                return null;
            }
            finally
            {
                //Independientemente se haga o no el proceso cerramos la conexión
                getConnection().Close();
            }

        }

        public bool CrearUsuario(DTOAdminUsers nuevoUsuario)
        {
            try
            {

                using (SqlConnection connection = dbContext.getConnection())
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO Empleados (Usuario, Contraseña, Correo, Telefono, PrimerNombre, Apellido, FechaNacimiento, DUI) " +
                                          "VALUES (@username, @password, @correo, @telefono, @primerNombre, @apellido, @fechaNacimiento, @dui)";
                    command.Parameters.AddWithValue("@username", nuevoUsuario.Usuario1);
                    command.Parameters.AddWithValue("@password", nuevoUsuario.Password1);
                    command.Parameters.AddWithValue("@correo", nuevoUsuario.Correo1);
                    command.Parameters.AddWithValue("@telefono", nuevoUsuario.Phone1);
                    command.Parameters.AddWithValue("@primerNombre", nuevoUsuario.Nombre1);
                    command.Parameters.AddWithValue("@apellido", nuevoUsuario.Apellido1);
                    command.Parameters.AddWithValue("@fechaNacimiento", nuevoUsuario.FechaNacimiento);
                    command.Parameters.AddWithValue("@dui", nuevoUsuario.Dui);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
