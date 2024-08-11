using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgroServicios.Modelo.DTO;
using System.Security.Cryptography.X509Certificates;

namespace AgroServicios.Modelo.DAO
{
    internal class DAOProveedores:DTOProveedores
    {
        readonly SqlCommand Command = new SqlCommand();
        public DataSet ObtenerPersonas()
        {
            try
            {
                //Accedemos a la conexión que ya se tiene
                Command.Connection = getConnection();
                //Instrucción que se hará hacia la base de datos
                string query = "SELECT * FROM Proveedores";
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
                adp.Fill(ds, "Proveedores");
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
        public int RegistrarProveedor()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "INSERT INTO Proveedores(Nombre,DUI,Teléfono,Correo,Empresa) VALUES (@Param2,@Param3,@Param4,@Param5,@Param6)";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("Param2", Nombre1);
                cmd.Parameters.AddWithValue("Param3", DUI1);
                cmd.Parameters.AddWithValue("Param4", Teléfono1);
                cmd.Parameters.AddWithValue("Param5", Correo1);
                cmd.Parameters.AddWithValue("Param6", Empresa1);
                int respuesta = cmd.ExecuteNonQuery();
                return respuesta;
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
        public int EliminarProv()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "DELETE Proveedores WHERE IdProveedor = @param1";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("param1", IdProveedor);
                int respuesta = cmd.ExecuteNonQuery();
                return respuesta;
            }
            catch(Exception) 
            {
                return -1;
            }
            finally 
            { 
            getConnection().Close();
            }
        }
        public int ActualizarProveedor()
        {
            try
            {
                Command.Connection = getConnection();

                string query = "UPDATE Proveedores SET Nombre = @nombre, DUI = @dui, Teléfono = @telefono, Correo = @correo, Empresa = @empresa WHERE idProveedor = @idProveedor";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);

                cmd.Parameters.AddWithValue("@idProveedor", IdProveedor);
                cmd.Parameters.AddWithValue("@nombre", Nombre1);
                cmd.Parameters.AddWithValue("@telefono", Teléfono1);
                cmd.Parameters.AddWithValue("@correo", Correo1);
                cmd.Parameters.AddWithValue("@dui", DUI1);
                cmd.Parameters.AddWithValue("@empresa", Empresa1);

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
    }
}
