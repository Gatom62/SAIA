using AgroServicios.Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
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
                string query = "SELECT * FROM VistaEmpleadosConRol";
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
                adp.Fill(ds, "VistaEmpleadosConRol");
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

        public DataSet LlenarCombo()
        {
            try
            {
                //Se crea una conexión para garantizar que efectivamente haya conexión a la base.
                Command.Connection = getConnection();
                //**
                //Se crea el query que indica la acción que el sistema desea realizar con la base de datos
                //En caso sea una consulta parametrizada se deberá respetar la sintaxis sobre como colocar parametros en la instrucción sql (REVISAR LOS DEMÁS MANTENIMIENTOS PARA VER COMO SE CREAN PARAMETROS Y SE LES DA VALORES).
                string query = "SELECT * FROM Categorias";
                //Se crea un comando de tipo sql al cual se le pasa el query y la conexión, esto para que el sistema sepa que hacer y donde hacerlo.
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                //ExecuteNonQuery indicará cuantos filas fueron afectadas, es decir, cuantas filas de datos se ingresaron o encontraron, por lo general cuando es una consulta su valor puede ser 1 o mayor a 1.
                cmd.ExecuteNonQuery();
                //Se crea un objeto SqlDataAdapter para poder llenar el DataSet que posteriormente utilizaremos, además recibe el comando sql
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                //Se crea un DataSet que será el objeto de retorno del método
                DataSet ds = new DataSet();
                //Rellenamos el DataSet con los datos encontrados con el SqlDataAdapter, además, indicamos de donde provienen los datos
                adp.Fill(ds, "Categorias");
                //Retornamos el objeto DataSet
                return ds;
            }
            catch (Exception)
            {
                //Se retorna null si durate la ejecución del try ocurrió algún error
                return null;
            }
            finally
            {
                //Independientemente se haga o no el proceso cerramos la conexión
                getConnection().Close();
            }
        }

        public int RegistrarUsuario()
        {
            try
            {
                //Se crea una conexión para garantizar que efectivamente haya conexión a la base.
                Command.Connection = getConnection();
                //**
                //Se crea el query que indica la acción que el sistema desea realizar con la base de datos
                //el query posee parametros para evitar algún tipo de ataque como SQL Injection
                string query2 = "INSERT INTO Usuarios(Usuario, Contraseña, IntentosUsuario, idCategoria, picprofile) VALUES (@username, @password, @userAttempts, @roleId, @picture)";
                //Se crea un comando de tipo sql al cual se le pasa el query y la conexión, esto para que el sistema sepa que hacer y donde hacerlo.
                SqlCommand cmd2 = new SqlCommand(query2, Command.Connection);
                //Se le da un valor a los parametros contenidos en el query, es importante mencionar que lo que esta entre comillas es el nombre del parametro y lo que esta después de la coma es el valor que se le asignará al parametro, estos valores vienen del DTO respectivo.
                cmd2.Parameters.AddWithValue("username", Usuario1);
                cmd2.Parameters.AddWithValue("password", Contraseña1);
                cmd2.Parameters.AddWithValue("userAttempts", IntentosUsuario1);
                cmd2.Parameters.AddWithValue("roleId", IdCategoria);
                cmd2.Parameters.AddWithValue("picture", Img);
                //Se ejecuta el comando ya con todos los valores de sus parametros.
                //ExecuteNonQuery indicará cuantos filas fueron afectadas, es decir, cuantas filas de datos se ingresaron, por lo general devolvera 1 porque se hace una inserción a la vez.
                int respuesta = cmd2.ExecuteNonQuery();
                //Se evalúa el valor de la variable respuesta que contiene el numero de filas afectadas
                if (respuesta == 1)
                {
                    //Si el valor de respuesta es 1, se procede a la inserción de los datos de la persona, como se puede observar en el diagrama de base de datos, primero es el usuario y despues la persona.
                    string query = "INSERT INTO Empleados (Nombre, FechaDeNacimiento, Telefono, Correo, DUI, Direccion, Usuario) VALUES (@param1, @param2, @param3, @param4, @param5, @param6, @param7)";
                    //Se crea un comando de tipo sql al cual se le pasa el query y la conexión, esto para que el sistema sepa que hacer y donde hacerlo.
                    SqlCommand cmd = new SqlCommand(query, Command.Connection);
                    //Se le da un valor a los parametros contenidos en el query, es importante mencionar que lo que esta entre comillas es el nombre del parametro y lo que esta después de la coma es el valor que se le asignará al parametro, estos valores vienen del DTO
                    cmd.Parameters.AddWithValue("param1", Nombre1);
                    cmd.Parameters.AddWithValue("param2", FechaDeNacimiento1);
                    cmd.Parameters.AddWithValue("param3", Telefono1);
                    cmd.Parameters.AddWithValue("param4", Correo1);
                    cmd.Parameters.AddWithValue("param5", DUI1);
                    cmd.Parameters.AddWithValue("param6", Direccion1);
                    cmd.Parameters.AddWithValue("param7", Usuario1);
                    //Se ejecuta el comando ya con todos los valores de sus parametros.
                    //ExecuteNonQuery indicará cuantos filas fueron afectadas, es decir, cuantas filas de datos se ingresaron, por lo general devolvera 1 porque se hace una inserción a la vez.
                    respuesta = cmd.ExecuteNonQuery();
                    //Se retorna el valor de respuesta, que si su valor es 1 indica que los valores fueron ingresados.
                    return respuesta;
                }
                else
                {
                    //Se retorna cero si sus valores no pudieron ser ingresados
                    return 0;
                }
            }
            catch (Exception)
            {
                //Se retorna -1 en caso que en el segmento del try haya ocurrido algún error.
                return -1;
            }
            finally
            {
                //Independientemente se haga o no el proceso cerramos la conexión
                Command.Connection.Close();
            }
        }

        public int DeteleEmpleado()
        {
            try
            {
                Command.Connection = getConnection();

                string query = "DELETE Empleados WHERE idEmpleado = @param1";

                SqlCommand cmd = new SqlCommand(query, Command.Connection);

                cmd.Parameters.AddWithValue("param1", IdEmpleado);

                int respuesta = cmd.ExecuteNonQuery();

                if (respuesta == 1)
                {
                    string query2 = "DELETE FROM Usuarios WHERE Usuario = @param2";

                    SqlCommand cmd2 = new SqlCommand( query2, Command.Connection);

                    cmd2.Parameters.AddWithValue("param2", Usuario1);

                    respuesta = cmd2.ExecuteNonQuery();
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

        public DataTable BuscarProducto(string criterio)
        {
            DataTable dataTable = new DataTable();

            try
            {
                Command.Connection = getConnection();
                Command.CommandText = "SELECT * FROM Productos WHERE Nombre LIKE @criterio";
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@criterio", "%" + criterio + "%");

                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                MessageBox.Show(ex.Message);
            }
            finally
            {
                getConnection().Close();
            }

            return dataTable;
        }
        public int ActualizarEmpleado()
        {
            try
            {
                Command.Connection = getConnection();

                string query2 = "UPDATE Usuarios SET picprofile = @img WHERE Usuario = @user";
                SqlCommand cmd2 = new SqlCommand(query2, Command.Connection);

                cmd2.Parameters.AddWithValue("img", Img);
                cmd2.Parameters.AddWithValue("user", Usuario1);

                int respuesta = cmd2.ExecuteNonQuery();

                if (respuesta == 1)
                {


                    string query = "UPDATE Empleados SET Nombre = @nombre, FechaDeNacimiento = @fechaDeNacimiento, Telefono = @telefono, Correo = @correo, DUI = @dui, Direccion = @direccion WHERE idEmpleado = @idEmpleado";
                    SqlCommand cmd = new SqlCommand(query, Command.Connection);

                    cmd.Parameters.AddWithValue("@idEmpleado", IdEmpleado);
                    cmd.Parameters.AddWithValue("@nombre", Nombre1);
                    cmd.Parameters.AddWithValue("@fechaDeNacimiento", FechaDeNacimiento1);
                    cmd.Parameters.AddWithValue("@telefono", Telefono1);
                    cmd.Parameters.AddWithValue("@correo", Correo1);
                    cmd.Parameters.AddWithValue("@dui", DUI1);
                    cmd.Parameters.AddWithValue("@direccion", Direccion1);

                    respuesta = cmd.ExecuteNonQuery();
                    return respuesta;
                }
                else
                {
                    //Se retorna cero si sus valores no pudieron ser ingresados
                    return 0;
                }
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

        public int restablecerEmpleado()
        {
            try
            {
                Command.Connection = getConnection();

                string query = "UPDATE Usuarios SET Contraseña = @pass WHERE Usuario = @user";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);

                cmd.Parameters.AddWithValue("@user", Usuario1);
                cmd.Parameters.AddWithValue("@pass", Contraseña1);

                int respuesta = cmd.ExecuteNonQuery();
                if (respuesta == 1)
                {
                    string query2 = "UPDATE Usuarios SET idCategoria = @idcat WHERE Usuario = @user";
                                    //"idCategoria = @idcat" +
                                    //"WHERE Usuario = @user";

                    SqlCommand cmd2 = new SqlCommand(query2, getConnection());

                    cmd2.Parameters.AddWithValue("idcat", IdCategoria);
                    cmd2.Parameters.AddWithValue("user", Usuario1);
                    respuesta = cmd2.ExecuteNonQuery();
                    respuesta = 2;
                }
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
    }
}

