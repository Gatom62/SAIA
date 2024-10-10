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
    internal class DAODevoluciones : DTODevoluciones
    {
        SqlCommand Command = new SqlCommand();
        public int RegistrarDevolucion()
        {
            SqlTransaction transaction = null;
            try
            {
                // Obtener el monto total de la venta antes de proceder con la devolución
                decimal montoTotalVenta = ObtenerMontoTotalVenta(Idventa);


                decimal totalDevolucionesPrevias = ObtenerTotalDevoluciones(Idventa);
                decimal montoDisponibleParaDevolucion = montoTotalVenta - totalDevolucionesPrevias;

                // Validar si el monto de la devolución es mayor que el monto total de la venta
                if (Montodevolucion > montoDisponibleParaDevolucion)
                {
                    return -2; // -2 indica que la devolución no puede proceder porque excede el monto disponible
                }


                // Se crea una conexión para garantizar que efectivamente haya conexión a la base.
                Command.Connection = getConnection();
                transaction = Command.Connection.BeginTransaction(); // Iniciamos una transacción

                //**
                // Se crea el query que indica la acción que el sistema desea realizar con la base de datos
                // el query posee parámetros para evitar algún tipo de ataque como SQL Injection.
                string query2 = "INSERT INTO Devoluciones(idVenta, idProducto, idCliente, FechaDevolucion, Cantidad, MontoDevolucion, Motivo) " +
                                "VALUES (@idVenta, @idProducto, @idCliente, @fechaDevolucion, @cantidadProducto, @montoDevolucion, @motivoDevolucion)";

                // Se crea un comando de tipo sql para insertar la devolución
                SqlCommand cmd2 = new SqlCommand(query2, Command.Connection, transaction);

                // Se le da un valor a los parámetros contenidos en el query.
                cmd2.Parameters.AddWithValue("idVenta", Idventa);
                cmd2.Parameters.AddWithValue("idProducto", Nombreproducto);
                cmd2.Parameters.AddWithValue("idCliente", Nombrecliente);
                cmd2.Parameters.AddWithValue("fechaDevolucion", Fechadeladevolucion);
                cmd2.Parameters.AddWithValue("cantidadProducto", CantidadProducto);
                cmd2.Parameters.AddWithValue("montoDevolucion", Montodevolucion);
                cmd2.Parameters.AddWithValue("motivoDevolucion", Motivodevolucion);

                // Se ejecuta el comando ya con todos los valores de sus parámetros.
                int respuesta = cmd2.ExecuteNonQuery();

                if (respuesta == 1)
                {
                    string querySumarStock = "UPDATE Productos SET Stock = Stock + @Cantidad WHERE IdProducto = @IdProducto";
                    SqlCommand cmdStock = new SqlCommand(querySumarStock, Command.Connection, transaction);

                    // Asignar parámetros
                    cmdStock.Parameters.AddWithValue("@IdProducto", Nombreproducto);
                    cmdStock.Parameters.AddWithValue("@Cantidad", CantidadProducto);

                    // Ejecutar la actualización de stock
                    cmdStock.ExecuteNonQuery();


                    // Query para restar el monto de la devolución al total de la venta
                    string queryRestarMonto = "UPDATE Ventas SET MontoTotal = MontoTotal - @montoDevolucion WHERE idVenta = @idVenta";
                    SqlCommand cmdRestarMonto = new SqlCommand(queryRestarMonto, Command.Connection, transaction);

                    cmdRestarMonto.Parameters.AddWithValue("@montoDevolucion", Montodevolucion);
                    cmdRestarMonto.Parameters.AddWithValue("@idVenta", Idventa);

                    cmdRestarMonto.ExecuteNonQuery();

                    transaction.Commit(); // Confirmamos la transacción
                    return respuesta;
                }
                else
                {
                    transaction.Rollback(); // En caso de error revertimos los cambios
                    return 0;
                }
            }
            catch (Exception)
            {
                if (transaction != null)
                {
                    transaction.Rollback(); // En caso de error revertimos la transacción
                }
                // Se retorna -1 en caso que en el segmento del try haya ocurrido algún error.
                return -1;
            }
            finally
            {
                // Independientemente de si se hace o no el proceso, cerramos la conexión.
                Command.Connection.Close();
            }
        }
        public DataSet ObtenerDevoluciones()
        {
            try
            {
                //Accedemos a la conexión que ya se tiene
                Command.Connection = getConnection();
                //Instrucción que se hará hacia la base de datos
                string query = "SELECT * FROM viewDevoluciones";
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
                adp.Fill(ds, "viewDevoluciones");
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
        public DataSet LlenarComboVenta()
        {
            try
            {
                //Se crea una conexión para garantizar que efectivamente haya conexión a la base.
                Command.Connection = getConnection();
                //**
                //Se crea el query que indica la acción que el sistema desea realizar con la base de datos
                //En caso sea una consulta parametrizada se deberá respetar la sintaxis sobre como colocar parametros en la instrucción sql (REVISAR LOS DEMÁS MANTENIMIENTOS PARA VER COMO SE CREAN PARAMETROS Y SE LES DA VALORES).
                string query = "SELECT * FROM Ventas";
                //Se crea un comando de tipo sql al cual se le pasa el query y la conexión, esto para que el sistema sepa que hacer y donde hacerlo.
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                //ExecuteNonQuery indicará cuantos filas fueron afectadas, es decir, cuantas filas de datos se ingresaron o encontraron, por lo general cuando es una consulta su valor puede ser 1 o mayor a 1.
                cmd.ExecuteNonQuery();
                //Se crea un objeto SqlDataAdapter para poder llenar el DataSet que posteriormente utilizaremos, además recibe el comando sql
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                //Se crea un DataSet que será el objeto de retorno del método
                DataSet ds = new DataSet();
                //Rellenamos el DataSet con los datos encontrados con el SqlDataAdapter, además, indicamos de donde provienen los datos
                adp.Fill(ds, "Ventas");
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

        public DataSet LlenarComboProducto()
        {
            try
            {
                //Se crea una conexión para garantizar que efectivamente haya conexión a la base.
                Command.Connection = getConnection();
                //**
                //Se crea el query que indica la acción que el sistema desea realizar con la base de datos
                //En caso sea una consulta parametrizada se deberá respetar la sintaxis sobre como colocar parametros en la instrucción sql (REVISAR LOS DEMÁS MANTENIMIENTOS PARA VER COMO SE CREAN PARAMETROS Y SE LES DA VALORES).
                string query = "SELECT * FROM Productos";
                //Se crea un comando de tipo sql al cual se le pasa el query y la conexión, esto para que el sistema sepa que hacer y donde hacerlo.
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                //ExecuteNonQuery indicará cuantos filas fueron afectadas, es decir, cuantas filas de datos se ingresaron o encontraron, por lo general cuando es una consulta su valor puede ser 1 o mayor a 1.
                cmd.ExecuteNonQuery();
                //Se crea un objeto SqlDataAdapter para poder llenar el DataSet que posteriormente utilizaremos, además recibe el comando sql
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                //Se crea un DataSet que será el objeto de retorno del método
                DataSet ds = new DataSet();
                //Rellenamos el DataSet con los datos encontrados con el SqlDataAdapter, además, indicamos de donde provienen los datos
                adp.Fill(ds, "Productos");
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
        public DataSet LlenarComboClientes()
        {
            try
            {
                //Se crea una conexión para garantizar que efectivamente haya conexión a la base.
                Command.Connection = getConnection();
                //**
                //Se crea el query que indica la acción que el sistema desea realizar con la base de datos
                //En caso sea una consulta parametrizada se deberá respetar la sintaxis sobre como colocar parametros en la instrucción sql (REVISAR LOS DEMÁS MANTENIMIENTOS PARA VER COMO SE CREAN PARAMETROS Y SE LES DA VALORES).
                string query = "SELECT * FROM Clientes";
                //Se crea un comando de tipo sql al cual se le pasa el query y la conexión, esto para que el sistema sepa que hacer y donde hacerlo.
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                //ExecuteNonQuery indicará cuantos filas fueron afectadas, es decir, cuantas filas de datos se ingresaron o encontraron, por lo general cuando es una consulta su valor puede ser 1 o mayor a 1.
                cmd.ExecuteNonQuery();
                //Se crea un objeto SqlDataAdapter para poder llenar el DataSet que posteriormente utilizaremos, además recibe el comando sql
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                //Se crea un DataSet que será el objeto de retorno del método
                DataSet ds = new DataSet();
                //Rellenamos el DataSet con los datos encontrados con el SqlDataAdapter, además, indicamos de donde provienen los datos
                adp.Fill(ds, "Clientes");
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

        // Método para obtener el monto total de la venta
        public decimal ObtenerMontoTotalVenta(int idVenta)
        {
            try
            {
                Command.Connection = getConnection();

                string query = "SELECT MontoTotal FROM Ventas WHERE idVenta = @idVenta";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("@idVenta", idVenta);

                object result = cmd.ExecuteScalar();
                if (result != null && result is decimal)
                {
                    return (decimal)result;
                }
                else
                {
                    return 0; // Si no se encuentra la venta, retornamos 0
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el monto total de la venta: " + ex.Message);
                return 0; // En caso de error, retornamos 0
            }
            finally
            {
                Command.Connection.Close();
            }
        }
        private decimal ObtenerTotalDevoluciones(int idVenta)
        {
            try
            {
                Command.Connection = getConnection();
                Command.Connection.Open();

                string query = "SELECT SUM(MontoDevolucion) FROM Devoluciones WHERE idVenta = @idVenta";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("@idVenta", idVenta);

                object result = cmd.ExecuteScalar();
                return result != null ? (decimal)result : 0; // Retorna 0 si no hay devoluciones
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el total de devoluciones: " + ex.Message);
                return 0;
            }
            finally
            {
                if (Command.Connection.State == System.Data.ConnectionState.Open)
                {
                    Command.Connection.Close();
                }
            }
        }

    }
}
