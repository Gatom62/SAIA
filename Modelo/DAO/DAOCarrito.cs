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
    internal class DAOCarrito: DTOCarrito
    {
        SqlCommand command = new SqlCommand();

        public int ObtenerStockDisponible(string producto)
        {
            try
            {
                // Abrimos la conexión a la base de datos
                command.Connection = getConnection();

                // Consulta para obtener el stock disponible del producto
                string query = "SELECT Stock FROM Productos WHERE Nombre = @producto";

                // Comando SQL con el query y la conexión
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.Parameters.AddWithValue("@producto", producto);

                // Ejecutar la consulta y obtener el resultado
                object result = cmd.ExecuteScalar();

                // Convertir el resultado a entero (el stock disponible)
                if (result != null && int.TryParse(result.ToString(), out int stockDisponible))
                {
                    return stockDisponible;
                }
                else
                {
                    // Si no se encuentra el producto o el valor no es válido, devolvemos 0
                    return 0;
                }
            }
            catch (Exception ex)
            {
                // En caso de error, mostramos el mensaje y devolvemos -1
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                // Cerramos la conexión
                command.Connection.Close();
            }
        }

        public int RegistrarVenta()
        {
            try
            {
                command.Connection = getConnection();

                string query = "INSERT INTO Ventas (idCliente, idEmpleado, FechaVenta, MontoTotal) " +
                           "VALUES (@idCliente, @idEmpleado, @FechaVenta, @MontoTotal)";

                SqlCommand cmd = new SqlCommand(query, command.Connection);

                cmd.Parameters.AddWithValue("idCliente", Idcliente);
                cmd.Parameters.AddWithValue("idEmpleado", Idempleado);
                cmd.Parameters.AddWithValue("FechaVenta", Fechaventa);
                cmd.Parameters.AddWithValue("MontoTotal", Montototal);

                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
                return -1;
            }
            finally
            {
                command.Connection.Close();
            }
        }
        public DataSet LlenarCombo()
        {
            try
            {
                //Se crea una conexión para garantizar que efectivamente haya conexión a la base.
                command.Connection = getConnection();
                //**
                //Se crea el query que indica la acción que el sistema desea realizar con la base de datos
                //En caso sea una consulta parametrizada se deberá respetar la sintaxis sobre como colocar parametros en la instrucción sql (REVISAR LOS DEMÁS MANTENIMIENTOS PARA VER COMO SE CREAN PARAMETROS Y SE LES DA VALORES).
                string query = "SELECT * FROM Clientes";
                //Se crea un comando de tipo sql al cual se le pasa el query y la conexión, esto para que el sistema sepa que hacer y donde hacerlo.
                SqlCommand cmd = new SqlCommand(query, command.Connection);
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
                command.Connection.Close();
            }
        }
        public DataSet BuscarCliente(string valor)
        {
            try
            {
                // Accedemos a la conexión que ya se tiene
                command.Connection = getConnection();

                // Instrucción que se hará hacia la base de datos
                string query = $"SELECT * FROM Clientes WHERE Nombre LIKE '%{valor}%'";

                // Comando sql en el cual se pasa la instrucción y la conexión
                SqlCommand cmd = new SqlCommand(query, command.Connection);

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
                command.Connection.Close();
            }
        }
        public void ActualizarStock(string producto, int cantidadVendida)
        {
            try
            {
                // Abrimos la conexión a la base de datos
                command.Connection = getConnection();

                // Consulta para actualizar el stock del producto
                string query = "UPDATE Productos SET Stock = Stock - @cantidadVendida WHERE Nombre = @producto";

                // Comando SQL con el query y la conexión
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.Parameters.AddWithValue("@producto", producto);
                cmd.Parameters.AddWithValue("@cantidadVendida", cantidadVendida);

                // Ejecutar la consulta
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cerramos la conexión
                command.Connection.Close();
            }
        }
    }
}
