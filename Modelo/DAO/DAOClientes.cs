using AgroServicios.Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroServicios.Modelo.DAO
{
    class DAOClientes : DTOClientes
    {
        readonly SqlCommand Command = new SqlCommand();
        public DataSet ObtenerClientes()
        {
            try
            {
                //Accedemos a la coneccion de slq por medio de un comando
                Command.Connection = getConnection();
                //Creamos la instruccion que queremos que haga sql
                string query = "SELECT * FROM Clientes";
                //Ahora mandamos esta misma instruccion a sql y tambien por medio de este comando mandamos la respuesta de slq
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.ExecuteNonQuery();
                //Realizamos un adaptador para poder rellenar el data set
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                //Creamos un objeto del dataset el cual ayudara para devolver los resultados
                DataSet ds = new DataSet();
                //Rellenamos el dataset indicandole de que tabla debe de el rellenar los datos
                adp.Fill(ds, "Clientes");
                //Devolvemos el data set
                return ds;
            }
            catch (Exception)
            {
                //Returnamos null si la conexion no fallo
                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }

        public int RetgistraCliente()
        {
            try
            {
                //Realizamos la coneccion a la base de datos
                Command.Connection = getConnection();
                //Realizamos la instrucciones que queremos que haga la base de datos
                string query2 = "INSERT INTO Clientes(Nombre, Telefono, Correo, Direccion, DUI)" + "VALUES (@name, @phone, @mail, @direccion, @dui)";
                //Pormedio de esto mandamos la instruccion que formulamos a la base de datos
                SqlCommand cmd2 = new SqlCommand(query2, Command.Connection);
                //Les daremos valores a los parametros del dto para realizar la insercion
                cmd2.Parameters.AddWithValue("name", Nombre1);
                cmd2.Parameters.AddWithValue("phone", Telefono1);
                cmd2.Parameters.AddWithValue("mail", Correo1);
                cmd2.Parameters.AddWithValue("direccion", Dirreccion1);
                cmd2.Parameters.AddWithValue("dui", DUI1);
                //Ya se ejecuta el comando por que ya les agregamos sus respectivos parametros
                //Esta variable servira para comprovar si el comando tu exito
                int respuesta = cmd2.ExecuteNonQuery();
                return respuesta;
            }
            catch (Exception)
            {
                //A ocurrido un error
                return -1;
            }
            finally
            {
                Command.Connection.Close();
            }
        }

        public int DeleteCLiente()
        {
            try
            {
                Command.Connection = getConnection();

                string query = "DELETE Clientes WHERE idCliente = @param1";

                SqlCommand cmd = new SqlCommand(query, Command.Connection);

                cmd.Parameters.AddWithValue("param1", IdCliente);

                int respuesta = cmd.ExecuteNonQuery();

                if (respuesta == 1)
                {
                    return respuesta;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                getConnection().Close();
            }
        }

        public int ActualizarCliente()
        {
            try
            {
                Command.Connection = getConnection();

                string query = "UPDATE Clientes SET Nombre = @name, Telefono = @phone, Correo = @email, Direccion = @direction, DUI = @dui WHERE idCliente = @idClient";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);

                cmd.Parameters.AddWithValue("@idClient", IdCliente);
                cmd.Parameters.AddWithValue("@name", Nombre1);
                cmd.Parameters.AddWithValue("@phone", Telefono1);
                cmd.Parameters.AddWithValue("@email", Correo1);
                cmd.Parameters.AddWithValue("@direction", Dirreccion1);
                cmd.Parameters.AddWithValue("@dui", DUI1);

                int respuesta = cmd.ExecuteNonQuery();
                return respuesta;
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                Command.Connection.Close();
            }
        }

        public DataSet BuscarClientes(string valor)
        {
            try
            {
                // Accedemos a la conexión que ya se tiene
                Command.Connection = getConnection();

                // Instrucción que se hará hacia la base de datos
                string query = $"SELECT * FROM Clientes WHERE [idCliente] LIKE '%{valor}%' OR Nombre LIKE '%{valor}%' OR DUI LIKE '%{valor}%'";

                // Comando sql en el cual se pasa la instrucción y la conexión
                SqlCommand cmd = new SqlCommand(query, Command.Connection);

                // Se utiliza un adaptador sql para rellenar el dataset
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                // Se crea un objeto Dataset que es donde se devolverán los resultados
                DataSet ds = new DataSet();

                // Rellenamos con el Adaptador el DataSet diciéndole de qué tabla provienen los datos
                adp.Fill(ds, "Clientes"); // Nombre correcto de la tabla

                // Devolvemos el Dataset
                return ds;
            }
            catch (Exception ex)
            {
                // Retornamos null si existiera algún error durante la ejecución
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
            finally
            {
                // Independientemente se haga o no el proceso cerramos la conexión
                Command.Connection.Close();
            }
        }
    }
}
